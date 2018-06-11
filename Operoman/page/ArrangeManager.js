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
    $('.dev').clone().appendTo('#all_device');
    $('#all_device .dev').addClass('device');
    ///
    $(".device").draggable({
        'containment': 'parent',
        'cursor': 'move',
        'snap': '#container'
    });
    //
    loadDevicesPosition();
    //    
    $('#btnUpdate').on('click', saveDevicesPosition);
}
//
function getRoomInfo() {
    var room = { width: $('.on_device').width(), height: $('.on_device').height(), offsetLeft: 10, offsetTop: 10 };
    console.log('Room -------------------------------------------');
    console.log(room);
    //
    return room;
}
//
function saveDevicesPosition() {
    var room = getRoomInfo();
    //
    var devices = new Array();
    var device = new Object();
    var sizeOfDevice = new Object();
    var positionOfDevice = new Object();
    //
    $('.device').each(function (index) {
        sizeOfDevice = { width: $(this).width(), height: $(this).height() };
        positionOfDevice = $(this).position();
        //
        device.left = positionOfDevice.left - room.offsetLeft + sizeOfDevice.width / 2;
        device.left = device.left / room.width * 100;
        //
        device.top = positionOfDevice.top - room.offsetTop + sizeOfDevice.height / 2;
        device.top = device.top / room.height * 100;
        //
        devices.push(JSON.stringify(device));
    });
    //
    localStorage.setItem('DEVICE', devices.join(';'));
    //
    console.log('List of Devices ------------------------------------');
    console.log(devices);
}
//
function loadDevicesPosition() {
    var storageData = localStorage.getItem('DEVICE');
    console.log(storageData);
    if (storageData != null) {
        var devices = storageData.split(';');
        console.log('Devices ------------------------------------');
        console.log(devices);
        //
        var device = new Object();
        var sizeOfDevice = new Object();
        //
        var room = getRoomInfo();
        //
        $('.device').each(function (index) {
            sizeOfDevice = { width: $(this).width(), height: $(this).height() };
            //
            device = JSON.parse(devices[index]);
            device.left = device.left * room.width / 100;
            device.left = device.left + room.offsetLeft - sizeOfDevice.width / 2;
            device.top = device.top * room.height / 100;
            device.top = device.top + room.offsetTop - sizeOfDevice.height / 2;
            //
            $(this).css({ left: device.left, top: device.top });
            console.log('Device ' + index + ' ------------------------------------');
            console.log(device);
        });
    }
}
// ------------------------------------ EOF -----------------------------------------
