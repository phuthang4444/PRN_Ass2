using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Repository;
using DataAccess;
using BusinessObject;

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
            if (!isAdmin)
            {
                tsMembers.Visible = false;
                tsProducts.Visible = false;
            }
            else
            {
                //tsMemberDetails.Visible = false;
            }
        }



        private void tsMembers_Click(object sender, EventArgs e)
        {
            if (frmMembers == null)
            {
                frmMembers = new frmMembers();
                frmMembers.MdiParent = this;
                frmMembers.FormClosed += frmMembers_FormClosed;
                frmMembers.Show();
            }
            else
            {
                frmMembers.Activate();
            }
        }

        private void frmMembers_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMembers = null;
        }

        private void tsProducts_Click(object sender, EventArgs e)
        {
            if (frmProducts == null)
            {
                frmProducts = new frmProducts();
                frmProducts.MdiParent = this;
                frmProducts.FormClosed += frmProducts_FormClosed;
                frmProducts.Show();
            }
            else
            {
                frmProducts.Activate();
            }
        }

        private void frmProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducts = null;
        }

        private void tsOrders_Click(object sender, EventArgs e)
        {
            if (frmOrders == null)
            {
                frmOrders = new frmOrders();
                frmOrders.MdiParent = this;
                frmOrders.FormClosed += frmOrders_FormClosed;
                frmOrders.Show();
            }
            else
            {
                frmOrders.Activate();
            }
        }

        private void frmOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmOrders = null;
        }

        private void tsCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsMemberDetails_Click(object sender, EventArgs e)
        {
            frmMemberDetails = new frmMemberDetails
            {
                Text = "Member Info",
                MemberInfo = MemberInfoMain,
                InsertOrUpdate = false
            };
            frmMemberDetails.MdiParent = this;
            frmMemberDetails.FormClosed += frmMemberDetails_FormClosed;
            frmMemberDetails.Show();

        }

        private void frmMemberDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmOrders = null;
        }
    }
}
