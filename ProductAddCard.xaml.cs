using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using Command;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для ProductAddCard.xaml
    /// </summary>
    public partial class ProductAddCard : UserControl, ICard
    {
        MainWindow From;
        public ProductAddCard(MainWindow from)
        {
            InitializeComponent();
            DataContext = this;
            From = from;
        }
        public CardType CardType => CardType.ProductAdd;

        public string Title => "Добавить";

        public ICommand ButtonClicked => new RelayCommand(o => {
            From.ProductAddButtonClicked();
        });
    }
}
