#region Copyright Syncfusion Inc. 2001 - 2007
//
//  Copyright Syncfusion Inc. 2001 - 2007. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Syncfusion.Pdf;
using Syncfusion.Windows.Forms;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Licensing;

namespace EssentialPDFSamples
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : MetroForm
    {
        # region Private Members
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private int i;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        # endregion

        # region Constructor
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.MinimizeBox = true;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
           //
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(285, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 84);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
                " that Adobe Reader or its equivalent is required to view the resultant document." +
                "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(374, 89);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            //this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 200);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
             this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drawing Shapes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        # endregion

        # region Events
        private void button1_Click(object sender, System.EventArgs e)
        {
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            // Add a new page to the document.
            PdfPage page = document.Pages.Add();

            // Obtain PdfGraphics object.
            PdfGraphics g = page.Graphics;

            // Set font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);

            PdfBrush textBrush = PdfBrushes.DarkBlue;

            #region Polygon
            PdfPen pen = new PdfPen(PdfBrushes.Brown, 10f);
            PointF p1 = new PointF(05, 10);
            PointF p2 = new PointF(05, 10);
            PointF p3 = new PointF(60, 70);
            PointF p4 = new PointF(40, 70);

            PointF[] points = { p1, p2, p3, p4 };

            int pointNum = 16;
            points = new PointF[pointNum];
            double f = 360.0 / pointNum * Math.PI / 180.0;
            const double r = 100;
            PointF center = new PointF(140, 140);

            for (i = 0; i < pointNum; ++i)
            {
                PointF p = new PointF();
                double theta = i * f;

                p.Y = (float)(Math.Sin(theta) * r + center.Y);
                p.X = (float)(Math.Cos(theta) * r + center.X);

                points[i] = p;
            }

            PdfBrush sGreenBrush = PdfBrushes.Green;
            g.DrawString("Polygon", font, textBrush, new PointF(50, 0));

            // Draw Polygon.
            g.DrawPolygon(pen, sGreenBrush, points);

            #endregion

            #region  Pie
            RectangleF rect = new RectangleF(20, 280, 200, 200);

            g.DrawString("Pie shape", font, textBrush, new PointF(50, 250));

            // Draw Pie
            g.DrawPie(pen, sGreenBrush, rect, 180, 60);
            g.DrawPie(pen, sGreenBrush, rect, 300, 60);
            g.DrawPie(pen, sGreenBrush, rect, 60, 60);
            #endregion

            #region Arc

            g.DrawString("Arcs", font, textBrush, new PointF(330, 0));
            pen.LineCap = PdfLineCap.Round;
            rect = new RectangleF(310, 40, 200, 200);
            g.DrawArc(pen, rect, 0, 90);

            pen.Color = Color.DarkGreen;
            rect.X -= 10;
            g.DrawArc(pen, rect, 90, 90);

            pen.Color = Color.Brown;
            rect.Y -= 10;
            g.DrawArc(pen, rect, 180, 90);

            pen.Color = Color.DarkGreen;
            rect.X += 10;
            g.DrawArc(pen, rect, 270, 90);

            #endregion

            #region Rectangle
            rect = new RectangleF(310, 280, 200, 100);
            pen.Color = Color.Brown;
            g.DrawString("Simple Rectangle", font, textBrush, new PointF(310, 255));

            // Draw rectangle using PdfPen and PdfBrush.
            g.DrawRectangle(pen, sGreenBrush, rect);
            #endregion

            #region Ellipse

            // Draw a simple ellipse.
            rect = new RectangleF(80, 520, 100, 200);
            PdfLinearGradientBrush lgBrush = new PdfLinearGradientBrush(rect, Color.DarkGreen, Color.White, 90);
            g.DrawString("Ellipse with Gradient", font, textBrush, new PointF(50, 490));
            g.DrawEllipse(pen, lgBrush, rect);

            // Ellipse with pagination.
            rect = new RectangleF(270, 400, 160, 1000);
            g.DrawString("Shape with pagination", font, textBrush, new PointF(300, 390));
            
            // Create layout format for pagination.
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Break = PdfLayoutBreakType.FitPage;
            format.Layout = PdfLayoutType.Paginate;

            PdfEllipse ellipse = new PdfEllipse(rect);
            ellipse.Brush = PdfBrushes.Brown;
            ellipse.Draw(page, 20, 20, format);

            ellipse.Brush = PdfBrushes.DarkGreen;
            ellipse.Draw(page, 40, 40, format);

            #endregion

            #region Transparency
            // Draw transparent rectangles.
            page = document.Pages[1];
            g = page.Graphics;
            g.DrawString("Transparent Rectangles", font, textBrush, new PointF(50, 80));
            
            PdfBrush gBrush = PdfBrushes.DarkGreen;
            pen = new PdfPen(Color.Black);
            rect = new RectangleF(10, 150, 100, 100);
            g.DrawRectangle(pen, gBrush, rect);

            gBrush = new PdfSolidBrush(Color.Brown);
            rect.X += 20;
            rect.Y += 20;
            pen = new PdfPen(Color.Brown);
            g.SetTransparency(0.7f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            gBrush = new PdfLinearGradientBrush(rect, Color.DarkGreen, Color.Brown, PdfLinearGradientMode.BackwardDiagonal);
            g.SetTransparency(0.5f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            pen = new PdfPen(Color.Blue);
            gBrush = new PdfSolidBrush(Color.Gray);
            g.SetTransparency(0.25f);
            g.DrawRectangle(pen, gBrush, rect);

            rect.X += 20;
            rect.Y += 20;
            pen = new PdfPen(Color.Black);
            gBrush = new PdfSolidBrush(Color.Green);
            g.SetTransparency(0.1f);
            g.DrawRectangle(pen, sGreenBrush, rect);

            #endregion

            #region Rectangle with Color space

            // Add a new page to the document.
            page = document.Pages.Add();
            g = page.Graphics;

            document.ColorSpace = (PdfColorSpace)i;

            // Solid Brush
            gBrush = new PdfSolidBrush(Color.Red);
            PointF location = new PointF(10, 50);
            DrawRectangles(location, g, font, gBrush, pen, document);

            // Linear Gradient
            location = new PointF(180, 50);
            PointF point2 = location;
            point2.X += 100;
            gBrush = new PdfLinearGradientBrush(location, point2, Color.Blue, Color.Red);
            DrawRectangles(location, g, font, gBrush, pen, document);

            // Radial Gradient
            location = new PointF(360, 50);
            point2 = location;
            point2.Y += 250;
            point2.X = 150;
            gBrush = new PdfRadialGradientBrush(point2, 210, point2, 400, Color.Blue, Color.Red);
            (gBrush as PdfRadialGradientBrush).Extend = PdfExtend.End;
            DrawRectangles(location, g, font, gBrush, pen, document);

            g.DrawString("Rectangle with color spaces", font, textBrush, new PointF(150, 0));
            #endregion

            // Save and close the document.
            document.Save("Sample.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                 == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                System.Diagnostics.Process.Start("Sample.pdf");
#endif
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }
        }

        # endregion

        # region Helpher Methods
        /// <summary>
        /// Draw rectangle in the document.
        /// </summary>
        private void DrawRectangles(PointF startPoint, PdfGraphics g, PdfFont font, PdfBrush brush, PdfPen pen, PdfDocument doc)
        {
            PdfBrush textBrush = new PdfSolidBrush(Color.Black);
            RectangleF rect = new RectangleF(startPoint.X, startPoint.Y, 100, 100);

            g.Save();

            g.DrawString("Default: " + doc.ColorSpace.ToString(), font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            doc.ColorSpace = PdfColorSpace.RGB;

            g.DrawString("RGB color space.", font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            doc.ColorSpace = PdfColorSpace.CMYK;

            g.DrawString("CMYK color space.", font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            doc.ColorSpace = PdfColorSpace.GrayScale;

            g.DrawString("Gray scale color space.", font, textBrush, rect.Location);
            rect.Y += 20;
            g.DrawRectangle(pen, brush, rect);
            rect.Y += 106;

            g.Restore();
        }
		      /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }
        #endregion
    }
	/// <summary>
    /// Represents a class that is used to find the licensing file for Syncfusion controls.
    /// </summary>
    public class DemoCommon
    {

        /// <summary>
        /// Finds the license key from the Common folder.
        /// </summary>
        /// <returns>Returns the license key.</returns>
        public static string FindLicenseKey()
        {

            string licenseKeyFile = @"Common\\SyncfusionLicense.txt";

            for (int n = 0; n < 20; n++)
            {
                if (!System.IO.File.Exists(licenseKeyFile))
                {
                    licenseKeyFile = @"..\" + licenseKeyFile;
                    continue;
                }
                return System.IO.File.ReadAllText(licenseKeyFile);
            }
            return string.Empty;
        }
    }
}
