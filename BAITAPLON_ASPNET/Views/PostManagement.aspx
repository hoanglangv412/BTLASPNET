<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="PostManagement.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.PostManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
            margin-top: 80px;
        }
        td{
            border: 1px solid white;
        }
        .grpadd{
            width: 90%;
            margin:0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="searchGr">
        <p>Tìm kiếm: <asp:TextBox ID="txtSearch" runat="server" placeholder="Nhập bài đăng cần tìm" />
            <asp:Button ID="btSearch" class="btn btn-primary" runat="server" Text="Tìm kiếm" OnClick="btSearch_Click" /> </p>
    
    </div>
    <asp:GridView ID="grdpost" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark" Width="90%">
        <Columns>
            <asp:BoundField DataField="maBaiDang" HeaderText="Mã Bài Đăng" />
            <asp:BoundField DataField="viTriCongViec" HeaderText="Vị trí công việc" />
            <asp:BoundField DataField="maNganhNghe" HeaderText="Mã ngành nghề" />
            <asp:BoundField DataField="soLuongTuyen" HeaderText="Số lượng tuyển" />
            <asp:BoundField DataField="mucLuong" HeaderText="Mức lương" />
            <asp:BoundField DataField="diaChi" HeaderText="Địa chỉ" />
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Xóa" ID="btndelete" CommandArgument='<%#Bind("maBaiDang")%>' CommandName="delete" OnCommand="btndelete_Click" CssClass="btn btn-danger"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Sửa" ID="btnedit" CommandArgument='<%#Bind("maBaiDang")%>' CommandName="edit" OnCommand="btnedit_Click" CssClass="btn btn-success"/>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Danh sách CV ứng tuyển">
                <ItemTemplate>
                    <a href="<%# String.Format("PostDetail.aspx?maBaiDang={0}", Eval("maBaiDang"))%>">Xem</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="grpadd">
            <asp:Button runat="server" Text="Thêm bài đăng" ID="btadd" PostBackUrl="AddPost.aspx" CssClass="btn btn-success"/>
    </div>
</asp:Content>
