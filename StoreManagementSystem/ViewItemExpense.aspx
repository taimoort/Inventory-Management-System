<%@ Page Title="" Language="C#" MasterPageFile="~/StoreMaster.master" AutoEventWireup="true" CodeFile="ViewItemExpense.aspx.cs" Inherits="ViewItemExpense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script>
          $(document).ready(function () {
              loaddata();
          });
        //PopUp
        function openModel() {

            $("#modalFlipInY").modal('show');
        }
        function CloseModel() {
            $('#modalFlipInY').modal('hide');
        }
        //function clearAll() {
        //    val = null;
             
        //    $("#ctl00_ContentPlaceHolder1_hdn").val("");
        //    $("#ctl00_ContentPlaceHolder1_txtUserName").val("");
        //    $("#ctl00_ContentPlaceHolder1_txtPassword").val("");
        //    $("#ctl00_ContentPlaceHolder1_txtName").val("");
        //    $("#ctl00_ContentPlaceHolder1_ddlRole").val(1);
        //    $("#ctl00_ContentPlaceHolder1_ddlStatus").val(1);
        //}


        //updateORSave
          function UpdateorSaveData() {
            /////JQuery+Asp
              var UserName = $("#<%=txtUserName.ClientID%>").val();
              /////Pure Jquery
              //var usrname = $('#ContentPlaceHolder1_txtUserName').val();
              //////////Pure Java script
              //var Username = document.getElementById('txtusername').value;

            var Password = $("#<%=txtPassword.ClientID%>").val();
            var Name = $("#<%=txtName.ClientID%>").val();
            var Role = $("#<%=ddlRole.ClientID%>").val();
            var Status = $("#<%=ddlStatus.ClientID%>").val();

            if (UserName == "") {
                alert('Name cannot be blank. ')
            }
            else if (Password == "") {
                alert('Name cannot be blank')
            }
            else if (Name == "")
            {
                alert('Name cannot be blank')
            }

                    else
                if ($("#ctl00_ContentPlaceHolder1_hdn").val() != "") {
                            $.ajax({
                                type: "POST",
                                dataType: "json",
                                url: "Test.aspx/Update",
                                contentType: "application/json; charset=utf-8",
                                data: '{UserID:"' + $("#ctl00_ContentPlaceHolder1_hdn").val() + '",UserName:"' + UserName + '",Password:"' + Password + '",Name:"' + Name + '",RoleID:"' + Role + '",Status:"' + Status +'"}',
                                success: function (data) {

                                    if (data.d.length > 0) {
                                        alert(data.d);
                                    }
                                    else {
                                        location.reload();
                                    }
                                },

                                error: function (responce) {
                                    alert(responce.d);
                                }
                            })
                        }
                        else {
                            $.ajax({
                                type: "POST",
                                url: "Test.aspx/Insert",
                                dataType: "json",
                                contentType: "application/json; charset=utf-8",
                                data: '{UserName:"' + UserName + '",Password:"' + Password + '",Name:"' + Name + '",RoleID:"' + Role + '",Status:"' + Status + '"}',
                                success: function (data) {
                                    if (data.d.length > 0) {
                                        alert(data.d);
                                    }
                                    else {
                                        location.reload();
                                    }
                                },
                                error: function (responce) {

                                    alert(responce.text);
                                }


                            });
                        }
        }




       

        // DeleteRecord
        function DeleteRecord(UserID) {
            var v = confirm('Are You Sure to Delete the Record!!!!');
            if (v == true) {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "Test.aspx/Delete",
                    contentType: "application/json; charset=utf-8",
                    data: '{UserID:' + UserID + '}',
                    success: function (data) {
                        if (data.d.length > 0) {
                            alert(data.d);
                        }
                        else {
                            location.reload();
                        }
                    },
                    error: function (responce) {
                        alert(responce.d);
                    }
                });
            }
          }
          function loaddata() {
              $.ajax({
                  type: "POST",
                  dataType: "json",
                  url: "ViewItemExpense.aspx/FillData",
                  contentType: "application/json; charset=utf-8",
                  data: "{}",
                  success: onLoadsuccess,
                  error: function (responce) {
                      alert(responce);
                  }
              });
          }
          function onLoadsuccess(responce) {
              var xmldoc = $.parseXML(responce.d);
              var xml = $(xmldoc);
              var user = xml.find("Table");
              var table = $('#demo-datatables-fixedheader-1').DataTable();
              var count = 0;
              user.each(function () {
                  count = count + 1;
                  var Users = $(this);
                  table.row.add([count,Users.find("UserName").text(),
                      Users.find("Password").text(),
                      Users.find("Name").text(),
                      Users.find("RoleID").text(),
                      Users.find("Status").text(),
                      '<a href="#" class="icon icon-pencil" onclick="EditRecord(' + Users.find("UserID").text() + ')"></a>&ensp;|&ensp;' +
                      '<a href="#" class="icon icon-trash" style="color: red" onclick="DeleteRecord(' + Users.find("UserID").text()+')"></a>'
                  ]);
                  table.draw(false);

              });
          }
        //EditRecord
        function EditRecord(UserID) {


            $.ajax({
                type: "POST",
                dataType: "json",
                url: "Test.aspx/Edit",
                contentType: "application/json; charset=utf-8",
                data: '{UserID:' + UserID + '}',
                success: OnEDSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (responce) {
                    alert(responce.d);
                }
            })

        }

        function OnEDSuccess(response) {
            openModel();
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var User = xml.find("Table");
            User.each(function () {
                var User = $(this);
                $("#ctl00_ContentPlaceHolder1_hdn").val(User.find("UserID").text());
                $("#ctl00_ContentPlaceHolder1_txtUserName").val(User.find("UserName").text());
                $("#ctl00_ContentPlaceHolder1_txtPassword").val(User.find("Password").text());
                $("#ctl00_ContentPlaceHolder1_txtName").val(User.find("Name").text());
                $("#ctl00_ContentPlaceHolder1_ddlRole").val(User.find("RoleID").text());
                $("#ctl00_ContentPlaceHolder1_ddlStatus").val(User.find("Status").text());
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="layout-content">
        <div class="layout-content-body">
            <div class="title-bar">
            </div>
            <div class="row gutter-xs">
                <div class="col-xs-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="card-actions">
                                <button style="float:right;margin-top: -7px;" class="btn btn-primary" data-toggle="modal" data-target="#modalFlipInY" type="button">Add New</button>
                            </div>
                            <h4>Test</h4>
                        </div>
                        <div class="card-body">
                            
                            <asp:Label runat="server" ID="lblMessage"></asp:Label>


                            <table id="demo-datatables-fixedheader-1" class="table table-hover table-striped table-nowrap dataTable" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        <th>SNO#</th>
                                        <th>User Name</th>
                                        <th>Password</th>
                                        <th>Name </th>
                                        <th>Role</th>
                                        <th>Status</th>
                                        <th>Action(s)</th>
                                    </tr>
                                </thead>
                                <tbody>
                                   <%-- <asp:Repeater runat="server" ID="RptShow">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Container.ItemIndex+1 %></td>
                                                <td><%#Eval("UserName")%></td>
                                                <td><%#Eval("Password")%></td>
                                                <td><%#Eval("Name")%></td>
                                                <td><%#Eval("RoleID")%></td>
                                                <td><%#Eval("Status")%></td>
                                                <td><a href="#" class="icon icon-pencil" onclick="EditRecord('<%#Eval("UserID") %>')"></a>&ensp;|&ensp;
                                                    <a href="#" class="icon icon-trash" style="color: red" onclick="DeleteRecord('<%#Eval("UserID") %>')"></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>--%>

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
                    <h3 class="txtwhite">Add User</h3>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <asp:HiddenField runat="server" ID="hdn" />
                            <label class="txtwhite">User Name:</label>
                            <asp:TextBox runat="server" ID="txtUserName" AutoComplete="off" CssClass="form-control"></asp:TextBox>
                          <%--  <input type="text" id="UserName" class="form-control" />--%>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <label class="txtwhite">Password:</label>
                            <asp:TextBox runat="server" ID="txtPassword" AutoComplete="off" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <label class="txtwhite">Name:</label>
                            <asp:TextBox runat="server" ID="txtName" onkeyup="IS_aLPHA(this);"  CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <label class="txtwhite">Role:</label>
                            <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <label class="txtwhite">Status:</label>
                            <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">InActive</asp:ListItem>
                            </asp:DropDownList>
                        </div>
 
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="m-t-lg">
                        <button class="btn btn-success" type="button" onclick="  UpdateorSaveData();">Save</button>
                        <button class="btn btn-default" data-dismiss="modal" type="button" onclick="clearAll();">Cancel</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

