<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="CompanyShow.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.CongTyShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
        }
        td{
            width: 50%;
        }
        .alertDiv{
            margin:0 auto;
            width:300px;
            color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:DataList ID="ddlcongty" runat="server" DataKeyField="maNhaTuyenDung" RepeatColumns="2" CssClass="table table-dark table-sm" Width="90%">
            <ItemTemplate>
                  <asp:Table ID="tblcongty" runat="server" Width="100%" CssClass="tableBaiDang">
                        <asp:TableRow>
                            <asp:TableCell RowSpan="3" Width="20%"> <asp:Image ID="Image2" runat="server" ImageUrl='<%#"~/Photos/" + Eval("anh") %>' Width="150px" Height="150px"/></asp:TableCell>
                            <asp:TableCell Width="40%">Mã nhà tuyển dụng:</asp:TableCell>
                            <asp:TableCell Width="40%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("maNhaTuyenDung") %>'/></asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell>Tên nhà tuyển dụng:</asp:TableCell><asp:TableCell><asp:Label ID="Label2" runat="server" Text='<%# Eval("tenNhaTuyenDung") %>'/></asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell>
                                Giới thiệu:
                            </asp:TableCell><asp:TableCell><asp:Label ID="Label3" runat="server" Text='<%# Eval("gioiThieu") %>'/></asp:TableCell></asp:TableRow><asp:TableRow>
                            <asp:TableCell ColumnSpan="3">
                                <asp:Button runat="server" ID="btnshowpost" Text="Danh sách bài đăng" CssClass="btn btn-secondary" CommandArgument='<%#Eval("maNhaTuyenDung")%>' OnCommand="btnshowpost_Click" CommandName="ShowDanhSach"/>                        
                            </asp:TableCell>                                                                                                                                               
                            </asp:TableRow>
                  </asp:Table>
            </ItemTemplate>
        </asp:DataList>
    <div class="alertDiv">
        <h3><asp:Label runat="server" id="lblalert"/></h3>
    </div>
        <asp:DataList ID="dtlbaidang" runat="server" DataKeyField="maBaiDang" RepeatColumns="3" Width="90%" CssClass="table table-dark table-sm">
        <ItemTemplate>
            <%--<div class="cell-content">--%>
                <asp:Table ID="tblbaidang" runat="server" Width="100%" CssClass="tableBaiDang">
                    <asp:TableRow>
                        <asp:TableCell RowSpan="3" Width="20%"><asp:Image ID="imgLogo" Width="150px" Height="150px" runat="server" ImageUrl='<%#"~/Photos/" + Eval("anh") %>'/></asp:TableCell>
                        <asp:TableCell Width="30%">Vị trí:</asp:TableCell>
                        <asp:TableCell Width="50%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("viTriCongVIec") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Công ty:</asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label2" runat="server" Text='<%# Eval("tenNhaTuyenDung") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <svg width="1.5em" height="1.5em" viewBox="0 0 16 16" class="bi bi-cash" fill="currentColor" xmlns="http://www.w3.org/2000/svg" color="Green">
                              <path fill-rule="evenodd" d="M15 4H1v8h14V4zM1 3a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h14a1 1 0 0 0 1-1V4a1 1 0 0 0-1-1H1z"/>
                              <path d="M13 4a2 2 0 0 0 2 2V4h-2zM3 4a2 2 0 0 1-2 2V4h2zm10 8a2 2 0 0 1 2-2v2h-2zM3 12a2 2 0 0 0-2-2v2h2zm7-4a2 2 0 1 1-4 0 2 2 0 0 1 4 0z"/>
                            </svg>
                        </asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label3" runat="server" Text='<%#  string.Format("{0:0000,0 đ}",Eval("mucLuong"))  %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3" CssClass="cell-lastcell" Width="100%">
                            <a href="PostDetail.aspx?maBaiDang=<%#Eval("maBaiDang")%>">Chi tiết</a>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
        </ItemTemplate>
        </asp:DataList>
</asp:Content>