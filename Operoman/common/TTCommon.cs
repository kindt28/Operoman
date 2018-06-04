using System;
using System.Text;
using System.Diagnostics;

using Npgsql;


namespace Operoman
{
    /////////////////////////////////////////////////////////////////////////////
    /// <summary> and's共通関数 </summary>
    /// <remarks>
    ///     and'sの共通関数
    ///     [ 更新履歴 ]
    ///         Ver 1.0.0       ... 2015.05.27      ... 高村　勉
    ///             新規作成
    /// </remarks>
    internal static class TTCommon
    {
        /////////////////////////////////////////////////////////////////////////
        /// <summary> DBｵｰﾌﾟﾝ </summary>
        /// <remarks>
        ///     環境情報を元にDBをｵｰﾌﾟﾝ
        /// </remarks>
        /// <param name="evmt">環境情報</param>
        internal static NpgDB DBConnect(TTConfig evmt)
        {
            NpgDB npgDB = new NpgDB(System.Configuration.ConfigurationManager.ConnectionStrings, "DbPgSql");
            // NpgDB npgDB = new NpgDB(     evmt.DBInfo.HOST,
            //                                 evmt.DBInfo.PORT,
            //                                 evmt.DBInfo.DBNAME,
            //                                 evmt.DBInfo.USER,
            //                                 evmt.DBInfo.PASS,
            //                                 evmt.DBInfo.TIMEOUT);
            npgDB.Open();
            //
            // Exit
            return npgDB;           
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary> GUID生成 </summary>
        /// <remarks>
        ///     GUIDを生成
        /// </remarks>
        internal static string CreateGUID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
