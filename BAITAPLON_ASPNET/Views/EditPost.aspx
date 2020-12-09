﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.EditPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="tbleditbaidang" runat="server">
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
            <asp:TableCell><asp:TextBox runat="server" ID="txttieude" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Vị trí công việc: </asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txtvitri" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mã ngành nghề: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtmanganhnghe" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mô tả: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtmota" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Số lượng tuyển: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtsoluongtuyen" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mức lương: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtmucluong" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Số điện thoại: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtsodienthoai" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Địa chỉ: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtdiachi" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Button runat="server" ID="btnedit" Text="Cập nhật" OnClick="btnedit_Click"/></asp:TableCell>
            <asp:TableCell><asp:Button runat="server" ID="btnback" Text="Hủy" PostBackUrl="~/Views/PostManagement.aspx"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
            <asp:Label id="lblalert" runat="server"/>
</asp:Content>