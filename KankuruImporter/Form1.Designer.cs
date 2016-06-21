namespace KankuruImporter
{
    partial class Form1
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
            this.openFileDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.TxtFile = new System.Windows.Forms.TextBox();
            this.buImport = new System.Windows.Forms.Button();
            this.TxtScript = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtFile
            // 
            this.TxtFile.Location = new System.Drawing.Point(12, 12);
            this.TxtFile.Name = "TxtFile";
            this.TxtFile.Size = new System.Drawing.Size(985, 22);
            this.TxtFile.TabIndex = 0;
            this.TxtFile.TextChanged += new System.EventHandler(this.TxtFile_TextChanged);
            // 
            // buImport
            // 
            this.buImport.Location = new System.Drawing.Point(1003, 10);
            this.buImport.Name = "buImport";
            this.buImport.Size = new System.Drawing.Size(114, 26);
            this.buImport.TabIndex = 1;
            this.buImport.Text = "Import Regsvr";
            this.buImport.UseVisualStyleBackColor = true;
            this.buImport.Click += new System.EventHandler(this.buImport_Click);
            // 
            // TxtScript
            // 
            this.TxtScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtScript.Location = new System.Drawing.Point(13, 43);
            this.TxtScript.Multiline = true;
            this.TxtScript.Name = "TxtScript";
            this.TxtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtScript.Size = new System.Drawing.Size(1104, 481);
            this.TxtScript.TabIndex = 2;
            this.TxtScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtScript_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 536);
            this.Controls.Add(this.TxtScript);
            this.Controls.Add(this.buImport);
            this.Controls.Add(this.TxtFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogBox;
        private System.Windows.Forms.TextBox TxtFile;
        private System.Windows.Forms.Button buImport;
        private System.Windows.Forms.TextBox TxtScript;

    }
}

