<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Medicines1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="auto-style2">
    <tr>
        <td style="text-align: right; width: 523px; height: 26px"></td>
        <td class="auto-style3"></td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">MEDICINE NAME</td>
        <td style="text-align: left">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td style="text-align: left">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">BATCH NO.</td>
        <td style="text-align: left">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td style="text-align: left">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">EXPIRY DATE</td>
        <td style="text-align: left">
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td style="text-align: left">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px; height: 26px">PURCHASE COST</td>
        <td class="auto-style3" style="text-align: left">
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td style="text-align: left">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">SELL COST</td>
        <td style="margin-left: 80px; text-align: left;">
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Number"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td style="text-align: left">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">QUANTITY (10 per SHEETS)</td>
        <td style="text-align: left">
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Number"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px; height: 26px"></td>
        <td class="auto-style3" style="text-align: left"></td>
    </tr>
    <tr>
        <td style="text-align: left; " colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SUBMIT" />
        </td>
        <td style="text-align: left">
            <asp:Button ID="Button2" runat="server" Text="CLEAR" OnClick="Button2_Click" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; width: 523px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
