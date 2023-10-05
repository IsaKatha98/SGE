<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms_CSharp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       
        <div class="row">

            <h1>Hola Mundo </h1>
           

            <h4><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:Label ID="lblValido" runat="server" ForeColor="red"></asp:Label></h4>
            <h5> <asp:Button ID="Button1" runat="server" Text="Ayuda" OnClick="Button1_Click" />
               <asp:Label ID="lblSaludo" runat="server" ></asp:Label></h5>

           
        </div>
    </main>
   
</asp:Content>
