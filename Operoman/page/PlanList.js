/// <reference path="../js/jquery-3.1.1.min.js" />
/// <reference path="../js/tableSort.js" />
/// <reference path="../js/ttCookie_1.0.0.js" />
/// <reference path="../js/ttGuard_1.0.0.js" />
/// <reference path="../js/ttMessage_1.0.0.js" />
/// <reference path="../js/ttDate_1.0.0.js" />
/// <reference path="../js/ttDlgContiner_1.0.0.js" />
/// <reference path="../js/ttTimeStamp_1.0.0.js" />
/// <reference path="../js/common.js" />
// ----------------------------------------------------------------------------------
// - ﾌｧｲﾙ名    ： ﾛｸﾞｲﾝﾍﾟｰｼﾞ
// - 備　考    ： ﾛｸﾞｲﾝﾍﾟｰｼﾞのjavascript処理を提供
// -           
// -             [ 命名規則 ]
// -                jsp_xxxxx               ... 変数
// -                JSP_XXXXX               ... 定数
// -                jspXXXXXX               ... 関数
// -                OnJspXXXX               ... ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
// -                         新規作成
// - [ 更新履歴 ] 
// -     Ver 1.0.0       ... 2018.06.04      ... Phat
// -                         新規作成
// ----------------------------------------------------------------------------------
// -----------------------------------------------------------------
// - 定数
// -----------------------------------------------------------------
var JSP_XXXXXX = true;
var JSP_COOKIE_START_DATE = 1;                // 開始日付
// -----------------------------------------------------------------
// - 変数
// -----------------------------------------------------------------
var jsp_xxxxxx = true;
var jspTtTimeStamp = new TtTimeStamp();
// -----------------------------------------------------------------
// - 関数名：ｲﾍﾞﾝﾄ登録
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jspAddEvent() {
    $('#btn_update_id').on('click', jspRefreshDetail);
    $(window).resize(OnJspListContinerResize);
    $('#table_hed_id thead').on('click', 'th', function () {

       // alert("a");
        var table1 = $("#pid_list_body").contents().find("#table_detail_id");
        var tr1 = table1.find('tr');
        //alert($(this).attr('data-order'));
        //alert($(this).attr('data-column'));
        //alert($(this).attr('data-key'));
        //alert($('table1 tbody tr'));
        var sorted = sorter.setOrder($(this).attr('data-order'))
                   .setColumn($(this).attr('data-column'))
                   .setKey($(this).attr('data-key'))
                   .sort(tr1);


        table1.find('tbody').empty().append(sorted);

        $('table thead th').not(this)
                           .attr('data-order', 'asc');

        $(this).attr(
            'data-order',
            ($(this).attr('data-order') == 'asc' ? 'desc' : 'asc')
        );

    });
    $('#trFltYearMonth').on('click', OnJspStartDateClick);
}
// -----------------------------------------------------------------
// - 関数名：子ﾌﾚｰﾑﾛｰﾄﾞ完了
// - 引　数：
// - 戻り値：なし
// - 備　考：ﾌﾚｰﾑ側のscriptからは
// -         window.parent.OnJspLoadComplete();で、ｱｸｾｽ
// -----------------------------------------------------------------
function OnJspLoadComplete() {
    try {
        // ｽｸﾛｰﾙﾊﾞｰの制御
        OnJspListContinerResize();    
        // ｶﾞｰﾄﾞの消去
        jscGuardDestory();
    }
    catch (ex) {
        jscDEBUGExceptionAlert(ex);
    }
    finally {
        ttGuard.destory();
    }
}
// -----------------------------------------------------------------
// - 関数名：表示日付ｸﾘｯｸ
// - 引　数：evt               ... ｲﾍﾞﾝﾄ引数
// - 戻り値：なし
// - 備　考：日付入力の表示
// -----------------------------------------------------------------
function OnJspStartDateClick() {
    try {
        //var sDate = jscGetArrayParamIX(JSC_COOKIE_PARAM_LV1_ID,
        //                                JSP_COOKIE_BASE_DATE);
        //
        //jspTtTimeStamp.ShowNoneTime("trFltYearMonth",
        //                                false,
        //                                true,
        //                                false,
        //                                new Date(sDate),
        //                                OnJspBaseDateClose);
        var datCalendar = new Date("2018/06/30");
        //alert(ttdDateFormat(datCalendar, 'yyyy/MM/dd'));
        jspTtTimeStamp.ShowNoneTime("trFltYearMonth",
                                        false,
                                        true,
                                        false,
                                        new Date(datCalendar),
                                        OnJspStartDateClose);
    }
    catch (ex) {
        jscDEBUGExceptionAlert(ex);
    }
    finally {
        return false;
    }
}
// -----------------------------------------------------------------
// - 関数名：表示日付指定ｸﾛｰｽﾞ
// - 引　数：evt               ... ｲﾍﾞﾝﾄ引数
// - 戻り値：なし
// - 備　考：表示日付の設定
// -----------------------------------------------------------------
function OnJspStartDateClose(bCommit, smpSel) {
    var nChange;
    //
    // 確定判定
    if (bCommit) {
        jscSetArrayParamIX(JSC_COOKIE_PARAM_LV1_ID,
                            JSP_COOKIE_START_DATE,
                            ttdDateFormat(smpSel, "yyyy/MM/dd"));
        //
        jspDispStartDate();
        ////
        //jspReloadDetail();
        ////
        //SetFocus();
    }
}
// -----------------------------------------------------------------
// - 関数名：ﾍﾞｰｽ日付の表示
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jspDispStartDate() {
    var sDate = jscGetArrayParamIX(JSC_COOKIE_PARAM_LV1_ID, JSP_COOKIE_START_DATE);
    var dtDate = null;
    var sHtml = "";
    var sCaption = "[yyyy]年[m]月[d]日";
    //
    dtDate = new Date(sDate);
    //
    sHtml = "<span class='size_mixed'>[yyyy]&nbsp;<span>年</span>&nbsp;[m]&nbsp;<span>月</span>&nbsp;[d]&nbsp;<span>日</span></span>"
                .replace("[yyyy]", ttdDateFormat(dtDate, "yyyy"))
                    .replace("[m]", ttdDateFormat(dtDate, "M"))
                        .replace("[d]", ttdDateFormat(dtDate, "d"));
    //
    sCaption = sCaption
                .replace("[yyyy]", ttdDateFormat(dtDate, "yyyy"))
                    .replace("[m]", ttdDateFormat(dtDate, "M"))
                        .replace("[d]", ttdDateFormat(dtDate, "d"));
    //
    $('#divExeStamp').attr('title', sCaption);
    $('#divExeStamp').html(sHtml);
}
// -----------------------------------------------------------------
// - 関数名：ﾘｽﾄ明細のﾘﾌﾚｯｼｭ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jspRefreshDetail() {
    var sURL = "";
    //
    try {
        ttGuard.showWait();
        //
        sURL = 'PlanListDetail.aspx';
        //
        $('#pid_list_body').attr('src', sURL);
    }
    catch (ex) {
        jscDEBUGExceptionAlert(ex);
    }
    finally {
        // Nop
    }
}
// -----------------------------------------------------------------
// - 関数名：ｺﾝﾃﾅのﾘｻｲｽﾞ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function OnJspListContinerResize(evt) {
    var sSub = "";
    var $Continer;
    var $List;
    //
    try {
        $Continer = $('#pid_list_body');
        if ($Continer.length > 0) {
            $List = $Continer.contents().find('#table_detail_id');
            if ($List.length > 0) {
                sSub = ($Continer.height() >= $List.outerHeight(true) ? "0px" : SCROLL_BAR_WIDTH);
            }
        }
        $('#table_hed_id').css('width', 'calc(100% - ' + sSub + ')');
    }
    catch (ex) {
        jscDEBUGExceptionAlert(ex);
    }
    finally {
        // Nop
    }
}







// ------------------------------------ EOF -----------------------------------------
