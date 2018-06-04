using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Operoman
{
    public abstract class KinAspPage: AspPage
    {
        /////////////////////////////////////////////////////////////////////////
        protected delegate string PARAM_DEF();
        /////////////////////////////////////////////////////////////////////////      
        protected const string COOKIE_STF_CD = "CMTSTFCD";         // ｽﾀｯﾌｺｰﾄﾞ
        protected const string COOKIE_STF_NM = "CMTSTFNM";         // ｽﾀｯﾌ名 
        //protected const string COOKIE_STF_ROLE           = "CMTSTFROLE";       // Role
        protected const string COOKIE_ARRAY_PARAM_SEP    = "\v";             // 配列ﾊﾟﾗﾒｰﾀのｾﾊﾟﾚｰﾀ
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾊﾟﾗﾒｰﾀｸｯｷｰの取得
        /// </summary>
        /// <param name="httpRequest">ﾘｸｴｽﾄｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="sCookieID">ｸｯｷｰID</param>
        public static string[] GetParamArray( HttpRequest httpRequest, string sCookieID )
        {
            string sParam = GetCookieStatic( httpRequest, sCookieID );
            //
            if( sParam == "" )
            {
                return new string[0];
            }else{
                return sParam.Split(new string[] {COOKIE_ARRAY_PARAM_SEP}, StringSplitOptions.None);
            }
        } 
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 配列ﾊﾟﾗﾒｰﾀ ｸｯｷｰの保存
        /// </summary>
        /// <param name="httpResponse">ﾚｽﾎﾟﾝｽｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="sCookieID">ｸｯｷｰID</param>
        /// <param name="sParam">ﾊﾟﾗﾒｰﾀ配列</param>
        protected static void SetParamArray( HttpResponse httpResponse, string sCookieID, string[] sParam )
        {
            SetCookieStatic(    httpResponse, 
                                sCookieID, 
                                string.Join( COOKIE_ARRAY_PARAM_SEP, sParam ) );
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
        /// <remarks>
        ///     ﾒﾝﾊﾞｰの初期化を実行
        /// </remarks>
        public KinAspPage(): base()
        {
            m_sSysNm = "Operoman";
            m_sLogTbl = "cmt_web_log";
            m_sConfigPath = GetConfigPath();
        } 
        /////////////////////////////////////////////////////////////////////////
        /// <summary> 設定ﾊﾟｽの取得 </summary>
        /// <remarks>
        ///     設定ﾌｧｲﾙのﾊﾟｽを返却
        /// </remarks>
        private string GetConfigPath()
        {
            string sPath = "";
            //
            sPath = Server.MapPath("/");
            sPath = System.IO.Directory.GetParent(sPath).Parent.FullName;
            sPath = Path.Combine( sPath, "Config.xml");
            //
            // Exit
            return sPath;
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾍﾟｰｼﾞﾛｰﾄﾞ
        /// </summary>
        public override void ExecutePageLoad()
        {
            m_sStfCd = GetCookie(COOKIE_STF_CD);
            m_sStfNm = GetCookie(COOKIE_STF_NM);
            //m_sStfRole = GetCookie(COOKIE_STF_ROLE);
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾎﾟｽﾄﾊﾞｯｸ
        /// </summary>
        public override void ExecutePostBack()
        {
            m_sStfCd = GetCookie(COOKIE_STF_CD);
            m_sStfNm = GetCookie(COOKIE_STF_NM);
            //m_sStfRole = GetCookie(COOKIE_STF_ROLE);
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Ajaxｺｰﾙ
        /// </summary>
        public override void ExecuteAjax()
        {
            m_sStfCd = GetCookie(COOKIE_STF_CD);
            m_sStfNm = GetCookie(COOKIE_STF_NM);
            //m_sStfRole = GetCookie(COOKIE_STF_ROLE);
        } 
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 配列へ追加
        /// </summary>
        /// <param name="sArray">配列</param>
        /// <param name="sItem">追加項目</param>
        public void AddArrayItem( ref string[] sArray, string sItem )
        {
            int iMax;
            //
            iMax = sArray.Length;
            //
            Array.Resize( ref sArray, iMax + 1 );
            //
            sArray[ iMax ] = sItem;
        } 
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ｸｯｷｰの初期化
        /// </summary>
        protected virtual void InitCookie()
        {
		    // ｸｯｷｰの初期化
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾊﾟﾗﾒｰﾀｸｯｷｰの取得
        /// </summary>
        /// <param name="sCookieID">ｸｯｷｰID</param>
        protected string[] GetArrayParam( string sCookieID )
        {
            string sParam = GetCookie(sCookieID );
            //
            if( sParam == "" )
            {
                return new string[0];
            }else{
                return sParam.Split(new string[] {COOKIE_ARRAY_PARAM_SEP}, StringSplitOptions.None);
            }
        } 
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 配列ﾊﾟﾗﾒｰﾀ ｸｯｷｰの保存
        /// </summary>
        /// <param name="sCookieID">ｸｯｷｰID</param>
        /// <param name="sParam">ﾊﾟﾗﾒｰﾀ配列</param>
        protected void SetArrayParam( string sCookieID, string[] sParam )
        {
            SetCookie(sCookieID, string.Join( COOKIE_ARRAY_PARAM_SEP, sParam ) );
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 配列ﾊﾟﾗﾒｰﾀの取得
        /// </summary>
        /// <param name="sParam">配列値</param>
        /// <param name="iIX">配列番号</param>
        /// <param name="delDefValue">初期値ﾃﾞﾘｹﾞｰﾄ</param>
        protected void GetArrayParamValue( ref string[] sParam, int iIX, PARAM_DEF delDefValue )
        {
            string sDefVal = delDefValue();
            //
            GetArrayParamValue( ref sParam, iIX, sDefVal );
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 配列ﾊﾟﾗﾒｰﾀの取得
        /// </summary>
        /// <param name="sParam">配列値</param>
        /// <param name="iIX">配列番号</param>
        /// <param name="sDefVal">初期値ﾃﾞﾘｹﾞｰﾄ</param>
        protected void GetArrayParamValue( ref string[] sParam, int iIX, string sDefVal )
        {
            if( sParam.Length > iIX )
            {
                if( sParam[ iIX ] == "" )
                {
                    sParam[iIX] = sDefVal;
                }
            }else{
                Array.Resize( ref sParam, iIX + 1 );
                //
                sParam[iIX] = sDefVal;
            }
        }
    }
}