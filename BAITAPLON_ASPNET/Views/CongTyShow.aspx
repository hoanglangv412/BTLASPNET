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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="ddlcongty" runat="server" DataKeyField="maNhaTuyenDung" RepeatColumns="4">
        <ItemTemplate>
            maNhaTuyenDung:
            <asp:Label ID="maNhaTuyenDungLabel" runat="server" Text='<%# Eval("maNhaTuyenDung") %>' />
            <br />
            tenNhaTuyenDung:
            <asp:Label ID="tenNhaTuyenDungLabel" runat="server" Text='<%# Eval("tenNhaTuyenDung") %>' />
            <br />
            maTaiKhoan:
            <asp:Label ID="maTaiKhoanLabel" runat="server" Text='<%# Eval("maTaiKhoan") %>' />
            <br />
            gioiThieu:
            <asp:Label ID="gioiThieuLabel" runat="server" Text='<%# Eval("gioiThieu") %>' />
            <br />
            logo:
            <asp:Label ID="logoLabel" runat="server" Text='<%# Eval("logo") %>' />
            <br />
<br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
