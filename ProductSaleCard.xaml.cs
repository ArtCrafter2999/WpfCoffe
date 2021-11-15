using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Command;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    public partial class ProductSaleCard : System.Windows.Controls.UserControl, ICard, INotifyPropertyChanged
    {
        public ProductType product;
        public string Title { get => product.Title; }
        public string Price { get => $"{product.Price}₴"; }
        public BitmapImage Image { get => new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Images\ID_" + product.Id + ".jpg")); }
        public MainWindow From;
        public CardType CardType => CardType.ProductSale;
        public int Count;
        public string CountString { get { return $"x{Count}"; } }
        public ICommand ButtonClicked => new RelayCommand(o =>
        {
            From.ProductSaleButtonClicked(this);
        });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ProductSaleCard(ProductType prod, MainWindow from)
        {
            InitializeComponent();
            DataContext = this;
            product = prod;
            Count = 1;
            From = from;
        }
    }
}
