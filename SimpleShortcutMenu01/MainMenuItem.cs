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

        public MainMenuItem () {
            InitializeComponent ();
        }

        private void MainMenuItem_Load ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, Properties.Resources.テスト修正版01, 220 );

            // 初期化
            Config.mouseHover = false;
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

            int formi = 0;
            // 変更されたフォームと座標取得
            for ( int i = 0; i < Form1.mainMenuItem.Count; i++ ) {
                if ( Form1.mainMenuItem[i] == Config.clickForm ) {
                    formi = i;
                }
            }

            Config.changing = true;

            int count1 = 1;
            int count2 = 1;
            for ( int i = formi - 1; i >= 0; i-- ) {
                Form1.mainMenuItem[i].Location = new Point ( this.Left, this.Top - ( count1 * 100 ) );
                count1++;
            }

            for ( int i = formi + 1; i < Form1.mainMenuItem.Count; i++ ) {
                Form1.mainMenuItem[i].Location = new Point ( this.Left, this.Top + ( count2 * 100 ) );
                count2++;
            }

            Config.changing = false;
            Config.kidou = true;
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
            Layered.UpdateLayer ( this, Properties.Resources.HomeIconYellow, 220 );
            // セカンドメニュー表示
            SecondMenuItemView ( sender );
        }

        /// <summary>
        /// マウスホバーイベント：瞬時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_MouseEnter ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, Properties.Resources.HomeIconDarkYellow, 220 );

            Config.mouseHover = true;  // ???
        }

        /// <summary>
        /// マウスが離れたイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_MouseLeave ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, Properties.Resources.HomeIcon, 220 );

            Config.mouseHover = false;  // ???
        }

        /// <summary>
        /// マウスホバーイベント：一定時間
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuItem_MouseHover ( object sender, EventArgs e ) {
            // 透過画像表示
            Layered.UpdateLayer ( this, Properties.Resources.HomeIconYellow, 220 );
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
            secondMenuForm = new SecondMenuForm ();

            // フォーム表示座標指定
            secondMenuForm.StartPosition = FormStartPosition.Manual;
            secondMenuForm.Location = new Point ( Form1.mainMenuItem[itemNum].Location.X + Form1.mainMenuItem[itemNum].Width, Form1.mainMenuItem[itemNum].Location.Y );

            secondMenuForm.Show ();
        }

    }
}
