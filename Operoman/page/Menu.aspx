<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Operoman.page.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name='viewport' content='width=device-width, minimum-scale=1, maximum-scale=1, initial-scale=1, user-scalable=no' />
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/ttCookie_1.0.0.js"></script>
    <script src="../js/ttGuard_1.0.0.js"></script>
    <script src="../js/common.js"></script>
    <script src="Menu.js"></script>
    <link href="../css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="../css/planlist.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
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
                                <li><a id="plan_link_id" href="#">手術スケジュール一覧管理</a><input id="date" type="date" value="" /></li>
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
