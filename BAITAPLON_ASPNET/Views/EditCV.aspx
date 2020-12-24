<%@ Page Title="editcv" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="EditCV.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.EditCV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #tbEdit {
                margin-left: 200px;

                 }



    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table id="tbEdit">
            <tr>
                <td>Mã CV:</td>
                <td><asp:TextBox ID="txtMaCV" runat="server" Enabled="false"/></td>
            </tr>
             <tr>
                <td>Tiêu đề:</td>
                <td><asp:TextBox ID="txtTieuDe" runat="server"/></td>
            </tr>
            <tr>
                <td>Họ tên: </td>
                <td><asp:TextBox id="txtHoten" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Ngày sinh: </td>
                <td><asp:TextBox id="txtNgaySinh" runat="server"></asp:TextBox></td>
                 <td><asp:ImageButton ID="imgbtDate" runat="server" ImageUrl="~/Photos/kaikaikiki.jpg" ImageAlign="AbsBottom" Width="30px" Height="30px" OnClick="imgbtDate_Click"/>
                     <asp:Calendar ID="clDate" runat="server" OnSelectionChanged="clDate_SelectionChanged" OnDayRender="clDate_DayRender"/>
                 </td>              
            </tr>

             <tr>
                <td>Giới tính: </td>
                <td><asp:TextBox id="txtGioiTinh" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Địa chỉ: </td>
                <td><asp:TextBox id="txtDaChi" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Số điện thoại: </td>
                <td><asp:TextBox id="txtSDT" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Email: </td>
                <td><asp:TextBox id="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Học vấn: </td>
                <td><asp:TextBox id="txtHocVan" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Kinh nghiệm: </td>
                <td><asp:TextBox id="txtKinhNghiem" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Kỹ năng: </td>
                <td><asp:TextBox id="txtKyNang" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Thông tin thêm: </td>
                <td><asp:TextBox id="txtThongtinThem" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td>Ngày tạo: </td>
                <td><asp:TextBox id="txtNgayTao" runat="server"></asp:TextBox></td>
            </tr>

        </table>



        <p><asp:Label ID="lbAnhThe" runat="server" Text="Ảnh Thẻ"/>
            <asp:Image ID="imgCV" runat="server"  ImageUrl='<%#"~/Photos/"+ Eval("anhThe") %>' Width="100"/><br />
            <asp:FileUpload ID="browserAvatar" runat="server" />
        </p>
        <asp:Button ID="btEdit" runat="server" Text="Sửa" OnClick="btEdit_Click" />

        </div>
</asp:Content>
