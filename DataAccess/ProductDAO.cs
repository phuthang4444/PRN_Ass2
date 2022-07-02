using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using System.Data;
using DataAccess.DataProvider;
using Microsoft.Data.SqlClient;


namespace DataAccess
{
    public class ProductDAO : BaseDAL
    {
        private static ProductDAO instance = null;
        private static readonly object instancelock = new object();

        private ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }

                    return instance;
                }
            }
        }

        public IEnumerable<ProductObject> GetProductList()
        {
            List<ProductObject> list = new List<ProductObject>();
            IDataReader dataReader = null;
            string SQLSelect = "Select ProductId, CategoryId, ProductName, \"Weight\", UnitPrice, UnitsInStock" +
                " From Product";

            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    list.Add(new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitsInStock = dataReader.GetInt32(5)
                    });

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }

            return list;
        }

        public ProductObject GetProductByID(int productID)
        {
            ProductObject get = null;
            IDataReader dataReader = null;

            String SQLSelect = "SELECT ProductId, CategoryId, ProductName, \"Weight\", UnitPrice, UnitsInStock" +
                " From Product" +
                " Where ProductId = @ProductId";
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                if (dataReader.Read())
                {
                    get = new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitsInStock = dataReader.GetInt32(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }

            return get;
        }

        public ProductObject SearchProduct(int productId, string productName, Decimal UnitPrice, int UnitsInStock)
        {
            ProductObject get = null;
            IDataReader dataReader = null;

            String SQLSelect = "SELECT ProductId, CategoryId, ProductName, \"Weight\", UnitPrice, UnitsInStock" +
                " From Product" +
                " Where ProductId = @ProductId AND ProductName like'%@ProductName%'" +
                    "AND @UnitPrice = @UnitPrice AND @UnitsInstock = @UnitsInStock";
            try
            {
                var param = dataProvider.CreateParameter("@ProductId", 4, productId, DbType.Int32);
                var param2 = dataProvider.CreateParameter("@ProductName", 40, productName, DbType.String);
                var param3 = dataProvider.CreateParameter("@UnitPrice", 50, UnitPrice, DbType.Decimal);
                var param4 = dataProvider.CreateParameter("@UnitsInStock", 4, UnitsInStock, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param, param2, param3, param4);
                if (dataReader.Read())
                {
                    get = new ProductObject
                    {
                        ProductId = dataReader.GetInt32(0),
                        CategoryId = dataReader.GetInt32(1),
                        ProductName = dataReader.GetString(2),
                        Weight = dataReader.GetString(3),
                        UnitPrice = dataReader.GetDecimal(4),
                        UnitsInStock = dataReader.GetInt32(5)
                    };
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }

            return get;
        }

        public void AddNew(ProductObject product)
        {

            String SQLAdd = "Insert Product" +
                " Values(@ProductId, @CategoryId, @ProductName, @Weight, @UnitPrice, @UnitsInStock)";

            try
            {
                if (GetProductByID(product.ProductId) != null)
                {
                    throw new Exception("Product with same ID exists.");
                }
                else
                {
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@ProductId", 4, product.ProductId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@CategoryId", 4, product.CategoryId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@ProductName", 40, product.ProductName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Weight", 20, product.Weight, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@UnitPrice", 50, product.UnitPrice, DbType.Decimal));
                    parameters.Add(dataProvider.CreateParameter("@UnitsInStock", 4, product.UnitsInStock, DbType.Int32));

                    dataProvider.Insert(SQLAdd, CommandType.Text, parameters.ToArray());
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Remove(int productId)
        {
            String SQLDelete = "Delete Product" +
                " Where ProductId = @ProductId";

            ProductObject del = GetProductByID(productId);

            try
            {
                if (del == null)
                {
                    throw new Exception("No such product in list.");
                }
                else
                {
                    var parameter = dataProvider.CreateParameter(SQLDelete, 4, del.ProductId, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, parameter);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
