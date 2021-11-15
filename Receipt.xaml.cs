using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Command;

namespace WpfApp2
{
    public partial class Receipt : Window, INotifyPropertyChanged
    {
        public ApplicationContext db;
        private int Sum = 0;
        private string Now;
        public string ReceiptText { get; set; }
        public ICommand OKButton => new RelayCommand(o => { DialogResult = true; db.Orders.Add(new Order() { Date = Now, Price = Sum, Receipt = ReceiptText}); db.SaveChanges(); Close();});
        public ICommand CancelButton => new RelayCommand(o => { DialogResult = false; Close(); });
        public Receipt(List<ICard> Cart, ApplicationContext DB)
        {
            InitializeComponent();
            DataContext = this;
            db = DB;
            Now = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            ReceiptText += $"Дата и время: {Now}\n\n";
            foreach (var product in Cart)
            {
                if ((product as ProductSaleCard).Count > 0)
                {
                    ReceiptText += (product as ProductSaleCard).product.ToString() + "\n";
                    Sum += (product as ProductSaleCard).product.Price * (product as ProductSaleCard).Count;
                }
            }
            ReceiptText += $"\nСумма {Sum}.00₴";
            OnPropertyChanged("ReceiptText");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
