using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository;

namespace SalesWinApp
{
    public partial class frmMemberDetails : Form
    {

        public IMemberRepository memberRepository { get; set; }

        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfo { get; set; }

        public frmMemberDetails()
        {
            InitializeComponent();
        }


        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate)
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
            else if (!InsertOrUpdate)
            {
                txtMemberID.Enabled = false;

                btnAdd.Visible = false;
                btnUpdate.Visible = true;

                //txtMemberID.Text = MemberInfo.MemberId.ToString();
                //txtEmail.Text = MemberInfo.Email;
                //txtCompanyName.Text = MemberInfo.CompanyName;
                //txtCity.Text = MemberInfo.City;
                //txtCountry.Text = MemberInfo.Country;
                //txtPassword.Text = MemberInfo.Password;

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var memUpdate = new MemberObject
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                memberRepository.UpdateMember(memUpdate);
                MessageBox.Show("Member Updated.", "Update member", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Update member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newMem = new MemberObject
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                memberRepository.AddNewMember(newMem);
                MessageBox.Show("New member added", "Add a Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add a Member"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
