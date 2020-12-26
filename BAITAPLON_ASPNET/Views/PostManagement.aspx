<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="PostManagement.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.PostManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
        }
        td{
            border: 1px solid white;
        }
        .grpadd{
            width: 90%;
            margin:0 auto;
        }
        .btnsearchgroup {
            height: 50px;
            margin: 0 auto;
            width: 90%;
        }
        .alertDiv{
            margin:0 auto;
            width:90%;
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div class="btnsearchgroup">
                  <asp:TextBox runat="server" ID="txtsearch" placeholder="Nhập vị trí cần tìm" Width="50%" Height="50px"/>&nbsp;&nbsp;
                  <asp:Button runat="server" ID="btnsearch" text="Tìm" OnClick="btnsearch_Click" CssClass="btn btn-primary"/>&nbsp;&nbsp;
            </div>
    <div class="alertDiv">
        <asp:Label ID="lblalert" runat="server" />
    </div>
    <asp:GridView ID="grdpost" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark" Width="90%">
        <Columns>
            <asp:BoundField DataField="maBaiDang" HeaderText="Mã Bài Đăng" />
            <asp:BoundField DataField="viTriCongViec" HeaderText="Vị trí công việc" />
            <asp:BoundField DataField="maNganhNghe" HeaderText="Mã ngành nghề" />
            <asp:BoundField DataField="soLuongTuyen" HeaderText="Số lượng tuyển" />
         <%--   <asp:BoundField DataField="mucLuong" HeaderText="Mức lương"/>--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblmucluong" Text='<%#  string.Format("{0:0000,0 đ}",Eval("mucLuong"))  %>' />
                </ItemTemplate>
            </asp:TemplateField>
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
    <div class="alertDiv">
            <asp:Button runat="server" Text="Thêm bài đăng" ID="btadd" PostBackUrl="AddPost.aspx" CssClass="btn btn-success"/>
    </div>
</asp:Content>
