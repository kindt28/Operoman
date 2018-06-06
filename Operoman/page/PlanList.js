/// <reference path="..js/jquery-3.1.1.min.js" />
/// <reference path="..js/tableSort.js" />
/// <reference path="..js/ttCookie_1.0.0.js" />
/// <reference path="..js/ttGuard_1.0.0.js" />
/// <reference path="..js/ttMessage_1.0.0.js" />
/// <reference path="..js/common.js" />
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
// -----------------------------------------------------------------
// - 変数
// -----------------------------------------------------------------
var jsp_xxxxxx = true;
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
