using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLLV2;
 
using System.Text;
 
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
 
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

    public class FillDropdowns
    {


        public static void FilldiffCheckboxList(int intOPCode, string spname, DropDownList _cbobox, CheckBoxList _cbobox2, CheckBoxList _cbobox3, CheckBoxList _cbobox4, CheckBoxList _cbobox5)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();

            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();






            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void EnableTextBoxCalender(string _ClientID, Page _p)
        {
            try
            {
                ScriptManager.RegisterStartupScript(_p.Page, _p.GetType(), "tmp_" + System.DateTime.Now.Ticks.ToString(), "<script>(function ($) { $('#" + _ClientID + "').mask(\"99/99/9999\"); });</script>", false);
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FillGridDropdowns(DropDownList _cbobox1, Label _lblSender)
        {
            try
            {
                if (_lblSender != null)
                {
                    if (_lblSender.Text.Trim().Length > 0)
                    {
                        if (_cbobox1.Items.FindByValue(_lblSender.Text) != null)
                        {
                            _cbobox1.SelectedValue = _lblSender.Text;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }



        public static void FilldiffCbos(int intOPCode, string spname, string _Values, string _FieldNames, ListBox _cbobox1,
               DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5,
               DropDownList _cbobox6, DropDownList _cbobox7, DropDownList _cbobox8, DropDownList _cbobox9, DropDownList _cbobox10
              )
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox1.DataSource = null;
            _cbobox1.DataBind();
            _cbobox1.Items.Clear();


            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();

            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();

            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();

            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();

            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();

            _cbobox7.DataSource = null;
            _cbobox7.DataBind();
            _cbobox7.Items.Clear();

            _cbobox8.DataSource = null;
            _cbobox8.DataBind();
            _cbobox8.Items.Clear();

            _cbobox9.DataSource = null;
            _cbobox9.DataBind();
            _cbobox9.Items.Clear();

            _cbobox10.DataSource = null;
            _cbobox10.DataBind();
            _cbobox10.Items.Clear();

            try
            {
                DataSet _ds = new DataSet();
                if (_FieldNames.Trim().Length > 0)
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _Values, _FieldNames, spname, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                }


                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox1.DataSource = _ds.Tables[0];
                            _cbobox1.DataValueField = "RecordID";
                            _cbobox1.DataTextField = "Record";
                            _cbobox1.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }

                        if (_ds.Tables.Count > 5)
                        {
                            _cbobox6.DataSource = _ds.Tables[5];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();
                        }

                        if (_ds.Tables.Count > 6)
                        {
                            _cbobox7.DataSource = _ds.Tables[6];
                            _cbobox7.DataValueField = "RecordID";
                            _cbobox7.DataTextField = "Record";
                            _cbobox7.DataBind();
                        }
                        if (_ds.Tables.Count > 7)
                        {
                            _cbobox8.DataSource = _ds.Tables[7];
                            _cbobox8.DataValueField = "RecordID";
                            _cbobox8.DataTextField = "Record";
                            _cbobox8.DataBind();
                        }
                        if (_ds.Tables.Count > 8)
                        {
                            _cbobox9.DataSource = _ds.Tables[8];
                            _cbobox9.DataValueField = "RecordID";
                            _cbobox9.DataTextField = "Record";
                            _cbobox9.DataBind();
                        }
                        if (_ds.Tables.Count > 9)
                        {
                            _cbobox10.DataSource = _ds.Tables[9];
                            _cbobox10.DataValueField = "RecordID";
                            _cbobox10.DataTextField = "Record";
                            _cbobox10.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }



        public static void FilldiffCbos(int intOPCode, string spname,
              DropDownList _cbobox1, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5,
              DropDownList _cbobox6, DropDownList _cbobox7, DropDownList _cbobox8)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox1.DataSource = null;
            _cbobox1.DataBind();
            _cbobox1.Items.Clear();


            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();

            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();

            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();

            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();

            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();

            _cbobox7.DataSource = null;
            _cbobox7.DataBind();
            _cbobox7.Items.Clear();

            _cbobox8.DataSource = null;
            _cbobox8.DataBind();
            _cbobox8.Items.Clear();


            try
            {
                DataSet _ds = new DataSet();
                _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);

                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox1.DataSource = _ds.Tables[0];
                            _cbobox1.DataValueField = "RecordID";
                            _cbobox1.DataTextField = "Record";
                            _cbobox1.DataBind();

                            _cbobox2.DataSource = _ds.Tables[0];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();

                            _cbobox3.DataSource = _ds.Tables[0];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();

                            _cbobox4.DataSource = _ds.Tables[0];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();

                            _cbobox5.DataSource = _ds.Tables[0];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();

                            _cbobox6.DataSource = _ds.Tables[0];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();

                            _cbobox7.DataSource = _ds.Tables[0];
                            _cbobox7.DataValueField = "RecordID";
                            _cbobox7.DataTextField = "Record";
                            _cbobox7.DataBind();

                            _cbobox8.DataSource = _ds.Tables[0];
                            _cbobox8.DataValueField = "RecordID";
                            _cbobox8.DataTextField = "Record";
                            _cbobox8.DataBind();

                        }
                    }
                }
            }
            catch
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FillListBox(ListBox _cbobox, int intOPCode, string _Values, string _FieldNames,
              string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }

                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //  MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbos(int intOPCode, string spname, ListBox _cbobox1,
            DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5,
            DropDownList _cbobox6, DropDownList _cbobox7, DropDownList _cbobox8
           )
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox1.DataSource = null;
            _cbobox1.DataBind();
            _cbobox1.Items.Clear();


            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();

            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();

            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();

            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();

            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();

            _cbobox7.DataSource = null;
            _cbobox7.DataBind();
            _cbobox7.Items.Clear();

            _cbobox8.DataSource = null;
            _cbobox8.DataBind();
            _cbobox8.Items.Clear();


            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox1.DataSource = _ds.Tables[0];
                            _cbobox1.DataValueField = "RecordID";
                            _cbobox1.DataTextField = "Record";
                            _cbobox1.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }

                        if (_ds.Tables.Count > 5)
                        {
                            _cbobox6.DataSource = _ds.Tables[5];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();
                        }

                        if (_ds.Tables.Count > 6)
                        {
                            _cbobox7.DataSource = _ds.Tables[6];
                            _cbobox7.DataValueField = "RecordID";
                            _cbobox7.DataTextField = "Record";
                            _cbobox7.DataBind();
                        }

                        if (_ds.Tables.Count > 7)
                        {
                            _cbobox8.DataSource = _ds.Tables[7];
                            _cbobox8.DataValueField = "RecordID";
                            _cbobox8.DataTextField = "Record";
                            _cbobox8.DataBind();
                        }

                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbos(int intOPCode, string spname, ListBox _cbobox1,
             DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5,
             DropDownList _cbobox6, DropDownList _cbobox7, DropDownList _cbobox8, DropDownList _cbobox9, DropDownList _cbobox10
            )
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox1.DataSource = null;
            _cbobox1.DataBind();
            _cbobox1.Items.Clear();


            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();

            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();

            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();

            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();

            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();

            _cbobox7.DataSource = null;
            _cbobox7.DataBind();
            _cbobox7.Items.Clear();

            _cbobox8.DataSource = null;
            _cbobox8.DataBind();
            _cbobox8.Items.Clear();

            _cbobox9.DataSource = null;
            _cbobox9.DataBind();
            _cbobox9.Items.Clear();

            _cbobox10.DataSource = null;
            _cbobox10.DataBind();
            _cbobox10.Items.Clear();

            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox1.DataSource = _ds.Tables[0];
                            _cbobox1.DataValueField = "RecordID";
                            _cbobox1.DataTextField = "Record";
                            _cbobox1.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }

                        if (_ds.Tables.Count > 5)
                        {
                            _cbobox6.DataSource = _ds.Tables[5];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();
                        }

                        if (_ds.Tables.Count > 6)
                        {
                            _cbobox7.DataSource = _ds.Tables[6];
                            _cbobox7.DataValueField = "RecordID";
                            _cbobox7.DataTextField = "Record";
                            _cbobox7.DataBind();
                        }
                        if (_ds.Tables.Count > 7)
                        {
                            _cbobox8.DataSource = _ds.Tables[7];
                            _cbobox8.DataValueField = "RecordID";
                            _cbobox8.DataTextField = "Record";
                            _cbobox8.DataBind();
                        }
                        if (_ds.Tables.Count > 8)
                        {
                            _cbobox9.DataSource = _ds.Tables[8];
                            _cbobox9.DataValueField = "RecordID";
                            _cbobox9.DataTextField = "Record";
                            _cbobox9.DataBind();
                        }
                        if (_ds.Tables.Count > 9)
                        {
                            _cbobox10.DataSource = _ds.Tables[9];
                            _cbobox10.DataValueField = "RecordID";
                            _cbobox10.DataTextField = "Record";
                            _cbobox10.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbosAllExceptOne(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {

                            if (_ds.Tables[0].Rows.Count > 0)
                            {
                                _cbobox.DataSource = _ds.Tables[0];
                                _cbobox.DataValueField = "RecordID";
                                _cbobox.DataTextField = "Record";
                                _cbobox.DataBind();
                            }
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            if (_ds.Tables[1].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[1].NewRow();
                                _dr[0] = "-1";
                                _dr[1] = "--All--";
                                _ds.Tables[1].Rows.InsertAt(_dr, 0);
                                _cbobox2.DataSource = _ds.Tables[1];
                                _cbobox2.DataValueField = "RecordID";
                                _cbobox2.DataTextField = "Record";
                                _cbobox2.DataBind();
                            }
                        }

                        if (_ds.Tables.Count > 2)
                        {
                            if (_ds.Tables[2].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[2].NewRow();
                                _dr[0] = "-1";
                                _dr[1] = "--All--";
                                _ds.Tables[2].Rows.InsertAt(_dr, 0);
                                _cbobox3.DataSource = _ds.Tables[2];
                                _cbobox3.DataValueField = "RecordID";
                                _cbobox3.DataTextField = "Record";
                                _cbobox3.DataBind();
                            }
                        }

                        if (_ds.Tables.Count > 3)
                        {
                            if (_ds.Tables[3].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[3].NewRow();
                                _dr[0] = "-1";
                                _dr[1] = "--All--";
                                _ds.Tables[3].Rows.InsertAt(_dr, 0);
                                _cbobox4.DataSource = _ds.Tables[3];
                                _cbobox4.DataValueField = "RecordID";
                                _cbobox4.DataTextField = "Record";
                                _cbobox4.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbosAll(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {

                            if (_ds.Tables[0].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[0].NewRow();
                                _dr[0] = "-1";
                                _dr[1] = "--All--";
                                _ds.Tables[0].Rows.InsertAt(_dr, 0);
                                _cbobox.DataSource = _ds.Tables[0];
                                _cbobox.DataValueField = "RecordID";
                                _cbobox.DataTextField = "Record";
                                _cbobox.DataBind();
                            }
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            if (_ds.Tables[1].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[1].NewRow();
                                _dr[0] = "-1";
                                _dr[1] = "--All--";
                                _ds.Tables[1].Rows.InsertAt(_dr, 0);
                                _cbobox2.DataSource = _ds.Tables[1];
                                _cbobox2.DataValueField = "RecordID";
                                _cbobox2.DataTextField = "Record";
                                _cbobox2.DataBind();
                            }
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            if (_ds.Tables[2].Rows.Count > 0)
                            {
                                DataRow _dr = _ds.Tables[2].NewRow();
                                _dr[0] = "-1";
                                _dr[1] = "--All--";
                                _ds.Tables[2].Rows.InsertAt(_dr, 0);
                                _cbobox3.DataSource = _ds.Tables[2];
                                _cbobox3.DataValueField = "RecordID";
                                _cbobox3.DataTextField = "Record";
                                _cbobox3.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }




        public static void FilldiffCbos(int intOPCode, string _Values, string _FieldNames, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            try
            {
                DataSet _ds = new DataSet();
                if (_FieldNames.Trim().Length > 0)
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _Values, _FieldNames, spname, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }




        public static void FilldiffCbos(int intOPCode, string _Values, string _FieldNames, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            try
            {
                DataSet _ds = new DataSet();
                if (_FieldNames.Trim().Length > 0)
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _Values, _FieldNames, spname, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbos(int intOPCode, string spname, string _Values, string _FieldNames, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            try
            {
                DataSet _ds = new DataSet();
                if (_FieldNames.Trim().Length > 0)
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _Values, _FieldNames, spname, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                }


                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }



        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }



        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5, DropDownList _cbobox6)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                        if (_ds.Tables.Count > 5)
                        {
                            _cbobox6.DataSource = _ds.Tables[5];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        //   FillDropdowns.FilldiffCbos(21, "SPR_DropDowns", CboProject, CboInvType, CboCat, CboPayType, ChkPurchasers);




        private static string GetChecklistsdata(CheckBoxList _chk)
        {
            string retCheckdata = "";
            int _n = 0;
            try
            {

                for (int i = 0; i < _chk.Items.Count; i++)
                {
                    if (_chk.Items[i].Selected == true)
                    {
                        if (_n == 0)
                        {
                            retCheckdata = Convert.ToString(_chk.Items[i].Value.Trim());
                            _n = 1;
                        }
                        else
                        {
                            retCheckdata = retCheckdata + "," + Convert.ToString(_chk.Items[i].Value.Trim());
                        }
                    }
                }
            }
            catch //(Exception exp)
            {
                //DivError.Visible = true;
                //lblError.Text = exp.Message;
            }
            return retCheckdata;
        }


        private static void CheckActives(ref CheckBoxList _chk, Hashtable _htable)
        {
            try
            {
                for (int i = 0; i < _chk.Items.Count; i++)
                {
                    if (_htable.Contains(_chk.Items[i].Value.Trim()))
                    {
                        _chk.Items[i].Selected = true;
                    }
                }
            }
            catch //(Exception exp)
            {
                //DivError.Visible = true;
                //lblError.Text = exp.Message;
            }
        }


        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, ListBox _cbobox5)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, ListBox _cbobox4)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();

            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5, ListBox _cbobox6)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();

            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                        if (_ds.Tables.Count > 5)
                        {
                            _cbobox6.DataSource = _ds.Tables[5];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, ListBox _cbobox5)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }

                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }

                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox5.DataSource = _ds.Tables[2];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, DropDownList _cbobox4, DropDownList _cbobox5, DropDownList _cbobox6, DropDownList _cbobox7)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            _cbobox4.DataSource = null;
            _cbobox4.DataBind();
            _cbobox4.Items.Clear();
            _cbobox5.DataSource = null;
            _cbobox5.DataBind();
            _cbobox5.Items.Clear();
            _cbobox6.DataSource = null;
            _cbobox6.DataBind();
            _cbobox6.Items.Clear();
            _cbobox7.DataSource = null;
            _cbobox7.DataBind();
            _cbobox7.Items.Clear();
            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }
                        if (_ds.Tables.Count > 2)
                        {
                            _cbobox3.DataSource = _ds.Tables[2];
                            _cbobox3.DataValueField = "RecordID";
                            _cbobox3.DataTextField = "Record";
                            _cbobox3.DataBind();
                        }
                        if (_ds.Tables.Count > 3)
                        {
                            _cbobox4.DataSource = _ds.Tables[3];
                            _cbobox4.DataValueField = "RecordID";
                            _cbobox4.DataTextField = "Record";
                            _cbobox4.DataBind();
                        }
                        if (_ds.Tables.Count > 4)
                        {
                            _cbobox5.DataSource = _ds.Tables[4];
                            _cbobox5.DataValueField = "RecordID";
                            _cbobox5.DataTextField = "Record";
                            _cbobox5.DataBind();
                        }
                        if (_ds.Tables.Count > 5)
                        {
                            _cbobox6.DataSource = _ds.Tables[5];
                            _cbobox6.DataValueField = "RecordID";
                            _cbobox6.DataTextField = "Record";
                            _cbobox6.DataBind();
                        }
                        if (_ds.Tables.Count > 6)
                        {
                            _cbobox7.DataSource = _ds.Tables[6];
                            _cbobox7.DataValueField = "RecordID";
                            _cbobox7.DataTextField = "Record";
                            _cbobox7.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FilldiffCbos(int intOPCode, string spname, DropDownList _cbobox, DropDownList _cbobox2)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();

            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();

                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();

                        }

                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbosRepeator(int intOPCode, string spname, DropDownList _cbobox, Repeater _cbobox2)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();


            try
            {
                DataSet _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataBind();
                        }

                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FilldiffCbos(int intOPCode, string spname, string _Values, string StrParam, DropDownList _cbobox, DropDownList _cbobox2)
        {
            string g_strErrorMessage = "";
            string g_strErrorType = "";
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            DataSet _ds = new DataSet();
            try
            {
                if (_Values.Trim().Length > 0)
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _Values, StrParam, spname, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, spname, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataValueField = "RecordID";
                            _cbobox.DataTextField = "Record";
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataValueField = "RecordID";
                            _cbobox2.DataTextField = "Record";
                            _cbobox2.DataBind();
                        }

                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }



        public static void FillCbos(DropDownList _cbobox, DropDownList _cbobox2, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            DataTable _dt = new DataTable();
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                            _cbobox2.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                            _cbobox2.DataValueField = _ValueMember;
                        }
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                        DataTable dt2 = _dt.Copy();
                        _cbobox2.DataSource = dt2;
                        _cbobox2.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }



        public static void FillCbos(DropDownList _cbobox, DropDownList _cbobox2, DropDownList _cbobox3, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            DataTable _dt = new DataTable();
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            _cbobox3.DataSource = null;
            _cbobox3.DataBind();
            _cbobox3.Items.Clear();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                            _cbobox2.DataTextField = _dispMember;
                            _cbobox3.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                            _cbobox2.DataValueField = _ValueMember;
                            _cbobox3.DataTextField = _dispMember;
                        }
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                        DataTable dt2 = _dt.Copy();
                        _cbobox2.DataSource = dt2;
                        _cbobox2.DataBind();

                        DataTable dt3 = _dt.Copy();
                        _cbobox3.DataSource = dt3;
                        _cbobox3.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

        public static void FillCbosTwoDs(DropDownList _cbobox, DropDownList _cbobox2, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            DataSet _ds = new DataSet();
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            _cbobox2.DataSource = null;
            _cbobox2.DataBind();
            _cbobox2.Items.Clear();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _ds = GeneralBL.FillDataSet(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (_dispMember.Trim().Length > 0)
                {
                    _cbobox.DataTextField = _dispMember;
                    _cbobox2.DataTextField = _dispMember;
                }
                if (_ValueMember.Trim().Length > 0)
                {
                    _cbobox.DataValueField = _ValueMember;
                    _cbobox2.DataValueField = _ValueMember;
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (_ds != null)
                    {
                        if (_ds.Tables.Count > 0)
                        {
                            _cbobox.DataSource = _ds.Tables[0];
                            _cbobox.DataBind();
                        }
                        if (_ds.Tables.Count > 1)
                        {
                            _cbobox2.DataSource = _ds.Tables[1];
                            _cbobox2.DataBind();
                        }
                    }
                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FillCbos(DropDownList _cbobox, int intOPCode,
            string _Values, string _FieldNames,
             string _Values2, string _FieldNames2,
            string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();

            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";

                if (_FieldNames.Trim().Length > 0)
                {
                    if (_FieldNames2.Trim().Length > 0)
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _Values2, _FieldNames, _FieldNames2, _spName, ref g_strErrorMessage, g_strErrorType);

                    }
                    else
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                    }

                }
                else
                {
                    if (_FieldNames2.Trim().Length > 0)
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _Values2, _FieldNames2, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                    else
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                }
                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        // MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //  MessageBox.Show(exp.Message);
            }
        }

        public static void FillCbos(DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                #region fillcbo


                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        // MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
            }
            catch (Exception exp)
            {
                //  MessageBox.Show(exp.Message);
            }
        }

        public static void FillCbos(bool _EnabledVal, string _defaultValue, DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();

                        if (_defaultValue.Trim().Length > 0)
                        {
                            _cbobox.SelectedValue = _defaultValue;
                            _cbobox.Enabled = _EnabledVal;
                        }
                        else
                        {
                            _cbobox.Enabled = true;
                        }
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        // MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //  MessageBox.Show(exp.Message);
            }
        }


        public static void FillCbosWithAll(DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _Values2, string _FieldNames2,
          string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    if (_FieldNames2.Trim().Length > 0)
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _Values2, _FieldNames, _FieldNames2, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                    else
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                }
                else
                {
                    if (_FieldNames2.Trim().Length > 0)
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _Values2, _FieldNames2, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                    else
                    {
                        _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        DataRow _dr = _dt.NewRow();
                        _dr[0] = "-1";
                        _dr[1] = "--All--";
                        _dt.Rows.InsertAt(_dr, 0);
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //  MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }

        public static void FillCbosWithAll(bool _EnabledVal, string _defaultValue, DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        DataRow _dr = _dt.NewRow();
                        _dr[0] = "-1";
                        _dr[1] = "";
                        _dt.Rows.InsertAt(_dr, 0);
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                        if (_defaultValue.Trim().Length > 0)
                        {
                            _cbobox.SelectedValue = _defaultValue;
                            _cbobox.Enabled = _EnabledVal;
                        }
                        else
                        {
                            _cbobox.Enabled = true;
                        }
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //  MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }

        public static void FillCbosWithAll(DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        DataRow _dr = _dt.NewRow();
                        _dr[0] = "-1";
                        _dr[1] = "";
                        _dt.Rows.InsertAt(_dr, 0);
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //  MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }



        public static void FillCbosWithAll(string _Title, DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember)
        {
            _cbobox.DataSource = null;
            _cbobox.DataBind();
            _cbobox.Items.Clear();
            DataTable _dt = new DataTable();
            try
            {
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        DataRow _dr = _dt.NewRow();
                        _dr[0] = "-1";
                        _dr[1] = _Title;
                        _dt.Rows.InsertAt(_dr, 0);
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //  MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }


        public static void FillCbos(DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember, ref DataTable _dtReturn)
        {
            try
            {
                _cbobox.DataSource = null;
                _cbobox.DataBind();
                _cbobox.Items.Clear();
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dtReturn = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dtReturn = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dtReturn))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        _cbobox.DataSource = _dtReturn;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        // MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                //  MessageBox.Show(exp.Message);
            }
        }


        public static void FillCbos(DropDownList _cbobox, int intOPCode,
            string _Values, string _FieldNames,
            string _Values2, string _FieldNames2,
            string _spName, string _dispMember, string _ValueMember, ref DataTable _dtReturn)
        {
            try
            {
                _cbobox.DataSource = null;
                _cbobox.DataBind();
                _cbobox.Items.Clear();
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    if (_FieldNames2.Trim().Length > 0)
                    {
                        _dtReturn = GeneralBL.FillDataGrid(intOPCode, _Values, _Values2, _FieldNames, _FieldNames2, _spName, ref g_strErrorMessage, g_strErrorType);

                    }
                    else
                    {
                        _dtReturn = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                    }

                }
                else
                {
                    if (_FieldNames2.Trim().Length > 0)
                    {
                        _dtReturn = GeneralBL.FillDataGrid(intOPCode, _Values2, _FieldNames2, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                    else
                    {
                        _dtReturn = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                    }
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dtReturn))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        _cbobox.DataSource = _dtReturn;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //  MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }


        public static void FillCbos(DropDownList _cbobox, int intOPCode, string _Values, string _FieldNames, string _spName, string _dispMember, string _ValueMember, bool isNoneAll)
        {
            DataTable _dt = new DataTable();
            try
            {
                _cbobox.DataSource = null;
                _cbobox.DataBind();
                _cbobox.Items.Clear();
                string g_strErrorMessage = "";
                string g_strErrorType = "";
                if (_FieldNames.Trim().Length > 0)
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _Values, _FieldNames, _spName, ref g_strErrorMessage, g_strErrorType);
                }
                else
                {
                    _dt = GeneralBL.FillDataGrid(intOPCode, _spName, ref g_strErrorMessage, g_strErrorType);
                }

                if (g_strErrorMessage.Length < 1)
                {
                    if (GeneralBL.isdtEmptyorRows(_dt))
                    {
                        if (_dispMember.Trim().Length > 0)
                        {
                            _cbobox.DataTextField = _dispMember;
                        }
                        if (_ValueMember.Trim().Length > 0)
                        {
                            _cbobox.DataValueField = _ValueMember;
                        }
                        if (isNoneAll == true)
                        {
                            DataRow dr = _dt.NewRow();
                            dr[0] = "-1";
                            dr[1] = "--ALL--";
                            _dt.Rows.InsertAt(dr, 0);
                        }
                        _cbobox.DataSource = _dt;
                        _cbobox.DataBind();
                    }

                }
                else
                {
                    if (g_strErrorMessage.Length > 1)
                    {
                        //   MessageBox.Show(g_strErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show(exp.Message);
            }
        }

    }