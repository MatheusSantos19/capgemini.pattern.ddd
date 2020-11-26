using ProductsControl.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;



namespace ProductsControl.Domain.Interfaces.ProductsRepository
{
    public interface IProductsRepository
    {
        List<Product> Get();
        void Post(Product products);
    }
}
