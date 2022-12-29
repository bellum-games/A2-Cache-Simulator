namespace A2
{
    partial class A2
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
            this.lbFR = new System.Windows.Forms.Label();
            this.lbIBS = new System.Windows.Forms.Label();
            this.lbIRmax = new System.Windows.Forms.Label();
            this.lbN_PEN = new System.Windows.Forms.Label();
            this.comboFR = new System.Windows.Forms.ComboBox();
            this.comboIBS = new System.Windows.Forms.ComboBox();
            this.comboIRmax = new System.Windows.Forms.ComboBox();
            this.lbSIZE_IC = new System.Windows.Forms.Label();
            this.comboSIZE_IC = new System.Windows.Forms.ComboBox();
            this.comboSIZE_DC = new System.Windows.Forms.ComboBox();
            this.lbSIZE_DC = new System.Windows.Forms.Label();
            this.btnSTART = new System.Windows.Forms.Button();
            this.comboN_PEN = new System.Windows.Forms.ComboBox();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.lbNR_REG = new System.Windows.Forms.Label();
            this.comboNR_REG = new System.Windows.Forms.ComboBox();
            this.lbNR_PORT = new System.Windows.Forms.Label();
            this.comboNR_PORT = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbFR
            // 
            this.lbFR.AutoSize = true;
            this.lbFR.Location = new System.Drawing.Point(638, 186);
            this.lbFR.Name = "lbFR";
            this.lbFR.Size = new System.Drawing.Size(23, 15);
            this.lbFR.TabIndex = 0;
            this.lbFR.Text = "FR:";
            // 
            // lbIBS
            // 
            this.lbIBS.AutoSize = true;
            this.lbIBS.Location = new System.Drawing.Point(635, 157);
            this.lbIBS.Name = "lbIBS";
            this.lbIBS.Size = new System.Drawing.Size(26, 15);
            this.lbIBS.TabIndex = 1;
            this.lbIBS.Text = "IBS:";
            // 
            // lbIRmax
            // 
            this.lbIRmax.AutoSize = true;
            this.lbIRmax.Location = new System.Drawing.Point(618, 128);
            this.lbIRmax.Name = "lbIRmax";
            this.lbIRmax.Size = new System.Drawing.Size(43, 15);
            this.lbIRmax.TabIndex = 2;
            this.lbIRmax.Text = "IRmax:";
            // 
            // lbN_PEN
            // 
            this.lbN_PEN.AutoSize = true;
            this.lbN_PEN.Location = new System.Drawing.Point(533, 215);
            this.lbN_PEN.Name = "lbN_PEN";
            this.lbN_PEN.Size = new System.Drawing.Size(128, 15);
            this.lbN_PEN.TabIndex = 3;
            this.lbN_PEN.Text = "N_PEN (miss in cache):";
            // 
            // comboFR
            // 
            this.comboFR.FormattingEnabled = true;
            this.comboFR.Items.AddRange(new object[] {
            "4",
            "8",
            "16"});
            this.comboFR.Location = new System.Drawing.Point(667, 183);
            this.comboFR.Name = "comboFR";
            this.comboFR.Size = new System.Drawing.Size(121, 23);
            this.comboFR.TabIndex = 6;
            this.comboFR.Text = "comboFR";
            // 
            // comboIBS
            // 
            this.comboIBS.FormattingEnabled = true;
            this.comboIBS.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32"});
            this.comboIBS.Location = new System.Drawing.Point(667, 154);
            this.comboIBS.Name = "comboIBS";
            this.comboIBS.Size = new System.Drawing.Size(121, 23);
            this.comboIBS.TabIndex = 7;
            this.comboIBS.Text = "comboIBS";
            // 
            // comboIRmax
            // 
            this.comboIRmax.FormattingEnabled = true;
            this.comboIRmax.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16"});
            this.comboIRmax.Location = new System.Drawing.Point(667, 125);
            this.comboIRmax.Name = "comboIRmax";
            this.comboIRmax.Size = new System.Drawing.Size(121, 23);
            this.comboIRmax.TabIndex = 8;
            this.comboIRmax.Text = "comboIRmax";
            // 
            // lbSIZE_IC
            // 
            this.lbSIZE_IC.AutoSize = true;
            this.lbSIZE_IC.Location = new System.Drawing.Point(613, 70);
            this.lbSIZE_IC.Name = "lbSIZE_IC";
            this.lbSIZE_IC.Size = new System.Drawing.Size(48, 15);
            this.lbSIZE_IC.TabIndex = 16;
            this.lbSIZE_IC.Text = "SIZE_IC:";
            // 
            // comboSIZE_IC
            // 
            this.comboSIZE_IC.FormattingEnabled = true;
            this.comboSIZE_IC.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192"});
            this.comboSIZE_IC.Location = new System.Drawing.Point(667, 67);
            this.comboSIZE_IC.Name = "comboSIZE_IC";
            this.comboSIZE_IC.Size = new System.Drawing.Size(121, 23);
            this.comboSIZE_IC.TabIndex = 17;
            this.comboSIZE_IC.Text = "comboSIZE_IC";
            // 
            // comboSIZE_DC
            // 
            this.comboSIZE_DC.FormattingEnabled = true;
            this.comboSIZE_DC.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192"});
            this.comboSIZE_DC.Location = new System.Drawing.Point(667, 96);
            this.comboSIZE_DC.Name = "comboSIZE_DC";
            this.comboSIZE_DC.Size = new System.Drawing.Size(121, 23);
            this.comboSIZE_DC.TabIndex = 18;
            this.comboSIZE_DC.Text = "comboSIZE_DC";
            // 
            // lbSIZE_DC
            // 
            this.lbSIZE_DC.AutoSize = true;
            this.lbSIZE_DC.Location = new System.Drawing.Point(608, 99);
            this.lbSIZE_DC.Name = "lbSIZE_DC";
            this.lbSIZE_DC.Size = new System.Drawing.Size(53, 15);
            this.lbSIZE_DC.TabIndex = 19;
            this.lbSIZE_DC.Text = "SIZE_DC:";
            // 
            // btnSTART
            // 
            this.btnSTART.Location = new System.Drawing.Point(713, 12);
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Size = new System.Drawing.Size(75, 23);
            this.btnSTART.TabIndex = 20;
            this.btnSTART.Text = "START";
            this.btnSTART.UseVisualStyleBackColor = true;
            this.btnSTART.Click += new System.EventHandler(this.btnSTART_Click);
            // 
            // comboN_PEN
            // 
            this.comboN_PEN.FormattingEnabled = true;
            this.comboN_PEN.Items.AddRange(new object[] {
            "1",
            "10",
            "15",
            "20"});
            this.comboN_PEN.Location = new System.Drawing.Point(667, 212);
            this.comboN_PEN.Name = "comboN_PEN";
            this.comboN_PEN.Size = new System.Drawing.Size(121, 23);
            this.comboN_PEN.TabIndex = 21;
            this.comboN_PEN.Text = "comboN_PEN";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Location = new System.Drawing.Point(12, 13);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxConsole.Size = new System.Drawing.Size(515, 528);
            this.textBoxConsole.TabIndex = 22;
            this.textBoxConsole.Text = "textBoxConsole";
            // 
            // lbNR_REG
            // 
            this.lbNR_REG.AutoSize = true;
            this.lbNR_REG.Location = new System.Drawing.Point(609, 244);
            this.lbNR_REG.Name = "lbNR_REG";
            this.lbNR_REG.Size = new System.Drawing.Size(52, 15);
            this.lbNR_REG.TabIndex = 23;
            this.lbNR_REG.Text = "NR_REG:";
            // 
            // comboNR_REG
            // 
            this.comboNR_REG.FormattingEnabled = true;
            this.comboNR_REG.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.comboNR_REG.Location = new System.Drawing.Point(667, 241);
            this.comboNR_REG.Name = "comboNR_REG";
            this.comboNR_REG.Size = new System.Drawing.Size(121, 23);
            this.comboNR_REG.TabIndex = 24;
            this.comboNR_REG.Text = "comboNR_REG";
            // 
            // lbNR_PORT
            // 
            this.lbNR_PORT.AutoSize = true;
            this.lbNR_PORT.Location = new System.Drawing.Point(602, 273);
            this.lbNR_PORT.Name = "lbNR_PORT";
            this.lbNR_PORT.Size = new System.Drawing.Size(59, 15);
            this.lbNR_PORT.TabIndex = 25;
            this.lbNR_PORT.Text = "NR_PORT:";
            // 
            // comboNR_PORT
            // 
            this.comboNR_PORT.FormattingEnabled = true;
            this.comboNR_PORT.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboNR_PORT.Location = new System.Drawing.Point(667, 270);
            this.comboNR_PORT.Name = "comboNR_PORT";
            this.comboNR_PORT.Size = new System.Drawing.Size(121, 23);
            this.comboNR_PORT.TabIndex = 26;
            this.comboNR_PORT.Text = "comboNR_PORT";
            // 
            // A2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 553);
            this.Controls.Add(this.comboN_PEN);
            this.Controls.Add(this.lbN_PEN);
            this.Controls.Add(this.comboNR_PORT);
            this.Controls.Add(this.lbNR_PORT);
            this.Controls.Add(this.comboNR_REG);
            this.Controls.Add(this.lbNR_REG);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.btnSTART);
            this.Controls.Add(this.lbSIZE_DC);
            this.Controls.Add(this.comboSIZE_DC);
            this.Controls.Add(this.comboSIZE_IC);
            this.Controls.Add(this.lbSIZE_IC);
            this.Controls.Add(this.comboIRmax);
            this.Controls.Add(this.comboIBS);
            this.Controls.Add(this.comboFR);
            this.Controls.Add(this.lbIRmax);
            this.Controls.Add(this.lbIBS);
            this.Controls.Add(this.lbFR);
            this.Name = "A2";
            this.Text = " A2 Cache Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbFR;
        private Label lbIBS;
        private Label lbIRmax;
        private Label lbN_PEN;
        private ComboBox comboFR;
        private ComboBox comboIBS;
        private ComboBox comboIRmax;
        private Label lbSIZE_IC;
        private ComboBox comboSIZE_IC;
        private ComboBox comboSIZE_DC;
        private Label lbSIZE_DC;
        private Button btnSTART;
        private ComboBox comboN_PEN;
        private TextBox textBoxConsole;
        private Label lbNR_REG;
        private ComboBox comboNR_REG;
        private Label lbNR_PORT;
        private ComboBox comboNR_PORT;
    }
}