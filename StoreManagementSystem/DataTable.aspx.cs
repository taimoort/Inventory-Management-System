using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using BLLV2;
public partial class DataTable : System.Web.UI.Page
{
    private static string strErrorMessge = "";
    private static string strErrorType = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string FillDataTable()
    {
        try
        {
            DataSet ds = GeneralBL.FillDataSet(40,"SP_RoomType", ref strErrorMessge, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {
            return strErrorMessge = exp.Message;
        }
    }
}