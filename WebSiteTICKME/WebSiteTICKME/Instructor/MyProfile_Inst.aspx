﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyProfile_Inst.aspx.cs" Inherits="MyProfile_Inst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
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
    z-index:-1;
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
    <style>
    .circular-button {
        border-radius: 50%;
        overflow: hidden;
        width: 250px; /* adjust the dimensions as needed */
        height: 250px; /* adjust the dimensions as needed */
    }
         .auto-style4 {
            font-size: 15px;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style7 {
            text-align: center;
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
                
                        
             
                       
                      
                 <asp:Image ID="Image1" runat="server" CssClass="circular-button" BorderColor="White" BorderStyle="Solid" BorderWidth="5px" />
                          
                    
                        <br />
              
                  
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="SavePictureButton" runat="server" CssClass="auto-style7" OnClick="SavePictureButton_Click" Text="Save picture" style="height: 29px" />
                       
                       
                      
                        <br />
          <br />
                       
                       
                      
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                      
                <nav>
                    <ul>
                        <li >
                                <div>
                                   
                                    <table>
                                        <tr>
                              <td> <asp:Label ID="NameLabel" runat="server" Text="Name :"></asp:Label></td>
                              <td> <asp:Label ID="NametxtLable" runat="server"  ></asp:Label></td> </tr>
                              
                             <tr> <td> <asp:Label ID="GenderLabel" runat="server" Text="Gender :"></asp:Label></td>
                            
                               <td>  <asp:Label ID="GendertxtLable" runat="server" ></asp:Label></td>
                             </tr> 
                                     
                              
                               <tr> <td> <asp:Label ID="IDLabel" runat="server" Text="ID :"></asp:Label></td>
                             
                                <td> <asp:Label ID="IDtxtLable" runat="server" ></asp:Label></td></tr> 

                               
                                 <tr> <td>   <asp:Label ID="EmailLabel" runat="server" Text="Email :"></asp:Label></td>
                           
                                <td> <asp:Label ID="EmailtxtLable" runat="server"></asp:Label></td></tr> 
                             
                              
                              <tr> <td>    <asp:Label ID="CollegeLabel" runat="server" Text="College :" ></asp:Label></td>
                               
        
                               <td>  <asp:Label ID="CollegetxtLable" runat="server" ></asp:Label></td></tr> 
                              

                                   
 
                              

                               <tr> <td>   <asp:Label ID="SpecializationLabel" runat="server" Text="Specialization :"></asp:Label></td>

                             
                           <td>     <asp:Label ID="SpecializationtxtLable" runat="server" ></asp:Label></td></tr> 



                                     <tr> <td>   <asp:Label ID="Label5" runat="server" Text="Password :"></asp:Label></td>
                            
                             <td>   <asp:Label ID="PasswordtxtLable" runat="server"></asp:Label></td></tr> </table>

                                
                                                        

                               
                               
                                </div>

                               
                        </li>
                    </ul>
                </nav>
                       
                   
           
            
        </div></div></div>
              
<footer class="footer">
	<p class="credits">
   copy; 2023 Tick Me. All rights reserved.</p>
</footer>	
    </form>
</body>
</html>