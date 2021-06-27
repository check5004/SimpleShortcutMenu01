using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        public string selectMainMenuitemName { get; set; }



        public SecondMenuItem () {
            InitializeComponent ();
        }

        /// <summary>
        /// Secondメニュー：クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondMenuItemClick ( object sender, EventArgs e ) {
            // クリック時
            this.BackColor = Color.Yellow;
            switch ( selectMainMenuitemName ) {
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
                        MessageBox.Show ( "アプリを起動できません。" );
                    }
                    break;
                case "Folder":

                    break;
                case "Setting":
                    try {
                        switch ( secondMenuItemData["url"].ToString () ) {
                            case "Form1":  // DataGridViewForm
                                Form1 form1 = new Form1 ();
                                form1.Show ();
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
            // マウスホバー時
            //this.BackColor = Color.Yellow;
            //this.BackColor = Color.FromArgb ( 180, 180, 0 );
        }

        /// <summary>
        /// Secoundメニュー：マウスホバー離れた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecoundMenuItemMouseLeave ( object sender, EventArgs e ) {
            this.BackColor = Color.FromArgb ( 200, 200, 200 );
        }

        private void SecondMenuItem_Load ( object sender, EventArgs e ) {
            this.label1.Text = labelText;
            // 画像パス設定
            if ( imagePath == "" || imagePath == null ) {
                this.pictureBox1.Image = iconBitmap == null ? Properties.Resources.NotFoundGray : iconBitmap;
            } else {
                this.pictureBox1.ImageLocation = imagePath;
            }
            this.BackColor = Color.FromArgb ( 200, 200, 200 );
        }

        /// <summary>
        /// Secoundメニュー：マウスホバーイベント(瞬時)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecoundMenuItemMouseEnter ( object sender, EventArgs e ) {
            this.BackColor = Color.FromArgb ( 180, 180, 0 );
        }

        private void SecondMenuItem_MouseDown ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                this.BackColor = Color.Yellow;
            }
        }
    }
}
