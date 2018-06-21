<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurgeryRoomMana.aspx.cs" Inherits="Operoman.page.SurgeryRoomMana" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    <script src="SurgeryRoomMana.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttMessage_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttTimeStamp_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttFilter_1.0.0.css" rel="stylesheet" />
    <link href="../css/common.css" rel="stylesheet" />
    <link href="../css/SurgeryRoomMana.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
</head>
<body>
    <div id="content_site">
        <div class="wrap_site">
            <div class="device_page">
                <h1 class="title">手術室マスタ管理画面案</h1>
                <div class="list_table">
                    <p>【機器機材マスタ一覧】</p>
                    <div>
                        <table id="id_table_head" class="table table_head">
                            <thead>
                                <tr>
                                    <th>手術室コード</th>
                                    <th>手術室名称</th>
                                    <th>オーダ手術室コード	</th>
                                    <th>オーダ手術室名称</th>
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
                                    for (var i = 1; i <= 21; i++) {
                                        document.write("<tr>");
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
                <div class="form_area">
                    <div class="item_form item_form1">
                        <p>【手術室コード】</p>
                        <div >
                            <input id="" type="text" value="" /></div>
                    </div>
                    <div class="item_form item_form2">
                        <p>【手術室名称】</p>
                        <div >
                            <input id="" type="text" value="" /></div>
                    </div>
                    <div class="item_form item_form3">
                        <p>【オーダ手術室コード】</p>
                        <div >
                            <input id="" type="text" value="" /></div>
                    </div>
                    <div class="item_form item_form4">
                        <p>【オーダ手術室名称】</p>
                        <div >
                            <input id="" type="text" value="" /></div>
                    </div>
                    <div class="item_form item_form5">
                        <p>【開始日】</p>
                        <div >
                            <input id="" type="date" value="2018-05-28" /></div>
                    </div>
                    <div class="item_form item_form6">
                        <p>【終了日】</p>
                        <div >
                            <input id="" type="date" value="" /></div>
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
