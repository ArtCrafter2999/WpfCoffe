using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    public abstract class ProductCardBase : System.Windows.Controls.UserControl, ICard, INotifyPropertyChanged
    {
        public ProductType product;
        public abstract CardType CardType { get; }
        public string Title { get => product.Title; }
        public string Price { get => $"{product.Price}₴"; }
        public BitmapImage Image { get => new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"Images\ID_" + product.Id + ".jpg")); }
        public MainWindow From;
        public abstract ICommand ButtonClicked { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
