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
    public partial class Form1 : Form {
        // フォーム呼び出しで作成するボタン(Windowsフォームのボタン - Buttonを継承する)
        //private Kazumi75Button[] manyButtons;
        private SecondMenuItem[] manySecoundMenuItemButton;

        // 配列の要素数(ここでは5個)
        private const int ElementNum = 10;

        public Form1 () {
            InitializeComponent ();

            // show
            FormMainMenu formMainMenu = new FormMainMenu ();
            formMainMenu.Show ();

            // 背景透明
            //this.TransparencyKey = this.BackColor;

            this.manySecoundMenuItemButton = null;
        }


        int i = 0;

        // フォームを呼び出すボタン
        private void button1_Click ( object sender, EventArgs e ) {
            if ( ElementNum <= i ) {
                MessageBox.Show ( "追加上限です" );
                return;
            }

            // ボタンの各メッセージはここであらかじめ設定する
            string[] msgs = new string[ElementNum];
            msgs[i] = $"Item{i + 1}";

            #region ButtonVersion
            /*
            // ボタンの作成(Windowsフォームのボタンを継承する)
            this.manyButtons = new Kazumi75Button[ElementNum];

            //for ( int i = 0; i < this.manyButtons.Length; i++ ) {


            // インスタンス作成
            this.manyButtons[i] = new Kazumi75Button ();

            // 名前とテキストのプロパティを設定
            this.manyButtons[i].Name = "OriginalButton" + i;
            this.manyButtons[i].Text = "ボタン" + ( i + 1 );

            // ボタンクリック時に参照するリストボックスを指定
            this.manyButtons[i].targetLbox = listBox1;

            // メッセージを設定
            this.manyButtons[i].buttonMsg = msgs[i];

            // サイズと配置
            this.manyButtons[i].Size = new Size ( 120, 50 );
            this.manyButtons[i].Location = new Point ( 10, 10 + i * 52 );

            // フォームへの追加
            this.Controls.Add ( this.manyButtons[i] );

            // クリック時のボタンごとのイベント動作を作成する
            this.manyButtons[i].eventMaking ();
            //}
            */
            #endregion

            #region original
            // test
            this.manySecoundMenuItemButton = new SecondMenuItem[ElementNum];
            // インスタンス作成
            this.manySecoundMenuItemButton[i] = new SecondMenuItem ();
            // 名前とテキストのプロパティを設定
            this.manySecoundMenuItemButton[i].Name = "SecondMenuItem" + i;
            this.manySecoundMenuItemButton[i].Text = "SecondMenuItem" + ( i + 1 );
            this.manySecoundMenuItemButton[i].labelText = "MenuItem" + ( i + 1 );
            // ボタンクリック時に参照するリストボックスを指定
            this.manySecoundMenuItemButton[i].targetLbox = listBox1;
            // メッセージを設定
            this.manySecoundMenuItemButton[i].buttonMsg = msgs[i];
            // サイズと配置
            //this.manySecoundMenuItemButton[i].Size = new Size ( 120, 50 );
            this.manySecoundMenuItemButton[i].Location = new Point ( 10, 10 + i * 47 );
            // フォームへの追加
            this.Controls.Add ( this.manySecoundMenuItemButton[i] );

            // クリック時のボタンごとのイベント動作を作成する
            //this.manySecoundMenuItemButton[i]eventMaking ();

            #endregion

            i++;
        }
    }
}
