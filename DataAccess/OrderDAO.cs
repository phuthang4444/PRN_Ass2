
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
        public class OrderDAO : BaseDAL
        {
            private static OrderDAO instance = null;
            private static readonly object instancelock = new object();

            private OrderDAO() { }

            public static OrderDAO Instance
            {
                get
                {
                    lock (instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new OrderDAO();
                        }

                        return instance;
                    }
                }
            }

            public IEnumerable<OrderObject> GetOrderList()
            {
                List<OrderObject> list = new List<OrderObject>();
                IDataReader dataReader = null;
                string SQLSelect = "Select OrderId, MemberId, OrderDate, RequiredDate,ShippedDate,Freight" +
                    " From Order";

                try
                {
                    dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                    while (dataReader.Read())
                    {
                        list.Add(new OrderObject
                        {
                            OrderId = dataReader.GetInt32(0),
                            MemberId = dataReader.GetInt32(1),
                            OrderDate = dataReader.GetDateTime(2),
                            RequiredDate = dataReader.GetDateTime(3),
                            ShippedDate = dataReader.GetDateTime(4),
                            Freight = dataReader.GetDecimal(5)
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

            public OrderObject GetOrderByID(int productID)
            {
            OrderObject get = null;
                IDataReader dataReader = null;

                String SQLSelect = "SELECT OrderId, MemberId, OrderDate, RequiredDate, ShippedDate, Freight" +
                    " From Order" +
                    " Where OrderId = @OrderId";
                try
                {
                    dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                    if (dataReader.Read())
                    {
                        get = new OrderObject
                        {
                            OrderId = dataReader.GetInt32(0),
                            MemberId = dataReader.GetInt32(1),
                            OrderDate = dataReader.GetDateTime(2),
                            RequiredDate = dataReader.GetDateTime(3),
                            ShippedDate = dataReader.GetDateTime(4),
                            Freight = dataReader.GetDecimal(5)
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

           
            public void AddNewOrder(OrderObject order)
            {

                String SQLAdd = "Insert Order" +
                    " Values(@OrderId, @MemberId, @OrderDate, @RequiredDate, @ShippedDate, @Freight)";

                try
                {
                    if (GetOrderByID(order.OrderId) != null)
                    {
                        throw new Exception("Order with same ID exists.");
                    }
                    else
                    {
                        var parameters = new List<SqlParameter>();
                        parameters.Add(dataProvider.CreateParameter("@OrderId", 4, order.OrderId, DbType.Int32));
                        parameters.Add(dataProvider.CreateParameter("@MemberId", 4, order.MemberId, DbType.Int32));
                        parameters.Add(dataProvider.CreateParameter("@OrderDate", 50, order.OrderDate, DbType.DateTime));
                        parameters.Add(dataProvider.CreateParameter("@RequiredDate", 50, order.RequiredDate, DbType.DateTime));
                        parameters.Add(dataProvider.CreateParameter("@ShippedDate", 50,order.ShippedDate, DbType.DateTime));;
                        parameters.Add(dataProvider.CreateParameter("@Freight", 50, order.Freight, DbType.Decimal));

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

            public void Remove(int orderid)
            {
                String SQLDelete = "Delete Order" +
                    " Where OrderId = @OrderId";

                OrderObject del = GetOrderByID(orderid);

                try
                {
                    if (del == null)
                    {
                        throw new Exception("No such order in this list.");
                    }
                    else
                    {
                        var parameter = dataProvider.CreateParameter(SQLDelete, 4, del.OrderId, DbType.Int32);
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
        public void Update(OrderObject order)
        {
            OrderObject orderUpdate = GetOrderByID(order.OrderId);

            try
            {
                if (orderUpdate != null)
                {
                    string SQLUpdate = "Update Order" +
                        " set OrderDate = @OrderDate," +
                            " RequiredDate = @RequiredDate" +
                            " ShippedDate = @ShippedDate" +
                            " Freight = @Freight" +
                        " Where OrderId = @OrderId";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@OrderId", 4, order.OrderId, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@OrderDate", 50, order.OrderDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@RequiredDate", 50, order.RequiredDate, DbType.DateTime));
                    parameters.Add(dataProvider.CreateParameter("@ShippedDate", 50, order.ShippedDate, DbType.DateTime)); ;
                    parameters.Add(dataProvider.CreateParameter("@Freight", 50, order.Freight, DbType.Decimal));
                    dataProvider.Insert(SQLUpdate, CommandType.Text, parameters.ToArray());

                }
                else
                {
                    throw new Exception("Order exists.");
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


