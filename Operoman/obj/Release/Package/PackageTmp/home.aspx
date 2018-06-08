<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Operoman.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name='viewport' content='width=device-width, minimum-scale=1, maximum-scale=1, initial-scale=1, user-scalable=no' />
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/ttCookie_1.0.0.js"></script>
    <script src="js/ttGuard_1.0.0.js"></script>
    <script src="js/common.js"></script>
    <script src="home.js"></script>
    <link href="css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="css/home.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
</head>
<body>
   <form id="form1" runat="server">
        <div id="pid_title" >&nbsp;</div>
        <div id="pid_body">
            <div id="pid_body_space" >&nbsp</div>
            <div id="pid_body_login_continer" >
                <div id="pid_login_title">ＩＤ／ＰＷを入力して下さい。</div>
                <br />
                <div id="pid_login_error" runat="server" >エラーですよ</div>
                <br />
                <div id="pid_login_uid_continer">
                    <label for="pid_txt_uid">ＩＤ</label><input id="pid_txt_uid" type="text" runat="server" autofocus="autofocus" />
                </div>
                <br />
                <div id="pid_login_pass_continer">
                    <label for="pid_txt_pass">ＰＷ</label><input id="pid_txt_pass" type="password" runat="server" />
                </div>
                <br />
                <div id="pid_login_button_continer">
                    <asp:Button runat="server" CssClass="btn_big_off" id="pid_login_button"  Text="ログイン" OnClick="pid_login_button_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
