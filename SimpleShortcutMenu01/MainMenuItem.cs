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
    public partial class MainMenuItem : Form {
        public MainMenuItem () {
            InitializeComponent ();
        }

        private void MainMenuItem_Load ( object sender, EventArgs e ) {
            Layered.UpdateLayer ( this, Properties.Resources.テスト修正版01, 220 );
        }

        #region マウス操作イベント群
        //private Point mousePoint;

        private void MainMenuItem_MouseDown ( object sender, MouseEventArgs e ) {
            if ( ( e.Button & MouseButtons.Left ) == MouseButtons.Left ) {
                Config.mousePoint = e.Location;
                Config.clickForm = sender;
            }
        }

        private void MainMenuItem_MouseMove ( object sender, MouseEventArgs e ) {
            if ( ( e.Button & MouseButtons.Left ) == MouseButtons.Left ) {
                this.Left += e.X - Config.mousePoint.X;
                this.Top += e.Y - Config.mousePoint.Y;
            }
        }

        private void MainMenuItem_DoubleClick ( object sender, EventArgs e ) {
            Close ();
        }
        #endregion

        private void MainMenuItem_LocationChanged ( object sender, EventArgs e ) {
            if ( Config.changing ) {
                return;
            }


            int formi = 0;
            // 変更されたフォームと座標取得
            for ( int i = 0; i < Form1.mainMenuItem.Count; i++ ) {
                if ( Form1.mainMenuItem[i] == Config.clickForm ) {
                    formi = i;
                }
            }

            Config.changing = true;

            int count1 = 1;
            int count2 = 1;
            for ( int i = formi - 1; i >= 0; i-- ) {
                Form1.mainMenuItem[i].Location = new Point ( this.Left, this.Top - ( count1 * 100 ) );
                count1++;
            }

            for ( int i = formi + 1; i < Form1.mainMenuItem.Count; i++ ) {
                Form1.mainMenuItem[i].Location = new Point ( this.Left, this.Top + ( count2 * 100 ) );
                count2++;
            }

            Config.changing = false;
            Config.kidou = true;
        }
    }
}
