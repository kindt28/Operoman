<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanList.aspx.cs" Inherits="Operoman.page.PlanList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name='viewport' content='width=device-width, minimum-scale=1, maximum-scale=1, initial-scale=1, user-scalable=no' />
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/ttCookie_1.0.0.js"></script>
    <script src="../js/ttGuard_1.0.0.js"></script>
    <script src="../js/common.js"></script>
    
    <link href="../css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="../css/planlist.css" rel="stylesheet" />
    <title>手術室配置管理システム</title>
</head>
<body>
    <div id="content_site">
        <div class="wrap_site">
            <div class="form_page">
                <h1 class="title">手術スケジュール一覧管理</h1>
                <div class="on_form">
                    <div class="top_form">
                        <div class="item_topform item_topform1">
                            <span>【 開始日付 】</span>
                            <div class="value_item_topform1"><input id="date" type="date" value="" /></div>
                        </div>
                        <div class="item_topform item_topform2">
                            <span>【 診療科 】</span>
                            <div class="value_item_topform2">
                                <select class="select">
                                  <option value="1">日本</option>
                                  <option value="2">ベトナム</option>
                                  <option value="3">韓国</option>
                                  <option value="4">中国</option>
                                </select>
                            </div>
                        </div>
                        <div class="item_topform item_topform3">
                            <span>【 手術室 】</span>
                            <div class="value_item_topform3">
                                <select class="select">
                                  <option value="1">日本</option>
                                  <option value="2">ベトナム</option>
                                  <option value="3">韓国</option>
                                  <option value="4">中国</option>
                                </select>
                            </div>
                        </div>
                        <div class="item_topform item_topform4">
                            <span>【 術式 】</span>
                            <div class="value_item_topform4">
                                <select class="select">
                                  <option value="1">日本</option>
                                  <option value="2">ベトナム</option>
                                  <option value="3">韓国</option>
                                  <option value="4">中国</option>
                                </select>
                            </div>
                        </div>
                        <div class="item_topform item_topform5">
                            <span>【 執刀医 】</span>
                            <div class="value_item_topform5">
                                <select class="select">
                                  <option value="1">日本</option>
                                  <option value="2">ベトナム</option>
                                  <option value="3">韓国</option>
                                  <option value="4">中国</option>
                                </select>
                            </div>
                        </div>
                        <div class="item_topform item_topform6">
                            <button type="button" class="btn">更新</button>
                        </div>
                    </div>
                    <div class="main_form">
                    <div class="table-responsive">          
                      <table class="table">
                        <thead>
                          <tr>
                            <th>No</th>
                            <th>診療科</th>
                            <th>開始予定日時</th>
                            <th>終了予定日時</th>
                            <th>状況</th>
                            <th>手術室</th>
                            <th>術式</th>
                            <th>執刀医</th>
                            <th>担当看護師</th>
                          </tr>
                        </thead>
                        <tbody>
                          
                          <script>
                              for (var i = 1; i <= 20; i++) {
                                  document.write("<tr>");
                                  document.write("<td>" + i + "</td>");
                                  document.write("<td></td>");
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
                    <div class="bottom_form">
                        <button type="button" class="btn btn-left">戻る</button>
                        <button type="button" class="btn btn-right">配置詳細</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
