using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    public partial class SecondMenuItem : UserControl {
        // ボタンを押して表示される文言テキスト
        public string buttonMsg { get; set; }
        /// <summary>
        /// ラベルに出力するテキスト
        /// </summary>
        public string labelText { get; set; }
        /// <summary>
        /// アイコン画像のパス
        /// </summary>
        public string imagePath { get; set; }
        public Bitmap iconBitmap { get; set; }
        public DataRow secondMenuItemData { get; set; }
        public string selectMainMenuItemName { get; set; }

        private BackgroundWorker _getImageWorker = new BackgroundWorker ();
        private Bitmap iconImage = null;
        private WebPreviewDialog webPreviewDialog;


        public SecondMenuItem () {
            InitializeComponent ();
            _getImageWorker.DoWork += _getImageWorker_DoWork;
            _getImageWorker.RunWorkerCompleted += _getImageWorker_RunWorkerCompleted;
        }

        private void SecondMenuItem_Load ( object sender, EventArgs e ) {
            this.label1.Text = labelText;
            this.pictureBox1.Image = Properties.Resources.NotFoundGray;
            _getImageWorker.RunWorkerAsync ();

            this.BackColor = Color.FromArgb ( 200, 200, 200 );
        }

        #region 画像取得
        /// <summary>
        /// 画像取得(非同期)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _getImageWorker_DoWork ( object sender, DoWorkEventArgs e ) {
            try {
                switch ( this.selectMainMenuItemName ) {
                    case "Web":
                        if ( (string)secondMenuItemData["imagePath"] == "" ) {
                            secondMenuItemData["imagePath"] = secondMenuItemData["url"].ToString () + @"/favicon.ico";

                            WebRequest.DefaultWebProxy = null; // プロキシ未使用を明示

                            HttpStatusCode statusCode = GetStatusCode ( secondMenuItemData["imagePath"].ToString () );

                            int code = (int)statusCode; // 列挙体の値を数値に変換
                            if ( code >= 400 ) { // 4xx、5xxはアクセス失敗とする
                                secondMenuItemData["imagePath"] = "";
                            }
                        }
                        break;
                    case "App":
                        // ソフトのショートカットアイコンを取得
                        Icon appIcon = System.Drawing.Icon.ExtractAssociatedIcon ( secondMenuItemData["url"].ToString () );
                        iconImage = appIcon.ToBitmap ();
                        break;
                    case "Folder":
                        if ( (string)secondMenuItemData["scondMenuName"] == "Folder" ) { iconImage = Properties.Resources.FolderGray; }
                        if ( (string)secondMenuItemData["scondMenuName"] == "File" ) { iconImage = Properties.Resources.FileGray; }
                        break;
                    case "Setting":
                        iconImage = Properties.Resources.SettingGray;
                        break;
                }
            } catch { }
        }

        /// <summary>
        /// 取得した画像を貼り付け
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _getImageWorker_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e ) {
            if ( (string)secondMenuItemData["imagePath"] == "" ) {
                iconBitmap = iconImage;
            } else {
                imagePath = secondMenuItemData["imagePath"].ToString ();
            }

            // 画像パス設定
            if ( imagePath == "" || imagePath == null ) {
                this.pictureBox1.Image = iconBitmap == null ? Properties.Resources.NotFoundGray : iconBitmap;
            } else {
                this.pictureBox1.ImageLocation = imagePath;
            }
        }
        #endregion 画像取得


        /// <summary>
        /// Secondメニュー：クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondMenuItemClick ( object sender, EventArgs e ) {
            // クリック時
            this.BackColor = Color.FromArgb ( 248, 206, 43 );

            switch ( selectMainMenuItemName ) {
                case "Web":
                    try {
                        System.Diagnostics.Process.Start ( secondMenuItemData["url"].ToString () );
                    } catch {
                        MessageBox.Show ( "Webサイトが開けません" );
                    }
                    break;
                case "App":
                    try {
                        System.Diagnostics.Process p = new System.Diagnostics.Process ();
                        //起動する実行ファイルのパスを設定する
                        p.StartInfo.FileName = secondMenuItemData["url"].ToString ();
                        //起動する。プロセスが起動した時はTrueを返す。
                        p.Start ();
                    } catch {
                        MainMenuItem.iCanNotActivateTheApp ();
                    }
                    break;
                case "Folder":

                    break;
                case "Setting":
                    try {
                        switch ( secondMenuItemData["url"].ToString () ) {
                            case "Form1":  // DataGridViewForm
                                DataGridViewForm dataGridViewForm = new DataGridViewForm ();
                                dataGridViewForm.Show ();
                                break;
                            case "Logout":
                                try { Config.mainMenuShowForm.Close (); } catch { }
                                break;
                        }
                    } catch {
                        MessageBox.Show ( "Form open error..." );
                    }
                    break;
            }
        }

        /// <summary>
        /// Secoundメニュー：マウスホバーイベント(すこし留まった時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecoundMenuItemMouseHover ( object sender, EventArgs e ) {

            //if ( webPreviewDialog != null ) {
            //    webPreviewDialog.Close ();
            //    webPreviewDialog = null;
            //}

            switch ( selectMainMenuItemName ) {
                case "Web":
                    // web preview show!!
                    //webPreviewDialog = new WebPreviewDialog ( secondMenuItemData );
                    if ( webPreviewDialog == null ) {
                        webPreviewDialog = new WebPreviewDialog ();
                    }
                    webPreviewDialog.Hide ();
                    webPreviewDialog.RefreshWebPage ( secondMenuItemData );

                    //webPreviewDialog.Opacity = 0;
                    webPreviewDialog.Location = new Point ( Config.secondMenuForm.Location.X + this.Width + 10, Config.secondMenuForm.Location.Y + this.Location.Y + (int)Math.Floor ( (double)this.Height / 2 ) - (int)Math.Floor ( (double)webPreviewDialog.maxHeight / 2 ) );
                    webPreviewDialog.Show (this);
                    //webPreviewDialog.Opacity = 100;
                    Config.secondMenuForm.Opacity = 100;
                    break;
            }

            for ( int i = 0; i < MainMenuShow.mainMenuItem.Count; i++ ) {
                if ( (string)Config.dataSet_MenuItems.Rows[i]["menuName"] == selectMainMenuItemName ) {
                    MainMenuShow.mainMenuItem[i].MainMenuItem_MouseLeave ( sender, e );
                    break;
                }
            }
        }

        /// <summary>
        /// Secoundメニュー：マウスホバー離れた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecoundMenuItemMouseLeave ( object sender, EventArgs e ) {
            this.BackColor = Color.FromArgb ( 200, 200, 200 );
            //if ( webPreviewDialog != null ) {
            //    webPreviewDialog.Close ();
            //    webPreviewDialog = null;
            //}
            webPreviewDialog?.Hide ();
        }


        /// <summary>
        /// Secoundメニュー：マウスホバーイベント(瞬時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecoundMenuItemMouseEnter ( object sender, EventArgs e ) {
            this.BackColor = Color.FromArgb ( 162, 129, 0 );
        }

        private void SecondMenuItem_MouseDown ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                this.BackColor = Color.FromArgb ( 248, 206, 43 );
            }
        }


        /// <summary>
        /// urlにアクセスしてステータス・コードを返す
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public HttpStatusCode GetStatusCode ( string url ) {
            try {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create ( url );
                req.Method = WebRequestMethods.Http.Get;
                req.Timeout = 2800;
                req.ReadWriteTimeout = 2800;

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
                        //return (HttpStatusCode)404;
                        throw; // サーバ接続不可などの場合は再スロー
                    }
                } finally {
                    if ( res != null ) {
                        res.Close ();
                    }
                }
                Debug.WriteLine ( url + " : " + (int)statusCode );
                return statusCode;
            } catch ( Exception ) {
                return (HttpStatusCode)404;
            }
        }
    }
}
