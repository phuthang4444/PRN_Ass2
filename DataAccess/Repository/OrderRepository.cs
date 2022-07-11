using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddNewOrder(OrderObject Order)
            => OrderDAO.Instance.AddNewOrder(Order);

        public OrderObject GetOrderByID(int OrderID)
            => OrderDAO.Instance.GetOrderByID(OrderID);

        public IEnumerable<OrderObject> GetOrderList()
            => OrderDAO.Instance.GetOrderList();

        public void Remove(int OrderId)
            => OrderDAO.Instance.Remove(OrderId);

        public void Update(OrderObject order)
            => OrderDAO.Instance.Update(order);
    }
}
