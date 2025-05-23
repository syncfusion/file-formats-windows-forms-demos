#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
using System;
using System.Windows.Forms;
using System.IO;
using Syncfusion.Windows.Forms;
using Syncfusion.Licensing;
using System.Reflection;
using System.Text;

namespace WriteProtection
{
    public partial class Form1 :  MetroForm 
    {
        #region Private Members
        private System.ComponentModel.IContainer components = null;
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
            this.txtProtectSource.Text = "Syncfusion Presentation.pptx";
#if !NETCore
            this.txtProtectSource.Tag = @"..\..\..\..\..\..\common\Data\Presentation\Syncfusion Presentation.pptx";
#else
            this.txtProtectSource.Tag = @"..\..\..\..\..\..\..\common\Data\Presentation\Syncfusion Presentation.pptx";
#endif

            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        /// <summary>
        /// Helper method to find a syncfusion license key from the Common folder
        /// </summary>
        /// <param name="fileName">File name of the syncfusion license key</param>
        /// <returns></returns>
        public static string FindLicenseKey()
        {
            string licenseKeyFile = "..\\common\\SyncfusionLicense.txt";
            for (int n = 0; n < 20; n++)
            {
                if (!System.IO.File.Exists(licenseKeyFile))
                {
                    licenseKeyFile = @"..\" + licenseKeyFile;
                    continue;
                }
                return File.ReadAllText(licenseKeyFile);
            }
            return string.Empty;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEncrypt = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEncryptBrowse = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtProtectSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnOpen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(0, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(372, 56);
            this.label2.TabIndex = 78;
            this.label2.Text = "Click the button to view the PowerPoint Presentation generated by Essential Prese" +
    "ntation. Please note that MS PowerPoint Viewer or MS PowerPoint is required to v" +
    "iew the resultant Presentation.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncrypt.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.btnEncrypt.BeforeTouchSize = new System.Drawing.Size(85, 21);
            this.btnEncrypt.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Dashed;
            this.btnEncrypt.ComboEditBackColor = System.Drawing.Color.Silver;
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.IsBackStageButton = false;
            this.btnEncrypt.KeepFocusRectangle = false;
            this.btnEncrypt.Location = new System.Drawing.Point(257, 92);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnEncrypt.Size = new System.Drawing.Size(85, 21);
            this.btnEncrypt.TabIndex = 76;
            this.btnEncrypt.Text = "Protect";
            this.btnEncrypt.ThemeName = "Metro";
            this.btnEncrypt.UseVisualStyle = true;
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnProtect_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(354, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 16);
            this.label9.TabIndex = 84;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEncryptBrowse);
            this.groupBox1.Controls.Add(this.txtProtectSource);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnEncrypt);
            this.groupBox1.Controls.Add(this.txtEnOpen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 124);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Protect Presentation from writing";
            // 
            // btnEncryptBrowse
            // 
            this.btnEncryptBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncryptBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnEncryptBrowse.BeforeTouchSize = new System.Drawing.Size(24, 20);
            this.btnEncryptBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncryptBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEncryptBrowse.IsBackStageButton = false;
            this.btnEncryptBrowse.Location = new System.Drawing.Point(318, 29);
            this.btnEncryptBrowse.Name = "btnEncryptBrowse";
            this.btnEncryptBrowse.Size = new System.Drawing.Size(24, 20);
            this.btnEncryptBrowse.TabIndex = 0;
            this.btnEncryptBrowse.Text = "...";
            this.btnEncryptBrowse.UseVisualStyleBackColor = false;
            this.btnEncryptBrowse.Click += new System.EventHandler(this.btnProtectBrowse_Click);
            // 
            // txtEncryptSource
            // 
            this.txtProtectSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProtectSource.Location = new System.Drawing.Point(123, 29);
            this.txtProtectSource.Name = "txtEncryptSource";
            this.txtProtectSource.Size = new System.Drawing.Size(172, 20);
            this.txtProtectSource.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Source Document";
            // 
            // txtEnOpen
            // 
            this.txtEnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnOpen.Location = new System.Drawing.Point(123, 60);
            this.txtEnOpen.Name = "txtEnOpen";
            this.txtEnOpen.PasswordChar = '*';
            this.txtEnOpen.Size = new System.Drawing.Size(219, 20);
            this.txtEnOpen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password To Protect";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.MidnightBlue;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(29, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 1);
            this.label8.TabIndex = 2;
            this.label8.Text = "label8";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.MidnightBlue;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(29, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 1);
            this.label11.TabIndex = 2;
            this.label11.Text = "label11";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(379, 295);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.DropShadow = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Write Protection";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Syncfusion.Windows.Forms.ButtonAdv btnEncrypt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.Windows.Forms.ButtonAdv btnEncryptBrowse;
        private System.Windows.Forms.TextBox txtProtectSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnOpen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SyncfusionLicenseProvider.RegisterLicense(FindLicenseKey());
            Application.Run(new Form1());
        }
        #endregion

        #region Events

        private void btnProtectBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
#if !NETCore
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"..\..\..\..\..\..\common\Data\Presentation\");
#else
            openFileDialog1.InitialDirectory = Path.GetFullPath(@"..\..\..\..\..\..\..\common\Data\Presentation\");
#endif
            openFileDialog1.Filter = "PowerPoint Presentations|*.pptx";
            DialogResult result = openFileDialog1.ShowDialog();

            //Get the selected file name and display in a TextBox
            if (result == DialogResult.OK)
            {
                this.txtProtectSource.Text = openFileDialog1.SafeFileName;
                this.txtProtectSource.Tag = openFileDialog1.FileName;
            }

        }
        private void btnProtect_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEnOpen.Text))
                {
                    MessageBox.Show("Please enter Password to protect writing", "Password Missing", MessageBoxButtons.OK);
                }
                else
                {
                    //Create instance for presentation
                    IPresentation presentation = Presentation.Open(txtProtectSource.Tag.ToString());
                    //Set the write protection for presentation instance
                    presentation.SetWriteProtection(txtEnOpen.Text);
                    //Saves the presentation
                    presentation.Save("WriteProtection.pptx");
                    //Closes the presentation
                    presentation.Close();

                    if (MessageBox.Show("Do you want to view the protected Presentation?", "Write Protected Presentation",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
#if !NETCore
                        System.Diagnostics.Process.Start("WriteProtection.pptx");
#else
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("WriteProtection.pptx")
                        {
                            UseShellExecute = true
                        };
                        process.Start();
#endif
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("This Presentation could not be write protected , please contact Syncfusion Direct-Trac system at http://www.syncfusion.com/support/default.aspx for any queries. ", "OOPS..Sorry!",
                      MessageBoxButtons.OK);
                this.Close();
            }
        }        
        #endregion
    }
}
