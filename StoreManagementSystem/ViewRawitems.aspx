<%@ Page Title="" Language="C#" MasterPageFile="~/StoreMaster.master" AutoEventWireup="true" CodeFile="ViewRawitems.aspx.cs" Inherits="ViewRawitems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>

          function openModel() {
            $("#modalFlipInY").modal('show');
        }
        function CloseModel() {
            $("#modalFlipInY").modal('hide');
        }
        function clearAll() {
         
            $("#ContentPlaceHolder1_txtCategory").val("");
            
        }
        $(document).ready(function () {
            LoadItemData();

        });


        function LoadItemData(value) {

            $.ajax({
                type: "POST",
                dataType: "json",
                url: " ViewRawitems.aspx/LoadRawItems",
                contentType: "application/json; charset=utf-8",
                data: '{Value:"' + value + '"}',
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
                    Teacher.find("Items").text(),
                    Teacher.find("inQty").text(),
                    Teacher.find("outQty").text(),
                    Teacher.find("stockQty").text(),
                    Teacher.find("PurchasedCost").text(),
                    Teacher.find("SoldCost").text(),
                    Teacher.find("Stockcost").text(),
                    '<a href="#" id="btnEdit" onclick="EditCustomer(' + Teacher.find("ItemsID").text() + ')"><img src="img/editwhite.png" /></a>&ensp;|&ensp;' +
                    '<a href="#" id="btnDelete" onclick="DeleteCustomer(' + Teacher.find("ItemsID").text() + ')"><img src="img/drop.png" />']);

                Tbl.draw(false);
            });
        }

        function InsertData() {

            var Items = $("#<%=txtCategory.ClientID%>").val();
              $.ajax({
                        type: "POST",
                        url: "ViewRawitems.aspx/insertItems",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{Items:'" + Items + "'}",
                        success: function () {
                            CloseModel();
                            clearAll();
                            LoadItemData();
                        },
                        error: function (responce) {

                            alert(responce.text);
                        }

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
                            <h4>Items Detail</h4>
                        </div>
                        <div class="container">
                            <div class="row">

                                <div class="col-sm-12  col-lg-3 ">

                                    <div class="form-group">

                                        <asp:DropDownList runat="server" ID="cboCategory" CssClass="form-control" onchange="LoadItemData(this.value);"></asp:DropDownList>
                                       
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
                                    <th>SNO#</th>
                                    <th>Items</th>
                                    <th>In Qty</th>
                                    <th>Out Qty</th>
                                    <th>Stock Qty  </th>
                                    <th>Purchased Cost  </th>
                                    <th>Solded Cost</th>
                                    <th>Stock Cost</th>

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
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <asp:HiddenField runat="server" ID="hdncpd" />
                            <label class="txtwhite">Items Name:</label>
                             <asp:TextBox runat="server" CssClass="form-control" ID="txtCategory"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="m-t-lg">
                        <button class="btn btn-success" type="button" onclick="return InsertData();">Save</button>
                        <button class="btn btn-default" data-dismiss="modal" type="button" onclick="ClearAll();">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

