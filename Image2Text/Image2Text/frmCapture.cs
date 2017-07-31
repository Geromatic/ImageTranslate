// Copyright (c) 2017 Scott Bishel
// License: Code Project Open License
// http://www.codeproject.com/info/cpol10.aspx

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageToText
{
    /// <summary>
    /// A form that allows user to capture a custom size image of their screen
    /// </summary>
    public partial class frmCapture : Form
    {
        #region Fields
        Point _startPos;
        Bitmap img;

        Bitmap img2;
        private bool _regionDrawn = false;

        private Rectangle _boundsRect;

        #endregion

        #region Properties
        public bool regionDrawn
        {
            get { return _regionDrawn; }
            set { _regionDrawn = value; }
        }

        public Rectangle boundsRect
        {
            get { return _boundsRect; }
            set { _boundsRect = value; }
        }
        #endregion

        #region Form Methods

        private void frmCapture_DoubleClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmCapture_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (regionDrawn)
            {
                img = (Bitmap)img2.Clone();
                this.BackgroundImage = img;
                this.Invalidate();
                Application.DoEvents();
            }
            _startPos = e.Location;
        }

        /// <summary>
        /// Creates a user specific box
        /// </summary>
        private void frmCapture_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Point startPos = _startPos;
            if (!startPos.IsEmpty)
            {
                img = (Bitmap)img2.Clone();
                Graphics gr = Graphics.FromImage(img);
                SolidBrush solidColorBrush = new SolidBrush(Color.Gray);
                Pen myPen = new Pen(solidColorBrush);
                myPen.Width = 1;
                myPen.DashStyle = DashStyle.Dash;
                if (e.X > startPos.X & e.Y > startPos.Y)
                {
                    gr.DrawRectangle(myPen, new Rectangle(startPos.X, startPos.Y, e.X - startPos.X, e.Y - startPos.Y));
                    boundsRect = new Rectangle(startPos.X, startPos.Y, e.X - startPos.X, e.Y - startPos.Y);
                }
                else if (e.X < startPos.X & e.Y > startPos.Y)
                {
                    gr.DrawRectangle(myPen, new Rectangle(e.X, startPos.Y, startPos.X - e.X, e.Y - startPos.Y));
                    boundsRect = new Rectangle(e.X, startPos.Y, startPos.X - e.X, e.Y - startPos.Y);
                }
                else if (e.X > startPos.X & e.Y < startPos.Y)
                {
                    gr.DrawRectangle(myPen, new Rectangle(startPos.X, e.Y, e.X - startPos.X, startPos.Y - e.Y));
                    boundsRect = new Rectangle(startPos.X, e.Y, e.X - startPos.X, startPos.Y - e.Y);
                }
                else if (e.X < startPos.X & e.Y < startPos.Y)
                {
                    gr.DrawRectangle(myPen, new Rectangle(e.X, e.Y, startPos.X - e.X, startPos.Y - e.Y));
                    boundsRect = new Rectangle(e.X, e.Y, startPos.X - e.X, startPos.Y - e.Y);
                }

                this.BackgroundImage = img;
                this.Invalidate();
                Application.DoEvents();

                regionDrawn = true;

            }
        }

        private void frmCapture_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _startPos = Point.Empty;
        }

        private void frmCapture_Load(System.Object sender, System.EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.Bounds;
            img2 = new Bitmap(this.Bounds.Width, this.Bounds.Height);
            Graphics gr = Graphics.FromImage(img2);
            gr.CopyFromScreen(new Point(0, 0), new Point(0, 0), this.Size);
            this.BackgroundImage = img2;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        #endregion

        public frmCapture()
        {
            InitializeComponent();
        }

    }
}
