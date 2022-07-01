using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<OrderObject> GetOrderList();

        public OrderObject GetOrderByID(int OrderID);

        public void AddNewOrder(OrderObject Order);

        public void Update(OrderObject order);

        public void Remove(int OrderId);
    }
}
