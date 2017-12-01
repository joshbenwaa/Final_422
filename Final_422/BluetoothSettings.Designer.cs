namespace Final_422
{
    partial class BluetoothSettings
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
            this.COM_list = new System.Windows.Forms.ComboBox();
            this.COMLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // COM_list
            // 
            this.COM_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COM_list.FormattingEnabled = true;
            this.COM_list.Items.AddRange(new object[] {
            "COM5",
            "COM4"});
            this.COM_list.Location = new System.Drawing.Point(62, 9);
            this.COM_list.Name = "COM_list";
            this.COM_list.Size = new System.Drawing.Size(121, 21);
            this.COM_list.TabIndex = 0;
            this.COM_list.SelectedIndexChanged += new System.EventHandler(this.COM_list_SelectedIndexChanged);
            this.COM_list.Click += new System.EventHandler(this.COM_list_Click);
            // 
            // COMLabel
            // 
            this.COMLabel.AutoSize = true;
            this.COMLabel.Location = new System.Drawing.Point(3, 9);
            this.COMLabel.Name = "COMLabel";
            this.COMLabel.Size = new System.Drawing.Size(53, 13);
            this.COMLabel.TabIndex = 2;
            this.COMLabel.Text = "COM Port";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(62, 36);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // BluetoothSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 75);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.COMLabel);
            this.Controls.Add(this.COM_list);
            this.Name = "BluetoothSettings";
            this.Text = "Bluetooth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox COM_list;
        private System.Windows.Forms.Label COMLabel;
        private System.Windows.Forms.Button connectButton;
    }
}