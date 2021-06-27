
namespace SimpleShortcutMenu01 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSetMenuItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_MenuItems = new SimpleShortcutMenu01.DataSet_MenuItems();
            this.button_DataSetSave = new System.Windows.Forms.Button();
            this.button_DataSetLoad = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_insert = new System.Windows.Forms.Button();
            this.button_itemUp = new System.Windows.Forms.Button();
            this.button_itemDown = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMenuItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MenuItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("UD デジタル 教科書体 N-B", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＤＨＰ平成ゴシックW5", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(984, 450);
            this.dataGridView1.TabIndex = 2;
            // 
            // dataSetMenuItemsBindingSource
            // 
            this.dataSetMenuItemsBindingSource.DataSource = this.dataSet_MenuItems;
            this.dataSetMenuItemsBindingSource.Position = 0;
            // 
            // dataSet_MenuItems
            // 
            this.dataSet_MenuItems.DataSetName = "DataSet_MenuItems";
            this.dataSet_MenuItems.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button_DataSetSave
            // 
            this.button_DataSetSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_DataSetSave.Location = new System.Drawing.Point(921, 468);
            this.button_DataSetSave.Name = "button_DataSetSave";
            this.button_DataSetSave.Size = new System.Drawing.Size(75, 23);
            this.button_DataSetSave.TabIndex = 3;
            this.button_DataSetSave.Text = "Save";
            this.button_DataSetSave.UseVisualStyleBackColor = true;
            this.button_DataSetSave.Click += new System.EventHandler(this.button_DataSetSave_Click);
            // 
            // button_DataSetLoad
            // 
            this.button_DataSetLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_DataSetLoad.Location = new System.Drawing.Point(12, 468);
            this.button_DataSetLoad.Name = "button_DataSetLoad";
            this.button_DataSetLoad.Size = new System.Drawing.Size(75, 23);
            this.button_DataSetLoad.TabIndex = 4;
            this.button_DataSetLoad.Text = "Load";
            this.button_DataSetLoad.UseVisualStyleBackColor = true;
            this.button_DataSetLoad.Click += new System.EventHandler(this.button_DataSetLoad_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button3.Location = new System.Drawing.Point(657, 468);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_insert
            // 
            this.button_insert.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_insert.Location = new System.Drawing.Point(159, 468);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(203, 23);
            this.button_insert.TabIndex = 7;
            this.button_insert.Text = "insert";
            this.button_insert.UseVisualStyleBackColor = true;
            this.button_insert.Click += new System.EventHandler(this.button_insert_Click);
            // 
            // button_itemUp
            // 
            this.button_itemUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_itemUp.Location = new System.Drawing.Point(424, 468);
            this.button_itemUp.Name = "button_itemUp";
            this.button_itemUp.Size = new System.Drawing.Size(75, 23);
            this.button_itemUp.TabIndex = 8;
            this.button_itemUp.Text = "↑";
            this.button_itemUp.UseVisualStyleBackColor = true;
            this.button_itemUp.Click += new System.EventHandler(this.button_itemUp_Click);
            // 
            // button_itemDown
            // 
            this.button_itemDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_itemDown.Location = new System.Drawing.Point(505, 468);
            this.button_itemDown.Name = "button_itemDown";
            this.button_itemDown.Size = new System.Drawing.Size(75, 23);
            this.button_itemDown.TabIndex = 9;
            this.button_itemDown.Text = "↓";
            this.button_itemDown.UseVisualStyleBackColor = true;
            this.button_itemDown.Click += new System.EventHandler(this.button_itemDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 503);
            this.Controls.Add(this.button_itemDown);
            this.Controls.Add(this.button_itemUp);
            this.Controls.Add(this.button_insert);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_DataSetLoad);
            this.Controls.Add(this.button_DataSetSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "DataEdditer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMenuItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MenuItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dataSetMenuItemsBindingSource;
        private DataSet_MenuItems dataSet_MenuItems;
        private System.Windows.Forms.Button button_DataSetSave;
        private System.Windows.Forms.Button button_DataSetLoad;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_insert;
        private System.Windows.Forms.Button button_itemUp;
        private System.Windows.Forms.Button button_itemDown;
    }
}

