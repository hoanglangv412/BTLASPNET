<%@ Page Title="homepage" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BTL_ASPNET_WEBGTVL.Views.BaiDang.Show_DeleteBaiDangView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        td{
            width:27%;
            border: 1px solid white;
        }
        table{
            margin: 0 auto;
            margin-top: 80px;
        }
        .cell-content{
            float:right;
            width:60%;
        }
        .btnsearchgroup{
              height: 50px;
              width: 100%;
              position: relative;
              top: 40px;
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
                  <asp:TextBox runat="server" ID="txtsearch" placeholder="Nhập công việc cần tìm" Width="50%" Height="50px"/>&nbsp;&nbsp;
                  <asp:Button runat="server" ID="btnsearch" text="Tìm" OnClick="btnsearch_Click" CssClass="btn btn-primary"/>&nbsp;&nbsp;
                  </div>
            </div>
   <%-- datalist--%>
    <asp:DataList ID="dtlbaidang" runat="server" DataKeyField="maBaiDang" RepeatColumns="3" Width="90%" CssClass="table table-striped table-dark">
        <ItemTemplate>
            <asp:Image ID="imgLogo" Width="150px" Height="100px" runat="server" ImageUrl='<%#"~/Photos/" + Eval("logo") %>'/>
            <div class="cell-content">
                 <h6><asp:Label ID="viTriCongVIecLabel" runat="server" Text='<%# Eval("viTriCongVIec") %>'/> - <asp:Label ID="tieuDeLabel" runat="server" Text='<%# Eval("tieuDe") %>' /></h6>
                <p>Công ty: <asp:Label ID="tenNhaTuyenDungLabel" runat="server" Text='<%# Eval("tenNhaTuyenDung") %>' /></p>
                <p><svg width="1.5em" height="1.5em" viewBox="0 0 16 16" class="bi bi-cash" fill="currentColor" xmlns="http://www.w3.org/2000/svg" color="Green">
                      <path fill-rule="evenodd" d="M15 4H1v8h14V4zM1 3a1 1 0 0 0-1 1v8a1 1 0 0 0 1 1h14a1 1 0 0 0 1-1V4a1 1 0 0 0-1-1H1z"/>
                      <path d="M13 4a2 2 0 0 0 2 2V4h-2zM3 4a2 2 0 0 1-2 2V4h2zm10 8a2 2 0 0 1 2-2v2h-2zM3 12a2 2 0 0 0-2-2v2h2zm7-4a2 2 0 1 1-4 0 2 2 0 0 1 4 0z"/>
                    </svg>
                    <asp:Label ID="mucLuongLabel" runat="server" Text='<%# Eval("mucLuong") %>'/>
                </p>
                <a href="PostDetail.aspx?maBaiDang=<%#Eval("maBaiDang")%>">Chi tiết</a>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
