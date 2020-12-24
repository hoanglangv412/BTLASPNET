<%@ Page Title="homepage" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BTL_ASPNET_WEBGTVL.Views.BaiDang.Show_DeleteBaiDangView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
            color: white;
        }
        .btnsearchgroup{
              height: 50px;
              width: 100%;
              position: relative;
              top: 40px;
              height:200px;
        }
        .searchcontent{
              margin: 0;
              position: absolute;
              width: 81%;
              top: 12%;
              left: 15%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  //button search group--%>
              <div class="btnsearchgroup">
                  <div class="searchcontent">
                      <asp:DropDownList class="btn btn-secondary dropdown-toggle" ID="ddldiachi" runat="server">
                      <asp:ListItem>Tất cả</asp:ListItem>
                      <asp:ListItem>Cần Thơ</asp:ListItem>
                      <asp:ListItem>Đà Nẵng</asp:ListItem>
                      <asp:ListItem>Hải Phòng</asp:ListItem>
                      <asp:ListItem>Hà Nội</asp:ListItem>
                      <asp:ListItem>Tp. Hồ Chí Minh</asp:ListItem>
                      <asp:ListItem>Thái Bình</asp:ListItem>
                  </asp:DropDownList>
                  <asp:DropDownList class="btn btn-secondary dropdown-toggle" ID="ddlnganhnghe" runat="server"  ondatabound="DDLpositionDataBound"/>
                  <asp:TextBox runat="server" ID="txtsearch" placeholder="Nhập vị trí cần tìm" Width="50%" Height="50px"/>&nbsp;&nbsp;
                  <asp:Button runat="server" ID="btnsearch" text="Tìm" OnClick="btnsearch_Click" CssClass="btn btn-primary"/>&nbsp;&nbsp;
                  </div>
            </div>
   <%-- datalist--%>
    <h4 style="color:white;margin:0 auto;width:300px"><asp:Label runat="server" ID="lblalert"/></h4>
    <asp:DataList ID="dtlbaidang" runat="server" DataKeyField="maBaiDang" RepeatColumns="3" Width="90%" CssClass="table table-dark table-sm">
        <ItemTemplate>
            <%--<div class="cell-content">--%>
                <asp:Table ID="tblbaidang" runat="server" Width="400px" CssClass="tableBaiDang">
                    <asp:TableRow>
                        <asp:TableCell RowSpan="3" Width="40%"><asp:Image ID="imgLogo" Width="150px" Height="100px" runat="server" ImageUrl='<%#"~/Photos/" + Eval("anh") %>'/></asp:TableCell>
                        <asp:TableCell Width="20%">Vị trí:</asp:TableCell>
                        <asp:TableCell Width="40%"><asp:Label ID="Label1" runat="server" Text='<%# Eval("viTriCongVIec") %>'/></asp:TableCell>
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
                        <asp:TableCell><asp:Label ID="Label3" runat="server" Text='<%# Eval("mucLuong") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3" CssClass="cell-lastcell" Width="100%">
                            <a href="PostDetail.aspx?maBaiDang=<%#Eval("maBaiDang")%>">Chi tiết</a> 
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
        </ItemTemplate>
        </asp:DataList>
    <asp:DataList ID="dtlcv" runat="server" DataKeyField="maCV" RepeatColumns="3" Width="90%" CssClass="table table-dark table-sm">
        <ItemTemplate>
                  <asp:Table ID="tblbaidang" runat="server" Width="430px" CssClass="tableBaiDang">
                    <asp:TableRow>
                        <asp:TableCell RowSpan="5" Width="30%"><asp:Image ID="imgLogo" Width="150px" Height="150px" runat="server" ImageUrl='<%#"~/Photos/" + Eval("anhThe") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Width="27%">Họ tên:</asp:TableCell>
                        <asp:TableCell Width="43%"><asp:Label ID="Label2" runat="server" Text='<%# Eval("hoTen") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Địa chỉ:
                        </asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label3" runat="server" Text='<%# Eval("diaChi") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Kinh nghiệm:
                        </asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label4" runat="server" Text='<%# Eval("kinhNghiem") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            Kĩ năng:
                        </asp:TableCell>
                        <asp:TableCell><asp:Label ID="Label5" runat="server" Text='<%# Eval("kyNang") %>'/></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            <a href="CVdetail.aspx?maCV=<%#Eval("maCV")%>">Chi tiết</a> 
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
