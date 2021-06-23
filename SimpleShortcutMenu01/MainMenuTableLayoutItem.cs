using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    /// <summary>
    /// メインメニュー：テーブルレイアウト
    /// </summary>
    class MainMenuTableLayoutItem : TableLayoutPanel {
        /// <summary>
        /// メインメニューのテーブルレイアウトにイベントをセット
        /// </summary>
        public void MenuItemTableLayoutEventMaking () {
            this.Click += new EventHandler ( doClickEvent );
            this.MouseHover += new EventHandler ( doMouseHover );


        }


        /// <summary>
        /// テーブルレイアウト：クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doClickEvent (object sender, EventArgs e) {
            return;
        }

        /// <summary>
        /// テーブルレイアウト：マウスホバーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doMouseHover(object sender, EventArgs e ) {
            return;
        }
    }

    /// <summary>
    /// メインメニュー：テーブルレイアウト in ラベル
    /// </summary>
    class MainMenuTableLayoutInLabel : Label {

    }
}
