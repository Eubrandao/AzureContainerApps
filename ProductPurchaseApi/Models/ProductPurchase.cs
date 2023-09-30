// Models/ProductPurchase.cs

using System;

namespace ProductPurchaseApi.Models
{
    public class ProductPurchase
    {
        public ProductPurchase(string produto)
        {
            Produto = produto;
        }

        public string Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}
