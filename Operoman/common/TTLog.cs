using System;
using System.Text;
using System.Diagnostics;
using Npgsql;

namespace Operoman
{
    /////////////////////////////////////////////////////////////////////////////
    /// <summary> ﾛｸﾞｸﾗｽ </summary>
    /// <remarks>
    ///     本ｸﾗｽは、ﾛｸﾞｻｰﾋﾞｽを提供する。
    ///     [ 更新履歴 ]
    ///         Ver 1.0.0       ... 2015.05.27      ... 高村　勉
    ///             新規作成
    /// </remarks>
    public class TTLog
    {
        /////////////////////////////////////////////////////////////////////////
        #region // 定数
        internal const string LOG_INFOMATION = "I";     // ﾛｸﾞ種別    - 情報
        internal const string LOG_WARNING = "W";        //           - 警告
        internal const string LOG_ERROR = "E";          //           - ｴﾗｰ
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // 設定情報 ﾌﾟﾛﾊﾟﾃｨ
        private TTConfig m_config = null;            // 設定情報
        internal TTConfig Config
        {
            get { return m_config; }
            set { m_config = value; }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // ｼｽﾃﾑ名
        private string m_sSysNm = "";            // ｼｽﾃﾑ名
        internal string SysNm
        {
            get { return m_sSysNm; }
            set { m_sSysNm = value; }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // ﾌﾟﾛｸﾞﾗﾑ名
        private string m_sPgNm = "";            // ﾌﾟﾛｸﾞﾗﾑ名
        internal string PgNm
        {
            get { return m_sPgNm; }
            set { m_sPgNm = value; }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // ﾃｰﾌﾞﾙ名
        private string m_sTbl = "";         // ﾃｰﾌﾞﾙ名
        internal string Tbl
        {
            get { return m_sTbl; }
            set { m_sTbl = value; }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // 職員ｺｰﾄﾞ
        private string m_sStfCd = "";     // 職員CD
        internal string StfCd
        {
            get { return m_sStfCd; }
            set { m_sStfCd = value; }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // 職員名
        private string m_sStfNm = "";     // 職員名
        internal string StfNm
        {
            get { return m_sStfNm; }
            set { m_sStfNm = value; }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
        /// <remarks>
        ///     ﾒﾝﾊﾞｰの初期化を実行
        /// </remarks>
        /// <param name="sSysNm">ｼｽﾃﾑ名</param>
        /// <param name="sPgNm">ﾌﾟﾛｸﾞﾗﾑ名</param>
        public TTLog(string sSysNm, string sPgNm)
        {
            m_config    = null;
            m_sPgNm     = sPgNm;
            m_sTbl      = "";
            m_sStfCd    = "";
            m_sSysNm    = sSysNm;
        }
        /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
        /// <remarks>
        ///     ﾒﾝﾊﾞｰの初期化を実行
        /// </remarks>
        /// <param name="config">設定情報</param>
        /// <param name="sSysNm">ｼｽﾃﾑ名</param>
        /// <param name="sPgNm">ﾌﾟﾛｸﾞﾗﾑ名</param>
        /// <param name="sTbl">ﾃｰﾌﾞﾙ名</param>
        public TTLog(TTConfig config, string sSysNm, string sPgNm, string sTbl, string sStfCd, string sStfNm)
        {
            m_config    = config;
            m_sPgNm     = sPgNm;
            m_sTbl      = sTbl;
            m_sStfCd    = sStfCd;
            m_sSysNm    = sStfNm;
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ﾛｸﾞ情報設定 </summary>
        /// <remarks>
        ///     ﾛｸﾞ関連ﾒﾝﾊﾞｰの初期化
        /// </remarks>
        /// <param name="config">設定情報</param>
        /// <param name="sTbl">ﾃｰﾌﾞﾙ名</param>
        /// <param name="sStfCd">ｽﾀｯﾌｺｰﾄﾞ</param>
        /// <param name="sPgNm">ｽﾀｯﾌ名</param>
        public void SetLogInfo(TTConfig config, string sTbl, string sStfCd, string sStfNm )
        {
            m_config    = config;
            m_sTbl      = sTbl;
            m_sStfCd    = sStfCd;
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ﾌﾟﾛｸﾞﾗﾑ開始ﾛｸﾞ </summary>
        /// <remarks>
        ///     ﾌﾟﾛｸﾞﾗﾑの開始ﾛｸﾞを出力
        /// </remarks>
        internal void ProgramStart()
        {
            LogWrite(   LOG_INFOMATION,
                        "プログラム開始",
                        "",
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｲﾍﾞﾝﾄ開始 </summary>
        /// <remarks>
        ///     ｲﾍﾞﾝﾄの開始ﾛｸﾞ
        /// </remarks>
        internal void EventStart(string sEvetName)
        {
            LogWrite(   LOG_INFOMATION,
                        sEvetName + "開始",
                        "",
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｲﾍﾞﾝﾄ終了 </summary>
        /// <remarks>
        ///     ｲﾍﾞﾝﾄの終了ﾛｸﾞ
        /// </remarks>
        internal void EventEnd(string sEvetName)
        {
            LogWrite(   LOG_INFOMATION,
                        sEvetName + "終了",
                        "",
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> 情報ﾛｸﾞ </summary>
        /// <remarks>
        ///     情報ﾛｸﾞ
        /// </remarks>
        /// <param name="sTtl">ﾀｲﾄﾙ</param>
        /// <param name="sMsg">ﾒｯｾｰｼﾞ</param>
        internal void Infomation(string sTtl, string sMsg)
        {
            LogWrite(  LOG_INFOMATION,
                        sTtl,
                        sMsg,
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> 警告ﾛｸﾞ </summary>
        /// <remarks>
        ///     警告ﾛｸﾞ
        /// </remarks>
        /// <param name="sTtl">ﾀｲﾄﾙ</param>
        /// <param name="sMsg">ﾒｯｾｰｼﾞ</param>
        internal void Warning(string sTtl, string sMsg)
        {
            LogWrite(  LOG_WARNING,
                        sTtl,
                        sMsg,
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｴﾗｰﾛｸﾞ </summary>
        /// <remarks>
        ///     ｴﾗｰﾛｸﾞ
        /// </remarks>
        /// <param name="sTtl">ﾀｲﾄﾙ</param>
        /// <param name="sMsg">ﾒｯｾｰｼﾞ</param>
        internal void Error(string sTtl, string sMsg)
        {
            LogWrite(  LOG_ERROR,
                        sTtl,
                        sMsg,
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｴﾗｰﾛｸﾞ </summary>
        /// <remarks>
        ///     例外情報出力
        /// </remarks>
        /// <param name="sTtl">ﾀｲﾄﾙ</param>
        /// <param name="ex">例外情報</param>
        internal void Error(string sTtl, Exception ex)
        {
            LogWrite(  LOG_ERROR,
                        sTtl,
                        ex.Message,
                        ex.StackTrace);
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｴﾗｰﾛｸﾞ </summary>
        /// <remarks>
        ///     情報 + 例外情報出力
        /// </remarks>
        /// <param name="sTtl">ﾀｲﾄﾙ</param>
        /// <param name="sMsg">ﾒｯｾｰｼﾞ</param>
        /// <param name="ex">例外情報</param>
        internal void Error(string sTtl, string sMsg, Exception ex)
        {
            LogWrite(  LOG_ERROR,
                        sTtl,
                        "【ログメッセージ】" + Environment.NewLine +
                        sMsg  + Environment.NewLine +
                        "【例外情報】" + Environment.NewLine +
                        ex.Message,
                        ex.StackTrace);
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ﾌﾟﾛｸﾞﾗﾑ終了ﾛｸﾞ </summary>
        /// <remarks>
        ///     ﾌﾟﾛｸﾞﾗﾑの終了ﾛｸﾞを出力
        /// </remarks>
        internal void ProgramEnd()
        {
            LogWrite(   LOG_INFOMATION,
                        "プログラム終了",
                        "",
                        "");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ﾛｸﾞ出力 </summary>
        /// <remarks>
        ///     ﾛｸﾞﾃｰﾌﾞﾙへﾛｸﾞを出力
        /// </remarks>
        /// <param name="sSts">ﾛｸﾞ種別</param>
        /// <param name="sTtl">ﾛｸﾞﾀｲﾄﾙ</param>
        /// <param name="sMsg">ﾛｸﾞﾒｯｾｰｼﾞ</param>
        /// <param name="sMsgEx">ﾛｸﾞ負荷情報</param>
        protected void LogWrite(string sSts, string sTtl, string sMsg, string sMsgEx)
        {
            StringBuilder sbSQL = new StringBuilder();
            //
            // ｴﾗｰﾄﾗｯﾌﾟ
            try
            {
                // 環境存在判定
                if (m_config != null)
                {
                    using (NpgDB npgDB = TTCommon.DBConnect(m_config))
                    {
                        // SQLの作成 & 実行
                        sbSQL.AppendLine(" INSERT INTO " + m_sTbl);
                        sbSQL.AppendLine(" " + "(");
                        sbSQL.AppendLine(" " + "log_stamp"  + ",");
                        sbSQL.AppendLine(" " + "log_kbn"    + ",");
                        sbSQL.AppendLine(" " + "log_ttl"    + ",");
                        sbSQL.AppendLine(" " + "log_memo"   + ",");
                        sbSQL.AppendLine(" " + "log_ext"    + ",");
                        sbSQL.AppendLine(" " + "log_prg_nm" + ",");
                        sbSQL.AppendLine(" " + "stf_cd"     + ",");
                        sbSQL.AppendLine(" " + "stf_j_nm"   + " ");
                        sbSQL.AppendLine(" " + ")" + " "    + "VALUES" + " " + "(");
                        sbSQL.AppendLine(" " + "CURRENT_TIMESTAMP" + ",");
                        sbSQL.AppendLine(" " + ":log_kbn"   + ",");
                        sbSQL.AppendLine(" " + ":log_ttl"   + ",");
                        sbSQL.AppendLine(" " + ":log_memo"  + ",");
                        sbSQL.AppendLine(" " + ":log_ext"   + ",");
                        sbSQL.AppendLine(" " + ":log_prg_nm" + ",");
                        sbSQL.AppendLine(" " + ":stf_cd"    + ",");
                        sbSQL.AppendLine(" " + ":stf_j_nm"  + " ");
                        sbSQL.AppendLine(" " + ")");
                        npgDB.Command = sbSQL.ToString();
                        npgDB.SetParams("log_kbn", sSts);
                        npgDB.SetParams("log_ttl", sTtl);
                        npgDB.SetParams("log_memo", sMsg);
                        npgDB.SetParams("log_ext", sMsgEx);
                        npgDB.SetParams("log_prg_nm", m_sPgNm);
                        npgDB.SetParams("stf_cd", m_sStfCd);
                        npgDB.SetParams("stf_j_nm", m_sStfNm);
                        npgDB.ExecuteNonQuery();
	
                    }
                }
                else
                {
                    LogfileWrite(sTtl, sMsg, sMsgEx);
                }
            }
            catch (Exception ex)
            {
                DebugWrite("ﾛｸﾞ出力失敗:" + ex.Message);
                LogfileWrite(sTtl, sMsg, ex.Source);
                LogfileWrite(sTtl, sMsg, sMsgEx);
            }
        }
        /// <summary>
        /// ﾛｸﾞﾌｧｲﾙ出力
        /// </summary>
        /// <param name="ttl">ﾀｲﾄﾙ</param>
        /// <param name="mgs">ﾒｯｾｰｼﾞ</param>
        /// <param name="msg_ex">ﾒｯｾｰｼﾞ不可情報</param>
        /// <remarks>ｲﾍﾞﾝﾄﾛｸﾞ出力</remarks>
        protected void LogfileWrite(string ttl, string msg, string msg_ex)
        {
            string sLog = "";
            string sLogFile;
            //
            // ｴﾗｰﾄﾗｯﾌﾟ
            try
            {
                // ﾄﾞｷｭﾒﾝﾄﾌｫﾙﾀﾞｰ
                // sLogFile = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                sLogFile = "C:\\OperomanLog";
                //
                // ﾌｧｲﾙ名
                if (sLogFile.Substring(sLogFile.Length - 1) != "\\")
                {
                    sLogFile += "\\";
                }
                sLogFile += m_sSysNm + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fffff") + ".log";
                //
                // ﾛｸﾞﾌｧｲﾙ作成
                sLog += "【" + ttl + "】" + Environment.NewLine;
                sLog += msg + Environment.NewLine;
                //
                // その他情報
                if (msg_ex != "")
                {
                    sLog += "【その他の情報】" + Environment.NewLine;
                    sLog += msg_ex + Environment.NewLine;
                }
                System.IO.File.WriteAllText(sLogFile, sLog);
            }
            catch (Exception)
            {
                // Nop
            }
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ﾃﾞﾊﾞｯｸﾞ出力 </summary>
        /// <remarks>
        ///     ﾃﾞﾊﾞｯｸﾞｳｨﾝﾄﾞｳへ取得
        /// </remarks>
        /// <param name="sLog">出力文字列</param>
        internal static void DebugWrite(string sLog)
        {
            Debug.WriteLine("");
            Debug.WriteLine("================================= 注意 =================================");
            Debug.WriteLine(sLog);
            Debug.WriteLine("========================================================================");
            Debug.WriteLine("");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> 後処理 </summary>
        /// <remarks>
        ///     後処理の実行
        /// </remarks>
        internal void Dispose()
        {
            m_config = null;
        }
    }
}
