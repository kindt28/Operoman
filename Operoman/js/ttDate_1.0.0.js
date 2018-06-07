/// <reference path="jquery-3.1.1.min.js" />
// ----------------------------------------------------------------------------------
// - ﾌｧｲﾙ名    ： ttDate.js
// - 備　考    ： 日付に関するのjavascript処理を提供
// -           
// -             [ 命名規則 ]
// -                ttd_xxxxx               ... 変数
// -                TTD_XXXXX               ... 定数
// -                ttdXXXXXX               ... 関数
// -                         新規作成
// - [ 更新履歴 ] 
// -     Ver 1.0.0       ... 2016.11.01      ... 高村　勉
// -                         新規作成
// ----------------------------------------------------------------------------------
// -----------------------------------------------------------------
// - 定数
// -----------------------------------------------------------------
var TTD_XXXXXX = true;
// -----------------------------------------------------------------
// - 変数
// -----------------------------------------------------------------
var ttd_xxxxxx = true;
// -----------------------------------------------------------------
// - 関数名：ｶﾚﾝﾀﾞｰHTMLの作成 ( ｽﾀｲﾙ : _ttCalender_x.x.x.scssが必要 )
// - 引　数：sCntnrID            ... ｶﾚﾝﾀﾞｰを追加するｺﾝﾃﾅ
// -        datCale             ... ｶﾚﾝﾀﾞｰ年月
// -        datCur              ... ｶﾚﾝﾄ日付
// -        fncMonthDesigClick  ... 年月指定
// -        fncMonthMoveClick   ... 前月/次月ｸﾘｯｸ時のｺｰﾙﾊﾞｯｸ
// -        fncDayClick         ... 日付ｺｰﾙ時のｺｰﾙﾊﾞｯｸ
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function ttdCreateCalenderHTML(     sCntnrID,
                                    datCale,
                                    datCur,
                                    fncMonthDesigClick,
                                    fncMonthMoveClick,
                                    fncDayClick)
{
    var strHTML         = "";
    var strTr           = "";
    var datCalendar    = new Date( datCale.getTime() );
    var datBefMonth    = null;
    var datAftMonth    = null;
    var datTrg          = null;
    var nBefMonth       = 0;
    var nAftMonth       = 0;
    var nTrgTime        = 0;
    var nCur            = 0;
    var sTdHTML         = "   <td class='[class]' data-date='[date]'>[day]</td>";
    var sAttrClass     = "";
    //
    datCalendar  = ttdGetYYYYMM01(datCalendar);
    datBefMonth  = ttdAddDay(datCalendar, -1);
    datAftMonth  = ttdAddMonth(datCalendar, 1);
    datTrg        = ttdAddDay(datCalendar, datCalendar.getDay() * -1);
    //
    strHTML += "<table class='ttCalendarIn'>";
    strHTML += "    <tr>";
    strHTML += "        <td><div>&nbsp;</div></td>";
    strHTML += "        <td>&nbsp;</td>";
    strHTML += "        <td><input type='text' maxlength='4' value='[Year]'  class='TtYearIn' /></td>";
    strHTML += "        <td class='over_txt'>年</td>";
    strHTML += "        <td>&nbsp;</td>";
    strHTML += "        <td><input type='text' maxlength='2' value='[Month]' class='TtMonthIn'/></td>";
    strHTML += "        <td class='over_txt'>月</td>";
    strHTML += "        <td>&nbsp;</td>";
    strHTML += "        <td><div>&nbsp;</div></td>";
    strHTML += "        <td>&nbsp;</td>";
    strHTML += "        <td><div>&nbsp;</div></td>";
    strHTML += "    </tr>";
    strHTML += "</table>";
    //
    strHTML = strHTML.replace("[Year]",     ttdDateFormat(datCalendar,"yyyy"));
    strHTML = strHTML.replace("[Month]",    ttdDateFormat(datCalendar,"MM"));
    //
    strHTML += "<table class='TtCalendar'>";
    strHTML += "   <tr>";
    strHTML += "       <td>日</td>";
    strHTML += "       <td>月</td>";
    strHTML += "       <td>火</td>";
    strHTML += "       <td>水</td>";
    strHTML += "       <td>木</td>";
    strHTML += "       <td>金</td>";
    strHTML += "       <td>土</td>";
    strHTML += "   </tr>";
    //
    nTrgTime    = datTrg.getTime();
    nBefMonth   = datBefMonth.getTime();
    nAftMonth   = datAftMonth.getTime();
    nCur        = (datCur == null ? null : datCur.getTime());
    while ( nTrgTime < nAftMonth )
    {
        strHTML += "   </tr>";
        for (var x = 0; x < 7; x++)
        {
            sAttrClass = (nTrgTime == nCur ?  "active"
                                              : ( nTrgTime <= nBefMonth || nTrgTime >= nAftMonth ? "other" : ""));
            //
            strHTML += sTdHTML.replace("[class]", sAttrClass)
                                 .replace("[date]", ttdDateFormat(datTrg, "yyyy/MM/dd") )
                                 .replace("[day]", datTrg.getDate() );
            //
            datTrg = ttdAddDay(datTrg, 1);
            //
            nTrgTime = datTrg.getTime();
        }
        strHTML += "   </tr>";
    }
    strHTML += "</table>";
    //
    $('#' + sCntnrID).html("");
    $('#' + sCntnrID).append(strHTML);
    //
    $('#' + sCntnrID + " > .TtCalendar   tr:nth-child(n + 2) > td").on('click', fncDayClick);
    $('#' + sCntnrID + " > .ttCalendarIn td:nth-child(1)  > div").on('click', { add: -1 }, fncMonthMoveClick);
    $('#' + sCntnrID + " > .ttCalendarIn td:nth-child(9)  > div").on('click', fncMonthDesigClick);
    $('#' + sCntnrID + " > .ttCalendarIn td:nth-child(11) > div").on('click', { add: 1 }, fncMonthMoveClick);
}
// -----------------------------------------------------------------
// - 関数名：1日日付の取得
// - 引　数：datTrg         ... ﾀｰｹﾞｯﾄ日付
// - 戻り値：ﾀｰｹﾞｯﾄ日付の01日
// - 備　考：なし
// -----------------------------------------------------------------
function ttdGetYYYYMM01(datTrg)
{
    var sDate = "";
    //
    sDate += ("0000" + datTrg.getFullYear()).slice(-4);
    sDate += "/";
    sDate += ("00" + (datTrg.getMonth() + 1)).slice(-2);
    sDate += "/";
    sDate += "01";
    //
    return new Date(sDate);
}
// -----------------------------------------------------------------
// - 関数名：次月日付の取得
// - 引　数：datTrg         ... ﾀｰｹﾞｯﾄ日付
// -         nAdd           ... 加算月 (今のﾊﾞｰｼｮﾝでは、1以外未対応)
// - 戻り値：ﾀｰｹﾞｯﾄ日付へ加算月を足す
// - 備　考：なし
// -----------------------------------------------------------------
function ttdAddMonth(trgDate, nAdd)
{
    var sDate = "";
    var iYear;
    var iMonth;
    //
    iYear  = trgDate.getFullYear();
    iMonth = (trgDate.getMonth() + 1);
    //
    if ((iMonth += nAdd) > 12)
    {
        iYear++;
        iMonth  = 1;
    }
    //
    if (iMonth < 1)
    {
        iYear--;
        iMonth = 12;
    }
    //
    sDate += ("0000" + iYear).slice(-4);
    sDate += "/";
    sDate += ("00" + iMonth).slice(-2);
    sDate += "/";
    sDate += ("00" + trgDate.getDate()).slice(-2);
    //
    return new Date(sDate);
}
// -----------------------------------------------------------------
// - 関数名：日付加算
// - 引　数：trgDate        ... 対象日付
//           nDays          ... 加算日数
// - 戻り値：対象日付に加算日数を加算した日付
// - 備　考：なし
// -----------------------------------------------------------------
function ttdAddDay(trgDate, nDays)
{
    nDays = nDays * 24 * 60 * 60 * 1000;
    //
    return new Date(trgDate.getTime() + nDays);
}
// -----------------------------------------------------------------
// - 関数名：日付ﾌｫｰﾏｯﾄ
// - 引　数：trgDate        ... 対象日付
//           sFormat          ... ﾌｫｰﾏｯﾄ
//                                  yyyy                : 年
//                                  MM                  : 月 (2桁)
//                                  M                   :    (1～2桁)
//                                  dd                  : 日 (2桁)
//                                  d                   :    (1～2桁)
//                                  hh                  : 時 (2桁)
//                                  h                   :    (1～2桁)
//                                  mm                  : 分 (2桁)
//                                  m                   :    (1～2桁)
//                                  ss                  : 秒 (2桁)
//                                  s                   :    (1～2桁)
//                                  hh:mm               : 時刻
//                                  yyyy/MM/dd          : 年月日
//                                  yyyy.MM.dd          : 年月日
//                                  yyyy/MM/dd hh:mm    : 日時
//                                  yyyy.MM.dd hh:mm    : 日時
// - 戻り値：対象日付に加算日数を加算した日付
// - 備　考：なし
// -----------------------------------------------------------------
function ttdDateFormat(trgDate, sFormat)
{
    switch( sFormat )
    {
        case "yyyy":
            return ("0000" + trgDate.getFullYear()).slice(-4);
        case "MM":
            return ("00" + (trgDate.getMonth() + 1)).slice(-2);
        case "M":
            return (trgDate.getMonth() + 1) + "";
        case "dd":
            return ("00" +  trgDate.getDate()).slice(-2);
        case "d":
            return trgDate.getDate() + "";
        case "hh":
            return ("00" +  trgDate.getHours()).slice(-2);
        case "h":
            return trgDate.getHours() + "";
        case "mm":
            return ("00" + trgDate.getMinutes()).slice(-2);
        case "m":
            return trgDate.getMinutes() + "";
        case "ss":
            return ("00" + trgDate.getSeconds()).slice(-2);
        case "s":
            return trgDate.getSeconds() + "";
        case "hh:mm":
            return ttdDateFormat(trgDate, "hh") + ":" +
                    ttdDateFormat(trgDate, "mm");
        case "yyyy/MM/dd":
            return ttdDateFormat(trgDate, "yyyy") + "/" +
                    ttdDateFormat(trgDate, "MM") + "/" +
                    ttdDateFormat(trgDate, "dd");
        case "yyyy.MM.dd":
            return ttdDateFormat(trgDate, "yyyy") + "." +
                    ttdDateFormat(trgDate, "MM") + "." +
                    ttdDateFormat(trgDate, "dd");
        case "yyyy/MM/dd hh:mm":
            return ttdDateFormat(trgDate, "yyyy") + "/" +
                    ttdDateFormat(trgDate, "MM") + "/" +
                    ttdDateFormat(trgDate, "dd") + " " +
                    ttdDateFormat(trgDate, "hh:mm");
        case "yyyy.MM.dd hh:mm":
            return ttdDateFormat(trgDate, "yyyy") + "." +
                    ttdDateFormat(trgDate, "MM") + "." +
                    ttdDateFormat(trgDate, "dd") + " " +
                    ttdDateFormat(trgDate, "hh:mm");
        default:
            return sFormat;
    }
}
// ------------------------------------ EOF -----------------------------------------