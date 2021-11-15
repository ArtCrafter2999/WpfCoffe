using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Command;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace WpfApp2
{
    public partial class GroupCard : UserControl, ICard, INotifyPropertyChanged
    {
        public List<ICard> products { get; set; } = new List<ICard>();
        public CardType CardType { get => CardType.Group; }
        public string Title { get; set; }
        //public string Image { get; set; }
        public string Count { get => "Элементов: " + products.Count.ToString(); }
        public bool IsOpen { get; set; }
        public MainWindow From;
        public string Sign { get { if (IsOpen) return "-"; return "+"; } }
        public ICommand ButtonClicked => new RelayCommand(o =>
        {
            IsOpen = !IsOpen;
            OnPropertyChanged("Sign");
            From.ProductsChange();
        });
        public GroupCard(MainWindow From)
        {
            InitializeComponent();
            DataContext = this;
            this.From = From;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
