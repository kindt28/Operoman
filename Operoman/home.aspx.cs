using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace Operoman
{

    /////////////////////////////////////////////////////////////////////////////
    /// <summary> ﾛｸﾞｲﾝ </summary>
    /// <remarks>
    /// </remarks>
    public partial class home : KinAspPage
    {
        /////////////////////////////////////////////////////////////////////////
        /// <summary> ｺﾝｽﾄﾗｸﾀ </summary>
        /// <remarks>
        ///     ﾒﾝﾊﾞｰの初期化を実行
        /// </remarks>
        public home()
            : base()
        {
            m_sPgNm = "home.aspx";
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾍﾟｰｼﾞﾛｰﾄﾞ
        /// </summary>
        public override void ExecutePageLoad()
        {
            // ｸﾘｱｰ
            pid_login_error.InnerText = " ";
            SetCookie(COOKIE_STF_CD, "");
            SetCookie(COOKIE_STF_NM, "");
            //
            base.ExecutePageLoad();
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾎﾟｽﾄﾊﾞｯｸ
        /// </summary>
        public override void ExecutePostBack()
        {
            base.ExecutePostBack();
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Ajaxｺｰﾙ
        /// </summary>
        public override void ExecuteAjax()
        {
            base.ExecuteAjax();
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾛｸﾞｲﾝ
        /// </summary>
        /// <param name="sender">ｲﾍﾞﾝﾄ発生ｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="e">ｲﾍﾞﾝﾄ引数</param>
        protected void pid_login_button_Click(object sender, EventArgs e)
        {
            //OnEventExecute("pid_login_button_Click", OnLoginButtonClick);
            OnLoginButtonClick();
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ﾛｸﾞｲﾝﾎﾞﾀﾝｸﾘｯｸ処理
        /// </summary>
        private void OnLoginButtonClick()
        {
            string sStfCd = "";
            string sStfNm = "";
            string sResult = "";
            //
            // ｴﾗｰｸﾘｱｰ
            pid_login_error.InnerText = "";
            //
            // IDﾁｪｯｸ
            if (pid_txt_uid.Value == "")
            {
                pid_login_error.InnerText = "ＩＤを入力して下さい。";
            }
            else
            {
                //
                // PWﾁｪｯｸ
                if (pid_txt_pass.Value == "")
                {
                    pid_login_error.InnerText = "ＰＷを入力して下さい。";
                }
                else
                {
                    //
                    // 職員情報存在ﾁｪｯｸ
                    if ((sResult = StaffCheck(out sStfCd, out sStfNm)) == "")
                    {
                        // ﾛｸﾞｲﾝ成功
                        //m_log.Infomation("ログイン成功",
                        //                    string.Format("[{0}]{1}がログインしました。",
                        //                                        sStfCd,
                        //                                        sStfNm));
                        SetCookie(COOKIE_STF_CD, sStfCd);
                        SetCookie(COOKIE_STF_NM, sStfNm);
                        Response.Redirect("page/Menu.aspx");
                    }
                    else
                    {
                        //
                        // ﾛｸﾞｲﾝ失敗
                        m_log.Infomation("ログイン成功", sResult);
                        pid_login_error.InnerText = "ＩＤ／ＰＷを確認して下さい。";
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 職員情報ﾁｪｯｸ
        /// </summary>
        /// <param name="sStfCd">ﾛｸﾞｲﾝ職員ｺｰﾄﾞ</param>
        /// <param name="sStfNm">ﾛｸﾞｲﾝ職員名</param>
        /// <returns>"" : ﾛｸﾞｲﾝ成功　　"" : ﾛｸﾞｲﾝｴﾗｰﾒｯｾｰｼﾞ</returns>
        private string StaffCheck(out string sStfCd, out string sStfNm)
        {
            //StringBuilder sbSQL = new StringBuilder();
            //string sError = "";

            ////クリア
            //sStfCd = "";
            //sStfNm = "";
            ////職員情報取得
            //sbSQL.AppendLine("SELECT      " + "*");
            //sbSQL.AppendLine("  FROM      " + "m_staff" + " " + "");
            //sbSQL.AppendLine(" WHERE     " + "stf_cd" + " " + " = " + ":stf");
            //sbSQL.AppendLine(" AND   " + "data_sts" + " " + "= '0'");
            //m_npgDB.Command = sbSQL.ToString();
            //m_npgDB.SetParams("stf", pid_txt_uid.Value);
            //using (NpgsqlDataReader rec = m_npgDB.Query())
            //{
            //    if (rec.Read())
            //    {
            //        if (NpgDB.getString(rec, "stf_pass") == pid_txt_pass.Value)
            //        {
            //            //ログイン成功
            //            sStfCd = NpgDB.getString(rec, "stf_cd");
            //            sStfNm = NpgDB.getString(rec, "stf_name");
            //        }
            //        else
            //        {
            //            //パスワード不正

            //            sError = string.Format("[{0}]{1}が不正なパスワード({2})を入力しました。",
            //                                         NpgDB.getString(rec, "stf_cd"),
            //                                         NpgDB.getString(rec, "stf_nm"), pid_txt_pass.Value);
            //        }
            //    }
            //    else
            //    {
            //        sError = string.Format("[{0}]の有効な職員情報が存在しません", pid_txt_uid.Value);
            //    }
            //}
            ////
            //// Exit
            //return sError;
            string s = "1";
            sStfCd = "user";
            sStfNm = "pass";
            if (pid_txt_uid.Value == "1" && pid_txt_pass.Value == "1")
            {
                s = "";
                
            }
            return s;
        }
    }
}