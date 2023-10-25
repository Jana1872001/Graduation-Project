<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Student_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Abcense Details</title>
    <style>
  body {
    background: #fff;
    color: #FFF;
  }

  .skewed-bg {
    background: #00B285;
    padding: 5px 0;
    transform: skew(0deg, -10deg);
    margin-top: -250px;
    z-index=-1;
  }

  .skewed-bg .content {
    transform: skew(0deg, 10deg);
    text-align: center;
  }

  .skewed-bg .content .title {
    padding-top: 100px;
    font-weight: normal;
  }

  .skewed-bg .content .text {
    width: 60%;
    margin: 25px auto;
    color: lighten(#00B285, 55);
  }

  .footer {
    padding-top: 300px;
  }

  .footer .credits {
    text-align: center;
    color: #666;
  }

  .footer .credits .link {
    color: #00B285;
    text-decoration: none;
  }

  @import url(https://fonts.googleapis.com/css?family=Open+Sans);

  nav {
    max-width: 960px;
    mask-image: linear-gradient(
      90deg,
      rgba(255, 255, 255, 0) 0%,
      #ffffff 25%,
      #ffffff 75%,
      rgba(255, 255, 255, 0) 100%
    );
    margin: 0 auto;
    padding: 20px 0;
  }

  nav ul {
    text-align: center;
    background: linear-gradient(
      90deg,
      rgba(255, 255, 255, 0) 0%,
      rgba(255, 255, 255, 0.2) 25%,
      rgba(255, 255, 255, 0.2) 75%,
      rgba(255, 255, 255, 0) 100%
    );
    box-shadow: 0 0 25px rgba(0, 0, 0, 0.1), inset 0 0 1px rgba(255, 255, 255, 0.6);
  }

  nav ul li {
    display: inline-block;
  }

  nav ul li a {
    padding: 18px;
    font-family: "Open Sans";
    text-transform: uppercase;
    color: #fff;
    font-size: 18px;
    text-decoration: none;
    display: block;
  }

  nav ul li a:hover {
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1), inset 0 0 1px rgba(255, 255, 255, 0.6);
    background: rgba(255, 255, 255, 0.1);
    color: rgba(0, 35, 122, 0.7);
  }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="skewed-bg">
            <div class="content">
             
                <br />                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
<br />                <br />
                <br />
                <br />
                <br />
                <br />
                <br />

	 <nav>  <div>
       <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Tick.png" />
         <nav>
                    <ul>
                        <li>
                            <a href="http://localhost:52201/Student/HomePage.aspx">Home</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Student/MyProfile.aspx">Profile</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Student/ScanQr.aspx">Scan Qr</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Student/Contact_Us.aspx">Contact</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Student/Login.aspx">Logout</a>
                        </li>
                    </ul>
                </nav>
                   </div>
 <div>
                <nav>
                    <ul>
                        <li>
		
            <br />  <asp:DropDownList ID="DropDownList1" AppendDataBoundItems="true" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" Height="22px" Width="215px">  
    <asp:ListItem Text="(Select subject)" Value="" />   
   
</asp:DropDownList>
<br /><br /><strong><asp:Label ID="Label1" runat="server" CssClass="auto-style3"></asp:Label>
                            </strong>
            <br /><br />
                            <strong><span class="auto-style3">
                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                            <br /><br />
                             <asp:Label ID="Label3" runat="server" ></asp:Label>
                             </span></strong>
                            <br /><br />
                            <strong>
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>

                            <br /><br />
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                             </strong>
                             <nav>
                    <ul>
                        <li class="auto-style4">
		
            <asp:GridView ID="GridView2" runat="server"  CssClass="auto-style1" AutoGenerateColumns="False" Height="22px" style="margin-left: 0px; font-size: 20px;" Width="600px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField  DataField="Status" HeaderText="Sataus" />

                    <asp:BoundField DataField="dat" HeaderText="Date"  DataFormatString="{0:dd-MM-yyyy}" />
                </Columns>
                
            </asp:GridView>
                              </li>
                    </ul>
                </nav>
                            </li>
                    </ul>
                </nav>
</div></div>
  </div>
          
<footer class="footer">
	<p class="credits">
    Pen by Jose L Pimienta 
    <a class="link" href="https://twitter.com/pipozoft">@pipozoft</a>
  </p>
</footer>
	

    </form>
</body>
</html>
