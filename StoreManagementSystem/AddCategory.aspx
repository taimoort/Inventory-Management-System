<%@ Page Title="" Language="C#" MasterPageFile="~/StoreMaster.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
          function openModel() {
            $("#modalFlipInY").modal('show');
        }
        function CloseModel() {
            $("#modalFlipInY").modal('hide');
        }
        function clearAll() {
            $("#ContentPlaceHolder1_hdncpd").val("");
            $("#ContentPlaceHolder1_txtCategoryName").val("");
         
        }
        function insertorUpdate() {
            var CategoryName = $("#<%=txtCategoryName.ClientID%>").val();

            if (CategoryName == '') {

                alert('Fill Category')

            }
            else if ($("#ContentPlaceHolder1_hdncpd").val() != "") {
                $.ajax({
                    type: "POST",
                    url: "AddCategory.aspx/UpdateCategory",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "{CategoryID:'" + $("#ContentPlaceHolder1_hdncpd").val() + "',CategoryName:'" + CategoryName + "'}",
                    success: function () {
                        CloseModel();
                        clearAll();
                        LoadDataItems();
                    },
                    error: function (responce) {

                        alert(responce.text);
                    }

                });
            }

            else {
                $.ajax({
                    type: "POST",
                    url: "AddCategory.aspx/insertCategory",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: "{CategoryName:'" + CategoryName + "'}",
                    success: function () {
                        CloseModel();
                        LoadDataItems();
                    },
                    error: function (responce) {

                        alert(responce.text);
                    }

                });

            }

        }

        $(document).ready(function () {
            LoadDataItems();
        });


        function LoadDataItems() {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: " AddCategory.aspx/LoadItemscategory",
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
                    Teacher.find("CategoryName").text(),
                    '<a href="#" id="btnEdit" onclick="EditCategory(' + Teacher.find("CategoryID").text() + ')"><img src="img/editwhite.png" /></a>&ensp;|&ensp;' +
                    '<a href="#" id="btnDelete" onclick="DeleteCategory(' + Teacher.find("CategoryID").text() + ')"><img src="img/drop.png" /></a>']);
                Tbl.draw(false);
            });
        }


        function DeleteCategory(CategoryID) {
            var v = confirm('Are You Sure to Deleting the record!!!!');
            if (v == true) {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "AddCategory.aspx/DeleteCategory",
                    contentType: "application/json;charset=utf-8",
                    data: '{CategoryID:"' + CategoryID + '"}',
                    success: function () {
                        LoadDataItems();
                    },
                    error: function (responce) {
                        alert(responce.d);
                    }
                });
            }
        }
        function EditCategory(CategoryID) {
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "AddCategory.aspx/EditCategory",
                contentType: "application/json; charset=utf-8",
                data: '{CategoryID:' + CategoryID + '}',
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
                $("#ContentPlaceHolder1_hdncpd").val(customer.find("CategoryID").text());
                $("#ContentPlaceHolder1_txtCategoryName").val(customer.find("CategoryName").text());


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
                            <h4>Category Detail</h4>
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
                                        <th>Category</th>
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
                    <h3 class="txtwhite">ADD Category</h3>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <asp:HiddenField runat="server" ID="hdncpd" />
                            <label class="txtwhite">CategoryName:</label>
                            <asp:TextBox runat="server" ID="txtCategoryName" AutoComplete="Off" onkeyup="IS_aLPHA(this);" CssClass="form-control"></asp:TextBox>

                        </div>


                    </div>
                </div>
                <div class="modal-footer">
                    <div class="m-t-lg">
                        <button class="btn btn-success" type="button" onclick="return insertorUpdate();">Save</button>
                        <button class="btn btn-default" data-dismiss="modal" type="button" onclick="clearAll();">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

