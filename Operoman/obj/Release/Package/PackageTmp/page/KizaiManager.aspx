<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KizaiManager.aspx.cs" Inherits="Operoman.page.KizaiManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name='viewport' content='width=device-width, minimum-scale=1, maximum-scale=1, initial-scale=1, user-scalable=no' />
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="../js/tableSort.js"></script>
    <script src="../js/ttCookie_1.0.0.js"></script>
    <script src="../js/ttGuard_1.0.0.js"></script>
    <script src="../js/ttMessage_1.0.0.js"></script>
    <script src="../js/ttDate_1.0.0.js"></script>
    <script src="../js/ttDlgContiner_1.0.0.js"></script>
    <script src="../js/ttTimeStamp_1.0.0.js"></script>
    <script src="../js/common.js"></script>
    <script src="KizaiManager.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttMessage_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttTimeStamp_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttFilter_1.0.0.css" rel="stylesheet" />
    <link href="../css/kizaimanager.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
</head>
<body>
    <div id="content_site">
        <div class="wrap_site">
            <div class="device_page">
                <h1 class="title">配置マスタ管理画面案</h1>
                <div id="device2" class="main_device">
                    <div id="device2_current" class="device_current">
                        <div class="dev2_list">
                            <div class="dev2_item">
                                <p>【機器コード】	</p>
                                <input type="text" value="" />
                            </div>
                            <div class="dev2_item">
                                <p>【機器名称】</p>
                                <input type="text" value="" />
                            </div>
                            <div class="dev2_item">
                                <p>	【形】</p>
                                <select class="select">
                                  <option value="1">日本</option>
                                  <option value="2">ベトナム</option>
                                  <option value="3">韓国</option>
                                  <option value="4">中国</option>
                                </select>
                            </div>
                            <div class="dev2_item">
                                <p>	【色】</p>
                                <select class="select">
                                  <option value="1">日本</option>
                                  <option value="2">ベトナム</option>
                                  <option value="3">韓国</option>
                                  <option value="4">中国</option>
                                </select>
                            </div>
                            <div class="dev2_item">
                                <p>【テキスト入力】</p>
                                <textarea></textarea>
                            </div>
                        </div>
                    </div>
                    <div class="device_content">

                        <div id="screen" class="device_content_main">
                            <div class="room_device">
                                <div class="on_device">
                                    <div id="container" class="wrap_device">
                                        <ul id="all_device"></ul>
                                    </div>
                                    <div class="ckeck_in"><span>ドア</span></div>
                                </div>
                                <div class="table_device">
                                   <ul>
                                        <li id="de_1_1" class="de_1 dev"><span>バ</span></li>
                                        <li id="de_1_2" class="de_1 dev"><span>バ</span></li>
                                        <li id="de_1_3" class="de_1 dev"><span>バ</span></li>
                                        <li id="de_2_1" class="de_2 dev"><span>吸</span></li>
                                        <li id="de_2_2" class="de_2 dev"><span>吸</span></li>
                                        <li id="de_3_1" class="de_3 dev"><span>ベ</span></li>
                                        <li id="de_4_1" class="de_4 dev"><span>ケ</span></li>
                                        <li id="de_5_1" class="de_5 dev"><span>VIO</span></li>
                                        <li id="de_6_1" class="de_6 dev"><span>フォーストライアド</span></li>
                                        <li id="de_7_1" class="de_7 dev"><span>大台</span></li>
                                        <li id="de_8_1" class="de_8 dev"><span>メーヨー台</span></li>
                                        <li id="de_9_1" class="de_9 dev"><span>プレキシパル</span></li>
                                        <li id="de_10_1" class="de_10 dev"><span>ウォームタッチ</span></li>
                                        <li id="de_11_1" class="de_11 dev"><span>個人カート</span></li>
                                        <li id="de_12_1" class="de_12 dev"><span>外科カート</span></li>
                                        <li id="de_13_1" class="de_13 dev"><span>VIOは必要時</span></li>
                                        <li id="de_14_1" class="de_14 dev"><span>ベッド（砕石位が可能なベッド</span></li>
                                        <li id="de_15_1" class="de_15 dev"><span>ルンバール台</span></li>
                                        <li id="de_15_2" class="de_15 dev"><span>ルンバール台</span></li>
                                        <li id="de_16_1" class="de_16 dev"><span>麻酔台</span></li>
                                        <li id="de_17_1" class="de_17 dev"><span>麻酔器</span></li>
                                        <li id="de_18_1" class="de_18 dev"><span>HOTライ</span></li>
                                        <li id="de_19_1" class="de_19 dev"><span>全モ二カート</span></li>
                                        <li id="de_20_1" class="de_20 dev"><span>ガーゼ</span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="button_device">
                    <div class="button-list-left">
                        <button type="button" class="btn btn-left1">戻る</button>
                        <button type="button" class="btn btn-right">削除</button>
                    </div>
                    <div class="button-list-right">
                        <button type="button" class="btn btn-left2 ">修正</button>
                        <button type="button" class="btn btn-right">新規</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
