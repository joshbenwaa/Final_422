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
            this.button_horizontal_set = new System.Windows.Forms.Button();
            this.groupBox_RunControl = new System.Windows.Forms.GroupBox();
            this.trackBar_trigger = new System.Windows.Forms.TrackBar();
            this.button_set_trigger = new System.Windows.Forms.Button();
            this.label_trigger = new System.Windows.Forms.Label();
            this.radioButton_rising = new System.Windows.Forms.RadioButton();
            this.radioButton_falling = new System.Windows.Forms.RadioButton();
            this.label_SamplingFreq = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.cartesianChart_DFT = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart_phase = new LiveCharts.WinForms.CartesianChart();
            this.groupBox_measurements = new System.Windows.Forms.GroupBox();
            this.label_phase = new System.Windows.Forms.Label();
            this.label_Freq = new System.Windows.Forms.Label();
            this.label_Vpp = new System.Windows.Forms.Label();
            this.trackBar_scale = new System.Windows.Forms.TrackBar();
            this.trackBar_offset = new System.Windows.Forms.TrackBar();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Vertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Horizontal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_horizontal.SuspendLayout();
            this.groupBox_RunControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_trigger)).BeginInit();
            this.groupBox_measurements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_offset)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BlutoothStatusLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 675);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1336, 22);
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
            this.menuStrip1.Size = new System.Drawing.Size(1336, 24);
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
            this.OutputGroupBox.Size = new System.Drawing.Size(546, 223);
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
            this.cartesianChart1.Location = new System.Drawing.Point(322, 27);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(933, 192);
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
            this.trackBar_Vertical.Minimum = 1;
            this.trackBar_Vertical.Name = "trackBar_Vertical";
            this.trackBar_Vertical.Size = new System.Drawing.Size(172, 45);
            this.trackBar_Vertical.TabIndex = 31;
            this.trackBar_Vertical.Value = 1;
            this.trackBar_Vertical.Scroll += new System.EventHandler(this.trackBar_Vertical_Scroll);
            // 
            // trackBar_Horizontal
            // 
            this.trackBar_Horizontal.Location = new System.Drawing.Point(6, 19);
            this.trackBar_Horizontal.Maximum = 9;
            this.trackBar_Horizontal.Minimum = 1;
            this.trackBar_Horizontal.Name = "trackBar_Horizontal";
            this.trackBar_Horizontal.Size = new System.Drawing.Size(107, 45);
            this.trackBar_Horizontal.TabIndex = 32;
            this.trackBar_Horizontal.Value = 1;
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
            // trackBar_trigger
            // 
            this.trackBar_trigger.Location = new System.Drawing.Point(271, 14);
            this.trackBar_trigger.Maximum = 255;
            this.trackBar_trigger.Name = "trackBar_trigger";
            this.trackBar_trigger.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_trigger.Size = new System.Drawing.Size(45, 192);
            this.trackBar_trigger.TabIndex = 36;
            this.trackBar_trigger.TickFrequency = 8;
            this.trackBar_trigger.Scroll += new System.EventHandler(this.trackBar_trigger_Scroll);
            // 
            // button_set_trigger
            // 
            this.button_set_trigger.Location = new System.Drawing.Point(178, 393);
            this.button_set_trigger.Name = "button_set_trigger";
            this.button_set_trigger.Size = new System.Drawing.Size(75, 23);
            this.button_set_trigger.TabIndex = 37;
            this.button_set_trigger.Text = "Set Trigger";
            this.button_set_trigger.UseVisualStyleBackColor = true;
            this.button_set_trigger.Click += new System.EventHandler(this.button_set_trigger_Click);
            // 
            // label_trigger
            // 
            this.label_trigger.AutoSize = true;
            this.label_trigger.Location = new System.Drawing.Point(141, 398);
            this.label_trigger.Name = "label_trigger";
            this.label_trigger.Size = new System.Drawing.Size(13, 13);
            this.label_trigger.TabIndex = 38;
            this.label_trigger.Text = "0";
            // 
            // radioButton_rising
            // 
            this.radioButton_rising.AutoSize = true;
            this.radioButton_rising.Checked = true;
            this.radioButton_rising.Location = new System.Drawing.Point(133, 421);
            this.radioButton_rising.Name = "radioButton_rising";
            this.radioButton_rising.Size = new System.Drawing.Size(54, 17);
            this.radioButton_rising.TabIndex = 39;
            this.radioButton_rising.TabStop = true;
            this.radioButton_rising.Text = "Rising";
            this.radioButton_rising.UseVisualStyleBackColor = true;
            // 
            // radioButton_falling
            // 
            this.radioButton_falling.AutoSize = true;
            this.radioButton_falling.Location = new System.Drawing.Point(198, 421);
            this.radioButton_falling.Name = "radioButton_falling";
            this.radioButton_falling.Size = new System.Drawing.Size(55, 17);
            this.radioButton_falling.TabIndex = 40;
            this.radioButton_falling.TabStop = true;
            this.radioButton_falling.Text = "Falling";
            this.radioButton_falling.UseVisualStyleBackColor = true;
            this.radioButton_falling.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label_SamplingFreq
            // 
            this.label_SamplingFreq.AutoSize = true;
            this.label_SamplingFreq.Location = new System.Drawing.Point(362, 9);
            this.label_SamplingFreq.Name = "label_SamplingFreq";
            this.label_SamplingFreq.Size = new System.Drawing.Size(35, 13);
            this.label_SamplingFreq.TabIndex = 41;
            this.label_SamplingFreq.Text = "label1";
            // 
            // cartesianChart_DFT
            // 
            this.cartesianChart_DFT.Location = new System.Drawing.Point(322, 225);
            this.cartesianChart_DFT.Name = "cartesianChart_DFT";
            this.cartesianChart_DFT.Size = new System.Drawing.Size(419, 166);
            this.cartesianChart_DFT.TabIndex = 42;
            this.cartesianChart_DFT.Text = "cartesianChart2";
            // 
            // cartesianChart_phase
            // 
            this.cartesianChart_phase.Location = new System.Drawing.Point(758, 247);
            this.cartesianChart_phase.Name = "cartesianChart_phase";
            this.cartesianChart_phase.Size = new System.Drawing.Size(497, 144);
            this.cartesianChart_phase.TabIndex = 43;
            this.cartesianChart_phase.Text = "cartesianChart_phase";
            // 
            // groupBox_measurements
            // 
            this.groupBox_measurements.Controls.Add(this.label_phase);
            this.groupBox_measurements.Controls.Add(this.label_Freq);
            this.groupBox_measurements.Controls.Add(this.label_Vpp);
            this.groupBox_measurements.Location = new System.Drawing.Point(1066, 449);
            this.groupBox_measurements.Name = "groupBox_measurements";
            this.groupBox_measurements.Size = new System.Drawing.Size(189, 67);
            this.groupBox_measurements.TabIndex = 44;
            this.groupBox_measurements.TabStop = false;
            this.groupBox_measurements.Text = "Measurements";
            // 
            // label_phase
            // 
            this.label_phase.AutoSize = true;
            this.label_phase.Location = new System.Drawing.Point(17, 46);
            this.label_phase.Name = "label_phase";
            this.label_phase.Size = new System.Drawing.Size(49, 13);
            this.label_phase.TabIndex = 2;
            this.label_phase.Text = "Phase = ";
            // 
            // label_Freq
            // 
            this.label_Freq.AutoSize = true;
            this.label_Freq.Location = new System.Drawing.Point(17, 33);
            this.label_Freq.Name = "label_Freq";
            this.label_Freq.Size = new System.Drawing.Size(69, 13);
            this.label_Freq.TabIndex = 1;
            this.label_Freq.Text = "Frequency = ";
            // 
            // label_Vpp
            // 
            this.label_Vpp.AutoSize = true;
            this.label_Vpp.Location = new System.Drawing.Point(17, 20);
            this.label_Vpp.Name = "label_Vpp";
            this.label_Vpp.Size = new System.Drawing.Size(35, 13);
            this.label_Vpp.TabIndex = 0;
            this.label_Vpp.Text = "Vpp =";
            // 
            // trackBar_scale
            // 
            this.trackBar_scale.Location = new System.Drawing.Point(12, 235);
            this.trackBar_scale.Maximum = 8;
            this.trackBar_scale.Minimum = 1;
            this.trackBar_scale.Name = "trackBar_scale";
            this.trackBar_scale.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_scale.Size = new System.Drawing.Size(45, 104);
            this.trackBar_scale.TabIndex = 45;
            this.trackBar_scale.Value = 1;
            this.trackBar_scale.Scroll += new System.EventHandler(this.trackBar_scale_Scroll);
            // 
            // trackBar_offset
            // 
            this.trackBar_offset.Location = new System.Drawing.Point(215, 14);
            this.trackBar_offset.Maximum = 255;
            this.trackBar_offset.Minimum = -255;
            this.trackBar_offset.Name = "trackBar_offset";
            this.trackBar_offset.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_offset.Size = new System.Drawing.Size(45, 363);
            this.trackBar_offset.TabIndex = 46;
            this.trackBar_offset.Scroll += new System.EventHandler(this.trackBar_offset_Scroll);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 697);
            this.Controls.Add(this.trackBar_offset);
            this.Controls.Add(this.trackBar_scale);
            this.Controls.Add(this.groupBox_measurements);
            this.Controls.Add(this.cartesianChart_phase);
            this.Controls.Add(this.cartesianChart_DFT);
            this.Controls.Add(this.label_SamplingFreq);
            this.Controls.Add(this.radioButton_falling);
            this.Controls.Add(this.radioButton_rising);
            this.Controls.Add(this.label_trigger);
            this.Controls.Add(this.button_set_trigger);
            this.Controls.Add(this.trackBar_trigger);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_trigger)).EndInit();
            this.groupBox_measurements.ResumeLayout(false);
            this.groupBox_measurements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_offset)).EndInit();
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
        private System.Windows.Forms.TrackBar trackBar_trigger;
        private System.Windows.Forms.Button button_set_trigger;
        private System.Windows.Forms.Label label_trigger;
        private System.Windows.Forms.RadioButton radioButton_rising;
        private System.Windows.Forms.RadioButton radioButton_falling;
        private System.Windows.Forms.Label label_SamplingFreq;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private LiveCharts.WinForms.CartesianChart cartesianChart_DFT;
        private LiveCharts.WinForms.CartesianChart cartesianChart_phase;
        private System.Windows.Forms.GroupBox groupBox_measurements;
        private System.Windows.Forms.Label label_Vpp;
        private System.Windows.Forms.Label label_Freq;
        private System.Windows.Forms.Label label_phase;
        private System.Windows.Forms.TrackBar trackBar_scale;
        private System.Windows.Forms.TrackBar trackBar_offset;
    }
}

