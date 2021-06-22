using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01
{
    public partial class Form1 : Form
    {
        // フォーム呼び出しで作成するボタン(Windowsフォームのボタン - Buttonを継承する)
        private Kazumi75Button[] manyButtons;

        // 配列の要素数(ここでは5個)
        private const int ElementNum = 5;

        public Form1()
        {
            InitializeComponent();
            this.manyButtons = null;
        }


        int i = 0;

        // フォームを呼び出すボタン
        private void button1_Click(object sender, EventArgs e)
        {
            if (5 <= i)
            {
                MessageBox.Show("フォームはすでに表示されています");
                return;
            }

            // ボタンの各メッセージはここであらかじめ設定する
            string[] msgs = new string[ElementNum];
            msgs[0] = "浦賀";
            msgs[1] = "鎌倉";
            msgs[2] = "三崎";
            msgs[3] = "観音崎";
            msgs[4] = "横須賀中央";


            // ボタンの作成(Windowsフォームのボタンを継承する)
            this.manyButtons = new Kazumi75Button[ElementNum];

            //for ( int i = 0; i < this.manyButtons.Length; i++ ) {


            // インスタンス作成
            this.manyButtons[i] = new Kazumi75Button();

            // 名前とテキストのプロパティを設定
            this.manyButtons[i].Name = "OriginalButton" + i;
            this.manyButtons[i].Text = "ボタン" + i;

            // ボタンクリック時に参照するリストボックスを指定
            this.manyButtons[i].targetLbox = listBox1;

            // メッセージを設定
            this.manyButtons[i].buttonMsg = msgs[i];

            // サイズと配置
            this.manyButtons[i].Size = new Size(100, 20);
            this.manyButtons[i].Location = new Point(10, 10 + i * 22);

            // フォームへの追加
            this.Controls.Add(this.manyButtons[i]);

            // クリック時のボタンごとのイベント動作を作成する
            this.manyButtons[i].eventMaking();

            i++;  // /////////////////////////////////////////
        }
    }
}
