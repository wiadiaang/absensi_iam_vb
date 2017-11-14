namespace IAM
{
    partial class FormSignStudent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignStudent));
            this.txtsmartcard = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnconnect = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.txtdata = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtsmartcard
            // 
            this.txtsmartcard.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsmartcard.Location = new System.Drawing.Point(37, 22);
            this.txtsmartcard.Name = "txtsmartcard";
            this.txtsmartcard.Size = new System.Drawing.Size(293, 29);
            this.txtsmartcard.TabIndex = 50;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(37, 85);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(203, 23);
            this.btnconnect.TabIndex = 51;
            this.btnconnect.Text = "Connect Devices";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // btnread
            // 
            this.btnread.Location = new System.Drawing.Point(255, 85);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(75, 23);
            this.btnread.TabIndex = 52;
            this.btnread.Text = "button2";
            this.btnread.UseVisualStyleBackColor = true;
            // 
            // txtdata
            // 
            this.txtdata.Location = new System.Drawing.Point(37, 146);
            this.txtdata.Name = "txtdata";
            this.txtdata.Size = new System.Drawing.Size(284, 20);
            this.txtdata.TabIndex = 53;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(37, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(327, 21);
            this.comboBox1.TabIndex = 54;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "label1";
            // 
            // FormSignStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 209);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtdata);
            this.Controls.Add(this.btnread);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.txtsmartcard);
            this.Name = "FormSignStudent";
            this.Text = "STUDENT ATTENDANCE APPLICATION";
            this.Load += new System.EventHandler(this.FormSignStudent_Load);
            this.Resize += new System.EventHandler(this.FormSignStudent_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtsmartcard;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.TextBox txtdata;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

