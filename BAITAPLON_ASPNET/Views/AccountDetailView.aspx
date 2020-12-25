<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="AccountDetailView.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.TaiKhoanDetailView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
            Width: 81%;
            background-color: #454d55;
            color: white;
            margin-top: 80px;
        }
        td{
            border: 1px solid white;
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
        .btnchange{
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 250px;
            height: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tbltaikhoan" CssClass="table table-dark table-sm">
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2">
                <%--anh--%>
                <asp:Image ID="imgavatar" runat="server" CssClass="imgavatar1"/>
                <div class="btnchange">
                    <asp:FileUpload runat="server" ID="iduploadphotos" />
                    <asp:Button ID="btnchangephoto" runat="server" Text="Change" OnClick="btnchangephoto_Click" CssClass="btn btn-primary"/>
                    <asp:Button ID="btnok" runat="server" Text="OK" OnClick="btnok_Click" CssClass="btn btn-primary"/>
                </div>
            </asp:TableHeaderCell>
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
                  <div class="dropdown-menu" style="background-color:#545b62;color:white; padding-left:30px">
                    Nhập mật khẩu cũ: <asp:TextBox ID="txtoldpassword" runat="server" TextMode="Password"/><br />
                    Nhập mật khẩu mới: <asp:TextBox ID="txtnewmatkhau" runat="server" TextMode="Password"/><br />
                    Nhập lại mật khẩu mới: <asp:TextBox ID="txtnewmatkhau2" runat="server" TextMode="Password"/>
                    <asp:Button runat="server" ID="btnagree" text="Xác nhận" CssClass="btn btn-primary" OnClick="btnagree_Click"/>
                  </div>
                </div>
                <asp:Label ID="lblalert" runat="server" ForeColor="Red"/>
                <!-- Split dropright button -->
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>