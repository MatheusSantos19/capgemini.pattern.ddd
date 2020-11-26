using Dapper;
using Microsoft.Extensions.Configuration;
using ProductsControl.Domain.Interfaces.ProductsRepository;
using ProductsControl.Domain.Products;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProductsControl.Infra.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly string _connectionString;

        public ProductsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }

        public List<Product> Get()
        {
            var connection = new SqlConnection(_connectionString);
            var products = connection.Query<Product>("SELECT"  +
                                                             "[Descriptions]"+ 
                                                             ",[Stock]"+
                                                             ",[FlgAtivo]"+
                                                       "FROM[SalesForce].[dbo].[Products]");
            return products.ToList();
        }

        public void Post(Product products)
        {
            var connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO [SalesForce].[dbo].[Products]"+
                             "([Descriptions]"+
                             ",[Stock]"+
                             ",[FlgAtivo])"+
                        "VALUES(@description,@stock,@flag)";

            connection.Execute(query, new { description = products.Descriptions, stock = products.Stock,flag=products.FlgAtivo });

        }
    }
}
