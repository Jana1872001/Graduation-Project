<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Connect.aspx.cs" Inherits="Connect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
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

	  <div>
       <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Tick.png" />
            <div>
                <nav>
                    <ul>
                        <li>
                            <a href="http://localhost:52201/Instructor/Instructor_profile_page.aspx">Home</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Instructor/MyProfile_Inst.aspx">Profile</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Instructor/QR_code.aspx">Generate Qr</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Instructor/Connect.aspx">Contact</a>
                        </li>
                        <li>
                            <a href="http://localhost:52201/Instructor/login.aspx">Logout</a>
                        </li>
                    </ul>
                </nav>
                </div>
                <div>
                <nav>
                    <ul>
                        <li>
            <br />
 To:&nbsp; <asp:TextBox ID="SubjectTextBox0" runat="server" BorderColor="Black" style="margin-left: 14px" Width="585px" Enabled="False">tickme040@gmail.com</asp:TextBox>
            <br />
            <br />
Subject:<asp:TextBox ID="SubjectTextBox" runat="server" BorderColor="Black" style="margin-left: 14px" Width="585px"></asp:TextBox>
            <br />
            <br />
            <br />
<br />
       Message:&nbsp; <asp:TextBox ID="MsgTextBox" runat="server" Height="208px" Width="586px" BorderColor="Black" CssClass="auto-style1"></asp:TextBox>
           <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
<br />
            <br />
<asp:Button ID="SendButton" runat="server" style="margin-left: 35px" Text="Send" OnClick="SendButton_Click" Height="28px" Width="265px" />
        <br />  <br />   </li>
                    </ul>
                </nav>
                </div>
       <footer class="footer">
	<p class="credits">
    

  </p>
</footer><div class="skewed-bg">
	
</div>  
           </div></div></div>       
<footer class="footer">
	<p class="credits">
   copy; 2023 Tick Me. All rights reserved.  </p>
</footer>	    
    </form>
</body>
</html>
