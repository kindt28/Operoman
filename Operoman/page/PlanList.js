/// <reference path="..js/jquery-3.1.1.min.js" />
/// <reference path="..js/ttCookie_1.0.0.js" />
/// <reference path="..js/ttGuard_1.0.0.js" />
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
    //alert("A" + SCROLL_BAR_WIDTH);
    //$(window).resize(OnJspListContinerResize);
    OnJspListContinerResize();
}
// -----------------------------------------------------------------
// - 関数名：ｺﾝﾃﾅのﾘｻｲｽﾞ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function OnJspListContinerResize(evt) {
    alert("a");
    var sSub = "";
    var $Continer;
    var $List;
    //
    try {
        $Continer = $('#pid_list_body');
        if ($Continer.length > 0) {
            //$List = $Continer.contents().find('#pid_list_detail');
            var iFrameDOM = $("iframe#pid_list_body").contents();
            selectorTable = iFrameDOM.find('#table_detail_id');
            if (selectorTable.length > 0) {
                sSub = ($Continer.height() >= selectorTable.outerHeight(true) ? "0px" : SCROLL_BAR_WIDTH);
            }
        }
        alert("a1 " + $Continer.height());
        alert("a2 " + selectorTable.height());
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
