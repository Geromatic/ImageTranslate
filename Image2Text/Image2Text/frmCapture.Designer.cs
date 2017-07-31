namespace ImageToText
{
    partial class frmCapture
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
            this.SuspendLayout();
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 234);
            this.ControlBox = false;
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCapture_Load);
            this.DoubleClick += new System.EventHandler(this.frmCapture_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmCapture_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmCapture_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmCapture_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}