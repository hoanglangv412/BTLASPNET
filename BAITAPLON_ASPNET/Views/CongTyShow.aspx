<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="CongTyShow.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.CongTyShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        td{
            width:27%;
        }
        table{
            margin: 0 auto;
            margin-top: 80px;
        }
        #Image2{
            float:left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="ddlcongty" runat="server" DataKeyField="maNhaTuyenDung" RepeatColumns="4" CssClass="table table-striped table-dark" Width="90%">
        <ItemTemplate>
            <asp:Image ID="Image2" runat="server" ImageUrl='<%#"~/Photos/" + Eval("logo") %>' Width="150px" Height="100px"/>
            <div class="divinfo">
                Mã nhà tuyển dụng: 
                <asp:Label ID="maNhaTuyenDungLabel" runat="server" Text='<%# Eval("maNhaTuyenDung") %>' />
                <br />
                Tên nhà tuyển dụng: 
                <asp:Label ID="tenNhaTuyenDungLabel" runat="server" Text='<%# Eval("tenNhaTuyenDung") %>' />
                <br />
                Mã tài khoản: 
                <asp:Label ID="maTaiKhoanLabel" runat="server" Text='<%# Eval("maTaiKhoan") %>' />
                <br />
                Giới thiệu: 
                <asp:Label ID="gioiThieuLabel" runat="server" Text='<%# Eval("gioiThieu") %>' />
            </div>
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
