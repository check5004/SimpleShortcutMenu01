using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    public partial class SecondMenuForm : Form {

        private SecondMenuItem[] manySecoundMenuItemButton;
        /// <summary>
        /// メインメニューで選択された項目名
        /// </summary>
        private string selectMainMenuItemName;
        private List<DataRow> secondMenuItemData = new List<DataRow> ();

        /// <summary>
        /// セカンドメニューフォーム
        /// </summary>
        /// <param name="selectMainMenuItemName">メインメニューで選択された項目名</param>
        public SecondMenuForm ( string selectMainMenuItemName ) {
            InitializeComponent ();
            this.Visible = false;
            this.selectMainMenuItemName = selectMainMenuItemName;

            // セカンド項目取得
            secondMenuItemData = Config.dataSet_MenuItems.AsEnumerable ().Where ( r => r.Field<string> ( "menuName" ) == selectMainMenuItemName ).ToList ();
        }

        private void SecondMenuForm_Load ( object sender, EventArgs e ) {
            // セカンドメニューがないやつ
            if ( selectMainMenuItemName == "CopyApp" || selectMainMenuItemName == "CalcApp" ) {
                this.Visible = false;
                this.Opacity = 0;
            }

            // Config Set
            Config.secondMenuForm = this;

            this.manySecoundMenuItemButton = null;

            // ----- アイテム表示 -----
            int elementNum = secondMenuItemData.Count;

            // アイテムを設定
            string[] title = new string[elementNum];

            // フォームサイズ
            double formsize = 0;

            this.manySecoundMenuItemButton = new SecondMenuItem[elementNum];

            for ( int i = 0; i < elementNum; i++ ) {

                title[i] = secondMenuItemData[i]["title"].ToString ();

                // インスタンス作成
                this.manySecoundMenuItemButton[i] = new SecondMenuItem ();
                // 名前とテキストのプロパティを設定
                this.manySecoundMenuItemButton[i].Name = "SecondMenuItem" + i;
                this.manySecoundMenuItemButton[i].Text = "SecondMenuItem" + ( i + 1 );
                this.manySecoundMenuItemButton[i].labelText = title[i];
                this.manySecoundMenuItemButton[i].secondMenuItemData = this.secondMenuItemData[i];
                this.manySecoundMenuItemButton[i].selectMainMenuItemName = this.selectMainMenuItemName;
                // メッセージを設定
                this.manySecoundMenuItemButton[i].buttonMsg = title[i];
                // サイズと配置
                this.manySecoundMenuItemButton[i].Location = new Point ( 0, i * ( this.manySecoundMenuItemButton[i].Height + 5 ) );

                // フォームへの追加
                this.Controls.Add ( this.manySecoundMenuItemButton[i] );
                // フォームのサイズ取得
                formsize += this.manySecoundMenuItemButton[i].Height + 9;  // なぜ9なのか不明
            }

            // フォームリサイズ
            this.Size = new Size ( this.manySecoundMenuItemButton[0].Width, (int)formsize );
        }

        // 非アクティブ化時
        private void SecondMenuForm_Deactivate ( object sender, EventArgs e ) {
            Config.secondMenuForm.Opacity = 0;
            for ( int i = 0; i < MainMenuShow.mainMenuItem.Count; i++ ) {
                if ( (string)Config.dataSet_MenuItems.Rows[i]["menuName"] == selectMainMenuItemName ) {
                    MainMenuShow.mainMenuItem[i].MainMenuItem_MouseLeave ( sender, e );
                    break;
                }
            }
        }
    }
}
