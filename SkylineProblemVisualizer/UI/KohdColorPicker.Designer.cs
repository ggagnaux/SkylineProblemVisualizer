namespace SkylineProblemVisualizer.UI
{
    partial class KohdColorPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectColor = new System.Windows.Forms.Button();
            this.textBoxColorRGBHex = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // buttonSelectColor
            // 
            this.buttonSelectColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSelectColor.Location = new System.Drawing.Point(0, 0);
            this.buttonSelectColor.Name = "buttonSelectColor";
            this.buttonSelectColor.Size = new System.Drawing.Size(38, 34);
            this.buttonSelectColor.TabIndex = 0;
            this.buttonSelectColor.UseVisualStyleBackColor = true;
            this.buttonSelectColor.Click += new System.EventHandler(this.buttonSelectColor_Click);
            // 
            // textBoxColorRGBHex
            // 
            this.textBoxColorRGBHex.Location = new System.Drawing.Point(60, 30);
            this.textBoxColorRGBHex.Name = "textBoxColorRGBHex";
            this.textBoxColorRGBHex.Size = new System.Drawing.Size(0, 22);
            this.textBoxColorRGBHex.TabIndex = 1;
            // 
            // KohdColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxColorRGBHex);
            this.Controls.Add(this.buttonSelectColor);
            this.Name = "KohdColorPicker";
            this.Size = new System.Drawing.Size(38, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button buttonSelectColor;
        private System.Windows.Forms.TextBox textBoxColorRGBHex;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
