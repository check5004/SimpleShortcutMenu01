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
    public partial class SecondMenuForm : Form {

        private SecondMenuItem[] manySecoundMenuItemButton;
        // 選択項目数
        private int elementNum = 10;

        /// <summary>
        /// セカンドメニューフォーム
        /// </summary>
        /// <param name="itemNum">選択項目の配列番号</param>
        public SecondMenuForm () {
            InitializeComponent ();
            this.Visible = false;
        }

        private void SecondMenuForm_Load ( object sender, EventArgs e ) {
            // Config Set
            Config.secondMenuForm = this;

            this.manySecoundMenuItemButton = null;

            // ----- アイテム表示 -----

            // アイテムを設定
            string[] title = new string[elementNum];
            string[] imgpath = new string[elementNum];

            // フォームサイズ
            double formsize = 0;

            this.manySecoundMenuItemButton = new SecondMenuItem[elementNum];

            for ( int i = 0; i < elementNum; i++ ) {
                title[i] = $"Item{i + 1}";

                // インスタンス作成
                this.manySecoundMenuItemButton[i] = new SecondMenuItem ();
                // 名前とテキストのプロパティを設定
                this.manySecoundMenuItemButton[i].Name = "SecondMenuItem" + i;
                this.manySecoundMenuItemButton[i].Text = "SecondMenuItem" + ( i + 1 );
                this.manySecoundMenuItemButton[i].labelText = "MenuItem" + ( i + 1 );
                this.manySecoundMenuItemButton[i].imagePath = @"C:\Users\check\Source\Repos\check5004\SimpleShortcutMenu01\SimpleShortcutMenu01\Resources\テスト修正版01.png";
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
    }
}
