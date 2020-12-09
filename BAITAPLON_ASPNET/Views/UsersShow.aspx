<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="UsersShow.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.UsersShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .font-weight-bolder{
            margin-left: 10%;
        }
        table{
            margin: 0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p class="font-weight-bolder"><asp:Label runat="server" ID="txtalert" Text="Loại tài khoản: 0 - Admin, 1 - Nhà Tuyển Dụng, 2 - Người dùng" /></p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="maTaiKhoan" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" class="table table-striped table-dark" width="81%">
        <Columns>
            <asp:BoundField DataField="maTaiKhoan" HeaderText="Mã tài khoản" InsertVisible="False" ReadOnly="True" SortExpression="maTaiKhoan" />
            <asp:BoundField DataField="tenTaiKhoan" HeaderText="Tên tài khoản" SortExpression="tenTaiKhoan" />
            <asp:BoundField DataField="matKhau" HeaderText="Mật khẩu" SortExpression="matKhau" DataFormatString="**********"/>
            <asp:BoundField DataField="loaiTaiKhoan" HeaderText="Loại tài khoản" SortExpression="loaiTaiKhoan" />
            <asp:BoundField DataField="anh" HeaderText="ảnh" SortExpression="anh"/>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DVVIECLAMConnectionString %>" DeleteCommand="DELETE FROM [TaiKhoan] WHERE [maTaiKhoan] = @maTaiKhoan" InsertCommand="INSERT INTO [TaiKhoan] ([tenTaiKhoan], [matKhau], [loaiTaiKhoan], [anh]) VALUES (@tenTaiKhoan, @matKhau, @loaiTaiKhoan, @anh)" SelectCommand="SELECT * FROM [TaiKhoan]" UpdateCommand="UPDATE [TaiKhoan] SET [tenTaiKhoan] = @tenTaiKhoan, [matKhau] = @matKhau, [loaiTaiKhoan] = @loaiTaiKhoan, [anh] = @anh WHERE [maTaiKhoan] = @maTaiKhoan">
        <DeleteParameters>
            <asp:Parameter Name="maTaiKhoan" Type="Int32" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
