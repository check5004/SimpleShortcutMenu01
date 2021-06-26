
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(990, 414);
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
            this.button_DataSetSave.Location = new System.Drawing.Point(927, 432);
            this.button_DataSetSave.Name = "button_DataSetSave";
            this.button_DataSetSave.Size = new System.Drawing.Size(75, 23);
            this.button_DataSetSave.TabIndex = 3;
            this.button_DataSetSave.Text = "Save";
            this.button_DataSetSave.UseVisualStyleBackColor = true;
            this.button_DataSetSave.Click += new System.EventHandler(this.button_DataSetSave_Click);
            // 
            // button_DataSetLoad
            // 
            this.button_DataSetLoad.Location = new System.Drawing.Point(12, 432);
            this.button_DataSetLoad.Name = "button_DataSetLoad";
            this.button_DataSetLoad.Size = new System.Drawing.Size(75, 23);
            this.button_DataSetLoad.TabIndex = 4;
            this.button_DataSetLoad.Text = "Load";
            this.button_DataSetLoad.UseVisualStyleBackColor = true;
            this.button_DataSetLoad.Click += new System.EventHandler(this.button_DataSetLoad_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(694, 432);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_insert
            // 
            this.button_insert.Location = new System.Drawing.Point(117, 432);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(203, 23);
            this.button_insert.TabIndex = 7;
            this.button_insert.Text = "insert";
            this.button_insert.UseVisualStyleBackColor = true;
            this.button_insert.Click += new System.EventHandler(this.button_insert_Click);
            // 
            // button_itemUp
            // 
            this.button_itemUp.Location = new System.Drawing.Point(412, 432);
            this.button_itemUp.Name = "button_itemUp";
            this.button_itemUp.Size = new System.Drawing.Size(75, 23);
            this.button_itemUp.TabIndex = 8;
            this.button_itemUp.Text = "↑";
            this.button_itemUp.UseVisualStyleBackColor = true;
            this.button_itemUp.Click += new System.EventHandler(this.button_itemUp_Click);
            // 
            // button_itemDown
            // 
            this.button_itemDown.Location = new System.Drawing.Point(522, 432);
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
            this.ClientSize = new System.Drawing.Size(1014, 467);
            this.Controls.Add(this.button_itemDown);
            this.Controls.Add(this.button_itemUp);
            this.Controls.Add(this.button_insert);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_DataSetLoad);
            this.Controls.Add(this.button_DataSetSave);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
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

