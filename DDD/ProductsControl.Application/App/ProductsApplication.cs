using ProductsControl.Application.App.Interfaces;
using ProductsControl.Application.DTO;
using ProductsControl.Domain.Interfaces.ProductsRepository;
using ProductsControl.Domain.Products;
using ProductsControl.Infra.Repository;
using System.Collections.Generic;

namespace ProductsControl.Application.App
{
    public class ProductsApplication : IProductApplication
    { 
        private readonly IProductsRepository _productsRepository;

        public ProductsApplication(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<ProductListDTO> Get()
        {
            var products = _productsRepository.Get();

            var listDTO = new List<ProductListDTO>();
            foreach (var item in products)
            {
                listDTO.Add(new ProductListDTO() { Description = item.Descriptions, Stock = item.Stock, Flagativo = item.FlgAtivo });
            }
            return listDTO;

        }

        public void Post(ProductCreateDTO product)
        {
            var products = new Product(product.Description, product.Stock, product.Flagativo);
            _productsRepository.Post(products);
        }
    }
}
