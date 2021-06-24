using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleShortcutMenu01 {
    class Config : Form {
        /// <summary>
        /// マウス座標
        /// </summary>
        public static Point mousePoint { get; set; }

        public static object clickForm;

        /// <summary>
        /// 起動チェック
        /// </summary>
        public static bool kidou { get; set; }
        public static bool changing { get; set; }
        public static int mainMenuItemCount { get; set; }
    }
}
