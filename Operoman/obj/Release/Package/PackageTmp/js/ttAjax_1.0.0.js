// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' ｽﾃｰﾀｽ
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
var	TT_AJAX_STS_NORMAL		= 'NORMAL';					// ｽﾃｰﾀｽ	- 正常
var TT_AJAX_STS_ERROR		= 'ERROR';					//			- ﾀｲﾑｱｳﾄ
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' ﾌｧｲﾙ名	: TtAjax_1.0.0.js
// ' 概　要	: Ajax処理を行う。
// ' 備　考	: ttAjaxがｲﾝｽﾀﾝｽ変数
// ' 作成日	: 2014/03/30 ... T.Takamura
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
function TtAjax()
{
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' 定数
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' 変数
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	var m_fResponse	= null;									// ﾚｽﾎﾟﾝｽ時ｺｰﾙ関数
	var m_iTimeout = 1000 * 60 * 60;						// ﾀｲﾑｱｳﾄ値 (ms)
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' ｺﾝｽﾄﾗｸﾀ
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' ﾒｿｯﾄﾞ
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	// ' ﾒｿｯﾄﾞ	: ｵﾌﾞｼﾞｪｸﾄ要求関数
	// ' 引　数	: sUrl			...	要求先URL
	// '		: objREQ		... 要求先送信ｵﾌﾞｼﾞｪｸﾄ
	// '		: fResponse		... ﾚｽﾎﾟﾝｽ時ｺｰﾙ関数
	// ' 備　考	: 要求先送信ｵﾌﾞｼﾞｪｸﾄをJSONに変換し、要求先URLへ送信
	// ' 戻り値	: なし
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	this.requestObject = function( sUrl, objREQ, fResponse )
	{
		var sJson		= "";
		//
		m_fResponse = fResponse;
		//
		if( objREQ != null )
		{
			sJson = convertJSON( objREQ );
		}
		// 
		$.ajax(
					{
					    async       : true,
					    cache       : false,
						type        : 'POST',
						dataType    : "json",
						url         : sUrl,
						timeout     : m_iTimeout,
						contentType : 'application/json;',
						data        : sJson,
						complete    : completeRequestObject,
						error       : completeRequestObject
					}
				);

	}
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	// ' ﾒｿｯﾄﾞ	: ｵﾌﾞｼﾞｪｸﾄ要求関数
	// ' 引　数	: sUrl			...	要求先URL
	// '		: fResponse		... ﾚｽﾎﾟﾝｽ時ｺｰﾙ関数
	// ' 備　考	: 要求先送信ｵﾌﾞｼﾞｪｸﾄをJSONに変換し、要求先URLへ送信
	// ' 戻り値	: なし
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	this.request = function( sUrl, fResponse )
	{
		var sJson		= "";
		//
		m_fResponse = fResponse;
		// 
		$.ajax(
					{
						type: 'POST',
						dataType: "json",
						url: sUrl,
						timeout : m_iTimeout,
						contentType: 'application/json;',
						complete: completeRequestObject,
						error: completeRequestObject
					}
				);

	}
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
// ' 関数
// ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	// ' 関数名	:	ｵﾌﾞｼﾞｪｸﾄ通信完了	
	// ' 引　数	:		Response	... HTTPﾚｽﾎﾟﾝｽ
	// '				status		...	ｽﾃｰﾀｽ
	// ' 戻り値	:	なし
	// ' 備　考	:	なし
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	function completeRequestObject( Response, status )
	{
		var objResponse;
		//
		if( m_fResponse != null )
		{
			status = status.toUpperCase();
			//
			if (status == 'TIMEOUT' || Response.readyState == 4) 
			{
				if (status != 'TIMEOUT' && Response.status == 200) 
				{
					eval("objResponse = " + Response.responseText + ";");
					objResponse.ajaxSTS = TT_AJAX_STS_NORMAL;
					objResponse.ajaxSTSMessage = "";
				}else{
					objResponse = new Object();
					objResponse.ajaxSTS = TT_AJAX_STS_ERROR;
					objResponse.ajaxSTSMessage = "HTTPステータス : " + Response.status;
					//
					if( status == 'TIMEOUT' )
					{
						Response.abort();	
					}
				}
				//
				m_fResponse( objResponse );
				//
				m_fResponse = null;
			}
		}
	}
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	// ' 関数名	:	JSON変換
	// ' 引　数	:		obj		... 変換ｵﾌﾞｼﾞｪｸﾄ
	// ' 戻り値	:	JSON文字列
	// ' 備　考	:	変換ｵﾌﾞｼﾞｪｸﾄからJSON文字列へ変換
	// '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	function convertJSON( obj )
	{
    	var ret = '';

		// ﾌﾟﾗｸﾞｲﾝ存在ﾁｪｯｸ
		if ($.stringify === undefined) 
		{
			// 変換関数のﾌﾟﾗｸﾞｲﾝ
			jQuery.extend(
			{
				stringify: function stringify(obj) {
					var t = typeof (obj);
					if (t != "object" || obj === null) 
					{
						if (t == "string") 
						{
							obj = obj.split('\\').join('\\\\');
							obj = obj.split('"').join('\\"');
							obj = '"' + obj + '"';
						}
						return String(obj);
					} else {
						var n, v, json = [], arr = (obj && obj.constructor == Array);

						for (n in obj) {
							v = obj[n];
							t = typeof (v);
							if (obj.hasOwnProperty(n)) 
							{

								if (t == "string") 
								{

									v = v.split('\\').join('\\\\');
									v = v.split('"').join('\\"');
									v = '"' + v + '"';
								} else {

									if (t == "object" && v !== null) 
									{
										v = jQuery.stringify(v);
									}
								}
								json.push((arr ? "" : '"' + n + '":') + String(v));
							}
						}
						return (arr ? "[" : "{") + String(json) + (arr ? "]" : "}");
					}
				}
			});
    	}
		//
    	// ﾌﾟﾗｸﾞｲﾝによる変換
    	ret = $.stringify(obj);
		//
    	// Exit
    	return ret;
	}
}
// ----------------------------------------------------------------------------------
var ttAjax = new TtAjax();
// ----------------------------------------------------------------------------------

									