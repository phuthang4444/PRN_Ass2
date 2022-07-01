using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<ProductObject> GetProductList();

        public ProductObject GetProductByID(int productID);

        public ProductObject SearchProduct(int productId, string productName, Decimal UnitPrice, int UnitsInStock);

        public void AddNew(ProductObject product);

        public void Remove(int productId);

    }
}
