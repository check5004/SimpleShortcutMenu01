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
        // フォーム呼び出しで作成するボタン(Windowsフォームのボタン - Buttonを継承する)
        //private Kazumi75Button[] manyButtons;
        private SecondMenuItem[] manySecoundMenuItemButton;

        // 配列の要素数(ここでは5個)
        private const int ElementNum = 10;

        public static List<MainMenuItem> mainMenuItem = new List<MainMenuItem> ();

        public Form1 () {
            InitializeComponent ();

            Config.changing = false;
            // test


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
                //mainMenuItem[i].Show ();
            }

            // 表示位置指定
            // ------------------ ウインドウを閉じた位置にする --------------------
            mainMenuItem[0].Left = 100;
            mainMenuItem[0].Top = 100;

            // 移動してから表示（カクつかない）
            foreach ( var item in mainMenuItem ) {
                item.Show ();
            }

            this.manySecoundMenuItemButton = null;
        }

        int i = 0;

        // フォームを呼び出すボタン
        private void button1_Click ( object sender, EventArgs e ) {
            if ( ElementNum <= i ) {
                MessageBox.Show ( "追加上限です" );
                return;
            }

            // ボタンの各メッセージはここであらかじめ設定する
            string[] msgs = new string[ElementNum];
            msgs[i] = $"Item{i + 1}";

            #region original
            // test
            //this.manySecoundMenuItemButton = new SecondMenuItem[ElementNum];
            //// インスタンス作成
            //this.manySecoundMenuItemButton[i] = new SecondMenuItem ();
            //// 名前とテキストのプロパティを設定
            //this.manySecoundMenuItemButton[i].Name = "SecondMenuItem" + i;
            //this.manySecoundMenuItemButton[i].Text = "SecondMenuItem" + ( i + 1 );
            //this.manySecoundMenuItemButton[i].labelText = "MenuItem" + ( i + 1 );
            //this.manySecoundMenuItemButton[i].imagePath = @"";
            //// ボタンクリック時に参照するリストボックスを指定
            //// メッセージを設定
            //this.manySecoundMenuItemButton[i].buttonMsg = msgs[i];
            //// サイズと配置
            ////this.manySecoundMenuItemButton[i].Size = new Size ( 120, 50 );
            //this.manySecoundMenuItemButton[i].Location = new Point ( 10, 10 + i * 47 );
            //// フォームへの追加
            //this.Controls.Add ( this.manySecoundMenuItemButton[i] );
            #endregion

            i++;
        }


        //private DataSet_MenuItems dataSet_MenuItems2 = new DataSet_MenuItems ();

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

            // reload
            //dataSet_MenuItems.Clear ();
            //var mainMenuItems = DataLoad.GetXMLDate ( dataSet_MenuItems );
            //Config.dataSet_MenuItems = mainMenuItems.Tables[0];
            //button_DataSetLoad_Click ( sender, e );
        }

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
    }
}
