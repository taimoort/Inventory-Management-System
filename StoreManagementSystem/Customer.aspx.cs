using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLV2;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Web.Services;




public partial class Customer : System.Web.UI.Page
{

    private static string strErrorMessage = "";
    private static string strErrorType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
    }


    [WebMethod]
    public static string InsertCustomer(string Customer, string Email, string CellNo, string Cnic, string Address)
    {
        try
        {
            GeneralBL.AddUpdate(1, "@CustomerName", Customer, "@Email", Email, "@CellPhone", CellNo, "@CNIC", Cnic, "@Address", Address, "SPR_Customers", ref strErrorMessage);
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
    public static string LoadCustomer(string Search)
    {
        try
        {
            strErrorType = strErrorType = "";

            //SqlParameter[] paramstostore = new SqlParameter[2];
            //paramstostore[0] = new SqlParameter("@OpCode", SqlDbType.Int);
            //paramstostore[0].Value = 5;
            //paramstostore[1] = new SqlParameter("@Amount", SqlDbType.VarChar);
            //paramstostore[1].Value = Search;
            DataSet ds = GeneralBL.FillDataSet(8, Search, "@CustomerName", "SPR_Customers", ref strErrorType, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;
        }

    }

    [WebMethod]
    public static string DeleteCustomer(string CustomerID)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.Delete(3, "SPR_Customers", "@CustomerID", CustomerID, ref strErrorMessage, strErrorType);
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
    public static string EditCustomer(int CustomerID)
    {
        try
        {
            strErrorMessage = strErrorType = "";

            DataSet ds = GeneralBL.FillDataSet(5, CustomerID, "@CustomerID", "SPR_Customers", ref strErrorMessage, strErrorType);
            return ds.GetXml();
        }
        catch (Exception exp)
        {

            return strErrorMessage = exp.Message;

        }

    }


    [WebMethod]
    public static string UpdateCustomer(string CustomerID, string Customer, string Email, string CellNo, string Cnic, string Address)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.AddUpdate(2, "@CustomerID", CustomerID, "@CustomerName", Customer, "@Email", Email, "@CellPhone", CellNo, "@CNIC", Cnic, "@Address", Address, "SPR_Customers", ref strErrorMessage);
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
    public static string DeleteAllCustomer(string checkAll)
    {
        try
        {
            strErrorMessage = strErrorType = "";
            GeneralBL.Delete(13, "SPR_Customers", "@CustomerDel", checkAll, ref strErrorMessage, strErrorType);
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