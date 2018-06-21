﻿/// <reference path="../js/jquery-3.1.1.min.js" />
/// <reference path="../js/ttCookie_1.0.0.js" />
/// <reference path="../js/ttGuard_1.0.0.js" />
/// <reference path="../js/common.js" />
/// <reference path="../js/datepicker.js" />
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
    $('#plan_link_id').on('click', { page: 'PlanList.aspx' }, changePage);
    $('#arrangemana_link_id').on('click', { page: 'ArrangeManager.aspx' }, changePage);
    $('#kizai_link_id').on('click', { page: 'KizaiManager.aspx' }, changePage);
    $('#surgeryroommana_link_id').on('click', { page: 'SurgeryRoomMana.aspx' }, changePage);
    var input = document.querySelector('input[id="date"]');
    var picker = datepicker(input);
}
//
function changePage(param) {
    jscChangePage(param.data.page);
}
// ------------------------------------ EOF -----------------------------------------
