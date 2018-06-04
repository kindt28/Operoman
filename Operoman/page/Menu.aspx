<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Operoman.page.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="content_site">
                <div class="wrap_site">
                    <div class="home">
                        <h1>手術室配置管理システム</h1>
                        <div class="nav_menu">
                            <ul>
                                <li><a href="PlanList.aspx">手術スケジュール一覧管理</a><input id="date" type="date" value="" />
                                    <li><a href="#">配置マスタ管理</a></li>
                                    <li><a href="#">機器機材マスタ管理</a></li>
                                    <li><a href="#">手術室マスタ管理</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
