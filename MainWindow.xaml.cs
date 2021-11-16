using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Command;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System;

namespace WpfApp2
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //public static MainWindow Pointer;
        public ApplicationContext db;
        public IEnumerable<ProductType> ProductTypes;
        //new ProductType() { Title = "Американо",Price = 12, Image = @"Images\Americano.jpg"},
        //new ProductType() { Title = "Какао",    Price = 18, Image = @"Images\Cacao.jpg"},
        //new ProductType() { Title = "Капучино", Price = 16, Image = @"Images\Cappuccino.jpg"},
        //new ProductType() { Title = "Лате",     Price = 16, Image = @"Images\Latte.jpg"},
        //new ProductType() { Title = "Раф-Кофе", Price = 16, Image = @"Images\RafCoffee.jpg"},
        //new ProductType() { Title = "Эспрессо", Price = 11, Image = @"Images\Espresso.jpg" }
        public List<ICard> Cart = new List<ICard>();
        public ObservableCollection<Order> History { get; set; }
        public List<ICard> ShowCase { get; set; } = new List<ICard>();

        private Order _historyItem;
        public Order HistoryItem { get => _historyItem; set { _historyItem = value; OnPropertyChanged("HistoryItem"); OnPropertyChanged("RecieptText"); } }
        public string RecieptText { get { if (_historyItem != null) return _historyItem.Receipt; return ""; } }
        public string ToPay
        {
            get
            {
                int price = 0;
                foreach (var product in Cart)
                {
                    price += (product as ProductSaleCard).product.Price * (product as ProductSaleCard).Count;
                }
                return $"{price}₴";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            //Pointer = this;
            db = new ApplicationContext();
            db.Orders.Load();
            History = db.Orders.Local;

            db.ProductTypes.Load();
            ProductTypes = db.ProductTypes.Local.ToBindingList();
            DatabaseUpdate();
        }

        public ICommand PayCommand => new RelayCommand(o =>
        {
            var receipt = new Receipt(Cart, db);
            if (receipt.ShowDialog().Value)
            {
                Cart.Clear();
                ProductsChange();
                OnPropertyChanged("History");
            }

        }, o => ToPay != "0₴");
        public ICommand CancelCommand => new RelayCommand(o =>
        {
            Cart.Clear();
            ProductsChange();
        }, o => ToPay != "0₴");

        public void ProductAddButtonClicked()
        {
            var product = new ProductType() { Title = _searchText };
            db.ProductTypes.Add(product);
            db.Entry(product).State = EntityState.Added;
            db.SaveChanges();
            DatabaseUpdate();
            var modifier = new ProductModifier(product, this);
            bool? res = modifier.ShowDialog();
            if (res.HasValue && res.Value)
            {
                product.Title = modifier.Product.Title;
                product.Price = modifier.Product.Price;
                product.Category = modifier.Product.Category;
                db.Entry(product).State = EntityState.Modified;
            }
            else
            {
                if (db.ProductTypes.Local.Contains(product))
                {
                    db.ProductTypes.Remove(product);
                }
            }
            db.SaveChanges();
            DatabaseUpdate();
        }
        public void ProductViewButtonClicked(ProductType product)
        {
            var modifier = new ProductModifier(product, this);
            if (modifier.ShowDialog().Value == true)
            {
                var ChangeProduct = db.ProductTypes.Find(product.Id);
                ChangeProduct.Title = modifier.Product.Title;
                ChangeProduct.Price = modifier.Product.Price;
                ChangeProduct.Category = modifier.Product.Category;
                db.Entry(ChangeProduct).State = EntityState.Modified;
            }
            db.SaveChanges();
            DatabaseUpdate();
        }
        public void ProductSaleButtonClicked(ProductSaleCard product)
        {
            product.Count--;
            product.OnPropertyChanged("Count");
            if (product.Count == 0)
            {
                Cart.Remove(product);
            }
            ProductsChange();
        }
        public void ProductTypeButtonClicked(ProductType product)
        {
            var prod = Cart.Find(o => (o as ProductSaleCard).product == product);
            if (prod == null)
            {
                Cart.Add(new ProductSaleCard(product, this));
                ProductsChange();
            }
            else
            {
                (prod as ProductSaleCard).Count++;
                (prod as ProductSaleCard).OnPropertyChanged("CountString");
                OnPropertyChanged("ToPay");
            }

        }

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText; set
            {
                _searchText = value; ProductsChange();
            }
        }
        public void DatabaseUpdate()
        {
            ShowCase.Clear();
            foreach (var Product in ProductTypes)
            {
                if (Product.Category != null)
                {
                    var Category = (GroupCard)ShowCase.Find(o => o.CardType == CardType.Group && o.Title == Product.Category);
                    if (Category == null)
                    {
                        Category = new GroupCard(this) { Title = Product.Category };
                        ShowCase.Add(Category);
                    }
                    Category.products.Add(new ProductTypeCard(Product, this));
                }
                else
                {
                    ShowCase.Add(new ProductTypeCard(Product, this));
                }

            }
            ProductsChange();
        }
        private void WrapRenew(UIElementCollection Children, List<ICard> list)
        {
            foreach (var Product in list)
            {
                if (_searchText == "" || Product.Title.ToLower().Contains(_searchText.ToLower()))
                {
                    Children.Add((UserControl)Product);
                    //(Product as IOnPropretyChanged)?.OnPropertyChanged("Image");
                }
                var group = Product as GroupCard;
                if (group != null && (group.IsOpen || _searchText != ""))
                {
                    WrapRenew(Children, group.products);
                }
            }
        }
        public void ProductsChange()
        {
            ProductsWrap.Children.Clear();
            WrapRenew(ProductsWrap.Children, ShowCase);
            CartWrap.Children.Clear();
            WrapRenew(CartWrap.Children, Cart);
            AllProductsWrap.Children.Clear();
            AllProductsWrap.Children.Add(new ProductAddCard(this));
            foreach (var Product in ProductTypes)
            {
                if (_searchText == "" || Product.Title.ToLower().Contains(_searchText.ToLower()))
                {
                    AllProductsWrap.Children.Add(new ProductTypeCard(Product, this) { CardType = CardType.ProductView });
                }
            }
            OnPropertyChanged("ToPay");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
