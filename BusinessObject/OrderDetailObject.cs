using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetailObject
    {
        int OrderId { get; set; }

        int ProductId { get; set; }

        decimal UnitPrice { get; set; }

        int Quantity { get; set; }

        float Discount { get; set; }

    }
}
