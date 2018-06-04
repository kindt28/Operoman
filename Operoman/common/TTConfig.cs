using System;
using System.Text;
using System.Xml;

using System.IO;

namespace Operoman
{
    /////////////////////////////////////////////////////////////////////////////
    /// <summary> and's環境ｸﾗｽ </summary>
    /// <remarks>
    ///     and'sｼｽﾃﾑに必要な環境情報をand's.configより取得/格納する。
    ///     [ 環境定義 ]
    ///         System.config   ... DBﾀｸﾞ           ... DB接続情報
    ///     [ 更新履歴 ]
    ///         Ver 1.0.0       ... 2015.05.27      ... 高村　勉
    ///             新規作成
    /// </remarks>
    public class TTConfig
    {
        /////////////////////////////////////////////////////////////////////////
        #region // 定数
            protected const string    ERRMSG_READERROR      // ｴﾗｰﾒｯｾｰｼﾞ
                = "configリードエラー" + "{1}"
                + "【詳細】" + "{1}"
                + "{0}";
            protected const string    ERRMSG_NOTFOUND       // ｴﾗｰﾒｯｾｰｼﾞ
                = "configファイルが見つからない" + "{1}"
                + "【and's.config パス】" + "{1}"
                + "{0}";
            protected const string    ERRMSG_TAG            // ｴﾗｰﾒｯｾｰｼﾞ
                = "{0}タグが見つからない 又は 値 (value属性)が存在しない" + "{1}";
            protected const string    ERRMSG_NUMERIC        // ｴﾗｰﾒｯｾｰｼﾞ
                = "{0}タグのvaluesには、数値を定義して下さい" + "{2}"
                + "設定値 : {1}" + "{2}";
            protected const string TAG_CFG = "config";      // 設定ﾀｸﾞ
            protected const string TAG_CONNECT = "Connect"; // 接続
            //
            //
            private const string    TAG_DB  = "DB";         // DBﾀｸﾞ
            private const string    TAG_DB_HOST = "HOST";   // ﾎｽﾄ名
            private const string    TAG_DB_PORT = "PORT";   // ﾎﾟｰﾄ番号
            private const string    TAG_DB_NAME = "DBNAME"; // DB名
            private const string    TAG_DB_USER = "USER";   // ﾕｰｻﾞ名
            private const string    TAG_DB_PASS = "PASS";   // ﾊﾟｽﾜｰﾄﾞ
            private const string    TAG_DB_TIMEOUT          // DBﾀｲﾑｱｳﾄ
                = "TIMEOUT";    
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // ﾌﾟﾛﾊﾟﾃｨ
            internal TTConfigDB   DBInfo;                 // DB定義
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // ﾒﾝﾊﾞｰ
            private string         m_sConfig = "";     
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
        /// <remarks>
        ///     設定ﾌｧｲﾙﾊﾟｽを保存
        /// </remarks>
        /// <param name="sPath">configが存在するﾊﾟｽ</param>
        public TTConfig(string sPath)
        {
            return;
            //  //
            //  string sError;
            //  //
            //  // 設定情報ﾊﾟｽ
            //  if (!File.Exists( (m_sConfig = sPath)))
            //  {
            //      // ｴﾗｰｽﾛｰ
            //      throw new TTConfigError(string.Format(ERRMSG_NOTFOUND, m_sConfig, Environment.NewLine));
            //  }
            //  //
            //  // configから定義情報を取得
            //  if ( (sError = LoadDB()) != "" )
            //  {
            //      // ｴﾗｰｽﾛｰ
            //      throw new TTConfigError(sError);
            //  }
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> DB定義情報取得 </summary>
        /// <remarks>
        ///     and's.configのDBﾀｸﾞより定義情報をﾛｰﾄﾞ
        /// </remarks>
        /// <returns>
        ///     正常 : ""
        ///     異常 : 定義ｴﾗｰ情報
        /// </returns>
        private string LoadDB()
        {
            int iTest;
            string sMsg = "";
            string[] sTag = { TAG_CFG, TAG_CONNECT, TAG_DB, "" };
            //
            sTag[sTag.Length - 1] = TAG_DB_HOST;
            if ((DBInfo.HOST = GetTagValue(sTag)) == "")
            {
                sMsg += string.Format(ERRMSG_TAG, string.Join("/", sTag), Environment.NewLine);
            }
            sTag[sTag.Length - 1] = TAG_DB_PORT;
            if ((DBInfo.PORT = GetTagValue(sTag)) == "")
            {
                sMsg += string.Format(ERRMSG_TAG, string.Join("/", sTag), Environment.NewLine);
            }
            else
            {
                if (!int.TryParse(DBInfo.PORT, out iTest))
                {
                    sMsg += string.Format(ERRMSG_NUMERIC, string.Join("/", sTag), DBInfo.PORT, Environment.NewLine);
                }
            }
            sTag[sTag.Length - 1] = TAG_DB_NAME;
            if ((DBInfo.DBNAME = GetTagValue(sTag)) == "")
            {
                sMsg += string.Format(ERRMSG_TAG, string.Join("/", sTag), Environment.NewLine);
            }
            sTag[sTag.Length - 1] = TAG_DB_USER;
            if ((DBInfo.USER = GetTagValue(sTag)) == "")
            {
                sMsg += string.Format(ERRMSG_TAG, string.Join("/", sTag), Environment.NewLine);
            }
            sTag[sTag.Length - 1] = TAG_DB_PASS;
            if ((DBInfo.PASS = GetTagValue(sTag)) == "")
            {
                sMsg += string.Format(ERRMSG_TAG, string.Join("/", sTag), Environment.NewLine);
            }
            sTag[sTag.Length - 1] = TAG_DB_TIMEOUT;
            if ((DBInfo.TIMEOUT = GetTagValue(sTag)) != "")
            {
                if (!int.TryParse(DBInfo.TIMEOUT, out iTest))
                {
                    sMsg += string.Format(ERRMSG_NUMERIC, string.Join("/", sTag), DBInfo.TIMEOUT, Environment.NewLine);
                }
            }
            else
            {
                DBInfo.TIMEOUT = "0";
            }
            //
            // Exit
            return sMsg;
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ﾀｸﾞ値取得 </summary>
        /// <remarks>
        ///     指定されたﾀｸﾞ情報のvalues属性値を取得
        /// </remarks>
        /// <param name="sTag">ﾀｸﾞ階層</param>
        /// <returns>
        ///     正常 : values属性値
        ///     異常 : ""
        /// </returns>
        protected string GetTagValue(string[] sTag )
        {
            XmlNode     trgNord = null;
            //
            // ｴﾗｰﾄﾗｯﾌﾟ
            try
            {
                // XMLの生成
                XmlDocument xml_document = new XmlDocument();

                // 初期化
                xml_document.LoadXml(File.ReadAllText(m_sConfig));

                // ﾙｰﾄ取得
                if (xml_document.SelectNodes(sTag[0]).Count > 0)
                {
                    // ﾙｰﾄ設定
                    trgNord = (XmlElement)xml_document.SelectNodes(sTag[0]).Item(0);
                    //
                    // 一番下の階層まで辿る
                    for (int ix = 1; ix < sTag.Length; ix++)
                    {
                        // 存在ﾁｪｯｸ
                        if (trgNord.SelectNodes(sTag[ix]).Count == 0)
                        {
                            trgNord = null;
                            //
                            break;
                        }
                        //
                        // 次
                        trgNord = trgNord.SelectNodes(sTag[ix]).Item(0);
                    }
                }
                // Exit
                return (trgNord == null || trgNord.Attributes["value"] == null ? "" : trgNord.Attributes["value"].Value);
            }
            catch (Exception ex)                    // その他のｴﾗｰ
            {
                throw new TTConfigError(string.Format(ERRMSG_READERROR, ex.Message, Environment.NewLine));
            }
        }
        /////////////////////////////////////////////////////////////////////////////
        /// <summary> 環境ｴﾗｰ </summary>
        /// <remarks>
        ///     環境ｴﾗｰ時の例外情報
        ///     [ 更新履歴 ]
        ///         Ver 1.0.0       ... 2015.05.27      ... 高村　勉
        ///             新規作成
        /// </remarks>
        internal class TTConfigError : Exception
        {
            /////////////////////////////////////////////////////////////////////////
            #region // 定数
                private const string    ERROR_MESSAGE   = "configの下記、定義を確認して下さい。" + "{1}"
                                                        + "【エラー情報】" + "{1}"
                                                        + "{0}";
            #endregion
            /////////////////////////////////////////////////////////////////////////
            //
            /////////////////////////////////////////////////////////////////////////
            /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
            /// <remarks>
            ///     親ｸﾗｽにｴﾗｰ情報を設定
            /// </remarks>
            /// <param name="sMsg">ｴﾗｰ情報</param>
            internal TTConfigError(string sMsg) : base(sMsg)
            {
            }
            /////////////////////////////////////////////////////////////////////////
            /// <summary> ﾒｯｾｰｼﾞ </summary>
            /// <remarks>
            ///     ﾒｯｾｰｼﾞにand's環境の固有ﾒｯｾｰｼﾞを添付
            /// </remarks>
            public override string Message
            {
                get
                {
                    return string.Format(ERROR_MESSAGE, base.Message, Environment.NewLine);
                }
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    /// <summary> DB定義 </summary>
    /// <remarks>
    ///     DB定義情報の構造体
    ///     [ 更新履歴 ]
    ///         Ver 1.0.0       ... 2015.05.27      ... 高村　勉
    ///             新規作成
    /// </remarks>
    internal struct TTConfigDB
    {
        internal string HOST;                          //  ﾎｽﾄ
        internal string PORT;                          //  ﾎﾟｰﾄ
        internal string DBNAME;                        //  DB名
        internal string USER;                          //  ﾕｰｻﾞ
        internal string PASS;                          //  ﾊﾟｽ
        internal string TIMEOUT;                       //  ﾀｲﾑｱｳﾄ
        /////////////////////////////////////////////////////////////////////////
        /// <summary> 有効ﾁｪｯｸ </summary>
        /// <remarks>
        ///     本情報が有効かﾁｪｯｸ
        /// </remarks>
        /// <returns>true : 有効　false : 無効</returns>
        internal bool Enable()
        {
            return (HOST != "" && PORT != "" && DBNAME != "" && USER != "" && PASS != "");
        }
    }
}
