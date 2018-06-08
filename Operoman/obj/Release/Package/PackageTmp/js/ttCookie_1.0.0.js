// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' ﾌｧｲﾙ名：ttCookie_1.0.0.js
// ' 備　考：ｸｯｷｰ処理
// ' 作成日：2012/09/12 ... T.Takamura
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
////////////////////////////////////////////////////////////////////////////
// ｸｯｷｰへ保存
//      argment     ... key		[ 保存ｷｰ		]
//					... val		[ 値 ]
var JSC_APP_NAME = 'OPEROMAN';
function setCookie(key, val) {
    key = JSC_APP_NAME + "_" + key;
    var cokies = null;
    var cokie = "";
    var cokiesep = "";
    var itemsep = "";
    var posi = 0;
    var encodeValue = encodeURI(val);

    // ｸｯｷｰを取得
    cokies = expCookie();

    // ｸｯｷｰ位置の取得
    if ((posi = getCookiePosi(key, cokies)) > -1) {
        // 設定
        cokies[posi].VAL = encodeValue;
    } else {
        // 作成
        posi = cokies.length;
        //
        cokies[posi] = new Object();
        cokies[posi].KEY = key;
        cokies[posi].VAL = encodeValue;
    }

    // 保存
    for (posi = -1; ++posi < cokies.length;) {
        document.cookie = cokies[posi].KEY + "=" + cokies[posi].VAL + ";expires=" + new Date("2999/12/31").toGMTString() + ";path=/"
        //
        cokiesep = ";";
        itemsep = " ";
    }
}
////////////////////////////////////////////////////////////////////////////
// ｸｯｷｰの取得
//      argment     ... key		[ ｷｰ		]
function getCookie(key) {
    key = JSC_APP_NAME + "_" + key;
    var cokies = null;
    var posi = 0;

    // ｸｯｷｰを取得
    cokies = expCookie();

    // ｸｯｷｰ位置の取得
    if ((posi = getCookiePosi(key, cokies)) > -1) {
        // 設定
        return decodeURI(cokies[posi].VAL);
    } else {
        return ""
    }
}
////////////////////////////////////////////////////////////////////////////
// ｸｯｷｰ展開
//      argment     ... none
//		returns		... ｸｯｷｰ情報配列
//							.KEY
//							.VAL
function expCookie() {
    var cokie = document.cookie.split("; ");
    var cokies = new Array();
    var cokiei = null;
    var item = null;
    var ix = 0;

    // ｸｯｷｰ情報を全て展開
    for (ix = -1; ++ix < cokie.length;) {
        // ｱｲﾃﾑに展開
        item = cokie[ix].split("=");
        if (item.length >= 2) {
            // ｱｲﾃﾑｵﾌﾞｼﾞｪｸﾄ
            cokiei = new Object();
            cokiei.KEY = item[0];
            cokiei.VAL = item[1];
            cokies[cokies.length] = cokiei;
        }
    }

    // Exit 
    return cokies;
}
////////////////////////////////////////////////////////////////////////////
// ｸｯｷｰ位置の取得
//      argment     ... key				[ 検索ｷｰ			]
//						cokies			[ 検索ﾘｽﾄ		]
//		returns		... -1	: なし
//						以外	: 検索ﾘｽﾄ位置
function getCookiePosi(key, cokies) {
    var ix = -1;

    for (; ++ix < cokies.length;) {
        if (cokies[ix].KEY == key) {
            return ix;
        }
    }

    return -1;
}