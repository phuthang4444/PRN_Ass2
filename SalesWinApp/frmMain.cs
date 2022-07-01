using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMain : Form
    {
        private IMemberRepository memberRepository = new MemberRepository();
        private IOrderRepository orderRepository = new OrderRepository();
        private IProductRepository productRepository = new ProductRepository();

        frmMembers frmMembers;
        frmProducts frmProducts;
        frmOrders frmOrders;
        frmMemberDetails frmMemberDetails;

        public bool isAdmin { get; set; }
        public MemberObject MemberInfoMain { get; set; }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
