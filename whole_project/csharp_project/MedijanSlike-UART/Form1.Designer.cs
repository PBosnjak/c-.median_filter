namespace MedijanSlike_UART
{
    partial class Form1
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
            this.btn_browse = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_showoriginal = new System.Windows.Forms.Button();
            this.btn_greyscale = new System.Windows.Forms.Button();
            this.btn_showgreyscale = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_showaftermedian = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btn_disc = new System.Windows.Forms.Button();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(12, 12);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(97, 26);
            this.btn_browse.TabIndex = 1;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(12, 173);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(97, 26);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_showoriginal
            // 
            this.btn_showoriginal.Enabled = false;
            this.btn_showoriginal.Location = new System.Drawing.Point(12, 44);
            this.btn_showoriginal.Name = "btn_showoriginal";
            this.btn_showoriginal.Size = new System.Drawing.Size(97, 26);
            this.btn_showoriginal.TabIndex = 3;
            this.btn_showoriginal.Text = "Add noise";
            this.btn_showoriginal.UseVisualStyleBackColor = true;
            this.btn_showoriginal.Click += new System.EventHandler(this.btn_showoriginal_Click);
            // 
            // btn_greyscale
            // 
            this.btn_greyscale.Enabled = false;
            this.btn_greyscale.Location = new System.Drawing.Point(144, 44);
            this.btn_greyscale.Name = "btn_greyscale";
            this.btn_greyscale.Size = new System.Drawing.Size(97, 26);
            this.btn_greyscale.TabIndex = 4;
            this.btn_greyscale.Text = "Greyscale";
            this.btn_greyscale.UseVisualStyleBackColor = true;
            this.btn_greyscale.Click += new System.EventHandler(this.btn_greyscale_Click);
            // 
            // btn_showgreyscale
            // 
            this.btn_showgreyscale.Enabled = false;
            this.btn_showgreyscale.Location = new System.Drawing.Point(268, 44);
            this.btn_showgreyscale.Name = "btn_showgreyscale";
            this.btn_showgreyscale.Size = new System.Drawing.Size(97, 26);
            this.btn_showgreyscale.TabIndex = 5;
            this.btn_showgreyscale.Text = "Show greyscale";
            this.btn_showgreyscale.UseVisualStyleBackColor = true;
            this.btn_showgreyscale.Click += new System.EventHandler(this.btn_showgreyscale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baud rate:";
            // 
            // btn_showaftermedian
            // 
            this.btn_showaftermedian.Enabled = false;
            this.btn_showaftermedian.Location = new System.Drawing.Point(254, 168);
            this.btn_showaftermedian.Name = "btn_showaftermedian";
            this.btn_showaftermedian.Size = new System.Drawing.Size(111, 37);
            this.btn_showaftermedian.TabIndex = 8;
            this.btn_showaftermedian.Text = "Show after median";
            this.btn_showaftermedian.UseVisualStyleBackColor = true;
            this.btn_showaftermedian.Click += new System.EventHandler(this.btn_showaftermedian_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 211);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(353, 169);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(214, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(47, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(244, 103);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btn_disc
            // 
            this.btn_disc.Enabled = false;
            this.btn_disc.Location = new System.Drawing.Point(125, 173);
            this.btn_disc.Name = "btn_disc";
            this.btn_disc.Size = new System.Drawing.Size(101, 25);
            this.btn_disc.TabIndex = 14;
            this.btn_disc.Text = "Disconnect";
            this.btn_disc.UseVisualStyleBackColor = true;
            this.btn_disc.Click += new System.EventHandler(this.btn_disc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 404);
            this.Controls.Add(this.btn_disc);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_showaftermedian);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_showgreyscale);
            this.Controls.Add(this.btn_greyscale);
            this.Controls.Add(this.btn_showoriginal);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.btn_browse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_showoriginal;
        private System.Windows.Forms.Button btn_greyscale;
        private System.Windows.Forms.Button btn_showgreyscale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_showaftermedian;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btn_disc;
        private System.IO.Ports.SerialPort serialPort2;
    }
}

