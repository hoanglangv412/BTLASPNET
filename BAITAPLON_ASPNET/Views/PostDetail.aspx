<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.PostDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
            margin-top:80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tblDetail" CssClass="table table-striped table-dark" Width="81%">
        <asp:TableRow>
            <asp:TableCell>Mã bài đăng: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblmabaidang" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mã nhà tuyển dụng: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblmantd" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Tiêu đề: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbltieude" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Vị trí công việc: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblvitri" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mã ngành nghề: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblmann" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Số lượng tuyển: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblslt" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mức lương: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblml" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Số điện thoại: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblsdt" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Địa chỉ: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lbldiachi"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
