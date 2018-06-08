/// <reference path="jquery-3.1.1.min.js" />
/// <reference path="ttDlgContiner_1.0.0.js" />
// -------------------------------------------------------
// - ﾌｧｲﾙ名：ttMessage_1.0.0.js
// -
// - 備　考：ﾒｯｾｰｼﾞﾀﾞｲｱﾛｸﾞ
// -
// - 作成日：2016.11.15 ... T.Takamura
// -------------------------------------------------------
function TtMessage()
{
    // ------------------------------------------------------------
    // - ﾒﾝﾊﾞｰ
    // ------------------------------------------------------------
    var ID_CONTINER         = "msgContiner";         // ｺﾝﾃﾅID
    var ID_CONTINER_BUTTON = "msg_command";         // ﾎﾞﾀﾝｺﾝﾃﾅ
    var ID_BUTTON_TMP       = "msgButton[no]";      // ﾎﾞﾀﾝID
    //
    var MSG_TYPE_INFO       = "I";                    // 情報
    var MSG_TYPE_WARNING    = "W";                    // 警告
    var MSG_TYPE_ERROR      = "E";                    // ｴﾗｰ
    //
    var m_oParam            = null;                   // ﾊﾟﾗﾒｰﾀ
    var m_oButtonID         =null;                   // ﾎﾞﾀﾝID
    // ------------------------------------------------------------
    // - ﾒｿｯﾄﾞ
    // ------------------------------------------------------------
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：ﾀｲﾄﾙ設定
    // - 引　数：oParam
    //              .Type           ... ﾒｯｾｰｼﾞ種類
    //              .Title          ... ﾀｲﾄﾙ
    //              .MessageHTML    ... ﾒｯｾｰｼﾞ (HTML形式)
    //              .Button[n]
    //                  .Caption    ... ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ
    //                  .Class      ... ｸﾗｽ名
    //                  .Callback   ... ｺｰﾙﾊﾞｯｸ
    // - 戻り値：なし
    // -------------------------------------------------------
    this.Show = function ( oParam )
    {
        m_oParam = AnalysisParameter(oParam);
        //
        if ($('#' + ID_CONTINER).length == 0)
        {
            ttDlgContiner.Create(ID_CONTINER, "msgContiner");
            CreateMessage();
            CreateButton();
            ttDlgContiner.ShowCenter();
        }else{
            CreateMessage();
            CreateButton();
        }
    }
    // ------------------------------------------------------------
    // - 内部関数
    // ------------------------------------------------------------
    // -------------------------------------------------------
    // - 関数  ：ﾊﾟﾗﾒｰﾀ分析
    // - 引　数：oParam
    //              .Type           ... ﾒｯｾｰｼﾞ種類
    //              .Title          ... ﾀｲﾄﾙ
    //              .MessageHTML    ... ﾒｯｾｰｼﾞ (HTML形式)
    //              .Button[n]
    //                  .Caption    ... ﾎﾞﾀﾝｷｬﾌﾟｼｮﾝ
    //                  .Class      ... ｸﾗｽ名
    //                  .Callback   ... ｺｰﾙﾊﾞｯｸ
    // - 戻り値：分析後のﾊﾟﾗﾒｰﾀ
    // -------------------------------------------------------
    function AnalysisParameter(oParam)
    {
        var oButton;
        //
        if (oParam.Type == undefined) oParam.Type = "?00000";
        //
        if (oParam.Title == undefined) oParam.Title = "タイトルなし";
        //
        if (oParam.MessageHTML == undefined) oParam.MessageHTML = "&nbsp;";
        //
        if (oParam.Button == undefined)
        {
            oParam.Button = new Array();
        } else {

            oButton = oParam.Button;
            //
            for (var ix = 0; ix < oButton.length; ix++)
            {
                if (oButton[ix].Caption  == undefined) oButton[ix].Caption = "&nbsp;";
                //
                if (oButton[ix].Class    == undefined) oButton[ix].Class = "";
                //
                if (oButton[ix].Callback == undefined) oButton[ix].Callback = null;
            }
        }
        //
        return oParam;
    }
    // -------------------------------------------------------
    // - 関数  ：ﾒｯｾｰｼﾞ作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function CreateMessage()
    {
        var sHTML = "";
        //
        sHTML += "<div id='msg_title'>";
        sHTML += "    <table>";
        sHTML += "        <tr>";
        sHTML += "            <td><div id='msg_title_icon'>&nbsp;</div></td>";
        sHTML += "            <td>&nbsp;" + m_oParam.Title + "</td>";
        sHTML += "        <tr>";
        sHTML += "    </table>";
        sHTML += "</div>";
        sHTML += "<div id='msg_message'>";
        sHTML += m_oParam.MessageHTML;
        sHTML += "</div>";
        sHTML += "<div id='" + ID_CONTINER_BUTTON + "'>&nbsp;" + "</div>";
        //
        // 追加
        $('#' + ID_CONTINER).append(sHTML);
    }
    // -------------------------------------------------------
    // - 関数  ：ﾎﾞﾀﾝ作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function CreateButton()
    {
        var oButton         = m_oParam.Button;
        var iButtonCount   = m_oParam.Button.length;
        var sHTML_LI        = "";
        //
        if (iButtonCount > 0)
        {
            m_oButtonID = new Array();
            //
            for( var ix = 0; ix < iButtonCount; ix++ )
            {
                m_oButtonID[ix] = ID_BUTTON_TMP.replace('[no]', ix);
                //
                sHTML_LI += "<li><div id='[Id]' class='[Class]'>[Caption]</div></li>"
                                .replace("[Id]", m_oButtonID[ix])
                                    .replace("[Class]", oButton[ix].Class)
                                        .replace("[Caption]", oButton[ix].Caption);
            }
            $('#' + ID_CONTINER_BUTTON).append("<ul>" + sHTML_LI + "</ul>");
            //
            for (var ix = 0; ix < iButtonCount; ix++)
            {
                $('#' + m_oButtonID[ix]).on('click', { type: m_oParam.Type, info: m_oParam.Info, no: ix }, OnButtonClick);
            }
        }
    }
    // -----------------------------------------------------------------
    // - 関数名：ﾎﾞﾀﾝｸﾘｯｸ
    // - 引　数： evt               ... ｲﾍﾞﾝﾄ引数
    //              .data           ... ﾊﾞｲﾝﾄﾞ時に渡されたﾃﾞｰﾀ
    //                  .no         ... ﾎﾞﾀﾝ番号
    // - 戻り値：true : ｲﾍﾞﾝﾄ続行	false : ｲﾍﾞﾝﾄ中止
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnButtonClick(evt)
    {
        var no;
        //
        try
        {
            // ﾎﾞﾀﾝ番号
            no = evt.data.no;
            //
            // ﾛｰﾙﾊﾞｯｸ
            if( m_oParam.Callback != null )
            {
                m_oParam.Callback(evt);
            }
            //
            // ｲﾍﾞﾝﾄ
            if (m_oButtonID != null)
            {
                for (var ix = 0; ix < m_oButtonID.length; ix++)
                {
                    $('#' + m_oButtonID[ix]).off('click');
                }
            }
            //
            // ｸﾛｰｽﾞ
            ttDlgContiner.Close();
        }
        catch (ex)
        {
        }
        finally
        {
            return false;
        }
    }
}
var ttMessage = new TtMessage();
