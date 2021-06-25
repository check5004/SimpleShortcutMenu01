using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShortcutMenu01 {
    class DataLoad {
        /// <summary>XMLファイルをデータセットに読み込む
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="xmlFilePath"></param>
        /// <returns></returns>
        public static DataSet GetXMLDate ( DataSet ds ) {
            Config config = new Config ();
            string xmlFilePath = config.xmlFilePath;

            //XMLファイルが存在するか
            if ( File.Exists ( xmlFilePath ) ) {
                //存在する場合

                //XMLファイルを読み込む
                StreamReader sr = new StreamReader ( xmlFilePath, System.Text.Encoding.GetEncoding ( "utf-8" ) );
                ds.ReadXml ( sr );
                sr.Close ();
            }

            return ds;
        }
        /// <summary>データセットをXMLファイルに出力
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="xmlFilePath"></param>
        public static void OutputXML ( DataSet ds ) {
            Config config = new Config ();
            string xmlFilePath = config.xmlFilePath;

            //XMLファイル出力
            StreamWriter sr = new StreamWriter ( xmlFilePath, false, System.Text.Encoding.GetEncoding ( "utf-8" ) );
            ds.WriteXml ( sr );
            sr.Close ();
        }
    }
}
