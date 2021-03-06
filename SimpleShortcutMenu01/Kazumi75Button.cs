using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    // オリジナルのボタンを定義する(WindowsフォームのButtonを継承)
    public class Kazumi75Button : Button {
        // ボタンを押して表示される文言テキスト
        public string buttonMsg { get; set; }

        // リストボックスを参照させる
        public ListBox targetLbox { get; set; }

        // ボタンへのイベントをセットする
        public void eventMaking () {
            this.Click += new EventHandler ( doClickEvent );
            this.MouseHover += new EventHandler ( doMouseHover );
        }

        // ボタンへのイベントを解除する
        public void eventSuspend () {
            this.Click -= new EventHandler ( doClickEvent );
        }

        // クリックイベントの実体(参照するリストボックスに文言テキストを追加)
        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void doClickEvent ( object sender, EventArgs e ) {
            this.targetLbox.Items.Add ( this.buttonMsg );
        }

        /// <summary>
        /// マウスホバーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void doMouseHover ( object sender, EventArgs e ) {
            this.targetLbox.Items.Add ( this.buttonMsg );
        }
    }
}
