namespace SalesWinApp
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Loginlb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Usernametxt = new System.Windows.Forms.TextBox();
            this.Passwordtxt = new System.Windows.Forms.TextBox();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.Cacncelbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Loginlb
            // 
            this.Loginlb.AutoSize = true;
            this.Loginlb.Font = new System.Drawing.Font("Segoe UI Historic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Loginlb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Loginlb.Location = new System.Drawing.Point(287, 43);
            this.Loginlb.Name = "Loginlb";
            this.Loginlb.Size = new System.Drawing.Size(145, 54);
            this.Loginlb.TabIndex = 0;
            this.Loginlb.Text = "LOGIN";
            this.Loginlb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // Usernametxt
            // 
            this.Usernametxt.Location = new System.Drawing.Point(237, 132);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.Size = new System.Drawing.Size(248, 27);
            this.Usernametxt.TabIndex = 3;
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.Location = new System.Drawing.Point(237, 218);
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.Size = new System.Drawing.Size(248, 27);
            this.Passwordtxt.TabIndex = 4;
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(153, 319);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(94, 29);
            this.Loginbtn.TabIndex = 5;
            this.Loginbtn.Text = "&Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // Cacncelbtn
            // 
            this.Cacncelbtn.Location = new System.Drawing.Point(454, 319);
            this.Cacncelbtn.Name = "Cacncelbtn";
            this.Cacncelbtn.Size = new System.Drawing.Size(94, 29);
            this.Cacncelbtn.TabIndex = 6;
            this.Cacncelbtn.Text = "Cancel";
            this.Cacncelbtn.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 450);
            this.Controls.Add(this.Cacncelbtn);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.Passwordtxt);
            this.Controls.Add(this.Usernametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Loginlb);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Loginlb;
        private Label label1;
        private Label label2;
        private TextBox Usernametxt;
        private TextBox Passwordtxt;
        private Button Loginbtn;
        private Button Cacncelbtn;
    }
}