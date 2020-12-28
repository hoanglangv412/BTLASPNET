<%@ Page Title="CV Management" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" AutoEventWireup="true" CodeBehind="ListCV.aspx.cs" Inherits="BAITAPLON_ASPNET.Views.ListCV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            background-color:#f4e6f7;
        }
        h1{
            text-align:center;
        }
        table {
            text-align:center;
            margin: 0 auto;
        }
        #searchGr {
            margin-left: 5%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="searchGr">
        <h2 style="font-size:larger">Tìm kiếm:</h2> 
            <asp:TextBox ID="txtSearch" runat="server" Width="300px" placeholder="Nhập tiêu đề cần tìm" />
            <asp:Button ID="btSearch" class="btn btn-primary" runat="server" Text="Tìm kiếm" OnClick="btSearch_Click" />
    
    </div>
    <h1>MY CV</h1>
    <asp:GridView ID="grdCV" runat="server" AutoGenerateColumns="false" class="table table-striped table-success table-hover" width="90%">
        <Columns>
            <asp:BoundField DataField="maCV" HeaderText="Mã CV" />
            <asp:BoundField DataField="tieuDe"   HeaderText="Tiêu đề" />
            <asp:BoundField DataField="ngayTao" HeaderText="Ngày tạo" DataFormatString="{0:MM/dd/yyyy}" />
            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button class="btn btn-danger"  ID="btDel" runat="server" CommandName="xoa" CommandArgument='<%#Bind("maCV") %>' 
                        Text="Xóa" OnCommand="Xoa_Click" OnClientClick="return confirm('Bạn có chắc muốn xóa!')" /> 
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Sửa">
                <ItemTemplate>
                    <asp:Button class="btn btn-warning" ID="btEdit" runat="server" CommandName="sua" CommandArgument='<%#Bind("maCV") %>' 
                        Text="Sửa" OnCommand="Sua_Click" /> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Xem">
                 <ItemTemplate>
                    <a href="<%# String.Format("CVdetail.aspx?macv={0}", Eval("macv")) %>">Xem chi tiết</a>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>   
    </asp:GridView>
    <asp:Button class="btn btn-success" style="margin-left: 5%;" ID="btAddCV" runat="server"
        PostBackUrl="~/Views/AddCV.aspx" Text="Tạo CV mới"/>
    <asp:Button class="btn btn-success" ID="btCVPosted" runat="server"
        PostBackUrl="~/Views/ListCVPosted.aspx" Text="DS CV ứng tuyển"/>


</asp:Content>
