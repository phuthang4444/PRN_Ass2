namespace SalesWinApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMemberDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMembers,
            this.tsProducts,
            this.tsOrders,
            this.tsMemberDetails,
            this.tsCloseAll,
            this.tsExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsMembers
            // 
            this.tsMembers.Name = "tsMembers";
            this.tsMembers.Size = new System.Drawing.Size(85, 24);
            this.tsMembers.Text = "Members";
            this.tsMembers.Click += new System.EventHandler(this.tsMembers_Click_1);
            // 
            // tsProducts
            // 
            this.tsProducts.Name = "tsProducts";
            this.tsProducts.Size = new System.Drawing.Size(80, 24);
            this.tsProducts.Text = "Products";
            this.tsProducts.Click += new System.EventHandler(this.tsProducts_Click_1);
            // 
            // tsOrders
            // 
            this.tsOrders.Name = "tsOrders";
            this.tsOrders.Size = new System.Drawing.Size(67, 24);
            this.tsOrders.Text = "Orders";
            // 
            // tsMemberDetails
            // 
            this.tsMemberDetails.Name = "tsMemberDetails";
            this.tsMemberDetails.Size = new System.Drawing.Size(90, 24);
            this.tsMemberDetails.Text = "My Profile";
            // 
            // tsCloseAll
            // 
            this.tsCloseAll.Name = "tsCloseAll";
            this.tsCloseAll.Size = new System.Drawing.Size(121, 24);
            this.tsCloseAll.Text = "Close all forms";
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(47, 24);
            this.tsExit.Text = "Exit";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsMembers;
        private ToolStripMenuItem tsProducts;
        private ToolStripMenuItem tsOrders;
        private ToolStripMenuItem tsMemberDetails;
        private ToolStripMenuItem tsCloseAll;
        private ToolStripMenuItem tsExit;
    }
}