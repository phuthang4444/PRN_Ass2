using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddNew(ProductObject product)
            => ProductDAO.Instance.AddNew(product);

        public ProductObject GetProductByID(int productID)
            => ProductDAO.Instance.GetProductByID(productID);

        public IEnumerable<ProductObject> GetProductList()
            => ProductDAO.Instance.GetProductList();

        public void Remove(int productId)
            => ProductDAO.Instance.Remove(productId);

        public ProductObject SearchProduct(int productId, string productName, decimal UnitPrice, int UnitsInStock)
            => ProductDAO.Instance.SearchProduct(productId, productName, UnitPrice, UnitsInStock);
    }
}
