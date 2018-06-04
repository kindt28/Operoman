/// <reference path="jquery-3.1.1.min.js" />
/// <reference path="ttGuard_1.0.0.js" />
/// <reference path="ttCookie_1.0.0.js" />
//
// --------------------------------------------------------------------------------
// - ﾌｧｲﾙ名    ： 共通処理
// - 備　考    ： ﾍﾟｰｼﾞの共通処理を提供する。
// -           
// -             [ 命名規則 ]
// -                jsc_xxxxx               ... 変数
// -                JSC_XXXXX               ... 定数
// -                jscXXXXXX               ... 関数
// -                OnJscXXXX               ... ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
// -                         新規作成
// - [ 更新履歴 ] 
// -     Ver 1.0.0       ... 2015.05.27      ... 高村　勉
// -                         新規作成
// ----------------------------------------------------------------------------------
// -----------------------------------------------------------------
// - 定数
// -----------------------------------------------------------------
var JSC_DEBUG_ON    = true;
var JSC_DEBUG_OFF   = false;
var JSC_DEBUG_SW    = JSC_DEBUG_OFF;
//
var SCROLL_BAR_WIDTH            = "17px";
//

// -----------------------------------------------------------------
// - 変数
// -----------------------------------------------------------------
// -----------------------------------------------------------------
// - ｲﾍﾞﾝﾄ
// -----------------------------------------------------------------
$(document).ready(OnJscStartUp);                            // ｽﾀｰﾄｱｯﾌﾟ
// -----------------------------------------------------------------
// - 関数名：ｽﾀｰﾄｱｯﾌﾟ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function OnJscStartUp()
{
    var bWaitDestory = true;
    try
    {
        // ｶﾞｰﾄﾞの表示
        ttGuard.showWait();
        //
        // ｲﾍﾞﾝﾄ登録
        bWaitDestory = jspAddEvent();
    }
    catch (ex)
    {
        jscDEBUGExceptionAlert(ex);
    }
    finally
    {
        if (bWaitDestory == true || bWaitDestory == undefined) ttGuard.destory();
    }
}
// -----------------------------------------------------------------
// - 関数名：ｳｪｲﾄの表示
// - 引　数：fncClose   ... ｳｪｲﾄがｸﾘｯｸされた場合にｺｰﾙされるﾌｧﾝｸｼｮﾝ
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscGuardShow( fncClose )
{
    ttGuard.show(false, fncClose);
}
// -----------------------------------------------------------------
// - 関数名：ｳｪｲﾄの消去
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscGuardDestory()
{
    ttGuard.destory();
}
// -----------------------------------------------------------------
// - 関数名：ﾊﾟﾗﾒｰﾀｸﾘｱｰ (機器管理ｺｰﾄﾞ以外)
// - 引　数：なし
// - 戻り値：なし
// -----------------------------------------------------------------
function jscParamClear()
{
    //setCookie(JSC_COOKIE_CATNO, "");
    //setCookie(JSC_COOKIE_MODNO, "");
    //setCookie(JSC_COOKIE_ARRAY_PARAM_LV1, "");
    //setCookie(JSC_COOKIE_PARAM_LV1_ID, "");
    //setCookie(JSC_COOKIE_PARAM_TK_EXE_ID, "");
}
// -----------------------------------------------------------------
// - 関数名：ﾍﾟｰｼﾞ変更
// - 引　数：sURL           ... 変更するﾍﾟｰｼﾞURL
// -       :bClrParam      ... ﾊﾟﾗﾒｰﾀｸﾘｱｰ (機器管理ｺｰﾄﾞ以外)
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscChangePage( sURL, bClrParam )
{
    ttGuard.showWait();
    //
    // 第一画面ｸｯｷｰをｸﾘｱｰ
    if (bClrParam)
    {
        jscParamClear();
    }
    //
    // ﾍﾟｰｼﾞ遷移
    location.href = sURL;
}

