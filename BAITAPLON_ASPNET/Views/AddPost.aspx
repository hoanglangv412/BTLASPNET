<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.AddPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    table{
            margin: 0 auto;
            margin-top: 80px;
        }
     input,select{
            width: 100%;
        }
     td{
            border: 1px solid white;
        }
     .lbl{
            margin:0 auto;
            color: black;
            width: 300px;
            text-align: center;
     }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Table ID="tbladdbaidang" runat="server" CssClass="table table-striped table-dark" Width="90%">
        <asp:TableRow>
            <asp:TableCell>Mã nhà tuyển dụng: </asp:TableCell>
            <asp:TableCell><asp:Label runat="server" ID="lblmantd" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Tiêu đề: </asp:TableCell>
            <asp:TableCell><asp:TextBox runat="server" ID="txttieude" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Vị trí công việc: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtvitri" />
                <asp:RequiredFieldValidator ID="rtxtvitri" ControlToValidate="txtvitri" ErrorMessage="Bạn chưa nhập vị trí công việc" ForeColor="red" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mã ngành nghề: </asp:TableCell>
            <asp:TableCell><asp:DropDownList runat="server" ID="ddlnganhnghe" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mô tả: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  runat="server" ID="txtmota" />
                <asp:RequiredFieldValidator ID="rtxtmota" ControlToValidate="txtmota" ErrorMessage="Bạn chưa nhập mô tả công việc" ForeColor="red" runat="server"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Số lượng tuyển: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  runat="server" ID="txtsoluongtuyen" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtsoluongtuyen" ValidationExpression="^\d+$" ErrorMessage="Sai định dạng" ForeColor="Red" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Mức lương: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  runat="server" ID="txtmucluong" />
                <asp:RegularExpressionValidator ID="rml" ControlToValidate="txtmucluong" ValidationExpression="^\d+$" ErrorMessage="Sai định dạng" ForeColor="Red" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Số điện thoại: </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox  runat="server" ID="txtsodienthoai" />
                <asp:RegularExpressionValidator ID="rsdt" ControlToValidate="txtsodienthoai" ValidationExpression="\d{10}" ErrorMessage="Số điện là 10 số" ForeColor="Red" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>Địa chỉ: </asp:TableCell>
            <asp:TableCell><asp:TextBox  runat="server" ID="txtdiachi" /></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Button runat="server" ID="btnback" Text="Quay về" PostBackUrl="~/Views/PostManagement.aspx" CssClass="btn btn-danger"/></asp:TableCell>
            <asp:TableCell><asp:Button runat="server" ID="btnadd" Text="Thêm" OnClick="btnadd_Click" CssClass="btn btn-success"/></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <div class="lbl">
        <asp:Label id="lblalert" runat="server"/>
    </div>
</asp:Content>
