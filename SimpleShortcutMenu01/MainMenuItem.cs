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
    public partial class MainMenuItem : Form {
        SecondMenuForm secondMenuForm = null;
        private string mainMenuItemName;
        private Bitmap imageGray = Properties.Resources.InternetGray;
        private Bitmap imageYellow = Properties.Resources.InternetYellow;
        private Bitmap imageDarkYellow = Properties.Resources.InternetDarkYellow;

        public MainMenuItem ( string mainMenuItemName ) {
            InitializeComponent ();
            this.mainMenuItemName = mainMenuItemName;
        }

        private void MainMenuItem_Load ( object sender, EventArgs e ) {
            imageGray = Properties.Resources.InternetGray;  // default
            switch ( this.mainMenuItemName ) {
                case "Web":
                    imageGray = Properties.Resources.InternetGray;
                    imageYellow = Properties.Resources.InternetYellow;
                    imageDarkYellow = Properties.Resources.InternetDarkYellow;
                    break;
                case "App":
                    imageGray = Properties.Resources.AppGray;
                    imageYellow = Properties.Resources.AppYellow;
                    imageDarkYellow = Properties.Resources.AppDarkYellow;
                    break;
                case "CalcApp":
                    imageGray = Properties.Resources.CalcGray;
                    imageYellow = Properties.Resources.CalcYellow;
                    imageDarkYellow = Properties.Resources.CalcDarkYellow;
                    break;
                case "CopyApp":
                    imageGray = Properties.Resources.CopyGray;
                    imageYellow = Properties.Resources.CopyYellow;
                    imageDarkYellow = Properties.Resources.CopyDarkYellow;
                    break;
                case "Folder":
                    imageGray = Properties.Resources.FolderGray;
                    imageYellow = Properties.Resources.FolderYellow;
                    imageDarkYellow = Properties.Resources.FolderDarkYellow;
                    break;
                case "Setting":
                    imageGray = Properties.Resources.SettingGray;
                    imageYellow = Properties.Resources.SettingYellow;
                    imageDarkYellow = Properties.Resources.SettingDarkYellow;
                    break;
            }
            // 透過画像表示
            Layered.UpdateLayer ( this, imageGray, 220 );
        }


        /// <summary>
        /// フォームを移動した
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_LocationChanged ( object sender, EventArgs e ) {
            if ( Config.changing ) {
                return;
            }

            Config.changing = true;

            int formi = 0;
            // 変更されたフォームと座標取得
            for ( int i = 0; i < Form1.mainMenuItem.Count; i++ ) {
                if ( Form1.mainMenuItem[i] == Config.clickForm ) {
                    formi = i;
                }
            }

            int count1 = 1;
            int count2 = 1;
            for ( int i = formi - 1; i >= 0; i-- ) {
                Form1.mainMenuItem[i].Location = new Point ( this.Left, this.Top - ( count1 * 75 ) );
                count1++;
            }

            for ( int i = formi + 1; i < Form1.mainMenuItem.Count; i++ ) {
                Form1.mainMenuItem[i].Location = new Point ( this.Left, this.Top + ( count2 * 75 ) );
                count2++;
            }

            Config.changing = false;
        }


        #region マウス操作イベント群
        //private Point mousePoint;
        private void MainMenuItem_MouseDown ( object sender, MouseEventArgs e ) {
            if ( ( e.Button & MouseButtons.Left ) == MouseButtons.Left ) {
                Config.mousePoint = e.Location;
                Config.clickForm = sender;
            }
        }

        private void MainMenuItem_MouseMove ( object sender, MouseEventArgs e ) {
            if ( ( e.Button & MouseButtons.Left ) == MouseButtons.Left ) {
                this.Left += e.X - Config.mousePoint.X;
                this.Top += e.Y - Config.mousePoint.Y;

                // セカンドフォームが表示されていたら閉じる
                if ( Config.secondMenuForm != null ) {
                    Config.secondMenuForm.Close ();
                    Config.secondMenuForm = null;
                }
            }
        }

        private void MainMenuItem_DoubleClick ( object sender, EventArgs e ) {
            //Close ();
        }
        #endregion マウス操作イベント群


        /// <summary>
        /// マウスクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_Click ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, imageYellow, 220 );
            // セカンドメニュー表示
            //SecondMenuItemView ( sender );
        }

        /// <summary>
        /// マウスホバーイベント：瞬時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_MouseEnter ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, imageDarkYellow, 220 );

            // アプリ全体をアクティブにする
            // どのイベントでやるか要検討
            foreach ( var item in Form1.mainMenuItem ) {
                item.Activate ();
            }
        }

        /// <summary>
        /// マウスが離れたイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_MouseLeave ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, imageGray, 220 );

            // セカンドフォームが表示されていたら閉じる
            //System.Threading.Thread.Sleep ( 100 );
            //if ( Config.secondMenuForm != null && Config.secondMenuFormInMouse == true) {
            //    Config.secondMenuForm.Close ();
            //    Config.secondMenuForm = null;
            //}
        }

        /// <summary>
        /// マウスホバーイベント：一定時間
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_MouseHover ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, imageYellow, 220 );
            // セカンドメニュー表示
            SecondMenuItemView ( sender );
        }

        /// <summary>
        /// セカンドメニュー表示
        /// </summary>
        /// <param name="sender"></param>
        private void SecondMenuItemView ( object sender ) {
            // セカンドフォームが表示されていたら閉じる
            if ( Config.secondMenuForm != null ) {
                Config.secondMenuForm.Close ();
                Config.secondMenuForm = null;
            }

            int itemNum = 0;  // 選択項目配列番号
            // 選択項目取得
            for ( int i = 0; i < Config.mainMenuItemCount; i++ ) {
                if ( sender == Form1.mainMenuItem[i] ) {
                    itemNum = i;
                }
            }

            // セカンドメニューフォームを表示する
            secondMenuForm = new SecondMenuForm ( mainMenuItemName );

            // フォーム表示座標指定
            secondMenuForm.StartPosition = FormStartPosition.Manual;
            secondMenuForm.Location = new Point ( Form1.mainMenuItem[itemNum].Location.X + Form1.mainMenuItem[itemNum].Width, (int)Form1.mainMenuItem[itemNum].Location.Y + 5 );  // 要調整！！！！！！！！！！！！！！！！！！！！！

            secondMenuForm.Show ();
        }

    }
}
