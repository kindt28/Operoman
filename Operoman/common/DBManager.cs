using System;
using System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Configuration;
using System.Xml;
using Npgsql;


namespace Operoman
{
    /****************************************************************************************/
    /*	ｸﾗｽ名 ：NpgDB                   											        */
    /*																						*/
    /*	概　要：DB管理ﾏﾈｰｼﾞｬｸﾗｽ																*/
    /*																						*/
    /*	履　歴：2007.03.30	新規作成				IceLine@高村 勉							*/
    /****************************************************************************************/
    public sealed class NpgDB : NpgDBManager
    {
        /****************************************************************************/
        /* delegate																	*/
        /****************************************************************************/
        public delegate void InitExecuteProc(NpgDB referralDBManager);
        public delegate void QueryRecodeProc(NpgsqlDataReader oleDbDataReader);
        /****************************************************************************/
        /* Static																	*/
        /****************************************************************************/
        /// <summary>
        /// NULLを削除
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = rec.GetString(no);
            }

            return ret;
        }
        /// <summary>
        /// <summary>
        /// Integerを文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getInt16String(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = rec.GetInt16(no).ToString();
            }

            return ret;
        }        
        /// <summary>
        /// <summary>
        /// Integerを文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getIntegerString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = rec.GetInt32(no).ToString();
            }

            return ret;
        }
        /// <summary>
        /// <summary>
        /// Longを文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getLongString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = rec.GetDecimal(no).ToString();
            }

            return ret;
        }         
        /// <summary>
        /// <summary>
        /// 浮動小数点を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getFloatString(NpgsqlDataReader rec, string fld, string frm)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = string.Format("{0:" + frm + "}", rec.GetDecimal(no));
            }

            return ret;
        }
        /// <summary>
        /// <summary>
        /// 浮動小数点を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getDoubleString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = rec.GetDouble(no).ToString();
            }

            return ret;
        }           
        /// <summary>
        /// 日付を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getDateString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int    no  = rec.GetOrdinal( fld );

            if (! rec.IsDBNull(no) )
            {
                // ret = string.Format("{0:yyyy/MM/dd}", rec.GetDate(no));
                ret = ((DateTime)rec.GetDate(no)).ToString("yyyy/MM/dd");
            }

            return ret;
        }
        /// <summary>
        /// 日時時刻を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getDateTimeString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                // ret = string.Format("{0:yyyy/MM/dd hh:mm:ss}", rec.GetDateTime(no));
                ret = rec.GetDateTime(no).ToString("yyyy/MM/dd HH:mm:ss");
            }

            return ret;
        }
        /// <summary>
        /// 日時時刻を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getDateTimeString2(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                // ret = string.Format("{0:yyyy/MM/dd hh:mm:ss}", rec.GetDateTime(no));
                ret = rec.GetDateTime(no).ToString("yyyy-MM-dd HH:mm:ss");
            }

            return ret;
        }
        /// <summary>
        /// 日時時刻を文字列として取得
        /// </summary>
        /// <param name="rec">ﾚｺｰﾄﾞｾｯﾄ</param>
        /// <param name="fld">ﾌｨｰﾙﾄﾞ名</param>
        /// <param name="frm (ToStringの引数となる)">ﾌｫｰﾏｯﾄ</param>
        /// <returns>ﾌｫｰﾏｯﾄ変換したﾃﾞｰﾀ</returns>
        public static string getDateTimeString(NpgsqlDataReader rec, string fld, string frm)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = rec.GetDateTime(no).ToString(frm);
            }

            return ret;
        }
        /// <summary>
        /// 時刻を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getStampString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                // ret = string.Format("{0:yyyy/MM/dd hh:mm:ss.fffff}", rec.GetTimeStamp(no));
                ret = ((DateTime)rec.GetTimeStamp(no)).ToString("yyyy/MM/dd HH:mm:ss.fffff");
            }

            return ret;
        }
        /// <summary>
        /// 時刻を文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getStampString2(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                // ret = string.Format("{0:yyyy/MM/dd hh:mm:ss.fffff}", rec.GetTimeStamp(no));
                ret = ((DateTime)rec.GetTimeStamp(no)).ToString("yyyy-MM-dd HH:mm:ss.fffff");
            }

            return ret;
        }
        /// <summary>
        /// ｲﾝﾀｰﾊﾞﾙを文字列として取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string getIntervalString(NpgsqlDataReader rec, string fld)
        {
            string ret = "";

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = ((TimeSpan)rec.GetInterval(no)).ToString();
            }

            return ret;
        }
        /// <summary>
        /// 数値配列を文字列として取得
        /// </summary>
        /// <param name="rec">ﾚｺｰﾄﾞｾｯﾄ</param>
        /// <param name="fld">ﾌｨｰﾙﾄﾞ</param>
        /// <returns>指定文字列</returns>
        public static string[] getDoubleArrayString(NpgsqlDataReader rec, string fld)
        {
            string[] ret    = new string[0];
            double[] vals   = new double[0];
            int ix = 0;

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                vals = (double[])rec.GetValue(no);

                for (ix = 0; ix < vals.Length; ix++)
                {
                    Array.Resize<string>(ref ret, ret.Length + 1);

                    ret[ret.Length - 1] = vals[ix].ToString();
                }
            }

            return ret;
        }
        /// <summary>
        /// 数値配列を文字列として取得
        /// </summary>
        /// <param name="rec">ﾚｺｰﾄﾞｾｯﾄ</param>
        /// <param name="fld">ﾌｨｰﾙﾄﾞ</param>
        /// <returns>指定文字列</returns>
        public static string[] getIntegerArrayString(NpgsqlDataReader rec, string fld)
        {
            string[] ret = new string[0];
            int[]   vals = new int[0];
            int       ix = 0;

            int no = rec.GetOrdinal(fld);

            if (! rec.IsDBNull(no))
            {
                vals = (int[])rec.GetValue(no);

                for (ix = 0; ix < vals.Length; ix++)
                {
                    Array.Resize<string>(ref ret, ret.Length + 1);

                    ret[ret.Length - 1] = vals[ix].ToString();
                }
            }

            return ret;
        }
        /// <summary>
        /// 文字列配列の取得
        /// </summary>
        /// <param name="rec">ﾚｺｰﾄﾞｾｯﾄ</param>
        /// <param name="fld">ﾌｨｰﾙﾄﾞ</param>
        /// <returns>指定文字列</returns>
        public static string[] getArrayString(NpgsqlDataReader rec, string fld)
        {
            string[] ret = new string[0];

            int no = rec.GetOrdinal(fld);

            if (!rec.IsDBNull(no))
            {
                ret = (string[])rec.GetValue(no);
            }

            return ret;
        }
        public static bool ExecuteQuery(NpgDB referralDBManager, InitExecuteProc initExecuteProc, QueryRecodeProc queryRecodeProc)
        {
            bool recExist = false;

            NpgsqlDataReader oleDbDataReader = null;

            // 例外処理
            try
            {
                // DB設定
                initExecuteProc(referralDBManager);

                // ﾚｺｰﾄﾞ取得
                if ((oleDbDataReader = referralDBManager.Query()) != null)
                {
                    // ﾘｰﾄﾞ
                    if (oleDbDataReader.Read())
                    {
                        // ﾃﾞｰﾀの存在
                        recExist = true;

                        // 処理
                        queryRecodeProc(oleDbDataReader);

                        // 全てのﾚｺｰﾄﾞ処理
                        while (oleDbDataReader.Read())
                        {
                            // 処理
                            queryRecodeProc(oleDbDataReader);
                        }
                    }

                    // ｸﾛｰｽﾞ
                    oleDbDataReader.Close();
                }
            }
            catch
            {
                // DBｸﾛｰｽﾞ
                if (referralDBManager != null)
                {
                    referralDBManager.Close();
                }

                throw;
            }

            // 戻り値を返却
            return (recExist);
        }

        public static void ExecuteProcedure(NpgDB referralDBManager, InitExecuteProc initExecuteProc)
        {
            // 例外処理
            try
            {
                // DB設定
                initExecuteProc(referralDBManager);

                // 実行
                referralDBManager.ExecuteProcedure();
            }
            catch (Exception e)
            {
                // DBｸﾛｰｽﾞ
                if (referralDBManager != null)
                {
                    referralDBManager.Close();
                }

                throw (e);
            }
        }

        public static void ExecuteNonQuery(NpgDB referralDBManager, InitExecuteProc initExecuteProc)
        {
            // 例外処理
            try
            {
                // DB設定
                initExecuteProc(referralDBManager);

                // 実行
                referralDBManager.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // DBｸﾛｰｽﾞ
                if (referralDBManager != null)
                {
                    referralDBManager.Close();
                }

                throw (e);
            }
        }

        public NpgDB() : base()
        {
            // ﾌﾟﾛﾊﾞｲﾀﾞｰの設定
            base.Provider = NpgDBManager.GetProvider("connectDB");
        }
        public NpgDB(string sKey) : base()
        {
            // ﾌﾟﾛﾊﾞｲﾀﾞｰの設定
            base.Provider = NpgDBManager.GetProvider(sKey);
        }
        public NpgDB(string sHost, string sPort, string sDBNm, string sUser, string sPass) : base()
        {
            // ﾌﾟﾛﾊﾞｲﾀﾞｰの設定
            base.Provider = string.Format("Server={0};Port={1};Database={2};User ID={3};Password={4};CommandTimeout=0;",
                                            sHost,
                                            sPort,
                                            sDBNm,
                                            sUser,
                                            sPort );
        }
        public NpgDB(string sHost, string sPort, string sDBNm, string sUser, string sPass, string sTimeout) : base()
        {
            // ﾌﾟﾛﾊﾞｲﾀﾞｰの設定
            base.Provider = string.Format("Server={0};Port={1};Database={2};User ID={3};Password={4};CommandTimeout={5};",
                                            sHost,
                                            sPort,
                                            sDBNm,
                                            sUser,
                                            sPass,
                                            sTimeout );
        }
        public NpgDB(System.Configuration.ConnectionStringSettingsCollection col, string name) : base()
        {
            // nameに対応するﾉｰﾄﾞの取得
            if (col[name] == null)
            {
                throw new System.Configuration.ConfigurationErrorsException(string.Format("設定ファイル:WebConfigのconnectionStringsタグに、'{0}'の定義が見つかりません。", name));
            }
            base.Provider = col[name].ConnectionString;
        }
    }
    /****************************************************************************************/
    /*	ｸﾗｽ名 ：NpgDBManager														        */
    /*																						*/
    /*	概　要：DB管理ﾏﾈｰｼﾞｬｸﾗｽ																*/
    /*																						*/
    /*	履　歴：2007.03.30	新規作成				IceLine@高村 勉							*/
    /****************************************************************************************/
    public class NpgDBManager : IDisposable
    {
        /****************************************************************************/
        /* Static																	*/
        /****************************************************************************/
        /// <summary>
        /// ﾌﾟﾛﾊﾞｲﾀﾞｰの取得
        /// </summary>
        /// <returns>ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列</returns>
        public static string GetProvider( string sKey )
        {
            string result = "";

            // XMLの生成
            XmlDocument xml_document = new XmlDocument();

            // 初期化
            xml_document.LoadXml( File.ReadAllText( @".\app.config" ) );

            // DBConfigの取得
            foreach (XmlElement xml_coufig in xml_document.SelectNodes("config"))
            {
                // DBConfigの取得
                foreach (XmlElement xml_db_coufig in xml_coufig.SelectNodes("DBConfig"))
                {
                    // ﾌｨｰﾙﾄﾞ情報の保存
                    foreach (XmlNode xml_node in xml_db_coufig.SelectNodes(sKey))
                    {
                        // 属性の取得
                        XmlAttribute attr;
                        if ((attr = xml_node.Attributes["value"]) != null)
                        {
                            result = attr.Value;
                        }
                    }
                }
            }

            return result;
        }
        /****************************************************************************/
        /* ﾒﾝﾊﾞ変数																	*/
        /****************************************************************************/
        private string m_sProvider = "";						    // ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列
        private string m_sLastError = "";						// ｴﾗｰ情報
        private string m_sCommand = "";						    // SQLｺﾏﾝﾄﾞ
        private Queue m_oParams = new Queue();				    // SQLﾊﾟﾗﾒｰﾀ
        private NpgsqlConnection m_con = null;					// 接続情報
        private NpgsqlDataReader m_rec = null;					// 接続ﾚｺｰﾄﾞｾｯﾄ
        private NpgsqlTransaction m_trn = null;                // ﾄﾗﾝｻﾞｸｼｮﾝ
        /****************************************************************************/
        /* ｺﾝｽﾄﾗｸﾀ																	*/
        /****************************************************************************/
        public NpgDBManager()
        {
        }
        /****************************************************************************/
        /* ﾌﾟﾛﾊﾟﾃｨ																	*/
        /****************************************************************************/
        protected string Provider { get { return (m_sProvider); } set { m_sProvider = value; m_con = Setting(); } }
        public string LastError { get { return (m_sLastError); } }
        public string Command { get { return (m_sCommand); } set { m_sCommand = value; m_oParams.Clear(); } }
        /****************************************************************************/
        /* ﾒｿｯﾄﾞ																	*/
        /****************************************************************************/
        public void SetParams(String ix, String value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Varchar);

			if (value == "")
			{
				param.Value = DBNull.Value;
			}
			else
			{
				param.Value = value;
			}
            m_oParams.Enqueue(param);
        }
        public void SetParams(String ix, DateTime value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Date);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        public void SetParamsDateTime(String ix, DateTime value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix,NpgsqlTypes.NpgsqlDbType.Timestamp);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        public void SetParams(String ix, int value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Integer);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        public void SetParams(String ix, long value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Numeric);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        public void SetParamsNumber(String ix, string value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Numeric);

            if (value == "")
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = value;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParams(String ix, string[] value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Varchar);

            if (value != null && value.Length == 0)
            {
                param.Value = null;
            }
            else
            {
                param.Value = value;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParams(String ix, Byte[] value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix,NpgsqlTypes.NpgsqlDbType.Bytea);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        public void SetParams(ArrayList lstName, ArrayList lstType, ArrayList lstValue)
        {
            NpgsqlParameter param;
            DateTime dtValue;
            int iValue;
            Single sngValue;

            for (int iy = 0; iy < lstName.Count; iy++)
            {
                // 型判定
                switch ((string)lstType[iy])
                {
                    case "date":
                        param = new NpgsqlParameter((string)lstName[iy], NpgsqlTypes.NpgsqlDbType.Date);
                        if (DateTime.TryParse((string)lstValue[iy], out dtValue))
                        {
                            param.Value = dtValue;
                        }
                        else
                        {
                            param.Value = null;
                        }
                        break;
                    case "int4":
                        param = new NpgsqlParameter((string)lstName[iy], NpgsqlTypes.NpgsqlDbType.Integer);
                        if (int.TryParse((string)lstValue[iy], out iValue))
                        {
                            param.Value = iValue;
                        }
                        else
                        {
                            param.Value = null;
                        }
                        break;
                    case "numeric":
                        param = new NpgsqlParameter((string)lstName[iy], NpgsqlTypes.NpgsqlDbType.Numeric);
                        if (Single.TryParse((string)lstValue[iy], out sngValue))
                        {
                            param.Value = sngValue;
                        }
                        else
                        {
                            param.Value = null;
                        }
                        break;
                    case "timestamp":
                        param = new NpgsqlParameter((string)lstName[iy], NpgsqlTypes.NpgsqlDbType.Timestamp);
                        if (DateTime.TryParse((string)lstValue[iy], out dtValue))
                        {
                            param.Value = dtValue;
                        }
                        else
                        {
                            param.Value = null;
                        }
                        break;
                    case "text":
                        param = new NpgsqlParameter((string)lstName[iy], NpgsqlTypes.NpgsqlDbType.Text);
                        param.Value = ((string)lstValue[iy]).Length == 0 ? null : ((string)lstValue[iy]);
                        break;
                    default:
                        param = new NpgsqlParameter((string)lstName[iy], NpgsqlTypes.NpgsqlDbType.Varchar);
                        param.Value = ((string)lstValue[iy]).Length == 0 ? null : ((string)lstValue[iy]);
                        break;
                }

                m_oParams.Enqueue(param);
            }
        }
        public void SetParamsIntegerStringArray(String ix, string[] value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Integer);
            int[] ivalues = new int[0];
            int   ivalue;
            int   i = 0;

            if (value != null)
            {
                for (i = 0; i < value.Length; i++)
                {
                    if (int.TryParse(value[i], out ivalue))
                    {
                        Array.Resize<int>(ref ivalues, ivalues.Length + 1); ivalues[ivalues.Length - 1] = ivalue;

                    }
                }
            }
            if (ivalues.Length == 0)
            {
                param.Value = null;
            }
            else
            {
                param.Value = ivalues;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParamsIntegerString(String ix, string value)
        {
            int ivalue;

            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Integer);

            if (int.TryParse(value, out ivalue))
            {
                param.Value = ivalue;
            }
            else
            {
                param.Value = null;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParamsLongString(String ix, string value)
        {
            int ivalue;

            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Integer);

            if (int.TryParse(value, out ivalue))
            {
                param.Value = ivalue;
            }
            else
            {
                param.Value = null;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParamsNumericString(String ix, string value)
        {
            float fvalue;

            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Numeric);

            if (float.TryParse(value, out fvalue))
            {
                param.Value = fvalue;
            }
            else
            {
                param.Value = null;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParamsDateString(String ix, string value)
        {
            DateTime dtm;

            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Date);

            if (DateTime.TryParse(value, out dtm))
            {
                param.Value = dtm;
            }
            else
            {
                param.Value = null;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParamsDateTimeString(String ix, string value)
        {
            DateTime dtm;

            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Timestamp);

            if (DateTime.TryParse(value, out dtm))
            {
                param.Value = dtm;
            }
            else
            {
                param.Value = null;
            }

            m_oParams.Enqueue(param);
        }
        public void SetParamsDoubleArray(String ix, double[] value)
        {
            NpgsqlParameter param = new NpgsqlParameter(ix, NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Integer);
            double[] ivalues = new double[0];
            int i = 0;

            if (value != null)
            {
                for (i = 0; i < value.Length; i++)
                {
                    Array.Resize<double>(ref ivalues, ivalues.Length + 1); ivalues[ivalues.Length - 1] = value[i];
                }
            }
            if (ivalues.Length == 0)
            {
                param.Value = null;
            }
            else
            {
                param.Value = ivalues;
            }

            m_oParams.Enqueue(param);
        }
        /****************************************************************/
        /*	関数名：Query												    */
        /*																*/
        /*	概　要：取得系ｺﾒﾝﾄ実行										    */
        /*																*/
        /*	引  数：cmd		... 実行するSQLｺﾏﾝﾄﾞ						    */
        /*																*/
        /*	戻り値：なし												    */
        /****************************************************************/
        public NpgsqlDataReader Query(string cmd)
        {
            // SQLの設定
            this.Command = cmd;

            // 実行
            return (this.Query());
        }
        public NpgsqlDataReader Query()
        {
            NpgsqlCommand cmd = null;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    if (Open() == true)
                    {
                        try
                        {
                            // ｺﾏﾝﾄﾞの設定
                            cmd = new NpgsqlCommand(m_sCommand, m_con);
                            //
                            // ﾊﾟﾗﾒｰﾀの設定
                            foreach (NpgsqlParameter param in m_oParams)
                            {
                                cmd.Parameters.Add(param);
                            }
                            //
                            // ｺﾏﾝﾄﾞの実行
                            m_rec = cmd.ExecuteReader();

                        }
                        catch (Exception e)
                        {
                            throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                        }
                        finally
                        {
                            m_oParams.Clear();
                            //close connection
                          //  m_con.Close();
                        }
                    }
                }
            }

            // ﾘﾀｰﾝ
            return (m_rec);
        }
        public NpgsqlDataAdapter Query(DataSet dataSet, string setName)
        {
            NpgsqlCommand cmd = null;
            NpgsqlDataAdapter adapter = null;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    if (Open() == true)
                    {
                        try
                        {
                            // ｺﾏﾝﾄﾞの設定
                            cmd = new NpgsqlCommand(m_sCommand, m_con);
                            //
                            // ﾊﾟﾗﾒｰﾀの設定
                            foreach (NpgsqlParameter param in m_oParams)
                            {
                                cmd.Parameters.Add(param);
                            }
                            // ｺﾏﾝﾄﾞの実行
                            adapter = new NpgsqlDataAdapter(cmd);

                            // ﾃﾞｰﾀｾｯﾄへ登録
                            adapter.Fill(dataSet, setName);
                        }
                        catch (Exception e)
                        {
                            throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                        }
                        finally
                        {
                            m_oParams.Clear();
                        }
                    }
                }
            }

            // ﾘﾀｰﾝ
            return adapter;
        }
        /****************************************************************/
        /*	関数名：NonQuery											*/
        /*																*/
        /*	概　要：更新系ｺﾒﾝﾄ実行										*/
        /*																*/
        /*	引  数：cmd		... 実行するSQLｺﾏﾝﾄﾞ						*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void NonQuery(string cmd)
        {
            // SQLの設定
            this.Command = cmd;

            // 実行
            this.NonQuery();
        }
        public void NonQuery()
        {
            NpgsqlCommand cmd;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    // ｵｰﾌﾟﾝ
                    Open();
                    //
                    // ｺﾏﾝﾄﾞの設定
                    cmd = new NpgsqlCommand(m_sCommand, m_con);
                    //
                    // ﾊﾟﾗﾒｰﾀの設定
                    foreach (NpgsqlParameter param in m_oParams)
                    {
                        cmd.Parameters.Add(param);
                    }
                    //
                    // ｺﾏﾝﾄﾞの実行
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /****************************************************************/
        /*	関数名：ExecuteProcedure									*/
        /*																*/
        /*	概　要：ｽﾄｱｯﾄﾞﾌﾟﾛｼｼﾞｬｰの実行								*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        /****************************************************************/
        /*	引  数：cmd	... 実行するｽﾄｱｯﾄﾞﾌﾟﾛｼｼﾞｬｰ						*/
        /****************************************************************/
        public void ExecuteProcedure(string cmd)
        {
            // ｺﾏﾝﾄﾞの設定
            m_sCommand = cmd;

            // 実行
            ExecuteProcedure();
        }
        /****************************************************************/
        /*	引  数：なし												*/
        /****************************************************************/
        public void ExecuteProcedure()
        {
            NpgsqlCommand cmd;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    Open();

                    try
                    {
                        //
                        // ｺﾏﾝﾄﾞの設定
                        cmd = new NpgsqlCommand(m_sCommand, m_con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        //
                        // ﾊﾟﾗﾒｰﾀの設定
                        foreach (NpgsqlParameter param in m_oParams)
                        {
                            cmd.Parameters.Add(param);
                        }
                        //
                        // ｺﾏﾝﾄﾞの実行
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                    }
                    finally
                    {
                        m_oParams.Clear();
                    }
                }
            }
        }
        /****************************************************************/
        /*	関数名：ExecuteNonQuery 									*/
        /*																*/
        /*	概　要：Insert/Update/Deleteの実行							*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        /****************************************************************/
        /*	引  数：cmd	... 実行するｽﾄｱｯﾄﾞﾌﾟﾛｼｼﾞｬｰ						*/
        /****************************************************************/
        public void ExecuteNonQuery(string cmd)
        {
            // ｺﾏﾝﾄﾞの設定
            m_sCommand = cmd;

            // 実行
            ExecuteNonQuery();
        }
        /****************************************************************/
        /*	引  数：なし												*/
        /****************************************************************/
        public void ExecuteNonQuery()
        {
            NpgsqlCommand cmd;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    Open();

                    try
                    {
                        // ｺﾏﾝﾄﾞの設定
                        cmd = new NpgsqlCommand(m_sCommand, m_con);
                        //
                        // ﾊﾟﾗﾒｰﾀの設定
                        foreach (NpgsqlParameter param in m_oParams)
                        {
                            cmd.Parameters.Add(param);
                        }
                        //
                        // ｺﾏﾝﾄﾞの実行
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                    }
                    finally
                    {
                        m_oParams.Clear();
                    }
                }
            }
        }
        /****************************************************************/
        /*	関数名：BeginTran   										*/
        /*																*/
        /*	概　要：ﾄﾗﾝｻﾞｸｼｮﾝﾁｪｯｸ   									*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void BeginTran()
        {
            // ﾄﾗﾝｻﾞｸｼｮﾝ存在ﾁｪｯｸ
            if (m_trn == null)
            {
                // ｵｰﾌﾟﾝ済みﾁｪｯｸ
                if ((m_con.State & ConnectionState.Open) != ConnectionState.Open)
                {
                    Open();
                }
                m_trn = m_con.BeginTransaction();
            }
        }
        /****************************************************************/
        /*	関数名：CommitTran   										*/
        /*																*/
        /*	概　要：ｺﾐｯﾄ              									*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void CommitTran()
        {
            // ﾄﾗﾝｻﾞｸｼｮﾝ存在ﾁｪｯｸ
            if (m_trn != null)
            {
                m_trn.Commit();

                m_trn.Dispose();

                m_trn = null;
            }
        }
        /****************************************************************/
        /*	関数名：CommitAbort   										*/
        /*																*/
        /*	概　要：ｱﾎﾞｰﾄ              									*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void RollbackTran()
        {
            // ﾄﾗﾝｻﾞｸｼｮﾝ存在ﾁｪｯｸ
            if (m_trn != null)
            {
                m_trn.Rollback();

                m_trn.Dispose();

                m_trn = null;
            }
        }
        /****************************************************************/
        /*	関数名：Close												*/
        /*																*/
        /*	概　要：ｸﾛｰｽﾞ												*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void Close()
        {
            // 開放
            this.Dispose();
        }
        /****************************************************************/
        /*	関数名：Dispose												*/
        /*																*/
        /*	概　要：ﾘｿｰｽの開放											*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void Dispose()
        {
            Dispose( true );
        }
        /****************************************************************/
        /*	関数名：Dispose												*/
        /*																*/
        /*	概　要：ﾘｿｰｽの開放											*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        protected virtual void Dispose( bool bDispose )
        {
            // ｴﾗｰは無視
            try
            {
                // ﾚｺｰﾄﾞｾｯﾄ使用済みﾁｪｯｸ
                if (m_rec != null)
                {
                    m_rec.Close();

                    m_rec = null;
                }
                //
                // 接続のｸﾛｰｽﾞ
                if (m_con != null)
                {
                    m_con.Close();
                    //
                    // 初期化
                    m_con = null;
                }
            }
            catch (Exception)
            {
                // Nop
            }
            //
            // GCｺｰﾙ
            GC.SuppressFinalize(this);
        }
        /****************************************************************************/
        /* 関数																		*/
        /****************************************************************************/
        /****************************************************************/
        /*	関数名：DB接続												*/
        /*																*/
        /*	概　要：DBﾍﾞｰｽへ接続を確立する。							*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：DB接続ｵﾌﾞｼﾞｪｸﾄ										*/
        /****************************************************************/
        private NpgsqlConnection Setting()
        {
            try
            {
                // DB接続の設定
                if (m_sProvider == "")
                {
                    return (new NpgsqlConnection(NpgDBManager.GetProvider("connectDB")));
                }
                else
                {
                    return (new NpgsqlConnection(m_sProvider));
                }
            }
            catch (Exception e)
            {
                throw (new IcelineExceptionNpgDBConnect(m_sProvider, e.Message));
            }
        }
        /****************************************************************/
        /*	関数名：DBｵｰﾌﾟﾝ												    */
        /*																        */
        /*	概　要：DBﾍﾞｰｽをｵｰﾌﾟﾝ										        */
        /*																        */
        /*	引  数：なし												        */
        /*																        */
        /*	戻り値：True	... 成功									        */
        /*			false	... 失敗									        */
        /****************************************************************/
        public bool Open()
        {
            try
            {
                //
                // 接続存在ﾁｪｯｸ
                if (m_con != null)
                {
                    // ｵｰﾌﾟﾝ済みﾁｪｯｸ
                    if ((m_con.State & ConnectionState.Open) != ConnectionState.Open)
                    {
                        ////
                        //// ﾚｺｰﾄﾞｾｯﾄ使用済みﾁｪｯｸ
                        if (m_rec != null)
                        {
                            // ｸﾛｰｽﾞ
                            m_rec.Close();
                            //
                           // 初期化
                           m_rec = null;
                       }
                        ////
                        //// ｸﾛｰｽﾞ
                        //m_con.Close();

                        //
                        // ｵｰﾌﾟﾝ
                        m_con.Open();
                    }
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            catch (Exception e)
            {
                throw (new IcelineExceptionNpgDBConnect(m_sProvider, e.Message));
            }
        }
    }
    /****************************************************************************************/
    /*	ｸﾗｽ名 ：DBManager																	*/
    /*																						*/
    /*	概　要：DB管理ﾏﾈｰｼﾞｬｸﾗｽ																*/
    /*																						*/
    /*	履　歴：2007.03.30	新規作成				IceLine@高村 勉							*/
    /****************************************************************************************/
    public class DBManagerNpg : IDisposable
    {
        /****************************************************************************/
        /* ﾒﾝﾊﾞ変数																	*/
        /****************************************************************************/
        private string m_sProvider = "";						// ﾌﾟﾛﾊﾞｲﾀﾞｰ文字列
        private string m_sLastError = "";						// ｴﾗｰ情報
        private string m_sCommand = "";						    // SQLｺﾏﾝﾄﾞ
        private Queue m_oParams = new Queue();				    // SQLﾊﾟﾗﾒｰﾀ
        private OleDbConnection m_con = null;					// 接続情報
        private OleDbDataReader m_rec = null;					// 接続ﾚｺｰﾄﾞｾｯﾄ
        private OleDbTransaction m_trn = null;                  // ﾄﾗﾝｻﾞｸｼｮﾝ
        /****************************************************************************/
        /* ｺﾝｽﾄﾗｸﾀ																	*/
        /****************************************************************************/
        public DBManagerNpg()
        {
        }
        /****************************************************************************/
        /* ﾌﾟﾛﾊﾟﾃｨ																	*/
        /****************************************************************************/
        protected string Provider { get { return (m_sProvider); } set { m_sProvider = value; m_con = Setting(); } }
        public string LastError { get { return (m_sLastError); } }
        public string Command { get { return (m_sCommand); } set { m_sCommand = value; m_oParams.Clear(); } }
        /****************************************************************************/
        /* ﾒｿｯﾄﾞ																	*/
        /****************************************************************************/
        public void SetParams(String ix, String value)
        {
            OleDbParameter param = new OleDbParameter(ix, OleDbType.VarChar);

            param.Value = value;

            m_oParams.Enqueue(param);
        }

        public void SetParams(String ix, DateTime value)
        {
            OleDbParameter param = new OleDbParameter(ix, OleDbType.DBDate);

            param.Value = value;

            m_oParams.Enqueue(param);
        }

        public void SetParamsDateTime(String ix, DateTime value)
        {
            OleDbParameter param = new OleDbParameter(ix, OleDbType.DBTimeStamp);

            param.Value = value;

            m_oParams.Enqueue(param);
        }

        public void SetParams(String ix, int value)
        {
            OleDbParameter param = new OleDbParameter(ix, OleDbType.VarNumeric);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        public void SetParamsNumber(String ix, string value)
        {
            OleDbParameter param = new OleDbParameter(ix, OleDbType.VarNumeric);

            param.Value = value;

            m_oParams.Enqueue(param);
        }
        /****************************************************************/
        /*	関数名：Query												*/
        /*																*/
        /*	概　要：取得系ｺﾒﾝﾄ実行										*/
        /*																*/
        /*	引  数：cmd		... 実行するSQLｺﾏﾝﾄﾞ						*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public OleDbDataReader Query(string cmd)
        {
            // SQLの設定
            this.Command = cmd;

            // 実行
            return (this.Query());
        }
        public OleDbDataReader Query()
        {
            OleDbCommand cmd = null;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    if (Open() == true)
                    {
                        try
                        {
                            // ｺﾏﾝﾄﾞの設定
                            cmd = new OleDbCommand(m_sCommand, m_con);
                            //
                            // ﾊﾟﾗﾒｰﾀの設定
                            foreach (OleDbParameter param in m_oParams)
                            {
                                cmd.Parameters.Add(param);
                            }
                            //
                            // ｺﾏﾝﾄﾞの実行
                            m_rec = cmd.ExecuteReader();

                        }
                        catch (Exception e)
                        {
                            throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                        }
                        finally
                        {
                            m_oParams.Clear();
                        }
                    }
                }
            }

            // ﾘﾀｰﾝ
            return (m_rec);
        }
        public OleDbDataAdapter Query(DataSet dataSet, string setName)
        {
            OleDbCommand cmd = null;
            OleDbDataAdapter adapter = null;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    if (Open() == true)
                    {
                        try
                        {
                            //
                            // ｺﾏﾝﾄﾞの設定
                            cmd = new OleDbCommand(m_sCommand, m_con);
                            OleDbDataReader rd = cmd.ExecuteReader();

                            //
                            // ﾊﾟﾗﾒｰﾀの設定
                            foreach (OleDbParameter param in m_oParams)
                            {
                                cmd.Parameters.Add(param);
                            }
                            // ｺﾏﾝﾄﾞの実行
                            adapter = new OleDbDataAdapter(cmd);

                            // ﾃﾞｰﾀｾｯﾄへ登録
                            adapter.Fill(dataSet, setName);
                        }
                        catch (Exception e)
                        {
                            throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                        }
                        finally
                        {
                            m_oParams.Clear();
                        }
                    }
                }
            }

            // ﾘﾀｰﾝ
            return adapter;
        }
        /****************************************************************/
        /*	関数名：NonQuery											*/
        /*																*/
        /*	概　要：更新系ｺﾒﾝﾄ実行										*/
        /*																*/
        /*	引  数：cmd		... 実行するSQLｺﾏﾝﾄﾞ						*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void NonQuery(string cmd)
        {
            // SQLの設定
            this.Command = cmd;

            // 実行
            this.NonQuery();
        }
        public void NonQuery()
        {
            OleDbCommand cmd;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    // ｵｰﾌﾟﾝ
                    Open();
                    //
                    // ｺﾏﾝﾄﾞの設定
                    cmd = new OleDbCommand(m_sCommand, m_con);
                    //
                    // ﾊﾟﾗﾒｰﾀの設定
                    while (m_oParams.Count > 0)
                    {
                        cmd.Parameters.Add(m_oParams.Dequeue());
                    }
                    //
                    // ｺﾏﾝﾄﾞの実行
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /****************************************************************/
        /*	関数名：ExecuteProcedure									*/
        /*																*/
        /*	概　要：ｽﾄｱｯﾄﾞﾌﾟﾛｼｼﾞｬｰの実行								*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        /****************************************************************/
        /*	引  数：cmd	... 実行するｽﾄｱｯﾄﾞﾌﾟﾛｼｼﾞｬｰ						*/
        /****************************************************************/
        public void ExecuteProcedure(string cmd)
        {
            // ｺﾏﾝﾄﾞの設定
            m_sCommand = cmd;

            // 実行
            ExecuteProcedure();
        }
        /****************************************************************/
        /*	引  数：なし												*/
        /****************************************************************/
        public void ExecuteProcedure()
        {
            OleDbCommand cmd;
            //
            // 初期化
            m_sLastError = "";
            //
            // ｺﾏﾝﾄﾞ存在ﾁｪｯｸ
            if (m_sCommand != "")
            {
                //
                // 接続ﾁｪｯｸ
                if (m_con != null)
                {
                    //
                    // ｵｰﾌﾟﾝ
                    Open();

                    try
                    {
                        // ｺﾏﾝﾄﾞの設定
                        cmd = new OleDbCommand(m_sCommand, m_con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        //
                        // ﾊﾟﾗﾒｰﾀの設定
                        foreach (OleDbParameter param in m_oParams)
                        {
                            cmd.Parameters.Add(param);
                        }
                        //
                        // ｺﾏﾝﾄﾞの実行
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw (new IcelineExceptionNpgSql(e.Message, m_sCommand, m_oParams));
                    }
                    finally
                    {
                        m_oParams.Clear();
                    }
                }
            }
        }
        /****************************************************************/
        /*	関数名：BeginTran   										*/
        /*																*/
        /*	概　要：ﾄﾗﾝｻﾞｸｼｮﾝﾁｪｯｸ   									*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void BeginTran()
        {
            // ﾄﾗﾝｻﾞｸｼｮﾝ存在ﾁｪｯｸ
            if (m_trn == null)
            {
               m_trn = m_con.BeginTransaction();
            }
        }
        /****************************************************************/
        /*	関数名：CommitTran   										*/
        /*																*/
        /*	概　要：ｺﾐｯﾄ              									*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void CommitTran()
        {
            // ﾄﾗﾝｻﾞｸｼｮﾝ存在ﾁｪｯｸ
            if (m_trn != null)
            {
                m_trn.Commit();

                m_trn.Dispose();

                m_trn = null;
            }
        }
        /****************************************************************/
        /*	関数名：CommitAbort   										*/
        /*																*/
        /*	概　要：ｱﾎﾞｰﾄ              									*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void RollbackTran()
        {
            // ﾄﾗﾝｻﾞｸｼｮﾝ存在ﾁｪｯｸ
            if (m_trn != null)
            {
                m_trn.Rollback();

                m_trn.Dispose();

                m_trn = null;
            }
        }
        /****************************************************************/
        /*	関数名：Close												*/
        /*																*/
        /*	概　要：ｸﾛｰｽﾞ												*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void Close()
        {
            // 開放
            this.Dispose();
        }
        /****************************************************************/
        /*	関数名：Dispose												*/
        /*																*/
        /*	概　要：ﾘｿｰｽの開放											*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：なし												*/
        /****************************************************************/
        public void Dispose()
        {
            Dispose( true );
        }
        protected virtual void Dispose( bool bDispose )
        {
            try
            {
                // ﾚｺｰﾄﾞｾｯﾄ使用済みﾁｪｯｸ
                if (m_rec != null)
                {
                    m_rec.Close();

                    m_rec = null;
                }
                // 接続のｸﾛｰｽﾞ
                if (m_con != null)
                {
                    m_con.Close();
                    //
                    // 初期化
                    m_con = null;
                }
            }
            catch
            {
            }
            finally
            {
                // GCｺｰﾙ
                GC.SuppressFinalize(this);
            }
        }
        /****************************************************************************/
        /* 関数																		*/
        /****************************************************************************/
        /****************************************************************/
        /*	関数名：DB接続												*/
        /*																*/
        /*	概　要：DBﾍﾞｰｽへ接続を確立する。							*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：DB接続ｵﾌﾞｼﾞｪｸﾄ										*/
        /****************************************************************/
        private OleDbConnection Setting()
        {
            try
            {
                // DB接続の設定
                if (m_sProvider == "")
                {
                    return (new OleDbConnection(""));
                }
                else
                {
                    return (new OleDbConnection(m_sProvider));
                }
            }
            catch (Exception e)
            {
                throw (new IcelineExceptionNpgDBConnect(m_sProvider, e.Message));
            }
        }
        /****************************************************************/
        /*	関数名：DBｵｰﾌﾟﾝ												*/
        /*																*/
        /*	概　要：DBﾍﾞｰｽをｵｰﾌﾟﾝ										*/
        /*																*/
        /*	引  数：なし												*/
        /*																*/
        /*	戻り値：True	... 成功									*/
        /*			false	... 失敗									*/
        /****************************************************************/
        private bool Open()
        {
            try
            {
                //
                // 接続存在ﾁｪｯｸ
                if (m_con != null)
                {
                    // ｵｰﾌﾟﾝ済みﾁｪｯｸ
                    if ((m_con.State & ConnectionState.Open) == ConnectionState.Open)
                    {
                        //
                        // ﾚｺｰﾄﾞｾｯﾄ使用済みﾁｪｯｸ
                        if (m_rec != null)
                        {
                            // ｸﾛｰｽﾞ
                            m_rec.Close();
                            //
                            // 初期化
                            m_rec = null;
                        }
                        //
                        // ｸﾛｰｽﾞ
                        m_con.Close();
                    }
                    //
                    // ｵｰﾌﾟﾝ
                    m_con.Open();

                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            catch (Exception e)
            {
                throw (new IcelineExceptionNpgDBConnect(m_sProvider, e.Message));
            }
        }
    }
    /****************************************************************************************/
    /*	ｸﾗｽ名 ：IcelineExceptionDBConnect													*/
    /*																						*/
    /*	概　要：SQL実行ｴﾗｰｸﾗｽ																*/
    /*																						*/
    /*	履　歴：2007.03.30	新規作成				IceLine@高村 勉							*/
    /****************************************************************************************/
    public class IcelineExceptionNpgDBConnect : Exception
    {
        public IcelineExceptionNpgDBConnect(string sError, string sConnect)
            : base(sError)
        {
            // ｴﾗｰの設定
            base.Source = sConnect;
        }
        public IcelineExceptionNpgDBConnect(string sError)
            : base(sError)
        {
        }
    }
    /****************************************************************************************/
    /*	ｸﾗｽ名 ：IcelineExceptionSql															*/
    /*																						*/
    /*	概　要：SQL実行ｴﾗｰｸﾗｽ																*/
    /*																						*/
    /*	履　歴：2007.03.30	新規作成				IceLine@高村 勉							*/
    /****************************************************************************************/
    public class IcelineExceptionNpgSql : Exception
    {
        public IcelineExceptionNpgSql(string sError, string sSQL, Queue sqlParam) : base(sError)
        {
            int ix = 0;

            StringBuilder cmd = new StringBuilder();

            // ｺﾏﾝﾄﾞの設定
            cmd.Append(sSQL);

            // 実SQL
            string[] row_sql = sSQL.Split(':');

            // ｺﾏﾝﾄﾞﾊﾟﾗﾒｰﾀの編集
            foreach( NpgsqlParameter param in sqlParam )
            {
                // ﾊﾟﾗﾒｰﾀ情報の取得
                string param_value = "";

                // ﾊﾟﾗﾒｰﾀの追加
                switch (param.DbType)
                {
                    case DbType.VarNumeric:
                        param_value = string.Format("{0:d}", param.Value);
                        break;

                    case DbType.Date:
                        param_value = string.Format("TO_DATE('{0:yyyy/MM/dd}', 'YYYY/MM/DD')", param.Value);
                        break;

                    case DbType.DateTime:
                        param_value = string.Format("TO_DATE('{0:yyyy/MM/dd HH:mm:ss}', 'YYYY/MM/DD HH24:MI:SS')", param.Value);
                        break;

                    case DbType.Binary:
                        param_value = "ﾊﾞｲﾅﾘ情報 .....";
                        break;

                    default:
                        param_value = string.Format("'{0}'", param.Value);
                        break;
                }

                // ﾊﾟﾗﾒｰﾀSQLの設定
                cmd.AppendFormat("\n{0} : {1}", param.ParameterName, param_value);

                // 実SQLの作成
                if (row_sql.Length > ix)
                {
                    if (row_sql[ix].Split(',').Length > 1)
                    {
                        row_sql[ix] += param_value + "," + row_sql[ix].Split(',')[1];
                    }
                    else
                    {
                        if (row_sql[ix].Split(' ').Length > 1)
                        {
                            row_sql[ix] += param_value + " " + row_sql[ix].Split(' ')[1];
                        }
                        else
                        {
                            row_sql[ix] += param_value + " ";
                        }
                    }
                }
                // 次
                ix++;
            }
            // ｴﾗｰの設定
            string sql = "";
            foreach (string parts in row_sql)
            {
                sql += parts;
            }
            base.Source = string.Format("\n\n[ﾊﾟﾗﾒｰﾀSQL]\n{0} \n\n[展開SQL]\n{1}", cmd.ToString(), sql);

            // Debug
            try
            {
                System.IO.File.WriteAllText(@".\DBError-" + DateTime.Now.ToString("yyyyMMddHHmmss.fffff") + ".Log", sql);
            }
            catch(Exception)
            {
                // Nop
            }
            //
        }
    }
}
