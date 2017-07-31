namespace ImageToText
{
    partial class frmTranslate
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
            this.rchResult = new System.Windows.Forms.RichTextBox();
            this.ofdImageSelect = new System.Windows.Forms.OpenFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cboSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.chkScreen = new System.Windows.Forms.CheckBox();
            this.chkTranslate = new System.Windows.Forms.CheckBox();
            this.cboTargt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTranslateTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClipboard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rchResult
            // 
            this.rchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rchResult.Location = new System.Drawing.Point(12, 99);
            this.rchResult.Name = "rchResult";
            this.rchResult.Size = new System.Drawing.Size(372, 150);
            this.rchResult.TabIndex = 0;
            this.rchResult.Text = "";
            // 
            // ofdImageSelect
            // 
            this.ofdImageSelect.FileName = "openFileDialog1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cboSource
            // 
            this.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSource.FormattingEnabled = true;
            this.cboSource.Location = new System.Drawing.Point(161, 28);
            this.cboSource.Name = "cboSource";
            this.cboSource.Size = new System.Drawing.Size(121, 21);
            this.cboSource.TabIndex = 2;
            this.cboSource.SelectedIndexChanged += new System.EventHandler(this.cboSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Language:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mean Confidence:";
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new System.Drawing.Point(114, 80);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(27, 13);
            this.lblMean.TabIndex = 5;
            this.lblMean.Text = "N/A";
            // 
            // chkScreen
            // 
            this.chkScreen.AutoSize = true;
            this.chkScreen.Location = new System.Drawing.Point(12, 41);
            this.chkScreen.Name = "chkScreen";
            this.chkScreen.Size = new System.Drawing.Size(96, 17);
            this.chkScreen.TabIndex = 6;
            this.chkScreen.Text = "From Clipboard";
            this.chkScreen.UseVisualStyleBackColor = true;
            // 
            // chkTranslate
            // 
            this.chkTranslate.AutoSize = true;
            this.chkTranslate.Enabled = false;
            this.chkTranslate.Location = new System.Drawing.Point(12, 60);
            this.chkTranslate.Name = "chkTranslate";
            this.chkTranslate.Size = new System.Drawing.Size(70, 17);
            this.chkTranslate.TabIndex = 7;
            this.chkTranslate.Text = "Translate";
            this.chkTranslate.UseVisualStyleBackColor = true;
            this.chkTranslate.CheckedChanged += new System.EventHandler(this.chkTranslate_CheckedChanged);
            // 
            // cboTargt
            // 
            this.cboTargt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargt.Enabled = false;
            this.cboTargt.FormattingEnabled = true;
            this.cboTargt.Location = new System.Drawing.Point(161, 55);
            this.cboTargt.Name = "cboTargt";
            this.cboTargt.Size = new System.Drawing.Size(121, 21);
            this.cboTargt.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Source:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Target:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Translate Time:";
            // 
            // lblTranslateTime
            // 
            this.lblTranslateTime.AutoSize = true;
            this.lblTranslateTime.Location = new System.Drawing.Point(290, 35);
            this.lblTranslateTime.Name = "lblTranslateTime";
            this.lblTranslateTime.Size = new System.Drawing.Size(27, 13);
            this.lblTranslateTime.TabIndex = 12;
            this.lblTranslateTime.Text = "N/A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Clipboard(Image):";
            // 
            // lblClipboard
            // 
            this.lblClipboard.AutoSize = true;
            this.lblClipboard.Location = new System.Drawing.Point(290, 80);
            this.lblClipboard.Name = "lblClipboard";
            this.lblClipboard.Size = new System.Drawing.Size(36, 13);
            this.lblClipboard.TabIndex = 14;
            this.lblClipboard.Text = "Empty";
            // 
            // frmTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 261);
            this.Controls.Add(this.lblClipboard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTranslateTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTargt);
            this.Controls.Add(this.chkTranslate);
            this.Controls.Add(this.chkScreen);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSource);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rchResult);
            this.Name = "frmTranslate";
            this.Text = "Image Translate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTranslate_FormClosing);
            this.Load += new System.EventHandler(this.frmTranslate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchResult;
        private System.Windows.Forms.OpenFileDialog ofdImageSelect;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ComboBox cboSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.CheckBox chkScreen;
        private System.Windows.Forms.CheckBox chkTranslate;
        private System.Windows.Forms.ComboBox cboTargt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTranslateTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblClipboard;
    }
}

