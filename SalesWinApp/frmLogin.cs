using BusinessObject;
using DataAccess.Repository;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        IMemberRepository memberRepository = new MemberRepository();

        public MemberObject MemberInfo;

        frmMain frmMain;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            MemberObject memLogin = memberRepository.Login(email, password);

            if (memLogin != null)
            {
                string memEmail = memLogin.Email;
                MessageBox.Show($"Login sucess. Welcome {memEmail} ", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (memEmail.ToLower().Equals("admin@fstore.com"))
                {
                    MemberInfo = memLogin;
                    frmMain = new frmMain()
                    {
                        isAdmin = true,
                        MemberInfoMain = memLogin
                    };
                    frmMain.Show();
                    frmMain.Closed += (s, args) => this.Close();
                    this.Hide();
                }
                else
                {
                    MemberInfo = memLogin;
                    frmMain = new frmMain()
                    {
                        isAdmin = false,
                        MemberInfoMain = memLogin
                    };
                    frmMain.Closed += (s, args) => this.Close();
                    this.Hide();
                    frmMain.Show();
                }
            }
            else if ((memLogin == null))
            {
                var retryCheck = MessageBox.Show("Incorrect email or password.", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (retryCheck == DialogResult.Cancel)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Error", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Cacncelbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}