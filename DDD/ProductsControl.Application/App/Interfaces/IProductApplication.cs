using ProductsControl.Application.DTO;
using System.Collections.Generic;

namespace ProductsControl.Application.App.Interfaces
{
    public interface IProductApplication
    {
        List<ProductListDTO> Get();
        void Post(ProductCreateDTO product);
    }
}
