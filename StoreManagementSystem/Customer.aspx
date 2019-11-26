<%@ Page Title="" Language="C#" MasterPageFile="~/StoreMaster.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>


        function openModel() {
            $("#modalFlipInY").modal('show');
        }
        function CloseModel() {
            $("#modalFlipInY").modal('hide');
        }

        function ClearAll() {
            $("#ContentPlaceHolder1_hdncpd").val("");
            $("#ContentPlaceHolder1_txtCustomer").val("");
            $("#ContentPlaceHolder1_txtEmail").val("");
            $("#ContentPlaceHolder1_txtCellno").val("");
            $("#ContentPlaceHolder1_txtCnic").val("");
            $("#ContentPlaceHolder1_txtAddress").val("");



        }


        function InsertDataorUpdate() {
            var Customer = $("#<%=txtCustomer.ClientID%>").val();
            var Email = $("#<%=txtEmail.ClientID%>").val();
            var CellNo = $("#<%=txtCellno.ClientID%>").val();
            var Cnic = $("#<%=txtCnic.ClientID%>").val();
            var Address = $("#<%=txtAddress.ClientID%>").val();

            if (Customer == '') {
                alert('Fill Customer');

            }
            else
                if (Email == '') {
                    alert('Fill Email');

                }
                else
                    if (CellNo == '') {
                        alert('Fill CellNo');

                    }
                    else
                        if (Cnic == '') {
                            alert('Fill Cnic');

                        }
                        else
                            if (Address == '') {
                                alert('Fill Address');

                            }
                            else if ($("#ContentPlaceHolder1_hdncpd").val() != "") {

                                $.ajax({
                                    type: "POST",
                                    url: "Customer.aspx/UpdateCustomer",
                                    dataType: "json",
                                    contentType: "application/json; charset=utf-8",
                                    data: "{CustomerID:'" + $("#ContentPlaceHolder1_hdncpd").val() + "',Customer:'" + Customer + "',Email:'" + Email + "',CellNo:'" + CellNo + "',Cnic:'" + Cnic + "',Address:'" + Address + "'}",
                                    success: function () {
                                        CloseModel();
                                        ClearAll();
                                        LoadCustomerData();
                                    },
                                    error: function (responce) {

                                        alert(responce.text);
                                    }

                                });
                            }

                            else {
                                $.ajax({
                                    type: "POST",
                                    url: "Customer.aspx/InsertCustomer",
                                    dataType: "json",
                                    contentType: "application/json; charset=utf-8",
                                    data: "{Customer:'" + Customer + "',Email:'" + Email + "',CellNo:'" + CellNo + "',Cnic:'" + Cnic + "',Address:'" + Address + "'}",
                                    success: function () {
                                        CloseModel();
                                        ClearAll();
                                        LoadCustomerData();

                                    },
                                    error: function (responce) {

                                        alert(responce.text);
                                    }

                                });

                            }
        }


        $(document).ready(function () {
            LoadCustomerData();

        });


        function LoadCustomerData() {
            var Search = $("#<%=txtSearch.ClientID%>").val();
            $.ajax({
                type: "POST",
                dataType: "json",
                url: " Customer.aspx/LoadCustomer",
                contentType: "application/json; charset=utf-8",
                data: '{Search:"' + Search + '"}',
                success: OnloadSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (responce) {
                    alert(responce.d);
                }
            })
        }
        function OnloadSuccess(response) {

            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var Teacher = xml.find("Table");
            var Tbl = $('#demo-datatables-fixedheader-1').DataTable();
            Tbl.clear();
            var count = 0;
            Teacher.each(function () {
                var Teacher = $(this);
                count = count + 1;

                Tbl.row.add([
                    '<input type="checkbox" id="CheckOne_' + count + '" value="' + Teacher.find("CustomerID").text() + '">',
                    count,
                    Teacher.find("CustomerName").text(),
                    Teacher.find("Email").text(),
                    Teacher.find("CellPhone").text(),
                    Teacher.find("CNIC").text(),
                    Teacher.find("Address").text(),
                    '<a href="#" id="btnEdit" onclick="EditCustomer(' + Teacher.find("CustomerID").text() + ')"><img src="img/editwhite.png" /></a>&ensp;|&ensp;' +
                    '<a href="#" id="btnDelete" onclick="DeleteCustomer(' + Teacher.find("CustomerID").text() + ')"><img src="img/drop.png" />']);

                Tbl.draw(false);
            });
        }

        function DeleteCustomer(CustomerID) {
            var v = confirm('Are You Sure to Deleting the record!!!!');
            if (v == true) {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "Customer.aspx/DeleteCustomer",
                    contentType: "application/json;charset=utf-8",
                    data: '{CustomerID:"' + CustomerID + '"}',
                    success: function () {
                        LoadCustomerData();
                    },
                    error: function (responce) {
                        alert(responce.d);
                    }
                });
            }
        }

        function EditCustomer(CustomerID) {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "Customer.aspx/EditCustomer",
                contentType: "application/json; charset=utf-8",
                data: '{CustomerID:' + CustomerID + '}',
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            openModel();
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var customers = xml.find("Table");
            val = customers;
            customers.each(function () {
                var customer = $(this);
                $("#ContentPlaceHolder1_hdncpd").val(customer.find("CustomerID").text());
                $("#ContentPlaceHolder1_txtCustomer").val(customer.find("CustomerName").text());
                $("#ContentPlaceHolder1_txtEmail").val(customer.find("Email").text());
                $("#ContentPlaceHolder1_txtCellno").val(customer.find("CellPhone").text());
                $("#ContentPlaceHolder1_txtCnic").val(customer.find("CNIC").text());
                $("#ContentPlaceHolder1_txtAddress").val(customer.find("Address").text());


            });
        }



        function checKAll() {

            $('table [id*=ContentPlaceHolder1_chkAll]').click(function () {
                if ($(this).is(':checked'))
                    $('table [id*=CheckOne]').prop('checked', true)
                else
                    $('table [id*=CheckOne]').prop('checked', false)
            });
            $('table [id*=CheckOne]').click(function () {

                var total_rows_View = $('table [id*=CheckOne]').length;
                var checked_Rows_View = $('table [id*=CheckOne]:checked').length;

                if (checked_Rows_View == total_rows_View)
                    $('table [id*=chkAll]').prop('checked', true);
                else
                    $('table [id*=chkAll]').prop('checked', false);
            });

        }

        function DeleteAll() {

            var checkAll = '';
            var length = $('table [id*=CheckOne]').length;
            for (var i = 1; i <= length; i++) {
                if ($('#CheckOne_' + i).prop('checked')) {
                    checkAll += $('#CheckOne_' + i).val() + ',';
                }
            }
            checkAll = checkAll.substring(0, checkAll.length - 1);
            var v = confirm('Are You sure delete the Record')
            if (v == true) {


                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "Customer.aspx/DeleteAllCustomer",
                    contentType: "application/json; charset=utf-8",
                    data: '{ checkAll:"' + checkAll + '"}',
                    success: function (data) {
                        if (data.d.length > 0) {
                            alert(data.d);
                        } else {
                            LoadCustomerData();
                        }
                    },
                    error: function (responce) {
                        alert(responce.d);
                    }
                });
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="layout-content">
        <div class="layout-content-body">
            <div class="title-bar">
            </div>
            <div class="row gutter-xs">
                <div class="col-xs-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="card-actions">
                            </div>
                            <h4>Customer Detail</h4>
                        </div>
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-12  col-lg-2 ">

                                    <div class="form-group">

                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Customer Name.."></asp:TextBox>
                                    </div>

                                </div>

                                <div class="col-sm-12  col-lg-1 ">

                                    <div class="form-group">

                                        <button class="btn btn-primary" type="button" id="btnSearch" onclick="LoadCustomerData();">Search</button>
                                    </div>

                                </div>
                                <div class="col-sm-12  col-lg-1 ">

                                    <div class="form-group">

                                        <button class="btn btn-primary" type="button" id="btnDeleteall" onclick="DeleteAll();">Delete All </button>
                                    </div>

                                </div>

                                <div class="col-sm-12  col-lg-1 ">

                                    <div class="form-group">

                                        <button class="btn btn-primary" data-toggle="modal" data-target="#modalFlipInY" type="button">Add New</button>
                                    </div>

                                </div>

                            </div>
                        </div>
                        <div class="card-body">
                            <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            <table id="demo-datatables-fixedheader-1" class="table table-hover table-striped table-nowrap dataTable" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        <th>
                                            <asp:CheckBox runat="server" ID="chkAll" onchange="checKAll();" /></th>
                                        <th>SNO#</th>
                                        <th>Customer Name</th>
                                        <th>Email</th>
                                        <th>Cell No </th>
                                        <th>Cnic  </th>
                                        <th>Address  </th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="modalFlipInY" tabindex="-1" role="dialog" class="modal in">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="clearAll();">
                        <span aria-hidden="true" onclick="ClearAll();">×</span>
                        <span class="sr-only" onclick="ClearAll();">Close</span>
                    </button>
                    <h3 class="txtwhite">ADD</h3>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <asp:HiddenField runat="server" ID="hdncpd" />
                            <label class="txtwhite">Customer Name:</label>
                            <asp:TextBox runat="server" ID="txtCustomer" AutoComplete="Off" onkeyup="IS_aLPHA(this);" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <label class="txtwhite">Email:</label>
                            <asp:TextBox runat="server" ID="txtEmail" AutoComplete="Off" onkeyup="IS_eMAIL(this);" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <label class="txtwhite">Cell No:</label>
                            <asp:TextBox runat="server" ID="txtCellno" AutoComplete="Off" onkeyup="IS_iNT(this);" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <label class="txtwhite">Cnic:</label>
                            <asp:TextBox runat="server" ID="txtCnic" AutoComplete="Off" onkeyup="setCNIC(this);" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <label class="txtwhite">Address:</label>
                            <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" AutoComplete="Off" CssClass="form-control"></asp:TextBox>

                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="m-t-lg">
                        <button class="btn btn-success" type="button" onclick="return InsertDataorUpdate();">Save</button>
                        <button class="btn btn-default" data-dismiss="modal" type="button" onclick="ClearAll();">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

