<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="TypeManagement.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.TypeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="grdtype" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="maNganhNghe" HeaderText="Mã ngành nghề" />
            <asp:BoundField DataField="tenNganhNghe" HeaderText="Tên ngành nghề" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server" Text="Xóa" ID="btnxoa" OnClientClick="return confirm('Bạn chắc chắn muốn xóa?')" CommandArgument='<%#Bind("maNganhNghe")%>' OnCommand="btnxoa_Click" CommandName="xoa"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" Text="Thêm" ID="btnthem" OnClick="btnthem_Click"/>
    <asp:TextBox runat="server" ID="txttennn" />
    <asp:Button runat="server" Text="Xác nhận" ID="btnxacnhan" OnClick="btnxacnhan_Click"/>
 </asp:Content>
