﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.PostDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table{
            margin: 0 auto;
            margin-top:80px;
        }
        .divapply{
            width: 90%;
            padding-left: 100px;
        }
        .divadd{
            padding-top: 30px;
            height: 110px;
            width:90%;
            margin: 0 auto;
            margin-bottom:-70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table runat="server" ID="tblDetail" CssClass="table table-striped table-dark" Width="90%">
        <asp:TableRow>
            <asp:TableCell>Mã bài đăng: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblmabaidang" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Mã nhà tuyển dụng: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lblmantd" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Tiêu đề: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lbltieude" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Vị trí công việc: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lblvitri" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Mã ngành nghề: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lblmann" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Số lượng tuyển: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lblslt" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Mức lương: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lblml" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Số điện thoại: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lblsdt" /></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>Địa chỉ: </asp:TableCell><asp:TableCell><asp:Label runat="server" ID="lbldiachi"/></asp:TableCell></asp:TableRow></asp:Table>
    <div class="divapply">
        <asp:Button runat="server" ID="btnshowappliedCV" CssClass="btn btn-success" Text="Danh sách CV đã ứng tuyển" CommandName="detail" OnClick="btnshowappliedCV_Click"/>
        <asp:Button runat="server" ID="btnApply" CssClass="btn btn-success" Text="Nộp CV" OnClick="btnApply_Click"/>
    </div>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="maCV" RepeatColumns="4" Width="90%" CssClass="table table-striped table-dark">
        <ItemTemplate>
            <asp:Image ID="anhLabel" runat="server" ImageUrl='<%#"~/Photos/" + Eval("anhThe") %>' Width="150px" Height="100px" />
            Mã CV: <asp:Label ID="maCVLabel" runat="server" Text='<%# Eval("maCV") %>' /><br />
            Tiêu đề: <asp:Label ID="tieuDeLabel" runat="server" Text='<%# Eval("tieuDe") %>' /><br />
            Kỹ năng: <asp:Label ID="kyNangLabel" runat="server" Text='<%# Eval("kyNang") %>' /><br />
            Kinh nghiệm: <asp:Label ID="kinhNghiemLabel" runat="server" Text='<%# Eval("kinhNghiem") %>' /><br />
            Ngày tạo: <asp:Label ID="ngayTaoLabel" runat="server" Text='<%# Eval("ngayTao") %>'/><br />
            <br />
            <asp:Button runat="server" ID="btnback" CssClass="btn btn-danger" Text="Quay về" PostBackUrl="~/Views/HomePage.aspx"/>
            <asp:Button runat="server" ID="btnSelect" CssClass="btn btn-success" Text="Nộp CV" CommandArgument='<%# Eval("maCV") %>' CommandName="select" OnCommand="btnSelect_Click" />
        </ItemTemplate>
    </asp:DataList>


      <div class="divadd">
        <h5 style="color:white"><asp:Label runat="server" ID="lbltitle"/></h5>
        <h5 style="color:white"><asp:Label runat="server" ID="lblalert" /></h5>
    </div>
    <asp:GridView ID="grdUngtuyen" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark" Width="90%">
        <Columns>
            <asp:BoundField DataField="macv" HeaderText="Mã CV" />
            <asp:BoundField DataField="maBaiDang" HeaderText="Mã bài đăng" />
            <asp:BoundField DataField="ngayUngtuyen" HeaderText="Ngày ứng tuyển" />
            <asp:BoundField DataField="duyet" HeaderText="Duyệt" />
            <asp:TemplateField HeaderText="Chi tiết CV">
                <ItemTemplate>
                    <a href="<%# String.Format("CVdetail.aspx?macv={0}&mabd={1}&duyet={2}", Eval("macv"), Eval("maBaiDang"), Eval("duyet")) %>">Xem chi tiết</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
