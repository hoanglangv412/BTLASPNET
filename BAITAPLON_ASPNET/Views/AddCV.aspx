﻿<%@ Page Title="Thêm CV" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="AddCV.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.CVManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f4e6f7;
        }

        #tbAdd, h2 {
            text-align: center;
            margin: 30px auto;
            width: 700px;
            position: relative;
        }

        input {
            width: 500px;
        }

        .child {
            position: absolute;
            left: 100%;
            top: 170px;
        }

        .img {
            margin-top: 30px;
            margin-left: 29%;
        }

        #ContentPlaceHolder1_btAdd {
            width: 100px;
            margin-left: 30%;
        }
        #btnlogout, #ContentPlaceHolder1_btBack
        {
            width:100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>CV ADD</h2>
        <div class="img">
            <p>
                <asp:Label ID="lbAnhThe" runat="server" Text="Ảnh Thẻ" />
                <asp:Image ID="imgCV" runat="server" ImageUrl='<%#"~/Photos/"+ Eval("anhThe") %>' Width="100" /><br />
                <asp:FileUpload ID="browserAvatar" runat="server" />
            </p>
        </div>

        <table id="tbAdd" class="table table-info">

            <tr>
                <td>Tiêu đề:</td>
                <td>
                    <asp:TextBox ID="txtTieuDe" runat="server" /></td>
            </tr>
            <tr>
                <td>Họ tên: </td>
                <td>
                    <asp:TextBox ID="txtHoten" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày sinh: </td>
                <td>
                    <asp:TextBox ID="txtNgaySinh" runat="server"></asp:TextBox>
                    <div class="child">
                        <asp:ImageButton ID="imgbtDate" runat="server" ImageUrl="~/Photos/kaikaikiki.jpg" ImageAlign="AbsBottom" Width="30px" Height="30px" OnClick="imgbtDate_Click" />
                        <asp:Calendar ID="clDate" runat="server" Height="260px" Width="280px" OnSelectionChanged="clDate_SelectionChanged" OnDayRender="clDate_DayRender" BackColor="#CC99FF" />
                    </div>
            </tr>

            <tr>
                <td>Giới tính: </td>
                <td>
                    <asp:DropDownList ID="drGIoitinh" runat="server" Size="1" Style="width: 200px; margin-right: 300px;">
                        <asp:ListItem Value="nam">Nam</asp:ListItem>
                        <asp:ListItem Value="nữ">Nữ</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Địa chỉ: </td>
                <td>
                    <asp:TextBox ID="txtDaChi" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Số điện thoại: </td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email: </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Học vấn: </td>
                <td>
                    <asp:TextBox ID="txtHocVan" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Kinh nghiệm: </td>
                <td>
                    <asp:TextBox ID="txtKinhNghiem" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Kỹ năng: </td>
                <td>
                    <asp:TextBox ID="txtKyNang" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Thông tin thêm: </td>
                <td>
                    <asp:TextBox ID="txtThongtinThem" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Ngày tạo: </td>
                <td>
                    <asp:TextBox ID="txtNgayTao" runat="server" Enabled="false"></asp:TextBox></td>
            </tr>

        </table>
        <asp:Button ID="btAdd" runat="server" Text="Thêm" OnClick="btAdd_Click" class="btn btn-success"/>
        <asp:Button ID="btBack" runat="server" Text="Quay về" PostBackUrl="~/Views/ListCV.aspx"  class="btn btn-light"/>
    </div>
</asp:Content>
