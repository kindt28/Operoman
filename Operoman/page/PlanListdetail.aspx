<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanListdetail.aspx.cs" Inherits="Operoman.page.PlanListdetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name='viewport' content='widtd=device-widtd, minimum-scale=1, maximum-scale=1, initial-scale=1, user-scalable=no' />
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/ttCookie_1.0.0.js"></script>
    <script src="../js/ttGuard_1.0.0.js"></script>
    <script src="../js/common.js"></script>

    <link href="../css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="../css/planlist.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
</head>
<body>
    <form id="form1" runat="server" style="height: 100%;">
        <div id="divDetailContiner" runat="server" >
            <table id="table_detail_id" class="table">
                <script>
                    for (var i = 1; i <= 20; i++) {
                        document.write("<tr>");
                        document.write("<td>" + i + "</td>");
                        document.write("<td>診療科"+i+"</td>");
                        document.write("<td>開始予定日時" + i + "</td>");
                        document.write("<td>終了予定日時" + i + "</td>");
                        document.write("<td>状況" + i + "</td>");
                        document.write("<td>手術室" + i + "</td>");
                        document.write("<td>術式" + i + "</td>");
                        document.write("<td>執刀医" + i + "</td>");
                        document.write("<td>担当看護師" + i + "</td>");
                        document.write("</tr>");
                    }
                          </script>

               <%-- <tr>
                    <td>No</td>
                    <td>診療科</td>
                    <td>開始予定日時</td>
                    <td>終了予定日時</td>
                    <td>状況</td>
                    <td>手術室</td>
                    <td>術式</td>
                    <td>執刀医</td>
                    <td>担当看護師</td>
                </tr>--%>
            </table>
        </div>
    </form>
</body>
</html>
