<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="The_magic_of_NIC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row d-flex justify-content-center align-items-center h-100">
              <div class="form-group">
                <asp:Label runat="server">Enter your NIC number</asp:Label>
                <asp:TextBox runat="server" type="text" ID="Txt_nicNumber" placeholder="123456789V/111123456789" CssClass="form-control"/>
                  <asp:RequiredFieldValidator runat="server"  ControlToValidate="Txt_nicNumber" Display="Dynamic" ErrorMessage="Please Input NIC" CssClass="text-danger"/>
              </div> 
        </div>
        <div class="row d-flex justify-content-center align-items-center h-100">
              <div class="form-group">
                <asp:Button runat="server"  type="submit" ID="Cmd_find" Text="Find" class="btn btn-success" OnClick="Cmd_find_Click"/>
              </div>
        </div>
            <div class="row d-flex justify-content-center align-items-center">
              <div>
                  <asp:Label runat="server" ID="Lbl_error" CssClass="text-danger"/>
              </div>
            </div>
            <div class="row d-flex justify-content-center align-items-center">
                <div>
                    <asp:Label runat="server" ID="Lbl_birthDay" CssClass="text-danger"/>
                    <asp:Label runat="server" ID="Lbl_gender" CssClass="text-danger"/>
                </div>
            </div>
    </div>

</asp:Content>
