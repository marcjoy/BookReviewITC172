<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <link href="ClassicADO.css" rel="stylesheet" />
    <title>Book Review</title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
        <h1>Authors & Books</h1>
        <hr />
        <p>Select a author from the list to see 
            some of the books they have written.</p>

        <!--a couple of things are important in the drop down list:
            for one, the AutoPostBack property needs to be set
            to true. This makes it go back to the server everytime
            you make a new selection in the list.
            Also you need the OnSelectedIndexChanged method
            to run code when you change the selection
            -->

        <asp:DropDownList  ID="DropDownList1"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        </asp:DropDownList>

       <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
