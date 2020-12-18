<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="PostManagement.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.PostManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #grdpost{
            margin: 0 auto;
            margin-top: 80px;
        }
        .divadd{
            width:90%;
        }
        td{
            border: 1px solid white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdpost" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark" Width="90%">
        <Columns>
            <asp:BoundField DataField="maBaiDang" HeaderText="Mã Bài Đăng" />
            <asp:BoundField DataField="tieuDe" HeaderText="Tiêu đề" />
            <asp:BoundField DataField="viTriCongViec" HeaderText="Vị trí công việc" />
            <asp:BoundField DataField="maNganhNghe" HeaderText="Mã ngành nghề" />
            <asp:BoundField DataField="moTa" HeaderText="Mô tả" />
            <asp:BoundField DataField="soLuongTuyen" HeaderText="Số lượng tuyển" />
            <asp:BoundField DataField="mucLuong" HeaderText="Mức lương" />
            <asp:BoundField DataField="soDienThoai" HeaderText="Số điện thoại" />
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
              <asp:TemplateField HeaderText="Chi tiết">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Danh sách CV đã ứng tuyển" ID="btnshowdetail" CommandArgument='<%#Bind("maBaiDang")%>' CommandName="detail" OnCommand="btnshowdetail_Click" CssClass="btn btn-info"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="divadd">
        <asp:Button runat="server" Text="Thêm bài đăng" ID="btadd" PostBackUrl="AddPost.aspx" CssClass="btn btn-success"/><br /><br /><br />
        <h5 style="color:white"><asp:Label runat="server" ID="lbltitle"/></h5>
    </div>
    <asp:GridView ID="grdUngtuyen" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark" Width="90%">
        <Columns>
            <asp:BoundField DataField="macv" HeaderText="Mã CV" />
            <asp:BoundField DataField="ngayUngtuyen" HeaderText="Ngày ứng tuyển" />
            <asp:BoundField DataField="duyet" HeaderText="Duyệt" />
            <asp:TemplateField HeaderText="Duyệt">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Duyệt" CssClass="btn btn-success" ID="btnduyet" />
                    <asp:Button runat="server" Text="Đã duyệt" CssClass="btn btn-block" ID="btndaduyet"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chi tiết CV">
                <ItemTemplate>
                    <a href="<%# String.Format("CVdetail.aspx?macv={0}", Eval("macv")) %>">Xem chi tiết</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
