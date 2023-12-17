namespace WindowsFormsApp1
{
    partial class AdminForm
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
            this.schedLoadButton = new System.Windows.Forms.Button();
            this.bookLoadButton = new System.Windows.Forms.Button();
            this.ScheduleView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleView)).BeginInit();
            this.SuspendLayout();
            // 
            // schedLoadButton
            // 
            this.schedLoadButton.Location = new System.Drawing.Point(664, 44);
            this.schedLoadButton.Name = "schedLoadButton";
            this.schedLoadButton.Size = new System.Drawing.Size(124, 42);
            this.schedLoadButton.TabIndex = 0;
            this.schedLoadButton.Text = "Load Schedule";
            this.schedLoadButton.UseVisualStyleBackColor = true;
            this.schedLoadButton.Click += new System.EventHandler(this.schedLoadButton_Click);
            // 
            // bookLoadButton
            // 
            this.bookLoadButton.Location = new System.Drawing.Point(12, 44);
            this.bookLoadButton.Name = "bookLoadButton";
            this.bookLoadButton.Size = new System.Drawing.Size(124, 42);
            this.bookLoadButton.TabIndex = 1;
            this.bookLoadButton.Text = "Load Booking History";
            this.bookLoadButton.UseVisualStyleBackColor = true;
            this.bookLoadButton.Click += new System.EventHandler(this.bookLoadButton_Click);
            // 
            // ScheduleView
            // 
            this.ScheduleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleView.Location = new System.Drawing.Point(12, 104);
            this.ScheduleView.Name = "ScheduleView";
            this.ScheduleView.Size = new System.Drawing.Size(776, 304);
            this.ScheduleView.TabIndex = 2;
            this.ScheduleView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellValueChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScheduleView);
            this.Controls.Add(this.bookLoadButton);
            this.Controls.Add(this.schedLoadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button schedLoadButton;
        private System.Windows.Forms.Button bookLoadButton;
        private System.Windows.Forms.DataGridView ScheduleView;
    }
}