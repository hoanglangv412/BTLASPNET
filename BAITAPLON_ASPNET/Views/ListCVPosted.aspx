<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="ListCVPosted.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.ListCVPosted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #ContentPlaceHolder1_grdCVPosted
        {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:GridView ID="grdCVPosted" runat="server" AutoGenerateColumns="false" OnRowCommand="btXoa_Command" class="table table-striped table-success table-hover">
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
    <asp:Button ID="btBack" class="btn btn-light" style="width:100px;" runat="server" Text="Quay lại" PostBackUrl="~/Views/ListCV.aspx" />
</asp:Content>
