using System;

namespace ReadTrxFile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ResultTable resultTable = new ResultTable();
            if (!IsPostBack)
            {
                grdTestResult.DataSource = resultTable.GetTestResultData();
                grdTestResult.DataBind();
            }
        }
    }
}