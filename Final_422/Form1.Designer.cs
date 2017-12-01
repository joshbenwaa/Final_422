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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_download = new System.Windows.Forms.Button();
            this.button_StartStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_offset = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button_scale = new System.Windows.Forms.Button();
            this.label_offset = new System.Windows.Forms.Label();
            this.label_scale = new System.Windows.Forms.Label();
            this.button_period = new System.Windows.Forms.Button();
            this.textBox_Period = new System.Windows.Forms.TextBox();
            this.comboBox_FilterSelection = new System.Windows.Forms.ComboBox();
            this.comboBox_CutoffSelection = new System.Windows.Forms.ComboBox();
            this.label_FilterSelect = new System.Windows.Forms.Label();
            this.label_Cutoff = new System.Windows.Forms.Label();
            this.checkBox_manual = new System.Windows.Forms.CheckBox();
            this.label_period = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox_graph = new System.Windows.Forms.CheckBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_download
            // 
            this.button_download.Location = new System.Drawing.Point(9, 275);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(75, 23);
            this.button_download.TabIndex = 10;
            this.button_download.Text = "Download";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // button_StartStop
            // 
            this.button_StartStop.Location = new System.Drawing.Point(90, 275);
            this.button_StartStop.Name = "button_StartStop";
            this.button_StartStop.Size = new System.Drawing.Size(75, 23);
            this.button_StartStop.TabIndex = 11;
            this.button_StartStop.Text = "Start";
            this.button_StartStop.UseVisualStyleBackColor = true;
            this.button_StartStop.Click += new System.EventHandler(this.button_StartStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox_Offset_TextChanged);
            // 
            // button_offset
            // 
            this.button_offset.Enabled = false;
            this.button_offset.Location = new System.Drawing.Point(106, 165);
            this.button_offset.Name = "button_offset";
            this.button_offset.Size = new System.Drawing.Size(75, 23);
            this.button_offset.TabIndex = 14;
            this.button_offset.Text = "Send Offset";
            this.button_offset.UseVisualStyleBackColor = true;
            this.button_offset.Click += new System.EventHandler(this.button_offset_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(9, 204);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 20);
            this.textBox2.TabIndex = 15;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox_Scale_TextChanged);
            // 
            // button_scale
            // 
            this.button_scale.Enabled = false;
            this.button_scale.Location = new System.Drawing.Point(106, 201);
            this.button_scale.Name = "button_scale";
            this.button_scale.Size = new System.Drawing.Size(75, 23);
            this.button_scale.TabIndex = 16;
            this.button_scale.Text = "Send Scale";
            this.button_scale.UseVisualStyleBackColor = true;
            this.button_scale.Click += new System.EventHandler(this.button_scale_Click);
            // 
            // label_offset
            // 
            this.label_offset.AutoSize = true;
            this.label_offset.Location = new System.Drawing.Point(6, 149);
            this.label_offset.Name = "label_offset";
            this.label_offset.Size = new System.Drawing.Size(35, 13);
            this.label_offset.TabIndex = 17;
            this.label_offset.Text = "Offset";
            // 
            // label_scale
            // 
            this.label_scale.AutoSize = true;
            this.label_scale.Location = new System.Drawing.Point(6, 188);
            this.label_scale.Name = "label_scale";
            this.label_scale.Size = new System.Drawing.Size(34, 13);
            this.label_scale.TabIndex = 18;
            this.label_scale.Text = "Scale";
            // 
            // button_period
            // 
            this.button_period.Enabled = false;
            this.button_period.Location = new System.Drawing.Point(106, 241);
            this.button_period.Name = "button_period";
            this.button_period.Size = new System.Drawing.Size(75, 23);
            this.button_period.TabIndex = 19;
            this.button_period.Text = "Send Period";
            this.button_period.UseVisualStyleBackColor = true;
            this.button_period.Click += new System.EventHandler(this.button_period_Click);
            // 
            // textBox_Period
            // 
            this.textBox_Period.Enabled = false;
            this.textBox_Period.Location = new System.Drawing.Point(9, 244);
            this.textBox_Period.Name = "textBox_Period";
            this.textBox_Period.Size = new System.Drawing.Size(75, 20);
            this.textBox_Period.TabIndex = 20;
            this.textBox_Period.TextChanged += new System.EventHandler(this.textBox_Period_TextChanged);
            // 
            // comboBox_FilterSelection
            // 
            this.comboBox_FilterSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FilterSelection.FormattingEnabled = true;
            this.comboBox_FilterSelection.Items.AddRange(new object[] {
            "LPF",
            "BPF",
            "Custom"});
            this.comboBox_FilterSelection.Location = new System.Drawing.Point(15, 51);
            this.comboBox_FilterSelection.Name = "comboBox_FilterSelection";
            this.comboBox_FilterSelection.Size = new System.Drawing.Size(121, 21);
            this.comboBox_FilterSelection.TabIndex = 21;
            this.comboBox_FilterSelection.SelectionChangeCommitted += new System.EventHandler(this.comboBox_FilterSelection_SelectionChangeCommitted);
            // 
            // comboBox_CutoffSelection
            // 
            this.comboBox_CutoffSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CutoffSelection.Enabled = false;
            this.comboBox_CutoffSelection.FormattingEnabled = true;
            this.comboBox_CutoffSelection.Items.AddRange(new object[] {
            "100Hz",
            "200Hz",
            "300Hz"});
            this.comboBox_CutoffSelection.Location = new System.Drawing.Point(18, 91);
            this.comboBox_CutoffSelection.Name = "comboBox_CutoffSelection";
            this.comboBox_CutoffSelection.Size = new System.Drawing.Size(121, 21);
            this.comboBox_CutoffSelection.TabIndex = 22;
            // 
            // label_FilterSelect
            // 
            this.label_FilterSelect.AutoSize = true;
            this.label_FilterSelect.Location = new System.Drawing.Point(15, 32);
            this.label_FilterSelect.Name = "label_FilterSelect";
            this.label_FilterSelect.Size = new System.Drawing.Size(108, 13);
            this.label_FilterSelect.TabIndex = 23;
            this.label_FilterSelect.Text = "1. Select Which Filter";
            // 
            // label_Cutoff
            // 
            this.label_Cutoff.AutoSize = true;
            this.label_Cutoff.Location = new System.Drawing.Point(15, 75);
            this.label_Cutoff.Name = "label_Cutoff";
            this.label_Cutoff.Size = new System.Drawing.Size(143, 13);
            this.label_Cutoff.TabIndex = 24;
            this.label_Cutoff.Text = "2. Select A Cutoff Frequency";
            // 
            // checkBox_manual
            // 
            this.checkBox_manual.AutoSize = true;
            this.checkBox_manual.Enabled = false;
            this.checkBox_manual.Location = new System.Drawing.Point(9, 129);
            this.checkBox_manual.Name = "checkBox_manual";
            this.checkBox_manual.Size = new System.Drawing.Size(154, 17);
            this.checkBox_manual.TabIndex = 25;
            this.checkBox_manual.Text = "Edit these options manually";
            this.checkBox_manual.UseVisualStyleBackColor = true;
            this.checkBox_manual.CheckedChanged += new System.EventHandler(this.checkBox_manual_CheckedChanged);
            // 
            // label_period
            // 
            this.label_period.AutoSize = true;
            this.label_period.Location = new System.Drawing.Point(6, 227);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(37, 13);
            this.label_period.TabIndex = 26;
            this.label_period.Text = "Period";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // checkBox_graph
            // 
            this.checkBox_graph.AutoSize = true;
            this.checkBox_graph.Location = new System.Drawing.Point(9, 305);
            this.checkBox_graph.Name = "checkBox_graph";
            this.checkBox_graph.Size = new System.Drawing.Size(90, 17);
            this.checkBox_graph.TabIndex = 27;
            this.checkBox_graph.Text = "Check to Plot";
            this.checkBox_graph.UseVisualStyleBackColor = true;
            this.checkBox_graph.CheckedChanged += new System.EventHandler(this.checkBox_graph_CheckedChanged);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(216, 32);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(899, 411);
            this.cartesianChart1.TabIndex = 28;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 574);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.checkBox_graph);
            this.Controls.Add(this.label_period);
            this.Controls.Add(this.checkBox_manual);
            this.Controls.Add(this.label_Cutoff);
            this.Controls.Add(this.label_FilterSelect);
            this.Controls.Add(this.comboBox_CutoffSelection);
            this.Controls.Add(this.comboBox_FilterSelection);
            this.Controls.Add(this.textBox_Period);
            this.Controls.Add(this.button_period);
            this.Controls.Add(this.label_scale);
            this.Controls.Add(this.label_offset);
            this.Controls.Add(this.button_scale);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_offset);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_StartStop);
            this.Controls.Add(this.button_download);
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.Button button_StartStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_offset;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_scale;
        private System.Windows.Forms.Label label_offset;
        private System.Windows.Forms.Label label_scale;
        private System.Windows.Forms.Button button_period;
        private System.Windows.Forms.TextBox textBox_Period;
        private System.Windows.Forms.ComboBox comboBox_FilterSelection;
        private System.Windows.Forms.ComboBox comboBox_CutoffSelection;
        private System.Windows.Forms.Label label_FilterSelect;
        private System.Windows.Forms.Label label_Cutoff;
        private System.Windows.Forms.CheckBox checkBox_manual;
        private System.Windows.Forms.Label label_period;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBox_graph;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}

