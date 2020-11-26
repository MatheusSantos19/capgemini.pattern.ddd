using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsControl.Domain.Products
{
    public class Product 
    {
     

        public int Id { get; set; }
        public string Descriptions { get; set; }
        public float Stock { get; set; }
        public string FlgAtivo { get; set; }

        public Product(string description, float stock, string flagativo)
        {
            
            Descriptions = description;
            Stock = stock;
            FlgAtivo = flagativo;
        }

        public Product() { 
        }
    }

    
}
