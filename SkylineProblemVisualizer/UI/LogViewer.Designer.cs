namespace SkylineProblemVisualizer
{
    public partial class LogViewer
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
            this.buttonClose = new MetroFramework.Controls.MetroButton();
            this.panelContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.buttonClose.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonClose.Location = new System.Drawing.Point(889, 661);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(96, 39);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseSelectable = true;
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Location = new System.Drawing.Point(8, 72);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(981, 569);
            this.panelContent.TabIndex = 3;
            // 
            // LogViewer
            // 
            this.AcceptButton = this.buttonClose;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(997, 717);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.buttonClose);
            this.Name = "LogViewer";
            this.Text = "Log Viewer";
            this.ResumeLayout(false);

        }

        private MetroFramework.Controls.MetroButton buttonClose;
        private System.Windows.Forms.Panel panelContent;
    }
    #endregion
}
