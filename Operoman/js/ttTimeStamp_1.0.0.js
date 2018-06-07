/// <reference path="jquery-3.1.1.min.js" />
/// <reference path="ttDlgContiner_1.0.0.js" />
/// <reference path="ttDate_1.0.0.js" />
// -------------------------------------------------------
// - ﾌｧｲﾙ名：ttTimeStamp.0.0.js
// -
// - 備　考：日時選択
// -            [ 関連JS ]
// -                ttDate_x.x.x.js
// -                ttDlgContiner_x.x.x.js
// -
// - 作成日：2016.11.15 ... T.Takamura
// -------------------------------------------------------
function TtTimeStamp()
{
    // ------------------------------------------------------------
    // - ﾒﾝﾊﾞｰ
    // ------------------------------------------------------------
    var m_oParam =  {                                           // ﾊﾟﾗﾒｰﾀ
                        IDLayout            : "tsLayout",       //      ... ﾚｲｱｳﾄID
                        IDContiner          : "ts",             //      ... ｺﾝﾃﾅID
                        IDCalHeadContiner   : "tdCalHead",      //      ...     ｶﾚﾝﾀﾞｰﾍｯﾀﾞｰID
                        IDCalBodyCntiner    : "tdCalBody",      //      ...     ｶﾚﾝﾀﾞｰﾎﾞﾃﾞｨ
                        IDTimeContiner      : "tdTime",         //      ...     時刻
                        IDCommandContiner   : "tdCommand",      //      ...     ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                        IDCalHead           : "tsCalHead",      //      ... ｶﾚﾝﾀﾞｰHead
                        IDTxtYear           : "tsTxtYear",      //      ... 年ﾃｷｽﾄﾎﾞｯｸｽ
                        IDTxtMonth          : "tsTxtMonth",     //      ... 月ﾃｷｽﾄﾎﾞｯｸｽ
                        IDCmdDate           : "tsCmdDate",      //      ... 年月指定
                        IDCmdBackMonth      : "tsCmdBackMonth", //      ... 前月
                        IDCmdNextMonth      : "tsCmdNextMonth", //      ... 次月
                        IDCalBody           : "tsCal",          //      ... ｶﾚﾝﾀﾞｰBody
                        IDTime              : "tsTim",          //      ... 時刻
                        IDTxtHour           : "tsTxtHour",      //      ... 時ﾃｷｽﾄﾎﾞｯｸｽ
                        IDTxtMinus          : "tsTxtMinus",     //      ... 分ﾃｷｽﾄﾎﾞｯｸｽ
                        IDCommand           : "tsCommand",      //      ... ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                        IDCmdOK             : "tsCmdOK",        //      ... 確定ﾎﾞﾀﾝ
                        IDCmdClr            : "tsCmdClr",        //     ... ｸﾘｱｰ
                        IDCmdCan            : "tsCmdCan",       //      ... ｷｬﾝｾﾙﾎﾞﾀﾝ
                        CurStamp            : null,             //      ... ｶﾚﾝﾄ日時
                        DspStamp            : null,             //      ... 表示日時
                        Callback            : null,             //      ... ｺｰﾙﾊﾞｯｸ関数
                        IDLocation          : "",               //      ... 表示位置
                        CmdClr              : false,            //      ... ｸﾘｱｰﾎﾞﾀﾝ表示
                        TimeDisp            : true,             //      ... 時刻表示
                        TopAlign            : false,            //      ... 上揃え
                        LeftAlign           : false,            //      ... 右揃え
                        Last                : null
                    };
    // ------------------------------------------------------------
    // - ﾒｿｯﾄﾞ
    // ------------------------------------------------------------
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：表示処理
    // - 引　数：sBase          ... 表示ﾍﾞｰｽ位置
    // -         bTop           ... true : 上に配置	flase:下に配置
    // -         bLeft          ... true : 左揃え	    flase:右揃え
    // -         bCmdClear      ... true : 表示	    flase:表示
    // -         datCur         ... ｶﾚﾝﾄ日時
    // -         fncCallback    ... 確定/ｷｬﾝｾﾙ時のｺｰﾙﾊﾞｯｸ関数
    // - 戻り値：なし
    // -------------------------------------------------------
    this.Show = function (sBase, bTop, bLeft, bCmdClear, datCur, fncCallback)
    {
        analyzeParam(sBase, bTop, bLeft, bCmdClear, true, datCur, fncCallback);
        ttDlgContiner.Create(m_oParam.IDContiner, "tsContiner");
        createLayout();
        createCal();
        createTime();
        createCommand();
        //
        ttDlgContiner.Show( m_oParam.IDLocation, 
                            m_oParam.TopAlign,
                            m_oParam.LeftAlign,
                            0,
                            0,
                            true);
        //
        $('#' + m_oParam.IDTxtYear).focus();
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：表示処理
    // - 引　数：sBase          ... 表示ﾍﾞｰｽ位置
    // -         bTop           ... true : 上に配置	flase:下に配置
    // -         bLeft          ... true : 左揃え	    flase:右揃え
    // -         bCmdClear      ... true : 表示	    flase:表示
    // -         datCur         ... ｶﾚﾝﾄ日時
    // -         fncCallback    ... 確定/ｷｬﾝｾﾙ時のｺｰﾙﾊﾞｯｸ関数
    // - 戻り値：なし
    // -------------------------------------------------------
    this.ShowNoneTime = function (sBase, bTop, bLeft, bCmdClear, datCur, fncCallback)
    {
        analyzeParam(sBase, bTop, bLeft, bCmdClear, false, datCur, fncCallback);
        ttDlgContiner.Create(m_oParam.IDContiner, "tsContiner");
        createLayout();
        createCal();
        createTime();
        createCommand();
        //
        ttDlgContiner.Show(m_oParam.IDLocation,
                            m_oParam.TopAlign,
                            m_oParam.LeftAlign,
                            0,
                            0,
                            true);
        //
        $('#' + m_oParam.IDTxtYear).focus();
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：ｸﾛｰｽﾞ処理
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    this.Close = function ()
    {
        // ｷｬﾝｾﾙﾎﾞﾀﾝ ｸﾘｯｸ
        $('#tsClear').trigger('click');
    }
    // ------------------------------------------------------------
    // - 内部関数
    // ------------------------------------------------------------
    // -------------------------------------------------------
    // - 関数  ：ﾊﾟﾗﾒｰﾀの解析
    // - 引　数： sBase          ... 表示ﾍﾞｰｽ位置
    // -         bTop           ... true : 上に配置     flase:下に配置
    // -         bLeft          ... true : 左揃え	   flase:右揃え
    // -         bCmdClear      ... true : 表示        flase:非表示
    // -         bTime          ... true : 表示        false:非表示
    // -         datCur         ... ｶﾚﾝﾄ日時
    // -         fncCallback    ... 確定/ｷｬﾝｾﾙ時のｺｰﾙﾊﾞｯｸ関数
    // - 戻り値：解析されたﾊﾟﾗﾒｰﾀ
    // -------------------------------------------------------
    function analyzeParam(sBase, bTop, bLeft, bCmdClear, bTime, datCur, fncCallback)
    {
        m_oParam.IDLocation = sBase;
        m_oParam.TopAlign   = bTop;
        m_oParam.LeftAlign  = bLeft;
        m_oParam.CmdClr     = bCmdClear;
        m_oParam.Callback   = fncCallback;
        m_oParam.TimeDisp   = bTime;
        //
        if (isNaN(datCur))
        {
            m_oParam.CurStamp = new Date(ttdDateFormat(new Date(), "yyyy/MM/dd hh:mm"));
        }else{
            m_oParam.CurStamp = new Date(datCur);
        }
        m_oParam.DspStamp = m_oParam.CurStamp;
    }
    // -------------------------------------------------------
    // - 関数  ：ﾚｲｱｳﾄの作成
    // - 引　数： なし
    // - 戻り値： なし
    // -------------------------------------------------------
    function createLayout()
    {
        var sHTML = "";
        var sTimeDisplay = "";
        //
        if ( !m_oParam.TimeDisp )
        {
            sTimeDisplay = "display:none;";
        }
        //
        sHTML += "<table id='[ID01]'>";
        sHTML += "    " + "<tr>";
        sHTML += "    " + "    " + "<td>"                               + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td id='[ID02]'>"                   + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td>"                               + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td style='[TIME]'>"                + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td style='[TIME]'>"                + "&nbsp;" + "</td>";
        sHTML += "    " + "</tr>";
        sHTML += "    " + "<tr>";
        sHTML += "    " + "    " + "<td>"                               + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td id='[ID03]'>"                   + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td>"                               + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td id='[ID04]' style='[TIME]'>"    + "&nbsp;" + "</td>";
        sHTML += "    " + "    " + "<td             style='[TIME]'>"    + "&nbsp;" + "</td>";
        sHTML += "    " + "</tr>";
        sHTML += "    " + "<tr>";
        sHTML += "    " + "    " + "<td colspan='5' id='[ID05]' >" + "&nbsp;" + "</td>";
        sHTML += "    " + "</tr>";
        sHTML += "</table>";
        //
        sHTML = sHTML
                    .replace("[ID01]", m_oParam.IDLayout)
                    .replace("[ID02]", m_oParam.IDCalHeadContiner)
                    .replace("[ID03]", m_oParam.IDCalBodyCntiner)
                    .replace("[ID04]", m_oParam.IDTimeContiner)
                    .replace("[ID05]", m_oParam.IDCommandContiner)
                    .split('[TIME]').join(sTimeDisplay);
        //
        $(sHTML).appendTo("#" + m_oParam.IDContiner);
    }
    // -------------------------------------------------------
    // - 関数  ：ｶﾚﾝﾀﾞｰ作成
    // - 引　数： なし
    // - 戻り値： なし
    // -------------------------------------------------------
    function createCal()
    {
        createCalHead();
        createCalBody();
    }
    // -------------------------------------------------------
    // - 関数  ：ｶﾚﾝﾀﾞｰ ﾍｯﾀﾞｰ 作成
    // - 引　数： なし
    // - 戻り値： なし
    // -------------------------------------------------------
    function createCalHead()
    {
        var sHTML = "";
        //
        if ($('#' + m_oParam.IDCalHead).length == 0)
        {
            sHTML += "<table id='[ID01]'>";
            sHTML += "    " + "<tr>";
            sHTML += "    " + "    " + "<td>" + "<div id='[CMD01]' >&nbsp;</div>" + "</td>";
            sHTML += "    " + "    " + "<td>" + "&nbsp;" + "</td>";
            sHTML += "    " + "    " + "<td>" + "<input type='text' id='[ID02]'  style='text-align:right;' maxlength='4'/>" + "</td>";
            sHTML += "    " + "    " + "<td>" + "年" + "</td>";
            sHTML += "    " + "    " + "<td>" + "<input type='text' id='[ID03]' style='text-align:right;' maxlength='2'/>" + "</td>";
            sHTML += "    " + "    " + "<td>" + "月" + "</td>";
            sHTML += "    " + "    " + "<td>" + "&nbsp;" + "</td>";
            sHTML += "    " + "    " + "<td>" + "<div id='[CMD03]'>&nbsp;</div>" + "</td>";
            sHTML += "    " + "    " + "<td>" + "&nbsp;" + "</td>";
            sHTML += "    " + "    " + "<td>" + "<div id='[CMD02]' >&nbsp;</div>" + "</td>";
            sHTML += "    " + "</tr>";
            sHTML += "</table>";
            //
            sHTML = sHTML
                        .replace("[ID01]", m_oParam.IDCalHead)
                        .replace("[ID02]", m_oParam.IDTxtYear)
                        .replace("[ID03]", m_oParam.IDTxtMonth)
                        .replace("[CMD01]", m_oParam.IDCmdBackMonth)
                        .replace("[CMD02]", m_oParam.IDCmdNextMonth)
                        .replace("[CMD03]", m_oParam.IDCmdDate);
            //
            $(sHTML).appendTo("#" + m_oParam.IDCalHeadContiner);
            //
            $('#' + m_oParam.IDCmdBackMonth).on('click', { add: -1 }, OnMonthMoveClick);
            $('#' + m_oParam.IDCmdNextMonth).on('click', { add: 1 }, OnMonthMoveClick);
            $('#' + m_oParam.IDCmdDate).on('click', OnChangeMonth);
        }
        //
        $('#' + m_oParam.IDTxtYear).val( ttdDateFormat( m_oParam.DspStamp, "yyyy") );
        $('#' + m_oParam.IDTxtMonth).val(ttdDateFormat( m_oParam.DspStamp, "M") );
    }
    // -------------------------------------------------------
    // - 関数  ：ｶﾚﾝﾀﾞｰ ﾎﾞﾃﾞｨ 作成
    // - 引　数： なし
    // - 戻り値： なし
    // -------------------------------------------------------
    function createCalBody()
    {
        var sHTML = "";
        var datCalendar = ttdGetYYYYMM01(m_oParam.DspStamp);
        var datBefMonth = ttdAddDay(datCalendar, -1);
        var datAftMonth = ttdAddMonth(datCalendar, 1);
        var nBefMonth   = datBefMonth.getTime();
        var nAftMonth   = datAftMonth.getTime();
        var datTrg      = ttdAddDay(datCalendar, datCalendar.getDay() * -1);
        var nTrgTime    = datTrg.getTime();
        var nCur        = (new Date( ttdDateFormat(m_oParam.CurStamp, "yyyy/MM/dd") )).getTime();
        var sAttrClass  = "";
        var sTdHTML     = "   <td class='[class]' data-date='[date]'>[day]</td>";
        //
        sHTML += "<table id='[ID01]'>";
        sHTML += "    " + "<tr>";
        sHTML += "    " + "    " + "<td>" + "日" + "</td>";
        sHTML += "    " + "    " + "<td>" + "月" + "</td>";
        sHTML += "    " + "    " + "<td>" + "火" + "</td>";
        sHTML += "    " + "    " + "<td>" + "水" + "</td>";
        sHTML += "    " + "    " + "<td>" + "木" + "</td>";
        sHTML += "    " + "    " + "<td>" + "金" + "</td>";
        sHTML += "    " + "    " + "<td>" + "土" + "</td>";
        sHTML += "    " + "</tr>";
        //
        while (nTrgTime < nAftMonth)
        {
            sHTML += "   </tr>";
            for (var x = 0; x < 7; x++)
            {
                sAttrClass = (nTrgTime == nCur  ? "active"
                                                : (nTrgTime <= nBefMonth || nTrgTime >= nAftMonth ? "other" : ""));
                //
                sHTML += sTdHTML.replace("[class]", sAttrClass)
                                     .replace("[date]", ttdDateFormat(datTrg, "yyyy/MM/dd"))
                                     .replace("[day]", datTrg.getDate());
                //
                datTrg = ttdAddDay(datTrg, 1);
                //
                nTrgTime = datTrg.getTime();
            }
            sHTML += "   </tr>";
        }
        sHTML += "</table>";
        sHTML = sHTML.replace("[ID01]", m_oParam.IDCalBody);
        //
        if ($('#' + m_oParam.IDCalBody).length >= 1)
        {
            $('[data-date]').off('click');
            //
            $('#' + m_oParam.IDCalBody).remove();
        }
        $(sHTML).appendTo("#" + m_oParam.IDCalBodyCntiner);
        $('[data-date]').on('click', OnDayClick);
    }
    // -------------------------------------------------------
    // - 関数  ：時刻の作成
    // - 引　数： なし
    // - 戻り値： なし
    // -------------------------------------------------------
    function createTime()
    {
        var sHTML = "";
        //
        if ($("#" + m_oParam.IDTime).length == 0)
        {
            sHTML += "<table id='[ID01]'>";
            sHTML += "    " + "<tr>";
            sHTML += "    " + "    " + "<td colspan='3'>" + "時刻" + "</td>";
            sHTML += "    " + "</tr>";
            sHTML += "    " + "<tr>";
            sHTML += "    " + "    " + "<td>" + "<input type='text' style='text-align:right;'  id='[ID02]' maxlength='2'/>" + "</td>";
            sHTML += "    " + "    " + "<td>" + "：" + "</td>";
            sHTML += "    " + "    " + "<td>" + "<input type='text' style='text-align:left;'   id='[ID03]' maxlength='2'/>" + "</td>";
            sHTML += "    " + "</tr>";
            sHTML += "</table>";
            //
            sHTML = sHTML
                        .replace("[ID01]", m_oParam.IDTime)
                        .replace("[ID02]", m_oParam.IDTxtHour)
                        .replace("[ID03]", m_oParam.IDTxtMinus);
            //
            $(sHTML).appendTo("#" + m_oParam.IDTimeContiner);
            //
            $("#" + m_oParam.IDTxtHour).blur(onBlurTime);
            $("#" + m_oParam.IDTxtMinus).blur(onBlurTime);
        }
        //
        $('#' + m_oParam.IDTxtHour).val(ttdDateFormat(m_oParam.DspStamp, "hh"));
        $('#' + m_oParam.IDTxtMinus).val(ttdDateFormat(m_oParam.DspStamp, "mm"));
    }
    // -------------------------------------------------------
    // - 関数  ：ｺﾏﾝﾄﾞﾎﾞﾀﾝ作成
    // - 引　数： なし
    // - 戻り値： なし
    // -------------------------------------------------------
    function createCommand()
    {
        var sHTML = "";
        //
        sHTML += "<table id='[ID01]'>";
        sHTML += "    " + "<tr>";
        sHTML += "    " + "    " + "<td>" + "&nbsp" + "</td>";
        sHTML += "    " + "    " + "<td>" + "<input id='[ID02]' />" + "</td>";
        sHTML += "    " + "    " + "<td>" + "&nbsp" + "</td>";
        sHTML += "    " + "    " + "<td style='display:[CMDCLR];'>" + "<input id='[ID03]' type='image' />" + "</td>";
        sHTML += "    " + "    " + "<td style='display:[CMDCLR];'>" + "&nbsp" + "</td>";
        sHTML += "    " + "    " + "<td>" + "<input id='[ID04]' />" + "</td>";
        sHTML += "    " + "    " + "<td>" + "&nbsp" + "</td>";
        sHTML += "    " + "</tr>";
        sHTML += "</table>";
        //
        sHTML = sHTML
            .replace("[ID01]", m_oParam.IDCommand)
            .replace("[ID02]", m_oParam.IDCmdOK)
            .replace("[ID03]", m_oParam.IDCmdClr)
            .replace("[ID04]", m_oParam.IDCmdCan)
            .replace("[CMDCLR]", (m_oParam.CmdClr ? "" : "none"))
            .replace("[CMDCLR]", (m_oParam.CmdClr ? "" : "none"));
        //
        $(sHTML).appendTo("#" + m_oParam.IDCommandContiner);
        //
        $('#' + m_oParam.IDCmdOK).on('click',   { commit : 1 }, OnCloseCallback);
        $('#' + m_oParam.IDCmdClr).on('click',  { commit : 2 }, OnCloseCallback);
        $('#' + m_oParam.IDCmdCan).on('click',  { commit : 3 }, OnCloseCallback);
    }
    /*
    // -------------------------------------------------------
    // - 関数  ：日時ﾊﾟﾗﾒｰﾀの解析
    // - 引　数：oParam
    // -            ... BaseID      ( 表示ﾍﾞｰｽ位置                    )
    // -            ... Top         ( true : 上に配置	flase:下に配置   )
    // -            ... TopMove     ( 表示位置から上にずらす値(px)     )
    // -            ... Left        ( true : 左揃え	    flase:右揃え )
    // -            ... LeftMove    ( 表示位置から右にずらす値(px)     )
    // -            ... Opacity     ( true : 透明	false:不透明 (省略可))
    // - 戻り値：解析されたﾊﾟﾗﾒｰﾀ
    // -------------------------------------------------------
    function AnalyzeDispParam(oParam)
    {
        if (oParam.FrameID == undefined)
        {
            oParam.FrameID = "";
        }
        //
        if (oParam.BaseID == undefined)
        {
            oParam.BaseID = 'body'
        }
        //
        oParam.ID = m_sID;
        //
        if (oParam.Top == undefined)
        {
            oParam.Top = true;
        }
        if (oParam.TopMove == undefined)
        {
            oParam.TopMove = 0;
        }
        //
        if (oParam.Left == undefined)
        {
            oParam.Left = true;
        }
        if (oParam.LeftMove == undefined)
        {
            oParam.LeftMove = 0;
        }
        //
        if (oParam.Opacity == undefined)
        {
            oParam.Left = false;
        }
        //
        return oParam;
    }
    // -------------------------------------------------------
    // - 関数  ：表示ﾊﾟﾗﾒｰﾀの解析
    // - 引　数：oParam
    // -            ... Title       ( ﾀｲﾄﾙ                    )
    // -            ... CurDate     ( ｶﾚﾝﾄ日時                )
    // -            ... Callback    ( 確定/ｷｬﾝｾﾙ時のｺｰﾙﾊﾞｯｸ関数)
    // - 戻り値：解析されたﾊﾟﾗﾒｰﾀ 
    // -------------------------------------------------------
    function AnalyzeTimeParam(oPara)
    {
        if (oPara.CurDate == undefined || isNaN(oPara.CurDate))
        {
            oPara.CurDate = new Date();
        }
        //
        if (oPara.Title == undefined)
        {
            oPara.Title = "タイトルなし";
        }
        //
        if (oPara.Callback == undefined)
        {
            oPara.Title = null;
        }
        //
        return oPara;
    }
    // -------------------------------------------------------
    // - 関数  ：ﾀｲﾄﾙの作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function createTitle()
    {
        var strHTML;
        //
        strHTML = "<div class='tsTitle' >" + (m_sTitle == "" ? "&nbsp;" : m_sTitle) + "</div>";
        $('#' + m_sID).append(strHTML);
        //
        strHTML = "<div class='tsTtlDate' >日付</div>";
        $('#' + m_sID).append(strHTML);
        //
        strHTML = "<div class='tsTtlTime' >時刻</div>";
        $('#' + m_sID).append(strHTML);
    }
    // -------------------------------------------------------
    // - 関数  ：ｶﾚﾝﾀﾞｰｺﾝﾃﾅの作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function createCaleContiner()
    {
        var strHTML = "";
        //
        strHTML += "<div id='" + m_sCaleCntnrID + "' class='tsCalendar'></div>";
        strHTML += "<div style='clear:both;' >&nbsp;</div>";
        //
        $('#' + m_sID).append(strHTML);
    }
    // -----------------------------------------------------------------
    // - 関数名：ｶﾚﾝﾀﾞｰの作成
    // - 引　数：なし
    // - 戻り値：true : 正常  false : 以上
    // - 備　考：なし
    // -----------------------------------------------------------------
    function createCalender()
    {
        ttdCreateCalenderHTML(   m_sCaleCntnrID,
                                    m_datCalender,
                                    m_datCurrent,
                                    OnMonthGoClick,
                                    OnMonthMoveClick,
                                    OnDayClick);
    }
    // -----------------------------------------------------------------
    // - 関数名：日時作成
    // - 引　数：なし
    // - 戻り値：なし
    // - 備　考：なし
    // -----------------------------------------------------------------
    function createTime()
    {
        var strHTML = "";
        //
        if ($('#' + m_sTimeCntnrID).length == 0)
        {
            strHTML += "<div id='" + m_sTimeCntnrID  + "' class='tsTimeContiner'>&nbsp;";
            strHTML += "    <div class='tsTimeNow'>現在日時</div>";
            strHTML += "    <input type='text' class='tsHour'   maxlength='2' value='[Hours]' />";
            strHTML += "    <div class='tsTimeCap'>：</div>";
            strHTML += "    <input type='text' class='tsMinute' maxlength='2' value='[Minutes]' />";
            strHTML += "</div>";
            strHTML  = strHTML.replace("[Hours]",   ttdDateFormat(m_timCurrent, "hh") )
                                .replace("[Minutes]", ttdDateFormat(m_timCurrent, "mm") );
            $('#' + m_sID).append(strHTML);
        } else {
            strHTML += "    <div class='tsTimeNow'>現在時刻</div>";
            strHTML += "    <input type='text' class='tsHour'   maxlength='2' value='[Hours]' />";
            strHTML += "    <div class='tsTimeCap'>：</div>";
            strHTML += "    <input type='text' class='tsMinute' maxlength='2' value='[Minutes]' />";
            strHTML  = strHTML.replace("[Hours]",   ttdDateFormat(m_timCurrent, "hh") )
                                .replace("[Minutes]", ttdDateFormat(m_timCurrent, "mm"));
            //
            $('#' + m_sTimeCntnrID).html(strHTML);
            //
            $('#' + m_sTimeCntnrID + " " + ".tsHour").focus();
        }
        //
        $('#' + m_sTimeCntnrID + " " + ".tsTimeNow").on('click',    OnTimeNow);
        $('#' + m_sTimeCntnrID + " " + ".tsHour").on('change',      OnTimeChange);
        $('#' + m_sTimeCntnrID + " " + ".tsMinute").on('change',    OnTimeChange);
    }
    // -----------------------------------------------------------------
    // - 関数名：日時確認
    // - 引　数：なし
    // - 戻り値：なし
    // - 備　考：なし
    // -----------------------------------------------------------------
    function createCheck()
    {
        var strHTML = "";
        //
        if ($('#' + m_sCheckCntnrID).length == 0)
        {
            strHTML += "<div id='" + m_sCheckCntnrID + "' class='tsChkContiner'>";
            strHTML += "    <div class='ftsCheckCaption'>確認：</div>";
            strHTML += "    <div class='ftsCheckCaption'>[Date]&nbsp;[Time]</div>";
            strHTML += "</div>";
            strHTML = strHTML.replace("[Date]", ttdDateFormat(m_datCurrent, "yyyy/MM/dd"));
            strHTML = strHTML.replace("[Time]", ttdDateFormat(m_timCurrent, "hh:mm"));
            $('#' + m_sID).append(strHTML);
        }
        else
        {
            strHTML += "    <div class='ftsCheckCaption'>確認：</div>";
            strHTML += "    <div class='ftsCheckCaption'>[Date]&nbsp;[Time]</div>";
            strHTML = strHTML.replace("[Date]", ttdDateFormat(m_datCurrent, "yyyy/MM/dd"));
            strHTML = strHTML.replace("[Time]", ttdDateFormat(m_timCurrent, "hh:mm"));
            $('#' + m_sCheckCntnrID).html(strHTML);
        }
    }
    // -------------------------------------------------------
    // - 関数  ：確定ﾎﾞﾀﾝ作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function createCommitButton()
    {
        ttDlgContiner.CreateClose(  "tsCommit",
                                        "確定",
                                        "tsButton",
                                        false,
                                        OnCloseCallback,
                                        { commit: 1 });
    }
    // -------------------------------------------------------
    // - 関数  ：ｸﾘｱｰﾎﾞﾀﾝ作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function createClearButton()
    {
        ttDlgContiner.CreateClose(  "tsClear",
                                        "クリア",
                                        "tsButton",
                                        true,
                                        OnCloseCallback,
                                        { commit: 2 });
    }
    // -------------------------------------------------------
    // - 関数  ：ｷｬﾝｾﾙﾎﾞﾀﾝ作成
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function createCancelButton()
    {
        ttDlgContiner.CreateClose(  "tsCancel",
                                        "キャンセル",
                                        "tsButton",
                                        true,
                                        OnCloseCallback,
                                        { commit: 3 });
    }
    // -----------------------------------------------------------------
    // - 関数名：ｶﾚﾝﾀﾞｰ年月指定
    // - 引　数：evt               ... ｲﾍﾞﾝﾄ引数
    // - 戻り値：なし
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnMonthGoClick(evt)
    {
        try
        {
            ChangeMonth();
        }
        catch (ex)
        {
        }
        finally
        {
            return false;
        }
    }
    // -----------------------------------------------------------------
    // - 関数名：時刻変更
    // - 引　数：evt               ... ｲﾍﾞﾝﾄ引数
    // - 戻り値：true : ｲﾍﾞﾝﾄ続行	false : ｲﾍﾞﾝﾄ中止
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnTimeChange(evt)
    {
        var sYear   = $('#' + m_sTimeCntnrID + " " + ".tsHour").val();
        var sMonth = $('#' + m_sTimeCntnrID + " " + ".tsMinute").val();
        var smpInTime = new Date("1970/01/01" + " " + sYear + ":" + sMonth);
        //
        if (!isNaN(smpInTime))
        {
            m_timCurrent = smpInTime;
        }
        //
        createCheck();
        //
        return false;
    }
    // -----------------------------------------------------------------
    // - 関数名：現在時刻ｸﾘｯｸ
    // - 引　数： evt               ... ｲﾍﾞﾝﾄ引数
    //              .data           ... ﾊﾞｲﾝﾄﾞ時に渡されたﾃﾞｰﾀ
    // - 戻り値：なし
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnTimeNow(evt)
    {
        var datCur = new Date();
        //
        //
        m_datCalender = new Date(ttdDateFormat(datCur, "yyyy/MM/dd"));
        m_datCurrent  = new Date(ttdDateFormat(datCur, "yyyy/MM/dd"));
        m_timCurrent  = new Date("1970/01/01" + " " + ttdDateFormat(datCur, "hh:mm"));
        //
        createCalender();
        createTime();
        createCheck();
        //
        return false;
    }
    */
    // -----------------------------------------------------------------
    // - 関数名：時刻ﾌｫｰｶｽ移動
    // - 引　数：なし
    // - 戻り値：true : ｲﾍﾞﾝﾄ続行	false : ｲﾍﾞﾝﾄ中止
    // - 備　考：なし
    // -----------------------------------------------------------------
    function onBlurTime()
    {
        var sHour  = $('#' + m_oParam.IDTxtHour).val();
        var sMinut = $('#' + m_oParam.IDTxtMinus).val();
        var sCur   = ttdDateFormat( m_oParam.CurStamp, "yyyy/MM/dd") + " " + sHour + ":" + sMinut;
        var datCur = new Date(sCur);
        //
        if (!isNaN(datCur))
        {
            m_oParam.CurStamp = datCur;
            //
            m_oParam.DspStamp = new Date(ttdDateFormat(m_oParam.DspStamp, "yyyy/MM/dd") + " " + sHour + ":" + sMinut );
        }
        //
        createTime();
    }
    // -----------------------------------------------------------------
    // - 関数名：ｶﾚﾝﾀﾞｰ前月/次月ｸﾘｯｸ
    // - 引　数：evt               ... ｲﾍﾞﾝﾄ引数
    // - 戻り値：true : ｲﾍﾞﾝﾄ続行	false : ｲﾍﾞﾝﾄ中止
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnMonthMoveClick(evt)
    {
        try
        {
            var datDsp = ttdGetYYYYMM01(m_oParam.DspStamp);
                datDsp = ttdAddMonth( datDsp, evt.data.add );
            var sCur   = ttdDateFormat(datDsp, "yyyy/MM/dd") + " " + ttdDateFormat(m_oParam.DspStamp, "hh:mm");
            //
            m_oParam.DspStamp = new Date(sCur);
            //
            createCal();
        }
        catch (ex) {
        }
        finally {
            return false;
        }
    }
    // -----------------------------------------------------------------
    // - 関数名：年月変更
    // - 引　数：なし
    // - 戻り値：なし
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnChangeMonth()
    {
        var sYear   = $('#' + m_oParam.IDTxtYear).val();
        var sMonth  = $('#' + m_oParam.IDTxtMonth).val();
        var sCur    = sYear + "/" + sMonth + "/" + "01" + " " + ttdDateFormat(m_oParam.DspStamp, "hh:mm");
        var datIn   = new Date( sCur );
        //
        if (!isNaN(datIn))
        {
            m_oParam.DspStamp = datIn;
        }
        //
        createCal();
        //
        return false;
    }
    // -----------------------------------------------------------------
    // - 関数名：ｶﾚﾝﾀﾞｰｾﾙｸﾘｯｸ
    // - 引　数：evt               ... ｲﾍﾞﾝﾄ引数
    // - 戻り値：true : ｲﾍﾞﾝﾄ続行	false : ｲﾍﾞﾝﾄ中止
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnDayClick(evt)
    {
        try
        {
            var sCur = $(this).attr('data-date') + " " + ttdDateFormat(m_oParam.CurStamp, "hh:mm");
            //
            $('#' + m_oParam.IDCalBody + " .active").removeClass('active');
            //
            $(this).addClass('active');
            //
            m_oParam.CurStamp = new Date(sCur);
            m_oParam.DspStamp = m_oParam.CurStamp;
            createCal();
        }
        catch (ex)
        {
        }
        finally
        {
            return false;
        }
    }
    // -----------------------------------------------------------------
    // - 関数名：ｸﾛｰｽﾞｸﾘｯｸ
    // - 引　数： evt               ... ｲﾍﾞﾝﾄ引数
    //              .data           ... ﾊﾞｲﾝﾄﾞ時に渡されたﾃﾞｰﾀ
    //                  1 : 確定
    //                  2 : ｸﾘｱｰ
    //                  3 : ｷｬﾝｾﾙ
    // - 戻り値：true : ｲﾍﾞﾝﾄ続行	false : ｲﾍﾞﾝﾄ中止
    // - 備　考：なし
    // -----------------------------------------------------------------
    function OnCloseCallback(evt)
    {
        var sResult = "";
        //
        // 確定判定
        switch( evt.data.commit )
        {
            case 1:
                m_oParam.Callback(true, m_oParam.CurStamp);
                break;
            case 2:
                m_oParam.Callback(true, null);
                break;
            default:
                m_oParam.Callback(false, null);
                break;
        }
        //
        $('#' + m_oParam.IDCmdBackMonth).off('click');
        $('#' + m_oParam.IDCmdNextMonth).off('click');
        $('#' + m_oParam.IDCmdDate).off('click');
        $('[data-date]').off('click');
        $('#' + m_oParam.IDCmdOK).off('click');
        $('#' + m_oParam.IDCmdCan).off('click' );
        //
        ttDlgContiner.Close();
        //
        return false;
    }
}
