using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class ProductModifier : Window, INotifyPropertyChanged
    {
        public ApplicationContext DB;
        public ProductType Product;
        public MainWindow From;
        public string PTitle { get => Product.Title; set { Product.Title = value; } }
        public int Price { get => Product.Price; set { Product.Price = value; } }
        public string Category { get => Product.Category; set { Product.Category = value; OnPropertyChanged("Category"); } }
        public List<string> Categories { get; set; } = new List<string>();
        public BitmapImage Image { get => new BitmapImage( new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Images\ID_" + Product.Id + ".jpg")); }
        public ProductModifier(ProductType product, MainWindow from)
        {
            InitializeComponent();
            DataContext = this;
            From = from;
            Product = new ProductType() { Title = product.Title, Price = product.Price, Category = product.Category, Id = product.Id };
            DB = From.db;
            foreach (var Product in From.ProductTypes)
            {
                if (!Categories.Exists(o => o == Product.Category))
                {
                    Categories.Add(Product.Category);
                }
            }
            OnPropertyChanged("Categories");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
