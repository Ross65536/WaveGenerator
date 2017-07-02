namespace GUI
{
    partial class WFGUI
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelBottomButtons = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelDuration = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelDurationErrors = new System.Windows.Forms.Label();
            this.labelWaveImmut = new System.Windows.Forms.Label();
            this.comboOperator = new System.Windows.Forms.ComboBox();
            this.comboWaveType = new System.Windows.Forms.ComboBox();
            this.textBoxWaveFrequency = new System.Windows.Forms.TextBox();
            this.waveText = new System.Windows.Forms.Label();
            this.labelWaveErrors = new System.Windows.Forms.Label();
            this.buttonAddWave = new System.Windows.Forms.Button();
            this.textBoxWaveAlgebra = new System.Windows.Forms.TextBox();
            this.buttonDeleteWave = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.labelSampleRate = new System.Windows.Forms.Label();
            this.sampleRatesCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(614, 542);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(157, 58);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save ...";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // labelBottomButtons
            // 
            this.labelBottomButtons.AutoSize = true;
            this.labelBottomButtons.Location = new System.Drawing.Point(236, 618);
            this.labelBottomButtons.Name = "labelBottomButtons";
            this.labelBottomButtons.Size = new System.Drawing.Size(0, 20);
            this.labelBottomButtons.TabIndex = 3;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(218, 542);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(158, 58);
            this.buttonPlay.TabIndex = 4;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(423, 542);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(154, 58);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(32, 37);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(128, 20);
            this.labelDuration.TabIndex = 6;
            this.labelDuration.Text = "Target Duration: ";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(206, 33);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(187, 26);
            this.textBoxDuration.TabIndex = 7;
            this.textBoxDuration.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelDurationErrors
            // 
            this.labelDurationErrors.AutoSize = true;
            this.labelDurationErrors.Location = new System.Drawing.Point(425, 33);
            this.labelDurationErrors.Name = "labelDurationErrors";
            this.labelDurationErrors.Size = new System.Drawing.Size(0, 20);
            this.labelDurationErrors.TabIndex = 8;
            // 
            // labelWaveImmut
            // 
            this.labelWaveImmut.AutoSize = true;
            this.labelWaveImmut.Location = new System.Drawing.Point(32, 165);
            this.labelWaveImmut.Name = "labelWaveImmut";
            this.labelWaveImmut.Size = new System.Drawing.Size(49, 20);
            this.labelWaveImmut.TabIndex = 9;
            this.labelWaveImmut.Text = "Wave";
            // 
            // comboOperator
            // 
            this.comboOperator.FormattingEnabled = true;
            this.comboOperator.Location = new System.Drawing.Point(133, 162);
            this.comboOperator.Name = "comboOperator";
            this.comboOperator.Size = new System.Drawing.Size(116, 28);
            this.comboOperator.TabIndex = 13;
            this.comboOperator.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboWaveType
            // 
            this.comboWaveType.FormattingEnabled = true;
            this.comboWaveType.Location = new System.Drawing.Point(281, 162);
            this.comboWaveType.Name = "comboWaveType";
            this.comboWaveType.Size = new System.Drawing.Size(129, 28);
            this.comboWaveType.TabIndex = 15;
            this.comboWaveType.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // textBoxWaveFrequency
            // 
            this.textBoxWaveFrequency.Location = new System.Drawing.Point(429, 162);
            this.textBoxWaveFrequency.Name = "textBoxWaveFrequency";
            this.textBoxWaveFrequency.Size = new System.Drawing.Size(114, 26);
            this.textBoxWaveFrequency.TabIndex = 19;
            this.textBoxWaveFrequency.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // waveText
            // 
            this.waveText.AutoSize = true;
            this.waveText.Location = new System.Drawing.Point(43, 212);
            this.waveText.Name = "waveText";
            this.waveText.Size = new System.Drawing.Size(0, 20);
            this.waveText.TabIndex = 20;
            // 
            // labelWaveErrors
            // 
            this.labelWaveErrors.AutoSize = true;
            this.labelWaveErrors.Location = new System.Drawing.Point(419, 212);
            this.labelWaveErrors.Name = "labelWaveErrors";
            this.labelWaveErrors.Size = new System.Drawing.Size(0, 20);
            this.labelWaveErrors.TabIndex = 21;
            // 
            // buttonAddWave
            // 
            this.buttonAddWave.Location = new System.Drawing.Point(596, 159);
            this.buttonAddWave.Name = "buttonAddWave";
            this.buttonAddWave.Size = new System.Drawing.Size(126, 33);
            this.buttonAddWave.TabIndex = 22;
            this.buttonAddWave.Text = "Add Wave";
            this.buttonAddWave.UseVisualStyleBackColor = true;
            this.buttonAddWave.Click += new System.EventHandler(this.buttonAddWave_Click);
            // 
            // textBoxWaveAlgebra
            // 
            this.textBoxWaveAlgebra.Location = new System.Drawing.Point(82, 254);
            this.textBoxWaveAlgebra.Multiline = true;
            this.textBoxWaveAlgebra.Name = "textBoxWaveAlgebra";
            this.textBoxWaveAlgebra.ReadOnly = true;
            this.textBoxWaveAlgebra.Size = new System.Drawing.Size(570, 250);
            this.textBoxWaveAlgebra.TabIndex = 23;
            // 
            // buttonDeleteWave
            // 
            this.buttonDeleteWave.Location = new System.Drawing.Point(700, 260);
            this.buttonDeleteWave.Name = "buttonDeleteWave";
            this.buttonDeleteWave.Size = new System.Drawing.Size(128, 54);
            this.buttonDeleteWave.TabIndex = 24;
            this.buttonDeleteWave.Text = "Delete Wave";
            this.buttonDeleteWave.UseVisualStyleBackColor = true;
            this.buttonDeleteWave.Click += new System.EventHandler(this.buttonDeleteWave_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(700, 355);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(127, 56);
            this.Clear.TabIndex = 25;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // labelSampleRate
            // 
            this.labelSampleRate.AutoSize = true;
            this.labelSampleRate.Location = new System.Drawing.Point(45, 97);
            this.labelSampleRate.Name = "labelSampleRate";
            this.labelSampleRate.Size = new System.Drawing.Size(106, 20);
            this.labelSampleRate.TabIndex = 27;
            this.labelSampleRate.Text = "Sample Rate:";
            // 
            // sampleRatesCombo
            // 
            this.sampleRatesCombo.FormattingEnabled = true;
            this.sampleRatesCombo.Location = new System.Drawing.Point(210, 94);
            this.sampleRatesCombo.Name = "sampleRatesCombo";
            this.sampleRatesCombo.Size = new System.Drawing.Size(166, 28);
            this.sampleRatesCombo.TabIndex = 28;
            this.sampleRatesCombo.SelectedIndexChanged += new System.EventHandler(this.sampleRatesCombo_SelectedIndexChanged);
            // 
            // WFGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 668);
            this.Controls.Add(this.sampleRatesCombo);
            this.Controls.Add(this.labelSampleRate);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.buttonDeleteWave);
            this.Controls.Add(this.textBoxWaveAlgebra);
            this.Controls.Add(this.buttonAddWave);
            this.Controls.Add(this.labelWaveErrors);
            this.Controls.Add(this.waveText);
            this.Controls.Add(this.textBoxWaveFrequency);
            this.Controls.Add(this.comboWaveType);
            this.Controls.Add(this.comboOperator);
            this.Controls.Add(this.labelWaveImmut);
            this.Controls.Add(this.labelDurationErrors);
            this.Controls.Add(this.textBoxDuration);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.labelBottomButtons);
            this.Controls.Add(this.buttonSave);
            this.Name = "WFGUI";
            this.Text = "Audio Synth";
            this.Load += new System.EventHandler(this.WFGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelBottomButtons;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label labelDurationErrors;
        private System.Windows.Forms.Label labelWaveImmut;
        private System.Windows.Forms.ComboBox comboOperator;
        private System.Windows.Forms.ComboBox comboWaveType;
        private System.Windows.Forms.TextBox textBoxWaveFrequency;
        private System.Windows.Forms.Label waveText;
        private System.Windows.Forms.Label labelWaveErrors;
        private System.Windows.Forms.Button buttonAddWave;
        private System.Windows.Forms.TextBox textBoxWaveAlgebra;
        private System.Windows.Forms.Button buttonDeleteWave;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label labelSampleRate;
        private System.Windows.Forms.ComboBox sampleRatesCombo;
    }
}