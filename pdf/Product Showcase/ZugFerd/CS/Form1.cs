#region Copyright Syncfusion Inc. 2001 - 2018
//
//  Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.Forms;
using Syncfusion.Pdf.Graphics;
using System.IO;
using System.Text;
using Syncfusion.Licensing;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Interactive;
using System.Xml;
using System.Collections.Generic;

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
        RectangleF QuantityCellBounds = RectangleF.Empty;
        RectangleF TotalPriceCellBounds = RectangleF.Empty;

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
           //
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(286, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
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
            this.label1.Size = new System.Drawing.Size(373, 78);
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
            this.pictureBox1.Size = new System.Drawing.Size(373, 89);
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
            this.ClientSize = new System.Drawing.Size(380, 196);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
              this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(GetFullTemplatePath("syncfusion.ico", true));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZugFerd";
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
            //Create Zugferd invoice PDF
            PdfDocument document = new PdfDocument(PdfConformanceLevel.Pdf_A3B);

            document.ZugferdVersion = ZugferdVersion.ZugferdVersion2_1;
			document.ZugferdConformanceLevel = ZugferdConformanceLevel.Basic_WL;

            CreateZugferdInvoicePDF(document);

            //Create Zugferd Xml attachment file
            Stream zugferdXmlStream=  CreateZugferdXML();

            //Creates an attachment.
            PdfAttachment attachment = new PdfAttachment("factur-x.xml", zugferdXmlStream);
            attachment.Relationship = PdfAttachmentRelationship.Alternative;
            attachment.ModificationDate = DateTime.Now;
            attachment.Description = "factur-x";
            attachment.MimeType = "application/xml";

            document.Attachments.Add(attachment);

            // Save and close the document.
            document.Save("Zugferd.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Zugferd.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                System.Diagnostics.Process.Start("Zugferd.pdf");
#endif
                this.Close();
            }
            else
            {
                // Exit
                this.Close();
            }
        }

        public Stream CreateZugferdXML()
        {            
            //Create Zugferd Invoice
            ZugferdInvoice invoice = new ZugferdInvoice("2058557939", new DateTime(2013, 6, 5), CurrencyCodes.USD);

            //Set ZugferdProfile to ZugferdInvoice
            invoice.Profile = ZugferdProfile.Basic;

            //Add buyer details
            invoice.Buyer = new UserDetails
            {
                ID = "Abraham_12",
                Name = "Abraham Swearegin",
                ContactName = "Swearegin",
                City = "United States, California",
                Postcode = "9920",
                Country = CountryCodes.US,
                Street = "9920 BridgePointe Parkway"
            };

            //Add seller details
            invoice.Seller = new UserDetails
            {
                ID = "Adventure_123",
                Name = "AdventureWorks",
                ContactName = "Adventure support",
                City = "Austin,TX",
                Postcode = "",
                Country = CountryCodes.US,
                Street = "800 Interchange Blvd"               
            }; 

            float total = 0;
            List<string> productdetails = new List<string>();
            using (XmlReader reader = XmlReader.Create(GetFullTemplatePath("InvoiceProductList.xml", false)))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        reader.Name.ToString();

                        Product product = new Product();

                        if (reader.Name.ToString() == "Productid")
                        {
                            productdetails.Add(reader.ReadString());
                        }
                        else if (reader.Name.ToString() == "Product")
                        {
                            productdetails.Add(reader.ReadString());
                        }
                        else if (reader.Name.ToString() == "Price")
                        {
                            productdetails.Add(reader.ReadString());
                        }
                        else if (reader.Name.ToString() == "Quantity")
                        {
                            productdetails.Add(reader.ReadString());
                        }
                        else if (reader.Name.ToString() == "Total")
                        {
                            productdetails.Add(reader.ReadString());
                            invoice.AddProduct(productdetails[0], productdetails[1], float.Parse(productdetails[2], System.Globalization.CultureInfo.InvariantCulture), float.Parse(productdetails[3], System.Globalization.CultureInfo.InvariantCulture), float.Parse(productdetails[4], System.Globalization.CultureInfo.InvariantCulture));
                            total += float.Parse(productdetails[4], System.Globalization.CultureInfo.InvariantCulture);
                            productdetails = new List<string>();
                        }
                    }
                }
            }

            invoice.TotalAmount = total;

            MemoryStream ms = new MemoryStream();

            //Save Zugferd Xml
            return invoice.Save(ms);
        }     

        /// <summary>
        /// Create Zugferd Invoice Pdf
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public PdfDocument CreateZugferdInvoicePDF(PdfDocument document)
        {
            //Add page to the PDF
            PdfPage page = document.Pages.Add();

            PdfGraphics graphics = page.Graphics;

            //Create border color
            PdfColor borderColor = Color.FromArgb(255, 142, 170, 219);

            //Get the page width and height
            float pageWidth = page.GetClientSize().Width;
            float pageHeight = page.GetClientSize().Height;

            //Set the header height
            float headerHeight = 90;


            PdfColor lightBlue = Color.FromArgb(255, 91, 126, 215);
            PdfBrush lightBlueBrush = new PdfSolidBrush(lightBlue);

            PdfColor darkBlue = Color.FromArgb(255, 65, 104, 209);
            PdfBrush darkBlueBrush = new PdfSolidBrush(darkBlue);

            PdfBrush whiteBrush = new PdfSolidBrush(Color.White);

            PdfTrueTypeFont robotoFont = new PdfTrueTypeFont(new Font("Roboto Light", 30, FontStyle.Regular), true);

            PdfTrueTypeFont arialRegularFont = new PdfTrueTypeFont(new Font("Arial", 18, FontStyle.Regular), true);
            PdfTrueTypeFont arialBoldFont = new PdfTrueTypeFont(new Font("arial", 9f, FontStyle.Bold), true);

            //Create string format.
            PdfStringFormat format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            format.LineAlignment = PdfVerticalAlignment.Middle;

            float y = 0;
            float x = 0;

            //Set the margins of address.
            float margin = 30;

            //Set the line space
            float lineSpace = 7;

            PdfPen borderPen = new PdfPen(borderColor, 1f);

            //Draw page border
            graphics.DrawRectangle(borderPen, new RectangleF(0, 0, pageWidth, pageHeight));


            PdfGrid grid = new PdfGrid();

            grid.DataSource = GetZugferdDataset();

            #region Header         

            //Fill the header with light Brush 
            graphics.DrawRectangle(lightBlueBrush, new RectangleF(0, 0, pageWidth, headerHeight));

            string title = "INVOICE";

            SizeF textSize = robotoFont.MeasureString(title);

            RectangleF headerTotalBounds = new RectangleF(400, 0, pageWidth - 400, headerHeight);

            graphics.DrawString(title, robotoFont, whiteBrush, new RectangleF(0, 0, textSize.Width + 50, headerHeight), format);

            graphics.DrawRectangle(darkBlueBrush, headerTotalBounds);

            graphics.DrawString("$" + GetTotalAmount(grid).ToString(), arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight + 10), format);

            arialRegularFont = new PdfTrueTypeFont(new Font("Arial", 9, FontStyle.Regular), true);

            format.LineAlignment = PdfVerticalAlignment.Bottom;
            graphics.DrawString("Amount", arialRegularFont, whiteBrush, new RectangleF(400, 0, pageWidth - 400, headerHeight / 2 - arialRegularFont.Height), format);

            #endregion


            SizeF size = arialRegularFont.MeasureString("Invoice Number: 2058557939");
            y = headerHeight + margin;
            x = (pageWidth - margin) - size.Width;

            graphics.DrawString("Invoice Number: 2058557939", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            size = arialRegularFont.MeasureString("Date :" + DateTime.Now.ToString("dddd dd, MMMM yyyy"));
            x = (pageWidth - margin) - size.Width;
            y += arialRegularFont.Height + lineSpace;

            graphics.DrawString("Date: " + DateTime.Now.ToString("dddd dd, MMMM yyyy"), arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y = headerHeight + margin;
            x = margin;
            graphics.DrawString("Bill To:", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("Abraham Swearegin,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("United States, California, San Mateo,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("9920 BridgePointe Parkway,", arialRegularFont, PdfBrushes.Black, new PointF(x, y));
            y += arialRegularFont.Height + lineSpace;
            graphics.DrawString("9365550136", arialRegularFont, PdfBrushes.Black, new PointF(x, y));


            #region Grid

            grid.Columns[0].Width = 110;
            grid.Columns[1].Width = 150;
            grid.Columns[2].Width = 110;
            grid.Columns[3].Width = 70;
            grid.Columns[4].Width = 100;

            for (int i = 0; i < grid.Headers.Count; i++)
            {
                grid.Headers[i].Height = 20;
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;

                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    if (j == 0 || j == 2)
                        grid.Headers[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);

                    grid.Headers[i].Cells[j].StringFormat = pdfStringFormat;

                    grid.Headers[i].Cells[j].Style.Font = arialBoldFont;

                }
                grid.Headers[0].Cells[0].Value = "Product Id";
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].Height = 23;
                for (int j = 0; j < grid.Columns.Count; j++)
                {

                    PdfStringFormat pdfStringFormat = new PdfStringFormat();
                    pdfStringFormat.LineAlignment = PdfVerticalAlignment.Middle;

                    pdfStringFormat.Alignment = PdfTextAlignment.Left;
                    if (j == 0 || j == 2)
                        grid.Rows[i].Cells[j].Style.CellPadding = new PdfPaddings(30, 1, 1, 1);

                    grid.Rows[i].Cells[j].StringFormat = pdfStringFormat;
                    grid.Rows[i].Cells[j].Style.Font = arialRegularFont;
                }

            }
            grid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable4Accent5);
            grid.BeginCellLayout += Grid_BeginCellLayout;


            PdfGridLayoutResult result = grid.Draw(page, new PointF(0, y + 40));

            y = result.Bounds.Bottom + lineSpace;
            format = new PdfStringFormat();
            format.Alignment = PdfTextAlignment.Center;
            RectangleF bounds = new RectangleF(QuantityCellBounds.X, y, QuantityCellBounds.Width, QuantityCellBounds.Height);

            page.Graphics.DrawString("Grand Total:", arialBoldFont, PdfBrushes.Black, bounds, format);

            bounds = new RectangleF(TotalPriceCellBounds.X, y, TotalPriceCellBounds.Width, TotalPriceCellBounds.Height);
            page.Graphics.DrawString(GetTotalAmount(grid).ToString(), arialBoldFont, PdfBrushes.Black, bounds);


            #endregion



            borderPen.DashStyle = PdfDashStyle.Custom;
            borderPen.DashPattern = new float[] { 3, 3 };

            graphics.DrawLine(borderPen, new PointF(0, pageHeight - 100), new PointF(pageWidth, pageHeight - 100));

            y = pageHeight - 100 + margin;

            size = arialRegularFont.MeasureString("800 Interchange Blvd.");

            x = pageWidth - size.Width - margin;

            graphics.DrawString("800 Interchange Blvd.", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y += arialRegularFont.Height + lineSpace;

            size = arialRegularFont.MeasureString("Suite 2501,  Austin, TX 78721");

            x = pageWidth - size.Width - margin;

            graphics.DrawString("Suite 2501,  Austin, TX 78721", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            y += arialRegularFont.Height + lineSpace;

            size = arialRegularFont.MeasureString("Any Questions? support@adventure-works.com");

            x = pageWidth - size.Width - margin;
            graphics.DrawString("Any Questions? support@adventure-works.com", arialRegularFont, PdfBrushes.Black, new PointF(x, y));

            return document;
        }
                
        private void Grid_BeginCellLayout(object sender, PdfGridBeginCellLayoutEventArgs args)
        {
            PdfGrid grid = sender as PdfGrid;
            if (args.CellIndex == grid.Columns.Count - 1)
            {
                TotalPriceCellBounds = args.Bounds;
            }
            else if (args.CellIndex == grid.Columns.Count - 2)
            {
                QuantityCellBounds = args.Bounds;
            }

        }

        /// <summary>
        /// Get dataset from xml file.
        /// </summary>
        /// <returns></returns>
        private DataSet GetZugferdDataset()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(GetFullTemplatePath("InvoiceProductList.xml", false));
            return dataSet;
        }

        /// <summary>
        /// Get the Total amount of purcharsed items
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private float GetTotalAmount(PdfGrid grid)
        {
            float Total = 0f;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string cellValue = grid.Rows[i].Cells[grid.Columns.Count - 1].Value.ToString();
                float result = float.Parse(cellValue, System.Globalization.CultureInfo.InvariantCulture);
                Total += result;
            }
            return Total;

        }
        #endregion

        # region Helpher Methods
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

            string licenseKeyFile = "Common\\SyncfusionLicense.txt";

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
