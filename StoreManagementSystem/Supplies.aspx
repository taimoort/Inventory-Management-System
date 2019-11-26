<%@ Page Title="" Language="C#" MasterPageFile="~/StoreMaster.master" AutoEventWireup="true" CodeFile="Supplies.aspx.cs" Inherits="Supplies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.14.0/xlsx.full.min.js"></script>
    <script src="js/jquery.dataTables.min.js"></script>
    <script>
        function openModel() {
            $("#modalFlipInY").modal('show');
        }
        function CloseModel() {
            $("#modalFlipInY").modal('hide');
        }
        function clearAll() {
            $("#ContentPlaceHolder1_hdncpd").val("");
            $("#ContentPlaceHolder1_txtSuppliers").val("");
            $("#ContentPlaceHolder1_txtContact").val("");
            $("#ContentPlaceHolder1_txtAddress").val("");
            $("#ContentPlaceHolder1_cboStatus").val(1);

        }


        function InsertorUpdate() {
            var Suppliers = $("#<%=txtSuppliers.ClientID%>").val();
            var Address = $("#<%=txtAddress.ClientID%>").val();
            var Contact = $("#<%=txtContact.ClientID%>").val();
            var Status = $("#<%=cboStatus.ClientID%>").val();
            if (Suppliers == '') {

                alert('Fill Suppliers')

            }
            else
                if (Address == '') {
                    alert('Fill Address')

                }
                else if (Contact == '') {
                    alert('Fill Contact')

                }


                else if ($("#ContentPlaceHolder1_hdncpd").val() != "") {

                    $.ajax({
                        type: "POST",
                        url: "Supplies.aspx/UpdateSuppilers",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{SuppliersID:'" + $("#ContentPlaceHolder1_hdncpd").val() + "',Suppliers:'" + Suppliers + "',Address:'" + Address + "',Contact:'" + Contact + "',Status:'" + Status + "'}",
                        success: function () {
                            CloseModel();
                            clearAll();
                            LoadSData();
                        },
                        error: function (responce) {

                            alert(responce.text);
                        }

                    });
                }

                else {
                    $.ajax({
                        type: "POST",
                        url: "Supplies.aspx/insertSuppliers",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{Suppliers:'" + Suppliers + "',Address:'" + Address + "',Contact:'" + Contact + "',Status:'" + Status + "'}",
                        success: function () {
                            CloseModel();
                            clearAll();
                            LoadSData();
                        },
                        error: function (responce) {

                            alert(responce.text);
                        }

                    });
                }
        }

        $(document).ready(function () {
            LoadSData();

        });


        function LoadSData() {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: " Supplies.aspx/LoadSuppliers",
                contentType: "application/json; charset=utf-8",
                data: '{}',
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
                    count,
                    Teacher.find("Suppliers").text(),
                    Teacher.find("Contact").text(),
                    Teacher.find("Address").text(),
                    Teacher.find("Status").text(),
                    '<a href="#" id="btnEdit" onclick="EditSuppliers(' + Teacher.find("SuppliersID").text() + ')"><img src="img/editwhite.png" /></a>&ensp;|&ensp;' +
                    '<a href="#" id="btnDelete" onclick="DeleteSuppliers(' + Teacher.find("SuppliersID").text() + ')"><img src="img/drop.png" /></a>&ensp;|&ensp;' +
                    '<a href="#" class="' + Teacher.find("Statusicon").text() + '" style="color:Green" id="btnStatus" onclick="CheckStatus(' + Teacher.find("SuppliersID").text() + ')"></a>']);


                Tbl.draw(false);
            });
        }

        function DeleteSuppliers(SuppliersID) {
            var v = confirm('Are You Sure to Deleting the record!!!!');
            if (v == true) {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "Supplies.aspx/DeleteSuppliers",
                    contentType: "application/json;charset=utf-8",
                    data: '{SuppliersID:"' + SuppliersID + '"}',
                    success: function () {
                        LoadSData();
                    },
                    error: function (responce) {
                        alert(responce.d);
                    }
                });
            }
        }
        function CheckStatus(SuppliersID) {
            var status = $('#btnStatus').val();
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "Supplies.aspx/CheckStatus",
                contentType: "application/json;charset=utf-8",
                data: '{SuppliersID:"' + SuppliersID + '"}',
                success: function () {

                    LoadSData();

                },
                error: function (responce) {
                    alert(responce.d);
                }
            });
        }
        function EditSuppliers(SuppliersID) {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "Supplies.aspx/EditSuppilers",
                contentType: "application/json; charset=utf-8",
                data: '{SuppliersID:' + SuppliersID + '}',
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
                $("#ContentPlaceHolder1_hdncpd").val(customer.find("SuppliersID").text());
                $("#ContentPlaceHolder1_txtSuppliers").val(customer.find("Suppliers").text());
                $("#ContentPlaceHolder1_txtContact").val(customer.find("Contact").text());
                $("#ContentPlaceHolder1_txtAddress").val(customer.find("Address").text());
                $("#ContentPlaceHolder1_cboStatus").val(customer.find("Status").text());

            });
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
                            <h4>Suppliers Detail</h4>
                        </div>
                        <div class="container">
                            <div class="row">


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
                                        <th>SNO#</th>
                                        <th>Suppliers</th>
                                        <th>Contact</th>
                                        <th>Address</th>
                                        <th>Status</th>
                                        <th>Action(S)</th>
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
                        <span aria-hidden="true">×</span>
                        <span class="sr-only">Close</span>
                    </button>
                    <h3 class="txtwhite">ADD</h3>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <asp:HiddenField runat="server" ID="hdncpd" />
                            <label class="txtwhite">Suppliers:</label>
                            <asp:TextBox runat="server" ID="txtSuppliers" AutoComplete="Off" onkeyup="IS_aLPHA(this);" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <label class="txtwhite">Contact:</label>
                            <asp:TextBox runat="server" ID="txtContact" AutoComplete="Off" onkeyup="IS_iNT(this);" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <label class="txtwhite">Status:</label>
                            <asp:DropDownList runat="server" ID="cboStatus" CssClass="form-control">

                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">InActive</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <label class="txtwhite">Address:</label>
                            <asp:TextBox runat="server" ID="txtAddress" AutoComplete="Off" CssClass="form-control"></asp:TextBox>

                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="m-t-lg">
                        <button class="btn btn-success" type="button" onclick="return InsertorUpdate();">Save</button>
                        <button class="btn btn-default" data-dismiss="modal" type="button" onclick="clearAll();">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

