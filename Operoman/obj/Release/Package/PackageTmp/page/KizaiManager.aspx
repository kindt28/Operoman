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
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/kizaimanager.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
</head>
<body>
    <div id="content_site">
        <div class="wrap_site">
            <div class="device_page">
                <h1 class="title">機器機材マスタ管理画面案</h1>
                <div class="list_table">
                    <p>【機器機材マスタ一覧】</p>
                    <div>
                        <table id="id_table_head" class="table table_head">
                            <thead>
                                <tr>
                                    <th>機器コード</th>
                                    <th>機器名称</th>
                                    <th>形</th>
                                    <th>色</th>
                                    <th>テキスト</th>
                                    <th>有効開始日</th>
                                    <th>有効終了日</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                    <div id="id_div_table_detail" class="div_table_detail">
                        <table id="id_table_body" class="table table_body">
                            <tbody>
                                <script>
                                    for (var i = 1; i <= 20; i++) {
                                        document.write("<tr>");
                                        document.write("<td></td>");
                                        document.write("<td></td>");
                                        document.write("<td></td>");
                                        document.write("<td></td>");
                                        document.write("<td></td>");
                                        document.write("<td></td>");
                                        document.write("<td></td>");
                                        document.write("</tr>");
                                    }
                                </script>
                            </tbody>
                        </table>
                    </div>
                </div>
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
                                <div class="dev2_item_left">
                                    <p>【形】</p>
                                    <select class="select">
                                        <option value="1">日本</option>
                                        <option value="2">ベトナム</option>
                                        <option value="3">韓国</option>
                                        <option value="4">中国</option>
                                    </select>
                                </div>
                                <div class="dev2_item_right">
                                    <div class="dev2_item_right1">
                                        <p>【開始日】</p>
                                        <input type="text" value="" />
                                    </div>
                                    <div class="dev2_item_right2">
                                        <p>【終了日】</p>
                                        <input type="text" value="" />
                                    </div>
                                </div>
                            </div>
                            <div class="dev2_item">
                                <p>【色】</p>
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
                                モニターエリート
                            </div>
                        </div>
                    </div>

                </div>
                <div class="button_device">
                    <div class="button-list-left">
                        <button type="button" class="btn btn-left1">戻る</button>
                        <%--<button type="button" class="btn btn-right">削除</button>--%>
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
