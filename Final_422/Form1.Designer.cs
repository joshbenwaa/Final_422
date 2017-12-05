namespace Final_422
{

    partial class Main
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.BlutoothStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bluetoothSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.button_RunStop = new System.Windows.Forms.Button();
            this.button_single = new System.Windows.Forms.Button();
            this.trackBar_Vertical = new System.Windows.Forms.TrackBar();
            this.trackBar_Horizontal = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_horizontal = new System.Windows.Forms.GroupBox();
            this.groupBox_RunControl = new System.Windows.Forms.GroupBox();
            this.button_horizontal_set = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Horizontal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_horizontal.SuspendLayout();
            this.groupBox_RunControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BlutoothStatusLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1146, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // BlutoothStatusLabel
            // 
            this.BlutoothStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BlutoothStatusLabel.Name = "BlutoothStatusLabel";
            this.BlutoothStatusLabel.Size = new System.Drawing.Size(124, 17);
            this.BlutoothStatusLabel.Text = "Bluetooth Connection";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1146, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bluetoothSettingsToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // bluetoothSettingsToolStripMenuItem
            // 
            this.bluetoothSettingsToolStripMenuItem.Name = "bluetoothSettingsToolStripMenuItem";
            this.bluetoothSettingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.bluetoothSettingsToolStripMenuItem.Text = "Bluetooth Settings";
            this.bluetoothSettingsToolStripMenuItem.Click += new System.EventHandler(this.bluetoothSettingsToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.OutputLabel);
            this.OutputGroupBox.Location = new System.Drawing.Point(9, 449);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(698, 100);
            this.OutputGroupBox.TabIndex = 9;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output";
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputLabel.Location = new System.Drawing.Point(3, 16);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(19, 13);
            this.OutputLabel.TabIndex = 0;
            this.OutputLabel.Text = ">>";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(216, 32);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(899, 411);
            this.cartesianChart1.TabIndex = 28;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // button_RunStop
            // 
            this.button_RunStop.BackColor = System.Drawing.SystemColors.Control;
            this.button_RunStop.Location = new System.Drawing.Point(6, 19);
            this.button_RunStop.Name = "button_RunStop";
            this.button_RunStop.Size = new System.Drawing.Size(75, 23);
            this.button_RunStop.TabIndex = 29;
            this.button_RunStop.Text = "Run / Stop";
            this.button_RunStop.UseVisualStyleBackColor = false;
            this.button_RunStop.Click += new System.EventHandler(this.button_RunStop_Click);
            // 
            // button_single
            // 
            this.button_single.Location = new System.Drawing.Point(91, 19);
            this.button_single.Name = "button_single";
            this.button_single.Size = new System.Drawing.Size(75, 23);
            this.button_single.TabIndex = 30;
            this.button_single.Text = "Single";
            this.button_single.UseVisualStyleBackColor = true;
            this.button_single.Click += new System.EventHandler(this.button_single_Click);
            // 
            // trackBar_Vertical
            // 
            this.trackBar_Vertical.Location = new System.Drawing.Point(6, 19);
            this.trackBar_Vertical.Name = "trackBar_Vertical";
            this.trackBar_Vertical.Size = new System.Drawing.Size(172, 45);
            this.trackBar_Vertical.TabIndex = 31;
            // 
            // trackBar_Horizontal
            // 
            this.trackBar_Horizontal.Location = new System.Drawing.Point(6, 19);
            this.trackBar_Horizontal.Maximum = 9;
            this.trackBar_Horizontal.Name = "trackBar_Horizontal";
            this.trackBar_Horizontal.Size = new System.Drawing.Size(107, 45);
            this.trackBar_Horizontal.TabIndex = 32;
            this.trackBar_Horizontal.Scroll += new System.EventHandler(this.trackBar_Horizontal_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBar_Vertical);
            this.groupBox1.Location = new System.Drawing.Point(9, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 66);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vertical";
            // 
            // groupBox_horizontal
            // 
            this.groupBox_horizontal.Controls.Add(this.button_horizontal_set);
            this.groupBox_horizontal.Controls.Add(this.trackBar_Horizontal);
            this.groupBox_horizontal.Location = new System.Drawing.Point(9, 90);
            this.groupBox_horizontal.Name = "groupBox_horizontal";
            this.groupBox_horizontal.Size = new System.Drawing.Size(200, 69);
            this.groupBox_horizontal.TabIndex = 34;
            this.groupBox_horizontal.TabStop = false;
            this.groupBox_horizontal.Text = "Horizontal";
            // 
            // groupBox_RunControl
            // 
            this.groupBox_RunControl.Controls.Add(this.button_RunStop);
            this.groupBox_RunControl.Controls.Add(this.button_single);
            this.groupBox_RunControl.Location = new System.Drawing.Point(15, 32);
            this.groupBox_RunControl.Name = "groupBox_RunControl";
            this.groupBox_RunControl.Size = new System.Drawing.Size(172, 52);
            this.groupBox_RunControl.TabIndex = 35;
            this.groupBox_RunControl.TabStop = false;
            this.groupBox_RunControl.Text = "Run Control";
            // 
            // button_horizontal_set
            // 
            this.button_horizontal_set.Location = new System.Drawing.Point(119, 19);
            this.button_horizontal_set.Name = "button_horizontal_set";
            this.button_horizontal_set.Size = new System.Drawing.Size(75, 23);
            this.button_horizontal_set.TabIndex = 33;
            this.button_horizontal_set.Text = "Set";
            this.button_horizontal_set.UseVisualStyleBackColor = true;
            this.button_horizontal_set.Click += new System.EventHandler(this.button_horizontal_set_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 574);
            this.Controls.Add(this.groupBox_RunControl);
            this.Controls.Add(this.groupBox_horizontal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Final_422";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Horizontal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_horizontal.ResumeLayout(false);
            this.groupBox_horizontal.PerformLayout();
            this.groupBox_RunControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bluetoothSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.Label OutputLabel;
        public System.Windows.Forms.ToolStripStatusLabel BlutoothStatusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button button_RunStop;
        private System.Windows.Forms.Button button_single;
        private System.Windows.Forms.TrackBar trackBar_Vertical;
        private System.Windows.Forms.TrackBar trackBar_Horizontal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_horizontal;
        private System.Windows.Forms.GroupBox groupBox_RunControl;
        private System.Windows.Forms.Button button_horizontal_set;
    }
}

