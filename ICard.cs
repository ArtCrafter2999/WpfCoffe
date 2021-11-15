using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp2
{
    public enum CardType
    {
        ProductType,
        ProductSale,
        ProductView,
        ProductAdd,
        Group
    }
    public interface ICard
    {
        CardType CardType { get; }
        string Title { get; }
        ICommand ButtonClicked { get; }
    }
    
}
