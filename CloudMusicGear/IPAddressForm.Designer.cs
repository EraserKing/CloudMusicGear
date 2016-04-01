namespace CloudMusicGear
{
    partial class IPAddressForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.ipAddressCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(898, 619);
            this.OKButton.Margin = new System.Windows.Forms.Padding(6);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(150, 44);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ipAddressCheckedListBox
            // 
            this.ipAddressCheckedListBox.CheckOnClick = true;
            this.ipAddressCheckedListBox.ColumnWidth = 250;
            this.ipAddressCheckedListBox.FormattingEnabled = true;
            this.ipAddressCheckedListBox.Location = new System.Drawing.Point(15, 29);
            this.ipAddressCheckedListBox.Margin = new System.Windows.Forms.Padding(6);
            this.ipAddressCheckedListBox.MultiColumn = true;
            this.ipAddressCheckedListBox.Name = "ipAddressCheckedListBox";
            this.ipAddressCheckedListBox.Size = new System.Drawing.Size(1033, 550);
            this.ipAddressCheckedListBox.TabIndex = 1;
            // 
            // IPAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 678);
            this.Controls.Add(this.ipAddressCheckedListBox);
            this.Controls.Add(this.OKButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPAddressForm";
            this.ShowIcon = false;
            this.Text = "IPAddress";
            this.Load += new System.EventHandler(this.IPAddressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckedListBox ipAddressCheckedListBox;
    }
}