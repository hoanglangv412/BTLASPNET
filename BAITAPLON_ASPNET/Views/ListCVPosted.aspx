<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="ListCVPosted.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.ListCVPosted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:GridView ID="grdCVPosted" runat="server" AutoGenerateColumns="false" OnRowCommand="btXoa_Command">
        <Columns>
            <asp:BoundField DataField="maCV" HeaderText="Mã CV" />
             <asp:BoundField DataField="maBaiDang" HeaderText="Mã bài đăng" />
             <asp:BoundField DataField="tieuDe" HeaderText="Tiêu đề" />
             <asp:BoundField DataField="ngayTao" HeaderText="Ngày tạo" />
             <asp:BoundField DataField="duyet" HeaderText="Trạng thái duyệt" />
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button class="btn btn-danger" ID="btXoa" runat="server" Text="Xóa" CommandName="xoa" 
                        CommandArgument='<%#Eval("maCV")+","+ Eval("maBaiDang")%>' OnClientClick="return confirm('Bạn có chắc muốn xóa !')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
