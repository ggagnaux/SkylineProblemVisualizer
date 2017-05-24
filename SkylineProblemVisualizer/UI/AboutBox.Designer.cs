namespace SkylineProblemVisualizer.UI
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonOK = new MetroFramework.Controls.MetroButton();
            this.labelProductVersion = new MetroFramework.Controls.MetroLabel();
            this.labelCopyright = new MetroFramework.Controls.MetroLabel();
            this.textBoxThirdpartyComponents = new MetroFramework.Controls.MetroTextBox();
            this.linkLabelSource = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.linkLabelThirdparty = new MetroFramework.Controls.MetroLink();
            this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPictureBox.ErrorImage = null;
            this.logoPictureBox.Image = global::SkylineProblemVisualizer.Properties.Resources.SkylineProblemVisualizerLogo;
            this.logoPictureBox.InitialImage = global::SkylineProblemVisualizer.Properties.Resources.SkylineProblemVisualizerLogo;
            this.logoPictureBox.Location = new System.Drawing.Point(16, 78);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(556, 399);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.buttonOK.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonOK.Location = new System.Drawing.Point(971, 434);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(142, 43);
            this.buttonOK.Style = MetroFramework.MetroColorStyle.Teal;
            this.buttonOK.TabIndex = 28;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseSelectable = true;
            // 
            // labelProductVersion
            // 
            this.labelProductVersion.AutoSize = true;
            this.labelProductVersion.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelProductVersion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelProductVersion.Location = new System.Drawing.Point(604, 78);
            this.labelProductVersion.Name = "labelProductVersion";
            this.labelProductVersion.Size = new System.Drawing.Size(112, 20);
            this.labelProductVersion.TabIndex = 35;
            this.labelProductVersion.Text = "Product Version";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.labelCopyright.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCopyright.Location = new System.Drawing.Point(604, 106);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(129, 20);
            this.labelCopyright.TabIndex = 36;
            this.labelCopyright.Text = "Product Copyright";
            // 
            // textBoxThirdpartyComponents
            // 
            // 
            // 
            // 
            this.textBoxThirdpartyComponents.CustomButton.Image = null;
            this.textBoxThirdpartyComponents.CustomButton.Location = new System.Drawing.Point(438, 1);
            this.textBoxThirdpartyComponents.CustomButton.Name = "";
            this.textBoxThirdpartyComponents.CustomButton.Size = new System.Drawing.Size(63, 63);
            this.textBoxThirdpartyComponents.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxThirdpartyComponents.CustomButton.TabIndex = 1;
            this.textBoxThirdpartyComponents.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxThirdpartyComponents.CustomButton.UseSelectable = true;
            this.textBoxThirdpartyComponents.CustomButton.Visible = false;
            this.textBoxThirdpartyComponents.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxThirdpartyComponents.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxThirdpartyComponents.Lines = new string[] {
        "metroTextBox1"};
            this.textBoxThirdpartyComponents.Location = new System.Drawing.Point(604, 289);
            this.textBoxThirdpartyComponents.MaxLength = 32767;
            this.textBoxThirdpartyComponents.Multiline = true;
            this.textBoxThirdpartyComponents.Name = "textBoxThirdpartyComponents";
            this.textBoxThirdpartyComponents.PasswordChar = '\0';
            this.textBoxThirdpartyComponents.ReadOnly = true;
            this.textBoxThirdpartyComponents.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxThirdpartyComponents.SelectedText = "";
            this.textBoxThirdpartyComponents.SelectionLength = 0;
            this.textBoxThirdpartyComponents.SelectionStart = 0;
            this.textBoxThirdpartyComponents.ShortcutsEnabled = true;
            this.textBoxThirdpartyComponents.Size = new System.Drawing.Size(502, 65);
            this.textBoxThirdpartyComponents.TabIndex = 38;
            this.textBoxThirdpartyComponents.Text = "metroTextBox1";
            this.textBoxThirdpartyComponents.UseSelectable = true;
            this.textBoxThirdpartyComponents.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxThirdpartyComponents.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // linkLabelSource
            // 
            this.linkLabelSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelSource.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.linkLabelSource.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.linkLabelSource.Location = new System.Drawing.Point(604, 247);
            this.linkLabelSource.Name = "linkLabelSource";
            this.linkLabelSource.Size = new System.Drawing.Size(497, 23);
            this.linkLabelSource.TabIndex = 39;
            this.linkLabelSource.Text = "http://www.github.com/ggagnaux...";
            this.linkLabelSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelSource.UseSelectable = true;
            this.linkLabelSource.Click += new System.EventHandler(this.linkLabelSource_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(604, 222);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(159, 20);
            this.metroLabel1.TabIndex = 40;
            this.metroLabel1.Text = "Source Available Here:";
            // 
            // linkLabelThirdparty
            // 
            this.linkLabelThirdparty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelThirdparty.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.linkLabelThirdparty.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.linkLabelThirdparty.Location = new System.Drawing.Point(604, 370);
            this.linkLabelThirdparty.Name = "linkLabelThirdparty";
            this.linkLabelThirdparty.Size = new System.Drawing.Size(501, 23);
            this.linkLabelThirdparty.TabIndex = 41;
            this.linkLabelThirdparty.Text = "http://www.github.com/ggagnaux...";
            this.linkLabelThirdparty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelThirdparty.UseSelectable = true;
            this.linkLabelThirdparty.Click += new System.EventHandler(this.linkLabelThirdparty_Click);
            // 
            // textBoxDescription
            // 
            // 
            // 
            // 
            this.textBoxDescription.CustomButton.Image = null;
            this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(433, 2);
            this.textBoxDescription.CustomButton.Name = "";
            this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(61, 61);
            this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxDescription.CustomButton.TabIndex = 1;
            this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxDescription.CustomButton.UseSelectable = true;
            this.textBoxDescription.CustomButton.Visible = false;
            this.textBoxDescription.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDescription.Lines = new string[] {
        "metroTextBox1"};
            this.textBoxDescription.Location = new System.Drawing.Point(604, 140);
            this.textBoxDescription.MaxLength = 32767;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.PasswordChar = '\0';
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxDescription.SelectedText = "";
            this.textBoxDescription.SelectionLength = 0;
            this.textBoxDescription.SelectionStart = 0;
            this.textBoxDescription.ShortcutsEnabled = true;
            this.textBoxDescription.Size = new System.Drawing.Size(497, 66);
            this.textBoxDescription.TabIndex = 37;
            this.textBoxDescription.Text = "metroTextBox1";
            this.textBoxDescription.UseSelectable = true;
            this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDescription.CustomPaintBackground += new System.EventHandler<MetroFramework.Drawing.MetroPaintEventArgs>(this.textBoxDescription_CustomPaintBackground);
            this.textBoxDescription.CustomPaint += new System.EventHandler<MetroFramework.Drawing.MetroPaintEventArgs>(this.textBoxDescription_CustomPaint);
            this.textBoxDescription.CustomPaintForeground += new System.EventHandler<MetroFramework.Drawing.MetroPaintEventArgs>(this.textBoxDescription_CustomPaintForeground);
            this.textBoxDescription.Paint += new System.Windows.Forms.PaintEventHandler(this.textBoxDescription_Paint);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1125, 491);
            this.Controls.Add(this.linkLabelThirdparty);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.linkLabelSource);
            this.Controls.Add(this.textBoxThirdpartyComponents);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelProductVersion);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.logoPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(12, 60, 12, 11);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "About...";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox logoPictureBox;
        private MetroFramework.Controls.MetroButton buttonOK;
        private MetroFramework.Controls.MetroLabel labelProductVersion;
        private MetroFramework.Controls.MetroLabel labelCopyright;
        private MetroFramework.Controls.MetroTextBox textBoxThirdpartyComponents;
        private MetroFramework.Controls.MetroLink linkLabelSource;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLink linkLabelThirdparty;
        private MetroFramework.Controls.MetroTextBox textBoxDescription;
    }
}
