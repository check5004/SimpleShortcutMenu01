namespace SimpleShortcutMenu01
{
    partial class FormMainMenu
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
            this.mainMenuItem1 = new SimpleShortcutMenu01.MainMenuItem();
            this.SuspendLayout();
            // 
            // mainMenuItem1
            // 
            this.mainMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuItem1.Location = new System.Drawing.Point(12, 12);
            this.mainMenuItem1.Name = "mainMenuItem1";
            this.mainMenuItem1.Size = new System.Drawing.Size(105, 102);
            this.mainMenuItem1.TabIndex = 0;
            // 
            // FormMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LawnGreen;
            this.ClientSize = new System.Drawing.Size(237, 304);
            this.Controls.Add(this.mainMenuItem1);
            this.Name = "FormMainMenu";
            this.Text = "FormMainMenu";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenuItem mainMenuItem1;
    }
}