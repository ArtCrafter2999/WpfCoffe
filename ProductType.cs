using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public override int GetHashCode()
        {
            return Title.GetHashCode() + Price.GetHashCode() + Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
        public static bool operator ==(ProductType left, ProductType right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(ProductType left, ProductType right)
        {
            return !left.Equals(right);
        }
        
    }
    //public class ProductSale
    //{
    //    public ProductType product;
    //    public ProductSale(ProductType product)
    //    {
    //        this.product = product;
    //    }
    //    public string Title { get => product.Title; set { product.Title = value; } }
    //    public int Price { get => product.Price; set { product.Price = value; } }
    //    public int Id { get => product.Id; set { product.Id = value; } }
    //    public int Count { get; set; } = 0;
    //    public override string ToString()
    //    {
    //        return $"{Title} x{Count} ....... {Price * Count}.00₴";
    //    }
    //}
}
