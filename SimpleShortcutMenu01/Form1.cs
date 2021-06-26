using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    public partial class Form1 : Form {
        public static List<MainMenuItem> mainMenuItem = new List<MainMenuItem> ();

        public Form1 () {
            InitializeComponent ();

            Config.changing = false;

            // show
            DataSet_MenuItems dataSet_MenuItems = new DataSet_MenuItems ();
            var mainMenuItems = DataLoad.GetXMLDate ( dataSet_MenuItems );
            Config.dataSet_MenuItems = mainMenuItems.Tables[0];

            // メニュー項目名を取得
            var co = new HashSet<string> ();
            for ( int i = 0; i < Config.dataSet_MenuItems.Rows.Count; i++ ) {
                co.Add ( Config.dataSet_MenuItems.Rows[i]["menuName"].ToString () );
            }
            var coClear = co.ToList ();

            Config.mainMenuItemCount = coClear.Count;

            for ( int i = 0; i < Config.mainMenuItemCount; i++ ) {
                mainMenuItem.Add ( new MainMenuItem ( coClear[i] ) );

                mainMenuItem[i].StartPosition = FormStartPosition.Manual;
            }

            // 表示位置指定
            // ------------------ ウインドウを閉じた位置にする --------------------
            mainMenuItem[0].Left = 100;
            mainMenuItem[0].Top = 100;

            // 移動してから表示（カクつかない）
            foreach ( var item in mainMenuItem ) {
                item.Show ();
            }

            // DataGrid 表示
            button_DataSetLoad_Click ( new object (), new EventArgs () );
        }

        #region DataGridView操作
        // Save
        private void button_DataSetSave_Click ( object sender, EventArgs e ) {
            dataSet_MenuItems.Tables[0].Rows.Clear ();

            for ( int i = 0; i < dataGridView1.RowCount - 1; i++ ) {
                string[] items = new string[dataGridView1.ColumnCount];
                for ( int j = 0; j < dataGridView1.ColumnCount; j++ ) {
                    items[j] = dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString ();
                }
                dataSet_MenuItems.Tables[0].Rows.Add ( items );
            }

            DataLoad.OutputXML ( dataSet_MenuItems.DataTable_MenuItems.DataSet );
            MessageBox.Show ( "保存しました。\n再起動します。" );

            Application.Restart ();  // 再起動
        }

        // Load
        private void button_DataSetLoad_Click ( object sender, EventArgs e ) {
            if ( dataGridView1.RowCount > 1 ) {
                dataGridView1.Rows.Clear ();
            }

            // カラム数を指定
            dataGridView1.ColumnCount = Config.dataSet_MenuItems.Columns.Count;

            // カラム名を指定
            for ( int i = 0; i < Config.dataSet_MenuItems.Columns.Count; i++ ) {
                dataGridView1.Columns[i].HeaderText = Config.dataSet_MenuItems.Columns[i].ToString ();
            }
            // データを追加
            for ( int i = 0; i < Config.dataSet_MenuItems.Rows.Count; i++ ) {
                dataGridView1.Rows.Add ( Config.dataSet_MenuItems.Rows[i].ItemArray );
            }
        }

        // Delete
        private void button3_Click ( object sender, EventArgs e ) {
            dataGridView1.Rows.RemoveAt ( dataGridView1.SelectedCells[0].RowIndex );
        }

        // Insert
        private void button_insert_Click ( object sender, EventArgs e ) {
            dataGridView1.Rows.Insert ( dataGridView1.SelectedCells[0].RowIndex );
        }

        // Up
        private void button_itemUp_Click ( object sender, EventArgs e ) {
            try {
                if ( dataGridView1.SelectedCells.Count == 0 || dataGridView1.SelectedRows.Count > 1 ) {
                    MessageBox.Show ( "セルまたは行を1つ選択してください" );
                    return;
                }

                string[] selectRowValueStr = new string[dataGridView1.ColumnCount];
                string[] moveRowValueStr = new string[dataGridView1.ColumnCount];
                var selectRowIndex = dataGridView1.SelectedCells[0].RowIndex;

                for ( int i = 0; i < dataGridView1.ColumnCount; i++ ) {
                    selectRowValueStr[i] = dataGridView1.Rows[selectRowIndex].Cells[i].Value.ToString ();
                    moveRowValueStr[i] = dataGridView1.Rows[selectRowIndex - 1].Cells[i].Value.ToString ();
                }

                dataGridView1.Rows.RemoveAt ( selectRowIndex );
                dataGridView1.Rows.Insert ( selectRowIndex - 1, selectRowValueStr );
                dataGridView1.Rows.RemoveAt ( selectRowIndex );
                dataGridView1.Rows.Insert ( selectRowIndex, moveRowValueStr );

                foreach ( DataGridViewRow item in dataGridView1.Rows ) {
                    item.Selected = false;
                }
                dataGridView1.Rows[selectRowIndex - 1].Selected = true;
            } catch { return; }
        }

        // Down
        private void button_itemDown_Click ( object sender, EventArgs e ) {
            try {
                if ( dataGridView1.SelectedCells.Count == 0 || dataGridView1.SelectedRows.Count > 1 ) {
                    MessageBox.Show ( "セルまたは行を1つ選択してください" );
                    return;
                }

                string[] selectRowValueStr = new string[dataGridView1.ColumnCount];
                string[] moveRowValueStr = new string[dataGridView1.ColumnCount];
                var selectRowIndex = dataGridView1.SelectedCells[0].RowIndex;

                for ( int i = 0; i < dataGridView1.ColumnCount; i++ ) {
                    selectRowValueStr[i] = dataGridView1.Rows[selectRowIndex].Cells[i].Value.ToString ();
                    moveRowValueStr[i] = dataGridView1.Rows[selectRowIndex + 1].Cells[i].Value.ToString ();
                }

                dataGridView1.Rows.RemoveAt ( selectRowIndex );
                dataGridView1.Rows.Insert ( selectRowIndex + 1, selectRowValueStr );
                dataGridView1.Rows.RemoveAt ( selectRowIndex );
                dataGridView1.Rows.Insert ( selectRowIndex, moveRowValueStr );

                foreach ( DataGridViewRow item in dataGridView1.Rows ) {
                    item.Selected = false;
                }
                dataGridView1.Rows[selectRowIndex + 1].Selected = true;
            } catch { return; }
        }
        #endregion

        // Form1がアクティブになったらメインメニューアイテムもアクティブにする
        private bool act = false;
        private bool actWorkEnd = false;
        private void Form1_Activated ( object sender, EventArgs e ) {
            if ( act ) return;
            act = true;
            actWorkEnd = false;
            foreach ( var item in mainMenuItem ) {
                item.Activate ();
            }
            this.Activate ();
            actWorkEnd = true;
        }

        private void Form1_Deactivate ( object sender, EventArgs e ) {
            if ( actWorkEnd ) act = false;
        }
    }
}
