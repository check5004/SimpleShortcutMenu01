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
    public partial class MainMenuItem : UserControl {
        public MainMenuItem () {
            InitializeComponent ();
        }

        /// <summary>
        /// クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click ( object sender, EventArgs e ) {
            pictureBox1.ImageLocation = @"C:\Users\CRCL082\source\repos\SimpleShortcutMenu01\SimpleShortcutMenu01\IconImage\HomeIconYellow.png";
        }

        /// <summary>
        /// マウスホバー：瞬時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseEnter ( object sender, EventArgs e ) {
            pictureBox1.ImageLocation = @"C:\Users\CRCL082\source\repos\SimpleShortcutMenu01\SimpleShortcutMenu01\IconImage\HomeIconDarkYellow.png";
        }

        /// <summary>
        /// マウスが離れた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Mouseleave ( object sender, EventArgs e ) {
            pictureBox1.ImageLocation = @"C:\Users\CRCL082\source\repos\SimpleShortcutMenu01\SimpleShortcutMenu01\IconImage\HomeIcon.png";
        }
    }
}
