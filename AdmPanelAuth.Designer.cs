namespace WindowsFormsApp1
{
    partial class AdmPanelAuth
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.pwrdBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(184, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(69, 34);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Auth";
            // 
            // textBox0
            // 
            this.textBox0.BackColor = System.Drawing.SystemColors.Control;
            this.textBox0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox0.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox0.Location = new System.Drawing.Point(50, 79);
            this.textBox0.Name = "textBox0";
            this.textBox0.ReadOnly = true;
            this.textBox0.Size = new System.Drawing.Size(69, 25);
            this.textBox0.TabIndex = 1;
            this.textBox0.Text = "Login";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(50, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(88, 25);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Password";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(50, 122);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(109, 20);
            this.loginBox.TabIndex = 3;
            // 
            // pwrdBox
            // 
            this.pwrdBox.Location = new System.Drawing.Point(50, 215);
            this.pwrdBox.Name = "pwrdBox";
            this.pwrdBox.Size = new System.Drawing.Size(109, 20);
            this.pwrdBox.TabIndex = 4;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.Location = new System.Drawing.Point(292, 231);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(130, 47);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // AdmPanelAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 299);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pwrdBox);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdmPanelAuth";
            this.Text = "AdmPanelAuth";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox pwrdBox;
        private System.Windows.Forms.Button loginButton;
    }
}