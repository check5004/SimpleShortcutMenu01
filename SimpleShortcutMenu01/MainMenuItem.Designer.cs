
namespace SimpleShortcutMenu01 {
    partial class MainMenuItem {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.SuspendLayout();
            // 
            // MainMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 205);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenuItem";
            this.ShowInTaskbar = false;
            this.Text = "MainMenuItem";
            this.Load += new System.EventHandler(this.MainMenuItem_Load);
            this.LocationChanged += new System.EventHandler(this.MainMenuItem_LocationChanged);
            this.DoubleClick += new System.EventHandler(this.MainMenuItem_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainMenuItem_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMenuItem_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}