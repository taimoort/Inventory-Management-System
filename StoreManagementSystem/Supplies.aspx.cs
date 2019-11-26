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


public partial class Supplies : System.Web.UI.Page
{
    private static string strErrorMessage = "";
    private static string strErrorType = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string insertSuppliers(string Suppliers, string Address, string Contact, string Status)
    {
        try
        {
            GeneralBL.AddUpdate(1, "@Suppliers", Suppliers, "@Address", Address, "@Contact", Contact, "@Status", Status, "SPR_Suppliers", ref strErrorMessage);
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
    public static string LoadSuppliers()
    {
        try
        {
            strErrorType = strErrorType = "";
            DataSet ds = GeneralBL.FillDataSet(4, "SPR_Suppliers", ref strErrorType, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;
        }

    }

    [WebMethod]
    public static string DeleteSuppliers(string SuppliersID)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.Delete(3, "SPR_Suppliers", "@SuppliersID", SuppliersID, ref strErrorMessage, strErrorType);
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
    public static string EditSuppilers(int SuppliersID)
    {
        try
        {
            strErrorMessage = strErrorType = "";

            DataSet ds = GeneralBL.FillDataSet(4, SuppliersID, "@SuppliersID", "SPR_Suppliers", ref strErrorMessage, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;

        }

    }


    [WebMethod]
    public static string UpdateSuppilers(string SuppliersID, string Suppliers, string Address, string Contact,string Status)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.AddUpdate(2, "@SuppliersID", SuppliersID, "@Suppliers", Suppliers, "@Address", Address, "@Contact", Contact,"@Status",Status, "SPR_Suppliers", ref strErrorMessage);
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
    public static string CheckStatus(string SuppliersID)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.AddUpdate(100, "@SuppliersID", SuppliersID, "SPR_Suppliers", ref strErrorMessage);
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


