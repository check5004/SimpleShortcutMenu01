using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    class Config {
        /// <summary>
        /// マウス座標
        /// </summary>
        public static Point mousePoint { get; set; }

        /// <summary>
        /// クリックしたフォーム
        /// </summary>
        public static object clickForm { get; set; }

        /// <summary>
        /// セカンドメニューフォームのFormデータ
        /// </summary>
        public static System.Windows.Forms.Form secondMenuForm { get; set; }

        /// <summary>
        /// 起動チェック
        /// </summary>
        public static bool kidou { get; set; }  // test
        public static bool changing { get; set; }
        public static int mainMenuItemCount { get; set; }

        // Data
        public string xmlFilePath { get; }

        public static System.Data.DataTable dataSet_MenuItems { get; set; }

        public Config () {
            // Get xml file path.
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format ( "{0}Resources\\menuItemData.xml", Path.GetFullPath ( Path.Combine ( RunningPath, @"..\..\" ) ) );
            xmlFilePath = FileName;
        }
    }
}
