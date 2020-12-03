<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="TaiKhoanDetailView.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.TaiKhoanDetailView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
            Width: 81%;
            background-color: #454d55;
            color: white;
        }
        td{
            border: 2px solid black;
            width: 50%;
        }
        .imgavatar1{
            display: block;
            margin-left: auto;
            margin-right: auto;
            border: 2px solid #007bff;
            border-radius: 40px;
            width:250px;
            height:200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Table runat="server" ID="tbltaikhoan">
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2"><asp:Image ID="imgavatar" runat="server" CssClass="imgavatar1"/></asp:TableHeaderCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><h5>Mã tài khoản: </h5></asp:TableCell>
            <asp:TableCell><asp:Label id="lblmataikhoan" runat="server" CssClass="label1"/></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell><h5>Tên tài khoản: </h5></asp:TableCell><asp:TableCell><asp:Label id="lbltentaikhoan" runat="server" CssClass="label1"/></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <h5>Mật khẩu: </h5>
            </asp:TableCell><asp:TableCell>
                <div class="btn-group dropright">
                  <asp:Label id="lblmatkhau" runat="server" CssClass="label1" Text="**********"/>
                  <button type="button" class="btn btn-secondary dropdown-toggle dropdown-toggle-split" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="margin-left:100px">
                    <span>Đổi mật khẩu</span>
                  </button>
                  <div class="dropdown-menu">
                    Nhập mật khẩu cũ: <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password"/><br />
                    Nhập mật khẩu mới: <asp:TextBox ID="txtnewmatkhau" runat="server" TextMode="Password"/><br />
                    Nhập lại mật khẩu mới: <asp:TextBox ID="txtnewmatkhau2" runat="server" TextMode="Password"/>
                    <asp:Button runat="server" ID="btnagree" text="Xác nhận" CssClass="btn btn-primary" OnClick="btnagree_Click"/>
                  </div>
                </div>
                <asp:Label id="lblalert" runat="server" ForeColor="Red"/>
                <!-- Split dropright button -->
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>