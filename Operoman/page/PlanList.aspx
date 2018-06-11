﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlanList.aspx.cs" Inherits="Operoman.page.PlanList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name='viewport' content='width=device-width, minimum-scale=1, maximum-scale=1, initial-scale=1, user-scalable=no' />
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/tableSort.js"></script>
    <script src="../js/ttCookie_1.0.0.js"></script>
    <script src="../js/ttGuard_1.0.0.js"></script>
    <script src="../js/ttMessage_1.0.0.js"></script>
    <script src="../js/ttDate_1.0.0.js"></script>
    <script src="../js/ttDlgContiner_1.0.0.js"></script>
    <script src="../js/ttTimeStamp_1.0.0.js"></script>
    <script src="../js/common.js"></script>
    <script src="PlanList.js"></script>
    <link href="../css/ttGuard_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttMessage_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttTimeStamp_1.0.0.css" rel="stylesheet" />
    <link href="../css/ttFilter_1.0.0.css" rel="stylesheet" />
    <link href="../css/common.css" rel="stylesheet" />
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
                            <div class="value_item_topform1">
                                <table id="tblYearMonth" class="table_cal">
                                    <tr>
                                        <td id='trFltYearMonth' class="">
                                            <div id="divExeStampFram" class="cal_fram" runat="server">
                                                <div id="divExeStamp" class="cal_caption ">
                                                    <span class="">2017<span>年</span>&nbsp;01<span>月</span>&nbsp;12<span>日</span></span>
                                                </div>
                                                <div id="btnExeStamp" class="cal_btn">&nbsp;</div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
                            <button id="btn_update_id" type="button" class="btn">更新</button>
                        </div>
                    </div>
                    <div class="main_form">
                        <div class="table-responsive">
                            <table id="table_hed_id" class="table">
                                <thead>
                                    <tr>
                                        <th data-key="number" data-column="0">No</th>
                                        <th data-key="string" data-column="1">診療科</th>
                                        <th data-key="date" data-column="2">開始予定日時</th>
                                        <th data-key="date" data-column="3">終了予定日時</th>
                                        <th data-key="string" data-column="4">状況</th>
                                        <th data-key="string" data-column="5">手術室</th>
                                        <th data-key="string" data-column="6">術式</th>
                                        <th data-key="string" data-column="7">執刀医</th>
                                        <th data-key="string" data-column="8">担当看護師</th>
                                    </tr>
                                </thead>
                            </table>
                            <iframe class="ifram_table" id="pid_list_body" runat="server" src="PlanListdetail.aspx"></iframe>
                        </div>
                    </div>
                    <div class="bottom_form">
                        <button type="button" class="btn btn-left">戻る</button>
                        <button id="detail_id" type="button" class="btn btn-right">配置詳細</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
