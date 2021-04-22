<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio13._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>LABORATORIO#13</h1>
        <p class="lead">Control de la universidad</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:RadioButton ID="RadioButtonStudent" runat="server" Text="Estudiante" AutoPostBack="True" GroupName="GROUP" OnCheckedChanged="RadioButtonStudent_CheckedChanged" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButtonTeacher" runat="server" Text="Profesor" AutoPostBack="True" GroupName="GROUP" OnCheckedChanged="RadioButtonTeacher_CheckedChanged" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadioButtonStaff" runat="server" Text="Personal " AutoPostBack="True" GroupName="GROUP" OnCheckedChanged="RadioButtonStaff_CheckedChanged" />
            <br />
            <br />
            <h2> Universidad </h2>
            <p> 
                <asp:TextBox ID="TextUniversity" runat="server" Height="25px" Width="307px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <h2> Ingreso de Datos </h2>
            <p> 
                <asp:Label ID="LabelName" runat="server" Text="NOMBRE:   "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextName" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelLastname" runat="server" Text="APELLIDO:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextLastname" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelAddress" runat="server" Text="DIRECCIÓN:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextAddress" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelBirth" runat="server" Text="FECHA DE NACIMIENTO:"></asp:Label>
                <asp:Calendar ID="CalendarBirth" runat="server" CssClass="active" TitleFormat="Month">
                    <DayHeaderStyle BackColor="#66CCFF" />
                    <DayStyle Font-Bold="True" />
                </asp:Calendar>
            </p>
            <p> 
                <asp:Label ID="LabelAge" runat="server" CssClass="btn-success" Font-Bold="True" Font-Size="Small" Height="30px" Text="EDAD:" Width="250px"></asp:Label>
            </p>
            <p> 
                <asp:Label ID="LabelCarne" runat="server" Text="CARNÉ:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextID" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelDPI" runat="server" Text="DPI:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextDPI" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelTitle" runat="server" Text="TITULO:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextTitle" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelIGSS" runat="server" Text="IGSS:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextIGSS" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelProfession" runat="server" Text="PROFESIÓN:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextProfession" runat="server" Width="240px"></asp:TextBox>
            </p>
            <p> 
                <asp:Label ID="LabelStar" runat="server" Text="INICIO DE LABORES"></asp:Label>
            </p>
            <p> 
                <asp:Calendar ID="CalendarStart" runat="server"></asp:Calendar>
            </p>
            <p> 
                <asp:Label ID="LabelEnd" runat="server" Text="FIN DE LABORES"></asp:Label>
            </p>
            <p> 
                <asp:Calendar ID="CalendarEnd" runat="server"></asp:Calendar>
            </p>
            <p> 
                <asp:Button ID="ButtonStudent" runat="server" CssClass="btn-danger focus" Font-Bold="True" Height="50px" OnClick="ButtonStudent_Click" Text="Agregar Estudiante" />
                <asp:Button ID="ButtonTeacher" runat="server" CssClass="btn-info" Font-Bold="True" Height="50px" OnClick="ButtonTeacher_Click" Text="Agregar Profesor" />
                <asp:Button ID="ButtonStaff" runat="server" CssClass="btn-success disabled" Font-Bold="True" Height="50px" OnClick="ButtonStaff_Click" Text="Agregar Personal" />
            </p>
            <p> &nbsp;</p>
        </div>
    </div>
</asp:Content>