// - 関数名：ﾛｸﾞｱｳﾄ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscLogout()
{
    ttGuard.showWait();
    //
    jscParamClear();
    //
    location.href = "../home.aspx";
}
// -----------------------------------------------------------------
// - 関数名：ﾘﾛｰﾄﾞ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：ﾘﾛｰﾄﾞ
// -----------------------------------------------------------------
function jscFrameReload()
{
    location.reload();
}
// -----------------------------------------------------------------
// - 関数名：ﾃﾞﾊﾞｯｸﾞﾒｯｾｰｼﾞ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscDEBUGMessageAlert(msg) {
    var sMsg = "[Debugメッセージ]" + "\n"
              + "[MSG]" + "\n";
    //
    if (JSC_DEBUG_SW === JSC_DEBUG_ON) {
        alert(sMsg.replace("[MSG]", msg));
    }
}
// -----------------------------------------------------------------
// - 関数名：ﾃﾞﾊﾞｯｸﾞｱﾗｰﾄ
// - 引　数：なし
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscDEBUGExceptionAlert(ex) {
    var sMsg = "[例外通知]" + "\n"
             + "[MSG]" + "\n"
             + "[スタック]" + "\n"
             + "[STACK]";
    //
    if (JSC_DEBUG_SW === JSC_DEBUG_ON) {
        alert(
                sMsg.replace("[MSG]", ex.message)
                    .replace("[STACK]", ex.stack)
                );
    }
}
// -----------------------------------------------------------------
// - 関数名：配列ﾊﾟﾗﾒｰﾀの取得
// - 引　数：sCookieID      ... ｸｯｷｰID
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscGetArrayParam( sCookieID )
{
    if ((sParam = getCookie(sCookieID)) != "")
    {
        return sParam.split(JSC_COOKIE_ARRAY_PARAM_SEP);
    }else{
        return new Array();
    }
}
// -----------------------------------------------------------------
// - 関数名：配列ﾊﾟﾗﾒｰﾀの取得
// - 引　数：sCookieID      ... ｸｯｷｰID
// -         iNo            ... ﾌｨｰﾙﾄﾞ番号
// - 戻り値：ﾌｨｰﾙﾄﾞ番号に該当するﾊﾟﾗﾒｰﾀ
// - 備　考：なし
// -----------------------------------------------------------------
function jscGetArrayParamIX(sCookieID, iNo)
{
    var sParam = jscGetArrayParam(sCookieID);
    //
    return (sParam.length >= iNo ? sParam[iNo] : "" );
}
// -----------------------------------------------------------------
// - 関数名：配列ﾊﾟﾗﾒｰﾀの設定
// - 引　数：sCookieID      ... ｸｯｷｰID
// -       ：sParam         ... 保存するﾊﾟﾗﾒｰﾀ
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscSetArrayParam( sCookieID, sParam )
{
    var sStrParam = "";
    //
    sStrParam = sParam.join(JSC_COOKIE_ARRAY_PARAM_SEP);
    //
    setCookie(sCookieID, sStrParam);
}
// -----------------------------------------------------------------
// - 関数名：配列ﾊﾟﾗﾒｰﾀの設定
// - 引　数：sCookieID      ... ｸｯｷｰID
// -       ：sParam         ... ﾌｨｰﾙﾄﾞ番号
// -       : sVal           ... 値
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscSetArrayParamIX( sCookieID, iNo, sVal )
{
    var sParam = jscGetArrayParam(sCookieID);
    //
    if( sParam.length <= iNo )
    {
        sParam = jscResizeArray(sParam, iNo + 1);
    }
    //
    sParam[iNo] = sVal;
    //
    jscSetArrayParam(sCookieID, sParam);
}
// -----------------------------------------------------------------
// - 関数名：配列の拡張
// - 引　数：sArray         ... 拡張する配列
// -       ：iCount         ... 配列数
// - 戻り値：なし
// - 備　考：なし
// -----------------------------------------------------------------
function jscResizeArray(sArray, iCount)
{
    var sResult = new Array();
    //
    for (var ix = 0; ix < iCount; ix++ )
    {
        if( ix < sArray.length )
        {
            sResult[ix] = sArray[ix];
        }else{
            sResult[ix] = "";
        }
    }
    //
    return sResult;
}
