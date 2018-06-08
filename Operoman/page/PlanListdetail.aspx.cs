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
            for (int i = 0; i < 100; i++) {
                tblList.Controls.Add(CreateRow(""+i));
            }
            tblList.ID = "table_detail_id";
            tblList.Attributes["class"] = "table";
            divDetailContiner.Controls.Add(tblList);
        }
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 行の追加
        /// </summary>
        public HtmlTableRow CreateRow(string i)
        {
            string sDate = DateTime.Now.AddDays(Int32.Parse(i)).ToString("yyyy/MM/dd");
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(CreateCell(i, "over_txt"));
            row.Cells.Add(CreateCell("診療科"+i, "over_txt"));
            row.Cells.Add(CreateCell(sDate, "over_txt"));
            row.Cells.Add(CreateCell(sDate, "over_txt"));
            row.Cells.Add(CreateCell("状況"+i, "over_txt"));
            row.Cells.Add(CreateCell("手術室"+i, "over_txt"));
            row.Cells.Add(CreateCell("術式"+i, "over_txt"));
            row.Cells.Add(CreateCell("執刀医"+i, "over_txt"));
            row.Cells.Add(CreateCell("担当看護師"+i, "over_txt"));
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