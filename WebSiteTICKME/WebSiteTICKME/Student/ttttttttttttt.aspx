<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ttttttttttttt.aspx.cs" Inherits="Student_ttttttttttttt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function refreshImage() {
            var imgElement = document.getElementById("imgPhoto");
            var currentSrc = imgElement.src;
            imgElement.src = currentSrc.split('?')[0] + "?counter=" + Date.now();
        }
        setInterval(refreshImage, 5000); // Refresh the image every 5 seconds (adjust as needed)
    </script>
<style>
  body {
    background: #222;
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
    padding: 60px 0;
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
         <nav>
                    <br />
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:Label ID="Label2" runat="server" ></asp:Label>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    
                   <ContentTemplate>
                      
                                               
                       <asp:Timer ID="Timer2" runat="server" Interval="1000" OnTick="Timer2_Tick">
                       </asp:Timer>
                      
                                               
                       <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
                      
                                               
                    <asp:Image ID="Image2" runat="server" Height="191px" Width="293px" />
                      <div>
            
        </div>

                       <br />

                       <br />
                       <asp:Label ID="Label1" runat="server"></asp:Label>

                       <br />

                       <br />

                   </ContentTemplate>
               </asp:UpdatePanel>
       

         
                    <br />
                </nav>
                   </div>
                    <ul>
            
                        <li>
       
                            <br /></li>
        
        
        
    
                       
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
