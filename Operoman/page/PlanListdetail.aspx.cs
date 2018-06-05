using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Operoman.page
{
    public partial class PlanListdetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlTable tblList = new HtmlTable();
            divDetailContiner.Controls.Clear();
            for (int i = 0; i < 20; i++) {
                tblList.Controls.Add(CreateRow());
            }
            tblList.ID = "table_detail_id";
            tblList.Attributes["class"] = "table";
            divDetailContiner.Controls.Add(tblList);
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 行の追加
        /// </summary>
        public HtmlTableRow CreateRow()
        {
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(CreateCell("No", "over_txt"));
            row.Cells.Add(CreateCell("診療科", "over_txt"));
            row.Cells.Add(CreateCell("開始予定日時", "over_txt"));
            row.Cells.Add(CreateCell("終了予定日時", "over_txt"));
            row.Cells.Add(CreateCell("状況", "over_txt"));
            row.Cells.Add(CreateCell("手術室", "over_txt"));
            row.Cells.Add(CreateCell("術式", "over_txt"));
            row.Cells.Add(CreateCell("執刀医", "over_txt"));
            row.Cells.Add(CreateCell("担当看護師", "over_txt"));
            return row;
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ｾﾙの追加
        /// </summary>
        public HtmlTableCell CreateCell(string sCaption, string sClass)
        {
            HtmlTableCell cell = new HtmlTableCell();
            //
            cell.InnerText = sCaption;
            cell.Attributes["title"] = sCaption;
            cell.Attributes["class"] = sClass;
            //
            // Exit
            return cell;
        }
    }
}