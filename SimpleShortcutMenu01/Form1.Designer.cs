
namespace SimpleShortcutMenu01
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBoxOnly = new System.Windows.Forms.PictureBox();
            this.pBoxBatu = new System.Windows.Forms.PictureBox();
            this.pBoxMaru = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBatu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMaru)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-3, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 339);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(532, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Message Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageDialog_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageDialog_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pBoxOnly);
            this.panel1.Controls.Add(this.pBoxBatu);
            this.panel1.Controls.Add(this.pBoxMaru);
            this.panel1.Location = new System.Drawing.Point(4, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 94);
            this.panel1.TabIndex = 1;
            // 
            // pBoxOnly
            // 
            this.pBoxOnly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxOnly.BackgroundImage")));
            this.pBoxOnly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxOnly.Image = global::SimpleShortcutMenu01.Properties.Resources.BatuGray;
            this.pBoxOnly.Location = new System.Drawing.Point(149, 10);
            this.pBoxOnly.Name = "pBoxOnly";
            this.pBoxOnly.Size = new System.Drawing.Size(232, 77);
            this.pBoxOnly.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxOnly.TabIndex = 4;
            this.pBoxOnly.TabStop = false;
            this.pBoxOnly.Click += new System.EventHandler(this.CancelButton_Click);
            this.pBoxOnly.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CancelButton_Down);
            this.pBoxOnly.MouseEnter += new System.EventHandler(this.CancelButton_Enter);
            this.pBoxOnly.MouseLeave += new System.EventHandler(this.CancelButton_Leave);
            // 
            // pBoxBatu
            // 
            this.pBoxBatu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxBatu.BackgroundImage")));
            this.pBoxBatu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxBatu.Image = global::SimpleShortcutMenu01.Properties.Resources.BatuGray;
            this.pBoxBatu.Location = new System.Drawing.Point(291, 11);
            this.pBoxBatu.Name = "pBoxBatu";
            this.pBoxBatu.Size = new System.Drawing.Size(232, 77);
            this.pBoxBatu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxBatu.TabIndex = 3;
            this.pBoxBatu.TabStop = false;
            this.pBoxBatu.Click += new System.EventHandler(this.CancelButton_Click);
            this.pBoxBatu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CancelButton_Down);
            this.pBoxBatu.MouseEnter += new System.EventHandler(this.CancelButton_Enter);
            this.pBoxBatu.MouseLeave += new System.EventHandler(this.CancelButton_Leave);
            // 
            // pBoxMaru
            // 
            this.pBoxMaru.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxMaru.BackgroundImage")));
            this.pBoxMaru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBoxMaru.Image = global::SimpleShortcutMenu01.Properties.Resources.MaruGray;
            this.pBoxMaru.Location = new System.Drawing.Point(11, 11);
            this.pBoxMaru.Name = "pBoxMaru";
            this.pBoxMaru.Size = new System.Drawing.Size(232, 77);
            this.pBoxMaru.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxMaru.TabIndex = 2;
            this.pBoxMaru.TabStop = false;
            this.pBoxMaru.Click += new System.EventHandler(this.OkButton_Click);
            this.pBoxMaru.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OkButton_MouseDown);
            this.pBoxMaru.MouseEnter += new System.EventHandler(this.OkButton_MouseEnter);
            this.pBoxMaru.MouseLeave += new System.EventHandler(this.OkButton_MouseLeave);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(4, 102);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(532, 135);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "label2\r\nas\r\nsda\r\nfas\r\ndasf\r\ndsa\r\ns";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageDialog_MouseDown);
            this.lblMessage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MessageDialog_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBatu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMaru)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pBoxMaru;
        private System.Windows.Forms.PictureBox pBoxBatu;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pBoxOnly;
    }
}

