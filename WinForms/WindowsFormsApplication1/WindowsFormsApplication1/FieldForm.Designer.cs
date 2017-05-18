namespace WindowsFormsApplication1
{
    partial class FieldForm
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
            System.Windows.Forms.Button EnButton;
            this.redButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RusButton = new System.Windows.Forms.Button();
            this.DeButton = new System.Windows.Forms.Button();
            this.RedTrackBar = new System.Windows.Forms.TrackBar();
            this.GreenTrackBar = new System.Windows.Forms.TrackBar();
            this.BlueTrackBar = new System.Windows.Forms.TrackBar();
            this.RedTextBox = new System.Windows.Forms.TextBox();
            this.GreenTextBox = new System.Windows.Forms.TextBox();
            this.BlueTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            EnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // EnButton
            // 
            EnButton.Location = new System.Drawing.Point(63, 71);
            EnButton.Name = "EnButton";
            EnButton.Size = new System.Drawing.Size(94, 62);
            EnButton.TabIndex = 22;
            EnButton.Tag = "En";
            EnButton.Text = "English";
            EnButton.UseVisualStyleBackColor = true;
            EnButton.Click += new System.EventHandler(this.button18_Click);
            // 
            // redButton
            // 
            this.redButton.Location = new System.Drawing.Point(186, 71);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(94, 62);
            this.redButton.TabIndex = 13;
            this.redButton.Tag = "0";
            this.redButton.Text = "красный";
            this.redButton.UseVisualStyleBackColor = true;
            this.redButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // blueButton
            // 
            this.blueButton.Location = new System.Drawing.Point(186, 243);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(94, 62);
            this.blueButton.TabIndex = 12;
            this.blueButton.Tag = "1";
            this.blueButton.Text = "синий";
            this.blueButton.UseVisualStyleBackColor = true;
            this.blueButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // greenButton
            // 
            this.greenButton.Location = new System.Drawing.Point(186, 161);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(94, 62);
            this.greenButton.TabIndex = 10;
            this.greenButton.Tag = "2";
            this.greenButton.Text = "зеленый";
            this.greenButton.UseVisualStyleBackColor = true;
            this.greenButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(357, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 234);
            this.panel1.TabIndex = 21;
            // 
            // RusButton
            // 
            this.RusButton.Location = new System.Drawing.Point(63, 161);
            this.RusButton.Name = "RusButton";
            this.RusButton.Size = new System.Drawing.Size(94, 62);
            this.RusButton.TabIndex = 23;
            this.RusButton.Tag = "Ru";
            this.RusButton.Text = "Русский";
            this.RusButton.UseVisualStyleBackColor = true;
            this.RusButton.Click += new System.EventHandler(this.button18_Click);
            // 
            // DeButton
            // 
            this.DeButton.Location = new System.Drawing.Point(63, 243);
            this.DeButton.Name = "DeButton";
            this.DeButton.Size = new System.Drawing.Size(94, 62);
            this.DeButton.TabIndex = 24;
            this.DeButton.Tag = "De";
            this.DeButton.Text = "Deutch";
            this.DeButton.UseVisualStyleBackColor = true;
            this.DeButton.Click += new System.EventHandler(this.button18_Click);
            // 
            // RedTrackBar
            // 
            this.RedTrackBar.Location = new System.Drawing.Point(63, 337);
            this.RedTrackBar.Maximum = 255;
            this.RedTrackBar.Name = "RedTrackBar";
            this.RedTrackBar.Size = new System.Drawing.Size(217, 45);
            this.RedTrackBar.TabIndex = 25;
            this.RedTrackBar.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // GreenTrackBar
            // 
            this.GreenTrackBar.Location = new System.Drawing.Point(63, 399);
            this.GreenTrackBar.Maximum = 255;
            this.GreenTrackBar.Name = "GreenTrackBar";
            this.GreenTrackBar.Size = new System.Drawing.Size(217, 45);
            this.GreenTrackBar.TabIndex = 26;
            this.GreenTrackBar.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // BlueTrackBar
            // 
            this.BlueTrackBar.Location = new System.Drawing.Point(63, 450);
            this.BlueTrackBar.Maximum = 255;
            this.BlueTrackBar.Name = "BlueTrackBar";
            this.BlueTrackBar.Size = new System.Drawing.Size(217, 45);
            this.BlueTrackBar.TabIndex = 27;
            this.BlueTrackBar.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // RedTextBox
            // 
            this.RedTextBox.Location = new System.Drawing.Point(326, 346);
            this.RedTextBox.Name = "RedTextBox";
            this.RedTextBox.Size = new System.Drawing.Size(100, 20);
            this.RedTextBox.TabIndex = 28;
            this.RedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RedTextBox_KeyUp);
            // 
            // GreenTextBox
            // 
            this.GreenTextBox.Location = new System.Drawing.Point(326, 399);
            this.GreenTextBox.Name = "GreenTextBox";
            this.GreenTextBox.Size = new System.Drawing.Size(100, 20);
            this.GreenTextBox.TabIndex = 29;
            this.GreenTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GreenTextBox_KeyUp);
            // 
            // BlueTextBox
            // 
            this.BlueTextBox.Location = new System.Drawing.Point(326, 450);
            this.BlueTextBox.Name = "BlueTextBox";
            this.BlueTextBox.Size = new System.Drawing.Size(100, 20);
            this.BlueTextBox.TabIndex = 30;
            this.BlueTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BlueTextBox_KeyUp_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(505, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 73);
            this.button1.TabIndex = 31;
            this.button1.Text = "Резюме";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button2.Location = new System.Drawing.Point(505, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 104);
            this.button2.TabIndex = 32;
            this.button2.Text = "Давай угадаю число, что ты загадал? (от 0 до 2000)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 570);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BlueTextBox);
            this.Controls.Add(this.GreenTextBox);
            this.Controls.Add(this.RedTextBox);
            this.Controls.Add(this.BlueTrackBar);
            this.Controls.Add(this.GreenTrackBar);
            this.Controls.Add(this.RedTrackBar);
            this.Controls.Add(this.DeButton);
            this.Controls.Add(this.RusButton);
            this.Controls.Add(EnButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.redButton);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.greenButton);
            this.Name = "FieldForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FieldForm_Load);
            this.Click += new System.EventHandler(this.button11_Click);
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RusButton;
        private System.Windows.Forms.Button DeButton;
        private System.Windows.Forms.TrackBar RedTrackBar;
        private System.Windows.Forms.TrackBar GreenTrackBar;
        private System.Windows.Forms.TrackBar BlueTrackBar;
        private System.Windows.Forms.TextBox RedTextBox;
        private System.Windows.Forms.TextBox GreenTextBox;
        private System.Windows.Forms.TextBox BlueTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

