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
                Bitmap iconImage = null;
                try {
                    switch ( this.selectMainMenuItemName ) {
                        case "Web":
                            if ( (string)secondMenuItemData[i]["imagePath"] == "" ) {
                                secondMenuItemData[i]["imagePath"] = secondMenuItemData[i]["url"].ToString () + @"/favicon.ico";

                                //string url = "http://www.atmarkit.co.jp/nosuchpage.html";
                                WebRequest.DefaultWebProxy = null; // プロキシ未使用を明示

                                HttpStatusCode statusCode = GetStatusCode ( secondMenuItemData[i]["imagePath"].ToString () );

                                int code = (int)statusCode; // 列挙体の値を数値に変換

                                if ( code >= 400 ) { // 4xx、5xxはアクセス失敗とする
                                    secondMenuItemData[i]["imagePath"] = "";
                                } 
                                //else {
                                //    Console.WriteLine ( "ページは存在します：" + code );
                                //}
                            }
                            break;
                        case "App":
                            // ソフトのショートカットアイコンを取得
                            Icon appIcon = System.Drawing.Icon.ExtractAssociatedIcon ( secondMenuItemData[i]["url"].ToString () );
                            iconImage = appIcon.ToBitmap ();
                            break;
                        case "Folder":
                            if ( (string)secondMenuItemData[i]["scondMenuName"] == "Folder" ) { iconImage = Properties.Resources.FolderGray; }
                            if ( (string)secondMenuItemData[i]["scondMenuName"] == "File" ) { iconImage = Properties.Resources.FileGray; }
                            break;
                        case "Setting":
                            iconImage = Properties.Resources.SettingGray;
                            break;
                    }
                } catch { }

                title[i] = secondMenuItemData[i]["title"].ToString ();

                // インスタンス作成
                this.manySecoundMenuItemButton[i] = new SecondMenuItem ();
                // 名前とテキストのプロパティを設定
                this.manySecoundMenuItemButton[i].Name = "SecondMenuItem" + i;
                this.manySecoundMenuItemButton[i].Text = "SecondMenuItem" + ( i + 1 );
                this.manySecoundMenuItemButton[i].labelText = title[i];
                if ( (string)secondMenuItemData[i]["imagePath"] == "" ) {
                    this.manySecoundMenuItemButton[i].iconBitmap = iconImage;
                } else {
                    this.manySecoundMenuItemButton[i].imagePath = secondMenuItemData[i]["imagePath"].ToString ();
                }
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

        /// <summary>
        /// urlにアクセスしてステータス・コードを返す
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public HttpStatusCode GetStatusCode ( string url ) {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create ( url );
            HttpWebResponse res = null;
            HttpStatusCode statusCode;

            try {
                res = (HttpWebResponse)req.GetResponse ();
                statusCode = res.StatusCode;
            } catch ( WebException ex ) {
                res = (HttpWebResponse)ex.Response;
                if ( res != null ) {
                    statusCode = res.StatusCode;
                } else {
                    throw; // サーバ接続不可などの場合は再スロー
                }
            } finally {
                if ( res != null ) {
                    res.Close ();
                }
            }
            return statusCode;
        }

        // 非アクティブ化時
        private void SecondMenuForm_Deactivate ( object sender, EventArgs e ) {
            this.Close ();
        }
    }
}
