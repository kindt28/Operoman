/// <reference path="jquery-3.1.1.min.js" />
/// <reference path="ttGuard_1.0.0.js" />
// -------------------------------------------------------
// - ﾌｧｲﾙ名：ttDlgContiner_1.0.0.js
// -
// - 備　考：ﾀﾞｲｱﾛｸﾞｺﾝﾃﾅ
// -            ttGuard_x.x.xが必要
// -
// - 作成日：2016.11.16 ... T.Takamura
// -------------------------------------------------------
function TtDlgContiner()
{
    // ------------------------------------------------------------
    // - ﾒﾝﾊﾞｰ
    // ------------------------------------------------------------
    var m_sButtonID           = new Array();
    var m_fncButtonFunc      = new Array();
    var m_bOutSideCall       = new Array();
    var m_sID                 = "";
    // ------------------------------------------------------------
    // - ﾒｿｯﾄﾞ
    // ------------------------------------------------------------
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：ｺﾝﾃﾅの作成
    // - 引　数：sID		    ... ｺﾝﾃﾅID
    // -         sClass      ... ｸﾗｽ名
    // - 戻り値：なし
    // -------------------------------------------------------
    this.Create = function (sID, sClass)
    {
        m_sID = sID;
        //
        $('body').append("<div id='" + sID + "' class='" + sClass + "' style='display:none;' ></div>");
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：ｸﾛｰｽﾞﾎﾞﾀﾝの作成
    // - 引　数：sID		    ... ｺﾝﾃﾅID
    // -         sCaption   ... ｷｬﾌﾟｼｮﾝ
    // -         sClass      ... ｸﾗｽ名
    // -         bOutsize    ... 欄外ｸﾘｯｸ時ｺｰﾙﾌﾗｸﾞ
    // -         fncClick    ... ｸﾘｯｸ処理
    // -         objData     ... ﾃﾞｰﾀ
    // - 戻り値：なし
    // -------------------------------------------------------
    this.CreateClose = function (sID, sCaption, sClass, bOutsize,fncClick, objData)
    {
        $('#' + m_sID).append("<div id='" + sID + "' class='" + sClass + "'>" + sCaption + "</div>");
        //
        $('#' + sID).on('click', objData, fncClick );
        //
        SaveClickEvent(sID, bOutsize, fncClick);
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：表示
    // - 引　数：sBaseID		... 配置のﾍﾞｰｽとする要素ID
    // -         bTop		    ... true : 上に配置	flase:下に配置
    // -         bLeft		... true : 左揃え	flase:右揃え
    // -         nTopAdd     ... 上位置補正 (ずらす値)
    // -         nLeft     ... 右位置補正 (ずらす値)
    // -         bOpacity   ... true : 透明	false:不透明 (省略可)
    // - 戻り値：なし
    // -------------------------------------------------------
    this.Show = function (sBaseID, bTop, bLeft, nTop, nLeft, bOpacity)
    {
        ttGuard.show(bOpacity, OnOutsideClick);
        //
        ttGuard.setLocation(m_sID, bTop, bLeft, nTop, nLeft, sBaseID);
        //
        $('#' + m_sID).css( 'display', '');
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：表示
    // - 引　数：bOpacity   ... true : 透明	false:不透明 (省略可)
    // - 戻り値：なし
    // -------------------------------------------------------
    this.ShowCenter = function (bOpacity)
    {
        ttGuard.show(bOpacity, OnOutsideClick);
        //
        ttGuard.setCenter(m_sID);
        //
        $('#' + m_sID).css('display', '');
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：表示
    // - 概　要: 表示ﾊﾟﾗﾒｰﾀを使用して表示
    // - 引　数：oParam
    // '            ... FrameID     ( BaseIDがﾌﾚｰﾑ内の要素の場合      )
    // '            ... BaseID      ( 表示位置ﾍﾞｰｽ位置                )
    // '            ... ID          ( 位置を設定する要素ID             )
    // '            ... Top         ( true : 上に配置	flase:下に配置   )
    // '            ... TopMove     ( 表示位置から上にずらす値(px)     )
    // '            ... Left        ( true : 左揃え	    flase:右揃え )
    // '            ... LeftMove    ( 表示位置から右にずらす値(px)     )
    // -            ... Opacity     ( true : 透明	false:不透明 (省略可))
    // - 戻り値：なし
    // -------------------------------------------------------
    this.ShowForParam = function (oParam)
    {
        ttGuard.show(oParam.Opacity, OnOutsideClick);
        //
        if (oParam.FrameID == "")
        {
            ttGuard.setLocation(
                                    oParam.ID,
                                    oParam.Top,
                                    oParam.Left,
                                    oParam.TopMove,
                                    oParam.LeftMove,
                                    oParam.BaseID
                                  );
        } else {
           ttGuard.setLocationForFrame(oParam);
        }
        //
        $('#' + m_sID).css('display', '');
    }
    // -------------------------------------------------------
    // - ﾒｿｯﾄﾞ ：ｸﾛｰｽﾞ
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    this.Close = function ()
    {
        // // 解放処理 要素を削除するとｴﾍﾞﾝﾄは解除される
        // OffEvent();
        //
        // 削除
        $('#' + m_sID).remove();
        //
        // ｶﾞｰﾄﾞの消去
        ttGuard.destory();
    }
    // ------------------------------------------------------------
    // - 内部関数
    // ------------------------------------------------------------
    // -------------------------------------------------------
    // - 関数  ：ｲﾍﾞﾝﾄ保存
    // - 引　数：sID		    ... ｺﾝﾃﾅID
    // -         bOutsize    ... 欄外ｸﾘｯｸ時ｺｰﾙﾌﾗｸﾞ
    // -         fncClick    ... ｸﾘｯｸ処理
    // - 戻り値：なし
    // -------------------------------------------------------
    function SaveClickEvent(sID, bOutsize, fncClick)
    {
        m_sButtonID.push(sID);
        m_fncButtonFunc.push(fncClick);
        m_bOutSideCall.push(bOutsize);
    }
    // -------------------------------------------------------
    // - 関数  ：ｲﾍﾞﾝﾄOFF処理
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function OffEvent()
    {
        while (m_sButtonID.length > 0)
        {
            $('#' + m_sButtonID[0]).off('click', m_fncButtonFunc[0]);
            //
            m_sButtonID.shift();
            m_fncButtonFunc.shift();
            m_bOutSideCall.shift();
        }
    }
    // -------------------------------------------------------
    // - 関数  ：ｺﾝﾃﾅ外ｸﾘｯｸ
    // - 引　数：なし
    // - 戻り値：なし
    // -------------------------------------------------------
    function OnOutsideClick()
    {
        for( var ix = 0; ix < m_bOutSideCall.length; ix++ )
        {
            if( m_bOutSideCall[ix] )
            {
                $('#' + m_sButtonID[ix]).trigger('click');
                //
                break;
            }
        }
        //C008 ADD START 20180129
        $('#tsCmdCan').click();
        //C008 ADD END   20180129
    }
}
var ttDlgContiner = new TtDlgContiner();