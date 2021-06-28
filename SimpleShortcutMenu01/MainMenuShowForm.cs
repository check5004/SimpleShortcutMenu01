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
    public partial class MainMenuShowForm : Form {
        public MainMenuShowForm () {
            InitializeComponent ();

            MainMenuShow.mainMenuShow ();
        }

        // MainMenuShowFormがアクティブになったらメインメニューアイテムもアクティブにする
        private bool act = false;
        private bool actWorkEnd = false;
        private void MainMenuShowForm_Activated ( object sender, EventArgs e ) {
            if ( act ) return;
            act = true;
            actWorkEnd = false;
            foreach ( var item in MainMenuShow.mainMenuItem ) {
                item.Activate ();
            }
            this.Activate ();
            actWorkEnd = true;
        }

        private void MainMenuShowForm_Deactivate ( object sender, EventArgs e ) {
            if ( actWorkEnd ) act = false;
        }
    }
}
