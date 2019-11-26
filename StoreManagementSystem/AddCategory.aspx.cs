using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using BLLV2;


public partial class AddCategory : System.Web.UI.Page
{
    private static string strErrorMessage = "";
    private static string strErrorType = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string insertCategory(string CategoryName)
    {
        try
        {
            GeneralBL.AddUpdate(1, "@CategoryName", CategoryName, "SPR_ItemsCategory", ref strErrorMessage);
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



    [WebMethod]
    public static string LoadItemscategory()
    {
        try
        {
            strErrorType = strErrorType = "";
            DataSet ds = GeneralBL.FillDataSet(5, "SPR_ItemsCategory", ref strErrorType, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;
        }

    }


    [WebMethod]
    public static string DeleteCategory(string CategoryID)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.Delete(3, "SPR_ItemsCategory", "@CategoryID", CategoryID, ref strErrorMessage, strErrorType);
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
    [WebMethod]
    public static string EditCategory(int CategoryID)
    {
        try
        {
            strErrorMessage = strErrorType = "";

            DataSet ds = GeneralBL.FillDataSet(5, CategoryID, "@CategoryID", "SPR_ItemsCategory", ref strErrorMessage, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;

        }

    }
    [WebMethod]
    public static string UpdateCategory(string CategoryID,string CategoryName)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.AddUpdate(2, "@CategoryID", CategoryID, "@CategoryName", CategoryName, "SPR_ItemsCategory", ref strErrorMessage);
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