using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01
{
    /// <summary>
    /// [MainMenu] ラベルプロパティ設定クラス
    /// </summary>
    class MainMenuLabel : Label
    {
        /// <summary>
        /// ラベル用イベントセット
        /// </summary>
        public void labelEventMaking()
        {
            // クリックイベント追加
            this.Click += new EventHandler(doClickEvent);
            // マウスホバーイベント追加
            this.MouseHover += new EventHandler(doMouseHover);
        }


        /// <summary>
        /// ラベルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doClickEvent(object sender, EventArgs e)
        {
            return;
        }

        /// <summary>
        /// マウスホバーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doMouseHover(object sender, EventArgs e)
        {
            return;
        }
    }
}
