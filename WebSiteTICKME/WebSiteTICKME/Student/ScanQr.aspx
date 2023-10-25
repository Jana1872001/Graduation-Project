<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScanQr.aspx.cs" Inherits="Student_ScanQr" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Scan QR code</title>
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
    <style>
    
.scanner-content {
  position: relative;
  margin-top: 32px;
  max-width: 300px;
  margin: 32px auto;
}

.scanner-content .qr-preview > div {
  background-color: var(--bg-color);
  width: 250px;
  height: 250px;
  border-radius: 4px;
  margin: auto;
  position: relative;
  overflow: hidden;
}

.scanner-content .qr-preview video {
  height: 100%;
  -o-object-fit: cover;
     object-fit: cover;
  width: 100%;
}

.scanner-content .qr-preview:after {
  content: '';
  background-image: url("data:image/svg+xml,%3Csvg width='213' height='219' fill='none' xmlns='http://www.w3.org/2000/svg'%3E%3Cg opacity='.3' stroke='%23fff' stroke-width='1.5'%3E%3Cpath d='M1 181V218H38M212 181V218H175M1 38V1H38M212 38V1H175'/%3E%3C/g%3E%3C/svg%3E");
  position: absolute;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  background-position: center;
  background-repeat: no-repeat;
  z-index: 9;
}

.scanner-bar {
  -webkit-animation: scan 2s linear alternate infinite;
          animation: scan 2s linear alternate infinite;
  background-color: #fff;
  top: 0;
  box-shadow: 0 0 15px #fff;
  height: 2px;
  position: absolute;
  width: 100%;
  z-index: 99;
}

@-webkit-keyframes scan {
  0% {
    top: 0;
  }
  100% {
    top: 100%;
  }
}

@keyframes scan {
  0% {
    top: 0;
  }
  100% {
    top: 100%;
  }
}

    </style>
    <script src="JavaScript2.js"></script>
    <script src="JavaScript3.js"></script>
    
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
                    <ul>
            
            <li>
                  
     <div>

      

      </li>
                  
                             <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>

                              <asp:Label ID="Label5" runat="server"  Visible="False"></asp:Label>
                        
                                                      <asp:Label ID="Label7" runat="server"  Visible="False"></asp:Label>

               <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>

               <div>   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
                       <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick1" Interval="1000"></asp:Timer>
                       <strong>
                        <asp:Label ID="Label4" runat="server" Text="Select Subject" CssClass="auto-style2"></asp:Label>
                            
                        </strong>
<br />
                       <asp:Label ID="Label6" runat="server" ></asp:Label>
                                               <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                                                                                   <asp:Label ID="Label3" runat="server"  Visible="False"></asp:Label>

                       
              

                   </ContentTemplate>
               </asp:UpdatePanel></div>
                          <div class="scanner-content">
  <div class="qr-preview">
    <div id="reader"></div>
  </div>
  <div class="scanner-bar">
      <script>
          function qrFound(qrCode) {
              alert(qrCode);
              document.getElementById('Label1').innerHTML = '<span>' + qrCode + '</span>';
          }

          const html5QrCode = new Html5Qrcode("reader", { fps: 10, qrbox: 250 });

          html5QrCode.start({ facingMode: "environment" }, { fps: 10 }, qrFound)
              .catch(err => {
                  console.log(err);
              });


      </script>
        </div></div>

                <nav>
                    <ul>
                        <li> 
                        <strong>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AutoGenerateColumns="False" CssClass="auto-style3" style="font-size: 20px">
                            <Columns>
                                <asp:BoundField DataField="Course_name" HeaderText="Subject name" />
                                <asp:BoundField DataField="Course_ID"  HeaderText="Subject ID" />
                                <asp:BoundField  DataField="div" HeaderText= "Section" />
                            </Columns>
                        </asp:GridView>
                              </strong>
                            
               
                            </li>
                    </ul>
                </nav>
        

                       


           </div>

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
