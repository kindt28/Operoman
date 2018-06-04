using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Operoman
{
    public abstract class AspPage : System.Web.UI.Page
    {
        /////////////////////////////////////////////////////////////////////////
        #region // 仮想
            public delegate void OnEventHandler();
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // 仮想
            public abstract void    ExecutePageLoad();
            public abstract void    ExecuteAjax();
            public abstract void    ExecutePostBack();
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // ﾒﾝﾊﾞｰ
            protected   TTLog       m_log = null;                       // ﾛｸﾞ
            protected   TTConfig    m_config = null;                   // 設定情報
            protected   NpgDB        m_npgDB = null;                    // DB
            protected   string      m_sSysNm = "";                      // ｼｽﾃﾑ名
            protected   string      m_sPgNm = "";                       // ﾌﾟﾛｸﾞﾗﾑ名
            protected   string      m_sLogTbl = "";                     // ﾛｸﾞﾃｰﾌﾞﾙ名
            protected   string      m_sStfCd = "";                      // ｽﾀｯﾌｺｰﾄﾞ
            protected   string      m_sStfNm = "";                      // ｽﾀｯﾌ名
            protected   string      m_sStfRole = "";                     // Role
            protected   string      m_sConfigPath = "";                 // 設定ﾌｧｲﾙ
            protected string        m_sStfPw = "";
            protected string       m_sProjCd = "";
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        /////////////////////////////////////////////////////////////////////////
        #region // 定数
        #endregion
        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ｸｯｷｰの取得
        /// </summary>
        /// <param name="httpRequest">ﾘｸｴｽﾄｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="sKey">ｸｯｷｰのｷｰ</param>
        /// <remarks>ｸｯｷｰの値</remarks>
        public static string GetCookieStatic(HttpRequest httpRequest, string sKey)
        {
		    if( httpRequest.Cookies[sKey] != null )
            {
                return HttpUtility.UrlDecode(httpRequest.Cookies[sKey].Value);
            }
		    //
		    // Exit
		    return "";
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ｸｯｷｰの設定
        /// </summary>
        /// <param name="httpResponse">ﾚｽﾎﾟﾝｽｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="sKey">ｸｯｷｰのｷｰ</param>
        /// <param name="sVal">ｸｯｷｰの値</param>
        public static void SetCookieStatic(HttpResponse httpResponse, string sKey, string sVal)
        {
		    HttpCookie cookie;
		    //
		    // ｸｯｷｰ取得
		    if( httpResponse.Cookies[sKey] == null )
            {
			    cookie = httpResponse.Cookies[sKey];
            }else{
			    cookie = new HttpCookie(sKey);
                httpResponse.Cookies.Add(cookie);
            }
		    //
		    // 値の設定
		    cookie.Value	    = HttpUtility.UrlPathEncode( sVal );
		    cookie.Expires	= DateTime.Parse("2999/12/31");
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
        /// <remarks>
        ///     ﾒﾝﾊﾞｰの初期化を実行
        /// </remarks>
        public AspPage(): base()
        {
        }
        /////////////////////////////////////////////////////////////////////////
	    // <summary>
	    // ﾍﾟｰｼﾞﾛｰﾄﾞ
	    // </summary>
	    // <param name="e">ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ</param>
	    // <remarks></remarks>
        protected override void OnLoad(EventArgs e)
        {
            // ﾍﾞｰｽｺｰﾙ
 	        base.OnLoad(e);
            //
			// ﾍﾟｰｼﾞﾛｰﾄﾞ種別
			if( IsPostBack )
            {
				// ﾎﾟｽﾄﾊﾞｯｸ処理
                ExecutePostBack();
            }
            else
            {
                // Ajax判定
                if( IsAsync || Request.Params["Ajax"] == "TRUE" )
                {
                    ExecuteAjax();
                }else{
                    ExecutePageLoad();
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////
	    // <summary>
	    // ｲﾍﾞﾝﾄ処理
	    // </summary>
	    // <param name="delEventHandler">ｲﾍﾞﾝﾄ処理ﾃﾞﾘｹﾞｰﾄ</param>
	    // <remarks></remarks>
        protected void OnEventExecute( string sEventName, OnEventHandler delEventHandler)
        {
            // ｴﾗｰﾄﾗｯﾌﾟ
            try
            {
                // ﾛｸﾞ生成
                m_log = new TTLog(m_sSysNm, m_sPgNm);
                //
		        // 環境生成
                m_config = new TTConfig(m_sConfigPath);
                //
		        // ﾛｸﾞﾃｰﾌﾞﾙ設定
                m_log.SetLogInfo( m_config, m_sLogTbl, m_sStfCd, m_sStfNm );
                //
                // DB接続
                m_npgDB = TTCommon.DBConnect( m_config );
                //
                // 開始ﾛｸﾞ
                m_log.EventStart(sEventName);
                //
                // ｲﾍﾞﾝﾄ処理実行
                delEventHandler();
            }
            catch( TTConfig.TTConfigError ex )
            {
                m_log.Error( "環境設定エラー", ex );
            }
            catch( IcelineExceptionNpgDBConnect ex )
            {
                m_log.Error( "ＤＢ接続エラー", ex );
            }
            catch( System.Threading.ThreadAbortException)
            {
                // Redirectを実行するとこの例外が発生する為、Nop
            }
            catch( Exception ex )
            {
                m_log.Error( "想定外エラー", ex );
            }
            finally
            {
                // 終了ﾛｸﾞ
                m_log.EventEnd(sEventName);
                //
                // 後処理
                m_log.Dispose();
                //
                if( m_npgDB != null )
                {
                    m_npgDB.Dispose();
                    m_npgDB = null;
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ｸｯｷｰの取得
        /// </summary>
        /// <param name="sKey">ｸｯｷｰのｷｰ</param>
        /// <remarks>ｸｯｷｰの値</remarks>
        public string GetCookie(string sKey)
        {
            return AspPage.GetCookieStatic( Request, sKey );
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ｸｯｷｰの設定
        /// </summary>
        /// <param name="sKey">ｸｯｷｰのｷｰ</param>
        /// <param name="sVal">ｸｯｷｰの値</param>
        public void SetCookie(string sKey, string sVal)
        {
            AspPage.SetCookieStatic( Response, sKey, sVal );
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾚｽﾎﾟﾝｽ作成
        /// </summary>
        /// <param name="sVal">ﾚｽﾎﾟﾝｽへ書き込むﾃﾞｰﾀ</param>
        /// <remarks>
        /// HttpResponseへﾃﾞｰﾀをﾗｲﾄ (Ajaxのﾚｽﾎﾟﾝｽ作成で使用)
        ///     ※. ThreadAbortExceptionが発生する
        ///         ( Redirectと同じように強制的にｸﾗｲｱﾝﾄへﾚｽﾎﾟﾝｽが送信される。)
        /// </remarks>
        protected void WriteRequest( string sVal )
        {
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write( sVal );
            Response.End();
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    /// <summary> Ajaxﾚｽﾎﾟﾝｽ </summary>
    /// <remarks>
    ///     Ajaxのﾚｽﾎﾟﾝｽ
    ///     [ 更新履歴 ]
    ///         Ver 1.0.0       ... 2017.02.11  ... 高村　勉
    ///             新規作成
    /// </remarks>
    public class TTAjaxResponse
    {
        /////////////////////////////////////////////////////////////////////////
        #region // 定数
            public const string  STATUS_NORMAL  = "NORMAL";
            public const string  STATUS_WARNING = "WARNING";
            public const string  STATUS_ERROR   = "ERROR";
        #endregion
        /////////////////////////////////////////////////////////////////////////
        //
        public  string  Status  = STATUS_NORMAL;        // ｽﾃｰﾀｽ
    }
    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}