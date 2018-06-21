/// <reference path="../js/jquery-3.1.1.min.js" />
/// <reference path="../js/jquery-ui.js" />
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
    OnJspListContinerResize();
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
        $Continer = $('#id_div_table_detail');
        if ($Continer.length > 0) {
            $List = $('#id_table_body');
            if ($List.length > 0) {
                sSub = ($Continer.height() >= $List.outerHeight(true) ? "0px" : SCROLL_BAR_WIDTH);
            }
        }
        $('#id_table_head').css('width', 'calc(100% - ' + sSub + ')');
    }
    catch (ex) {
        jscDEBUGExceptionAlert(ex);
    }
    finally {
        // Nop
    }
}
// ------------------------------------ EOF -----------------------------------------
