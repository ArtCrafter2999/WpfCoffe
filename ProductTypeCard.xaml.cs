using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Command;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfApp2
{
    public partial class ProductTypeCard : UserControl, ICard, INotifyPropertyChanged
    {
        public ProductType product;
        public string Title { get => product.Title; }
        public string Price { get => $"{product.Price}₴"; }
        public string Id { get => $"Id:{product.Id}"; }
        public BitmapImage Image => new BitmapImage(
                File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Images\ID_" + product.Id + ".jpg") ?
                new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Images\ID_" + product.Id + ".jpg") :
                new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Images\None.jpg"));
        public MainWindow From;
        public CardType CardType { get; set; } = CardType.ProductType;
        public ICommand ButtonClicked => new RelayCommand(o =>
        {
            if (CardType == CardType.ProductType)
            {
                From.ProductTypeButtonClicked(product);
            }
            else if(CardType == CardType.ProductView)
            {
                From.ProductViewButtonClicked(product);
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        public ProductTypeCard(ProductType prod, MainWindow from)
        {
            InitializeComponent();
            DataContext = this;
            product = prod;
            From = from;
        }
    }
}