using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    class MainMenuShow : Form {
        public static List<MainMenuItem> mainMenuItem = new List<MainMenuItem> ();

        public static void mainMenuShow () {
            Config.changing = false;

            // show
            DataSet_MenuItems dataSet_MenuItems = new DataSet_MenuItems ();
            var mainMenuItems = DataLoad.GetXMLDate ( dataSet_MenuItems );
            Config.dataSet_MenuItems = mainMenuItems.Tables[0];

            // メニュー項目名を取得
            var co = new HashSet<string> ();
            for ( int i = 0; i < Config.dataSet_MenuItems.Rows.Count; i++ ) {
                co.Add ( Config.dataSet_MenuItems.Rows[i]["menuName"].ToString () );
            }
            var coClear = co.ToList ();

            Config.mainMenuItemCount = coClear.Count;

            for ( int i = 0; i < Config.mainMenuItemCount; i++ ) {
                mainMenuItem.Add ( new MainMenuItem ( coClear[i] ) );

                mainMenuItem[i].StartPosition = FormStartPosition.Manual;
            }

            // 表示位置指定
            // ------------------ ウインドウを閉じた位置にする --------------------
            mainMenuItem[0].Left = 100;
            mainMenuItem[0].Top = 100;

            // 移動してから表示（カクつかない）
            foreach ( var item in mainMenuItem ) {
                item.Show ();
            }
        }
    }
}
