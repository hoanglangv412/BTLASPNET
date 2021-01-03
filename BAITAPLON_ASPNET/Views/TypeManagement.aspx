<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="TypeManagement.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.TypeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            background-color: #f4e6f7;
        }
        table {
            text-align:center;
            margin: 0 auto;
        }
        #ContentPlaceHolder1_btnthem {
            margin-left: 20%;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="grdtype" AutoGenerateColumns="false" class="table table-striped table-success table-hover" width="90%">
        <Columns>
            <asp:BoundField DataField="maNganhNghe" HeaderText="Mã ngành nghề" />
            <asp:BoundField DataField="tenNganhNghe" HeaderText="Tên ngành nghề" />

            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button runat="server" Class="btn btn-danger" Text="Xóa" ID="btnxoa" OnClientClick="return confirm('Bạn chắc chắn muốn xóa?')" 
                        CommandArgument='<%#Bind("maNganhNghe")%>' OnCommand="btnxoa_Click" CommandName="xoa"/>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" Class="btn btn-success" Text="Thêm" ID="btnthem" OnClick="btnthem_Click"/>
    <asp:TextBox runat="server" ID="txttennn" placeholder="Tên ngành nghề "/> 
    <asp:Button runat="server" Class="btn btn-success" Text="Xác nhận" ID="btnxacnhan" OnClick="btnxacnhan_Click"/>

 </asp:Content>
