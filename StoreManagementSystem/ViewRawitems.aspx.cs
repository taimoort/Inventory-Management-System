using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BLLV2;
using System.Web.Services;

public partial class ViewRawitems : System.Web.UI.Page
{

    private static string strErrorMessage = "";
    private static string strErrorType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDown();
        }

    }

    public void FillDropDown()
    {
        FillDropdowns.FillCbos(cboCategory, 10, "", "", "SPR_ItemsCategory", "Record", "RecordID");
        


    }

    [WebMethod]
    public static string LoadRawItems(string Value)
    {
        try
        {
            strErrorType = strErrorType = "";
            DataSet ds = GeneralBL.FillDataSet(4, "SPR_RawItems", ref strErrorType, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;
        }

    }

    [WebMethod]
    public static string insertItems(string Items)
    {
        try
        {
            GeneralBL.AddUpdate(200, "@Items", Items, "SPR_RawItems", ref strErrorMessage);
            if (strErrorMessage.Length < 1)
            {
                return strErrorMessage;
            }
            else
            {
                return strErrorMessage;

            }
        }
        catch (Exception exp)
        {
            return strErrorMessage = exp.Message;
        }

    }

}