#region Copyright Syncfusion Inc. 2001 - 2008
//
//  Copyright Syncfusion Inc. 2001 - 2008. All rights reserved.
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
        private PdfPage page;
        PdfSolidBrush brush;
        PdfStandardFont font;
        PdfMetafileLayoutFormat format;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        # region Constructor
        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.MinimizeBox = true;
            Application.EnableVisualStyles();
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
            //this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(286, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "PDF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Click the button to view an PDF document generated by Essential PDF.  Please note" +
                " that Adobe Reader or its equivalent is required to view the resultant document." +
                "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = System.Drawing.Image.FromFile(GetFullTemplatePath("pdf_header.png", true));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 89);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            //  this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 196);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Column HTML Text";
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
            Application.Run(new Form1());
        }
        # endregion

        # region Events
        private void button1_Click(object sender, System.EventArgs e)
        {
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            // Set size for the page.
            document.PageSettings.Size = new SizeF(870, 732);

            // Add a new page to the document.
            page = document.Pages.Add();

            // Create brush.
            brush = new PdfSolidBrush(Color.Black);

            //Create font.
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 8.5f);

            // Adding Header to the document
            this.AddHeader(document, "Syncfusion Essential PDF", "MultiColumnText Demo");

            // Adding Footer to the document
            this.AddFooter(document, "@Copyright 2015");

            // Formatting Layout
            format = new PdfMetafileLayoutFormat();
            format.Layout = PdfLayoutType.OnePage;

            float width = 250;
            float height = page.GetClientSize().Height;

            #region htmlText
            string longtext = "<font color='#FF0000F'><b>PDF</b></font> stands for <i>\"Portable Document Format\"</i>." +
                " The key word is <i>portable</i>, intended to combine the qualities of <u>authenticity," +
                " reliability and ease of use together into a single packaged concept</u>.<br/><br/>" +
                "Adobe Systems invented PDF technology in the early 1990s to smooth the " +
                "process of moving text and graphics from publishers to printing-presses." +
                " <font color='#FF0000F'><b>PDF</b></font> turned out to be the very essence of paper, brought to life in a computer." +
                " In creating PDF, Adobe had almost unwittingly invented nothing less than a " +
                "bridge between the paper and computer worlds. <br/><br/>To be truly portable, an authentic electronic " +
                "document would have to appear exactly the same way on any computer at any time," +
                " at no cost to the user. It will deliver the exact same results in print or on-screen " +
                "with near-total reliability. ";
            #endregion

            //// Drawing htmlString
            DrawHTML(longtext, new RectangleF(0, 15, width, height));

            // Drawing Image
            PdfBitmap image = new PdfBitmap(Image.FromFile(GetFullTemplatePath("PDFImage.png", true)));
            page.Graphics.DrawImage(image, new RectangleF(50, 200, 130, 140));

            #region HtmlText
            longtext = "<font color='#FF0000F'><b>PDF</b></font> is used for representing two-dimensional documents in " +
            "a manner independent of the application software, hardware, and operating system.<sup>[1]</sup>" +
            "<br/><br/>Each PDF file encapsulates a complete description of a fixed-layout 2-D document " +
            "(and, with Acrobat 3-D, embedded 3-D documents) that includes the text, fonts, images, " +
            "and 2-D vector graphics which comprise the documents." +
            " <br/><br/><b>PDF</b> is an open standard that was officially published on July 1, 2008 by the ISO as" +
            "ISO 32000-1:2008.<sub>[2]</sub><br/><br/>" +
            "The PDF combines the technologies such as A sub-set of the PostScript page description programming " +
            "language, a font-embedding/replacement system to allow fonts to travel with the documents and a " +
            "structured storage system to bundle these elements and any associated content into a single file," +
            "with data compression where appropriate.";
            #endregion

            DrawHTML(longtext, new RectangleF(0, 375, width, height));

            #region HtmlText
            longtext = "<font color='#0000F8'>Essential PDF</font> is a <u><i>.NET</i></u> " +
                "library with the capability to produce Adobe PDF files " +
                "It features a full-fledged object model for the easy creation of PDF files from any .NET language. " +
                " It does not use any external libraries and is built from scratch in C#. ";
            #endregion

            width = 250;

            DrawHTML(longtext, new RectangleF(270, 15, width, height));

            // Drawing Image
            image = new PdfBitmap(Image.FromFile(GetFullTemplatePath("Essen PDF.gif", true)));
            page.Graphics.DrawImage(image, new RectangleF(310, 80, 180, 110));

            #region HtmlText
            longtext = "Essential PDF supports many features for creating a PDF document including <b>" +
                "drawing text, images, tables and other shapes</b>. " +
                "<br/><br/><font face='TimesRoman'>The generated PDF document can also be protected using <I>" +
                "40 Bit and 128 Bit encryption.</I></font><br/>" +
                "<p>Essential PDF is compatible with Microsoft Visual Studio .NET 2005 and 2008. " +
                "It is also compatible with the Express editions of Visual Studio.NET. <br/><br/>" +
                "The Essential PDF library can be used in any .NET environment including C#, VB.NET and managed C++.</p>" +
                "The PDF file that is created using Essential PDF can be viewed using Adobe Acrobat or the free " +
                "version of <u> Acrobat Viewer from Adobe only.</u>" +
                "<font color='#0000F8'><b><br/><br/>Essential PDF</b></font> It can be used on the server " +
                "side (ASP.NET or any other environment) or with Windows Forms applications. " +
                "The library is 100% managed, being written in C#.<br/><br/> " +
                "<font color='#FF0000F'>PdfDocument</font> is a top-level object in Essential PDF which implies a " +
                "representation of a PDF document. <br/><br/> " +
                   "The document contains a collection of sections that are represented by the <font color='#FF0000F'>PdfSection</font> class, " +
               "which is a logical entity containing a collection of pages and their settings. <br/><br/> Pages (which are represented by <font color='#FF0000F'>PdfPage</font> class) " +
               "are the main destinations of the graphics output.<br/><br/>" +
               "A document can be saved through its <font color='#0000F8'>Save()</font> method. It can be saved either to a file or stream.<br/><br/>" +
               "In order to use the Essential PDF library in your project, add the PdfConfig component found in the toolbox to a project to enable support for PDF. ";

            #endregion

            DrawHTML(longtext, new RectangleF(270, 225, width, height));

            #region HtmlText
            longtext = "<p>Every Syncfusion license includes a <i>one-year subscription</i> for unlimited technical support and new releases." +
               "Syncfusion licenses each product on a simple per-developer basis and charges no royalties," +
               "runtimes, or server deployment fees. A licensee can install his/her " +
               "license on multiple personal machines at <u>no extra charge.</u></p>"
              + "<p> At Syncfusion we are very excited about the Microsoft .NET platform.<br/><br/> " +
                "We believe that one of the key benefits of <font color='#0000F8'>.NET</font> is improved programmer productivity. " +
                "Solutions that used to take a very long time with traditional tools can now be " +
                "implemented in a much shorter time period with the <font color='#0000F8'>.NET</font> platform.</p>" +
                "Essential Studio includes seven component libraries in one great package." +
            "Essential Studio is available with full source code. It incorporates a " +
            "unique debugging support system that allows switching between 'Debug' and " +
            "\'Release\' versions of our library with a single click from inside the Visual" +
            "Studio.NET IDE. <br/><br/> <p> To ensure the highest quality of support possible," +
            "we use a state of the art <font color='#0000F8'>Customer Relationship Management software (CRM)</font> " +
            "based Developer Support System called Direct-Trac. Syncfusion Direc-Trac is a " +
            "support system that is uniquely tailored for developer needs. Support incidents " +
            "can be created and tracked to completion 24 hours a day, 7 days a week.</p><br/><br/> " +
            "We have a simple, royalty-free licensing model. Components are licensed to a single user." +
            " We recognize that you often work at home or on your laptop in addition to your work machine." +
            "Therefore, our license permits our products to be installed in more than one location." +
            " At Syncfusion, we stand behind our products 100%. <br/><br/>We have top notch management" +
            ", architects, product managers, sales people, support personnel, and developers " +
            "all working with you, the customer, as their focal point.";
            #endregion

            DrawHTML(longtext, new RectangleF(540, 15, width, height));

            #region HtmlText
            longtext = "Each licensed control would need to have an entry in the licx file. This would mean that if you were using 20 licensed controls, you would have 20 different entries complete with a full version number in your licx file." +
                "<br/><br/> This posed major problems when upgrading to a newer version since these entries would need to have their version numbers changed. This also made trouble shooting licensing issues very difficult. ";
            #endregion

            DrawHTML(longtext, new RectangleF(540, 465, width, height));

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

        # region Helpher methods
        /// <summary>
        /// Create an instance of PdfHTMLTextElement class and draw HTML string.
        /// </summary>
        /// <param name="longtext"></param>
        /// <param name="rectangleF"></param>
        private void DrawHTML(string longtext, RectangleF rectangleF)
        {
            PdfHTMLTextElement richTextElement = new PdfHTMLTextElement(longtext, font, brush);
            richTextElement.TextAlign = TextAlign.Justify;
            richTextElement.IsNativeRenderingEnabled = false;
            //Drawing htmlString
            richTextElement.Draw(page, rectangleF, format);
        }

        /// <summary>
        /// Draws header to the PDF.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        private void AddHeader(PdfDocument doc, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create page template
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfGraphics g = header.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 24);

            SizeF imageSize = new SizeF(110f, 35f);

            //Locating the logo on the right corner of the Drawing Surface
            PointF imageLocation = new PointF(doc.Pages[0].GetClientSize().Width - imageSize.Width - 20, 5);

            PdfImage img = new PdfBitmap(GetFullTemplatePath("logo.png", true));

            //Draw the image in the Header.
            g.DrawImage(img, imageLocation, imageSize);

            PdfSolidBrush brush = new PdfSolidBrush(Color.FromArgb(44, 71, 120));

            PdfPen pen = new PdfPen(Color.DarkBlue, 3f);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 16, PdfFontStyle.Bold);

            //Set formattings for the text
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            //Draw title
            g.DrawString(title, font, brush, new RectangleF(0, 0, header.Width, header.Height), format);
            brush = new PdfSolidBrush(Color.Gray);
            font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Left;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Draw description
            g.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            pen = new PdfPen(Color.DarkBlue, 0.7f);
            g.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(Color.DarkBlue, 2f);
            g.DrawLine(pen, 0, 03, header.Width + 3, 03);
            pen = new PdfPen(Color.DarkBlue, 2f);
            g.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            g.DrawLine(pen, 0, header.Height, header.Width, header.Height);

            //Add header template at the top.
            doc.Template.Top = header;
        }

        /// <summary>
        /// Draws footer to the PDF.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="footerText"></param>
        private void AddFooter(PdfDocument doc, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, doc.Pages[0].GetClientSize().Width, 50);

            //Create a page template
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 6, PdfFontStyle.Bold);

            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);

            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;
            footer.Graphics.DrawString(footerText, font, brush, new RectangleF(0, 18, footer.Width, footer.Height), format);

            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Right;
            format.LineAlignment = PdfVerticalAlignment.Bottom;

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, brush);

            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            compositeField.Draw(footer.Graphics, new PointF(650, 40));

            //Add the footer template at the bottom
            doc.Template.Bottom = footer;
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

        # endregion
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
