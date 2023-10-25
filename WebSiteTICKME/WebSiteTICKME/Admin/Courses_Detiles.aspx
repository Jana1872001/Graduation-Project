<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Courses_Detiles.aspx.cs" Inherits="Admin_Courses_Detiles" %>

<!DOCTYPE html>

<html  xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Courses Details Page</title>
	<style>
		
		
		table {
			width: 100%;
			margin-top: 20px;
			border-collapse: collapse;
			border-spacing: 0;
		}
		
		table td,
		table th {
			padding: 10px;
			font-size:15px;
			text-align: left;
		}
		
		table th {
			
		}
		
		button {
			padding: 10px 20px;
			
			border: none;
			
			border-radius: 5px;
			cursor: pointer;
			transition: background-color 0.3s ease;
		}
		
		button:hover {
			
		}
		
		.button-group {
			display: flex;
			justify-content: flex-end;
			align-items: center;
			margin-top: 20px;
		}
		
		</style>
		 <style>
		
		
		table {
			width: 100%;
			margin-top: 20px;
			border-collapse: collapse;
			border-spacing: 0;
		}
		
		table td,
		table th {
			padding: 10px;
			font-size:15px;
			text-align: left;
		}
		
		table th {
			
		}
		
		button {
			padding: 10px 20px;
			
			border: none;
			
			border-radius: 5px;
			cursor: pointer;
			transition: background-color 0.3s ease;
		}
		
		button:hover {
			
		}
		
		.button-group {
			display: flex;
			justify-content: flex-end;
			align-items: center;
			margin-top: 20px;
		}
		
		</style>
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

  <nav> <div>
               <asp:Image ID="Image1" runat="server" ImageUrl="~/Media/ti.png" />
               
    <nav>
  <ul >
    
    <li>
      <a href="http://localhost:52201/Admin/Profile.aspx">Profile</a>
    </li>
    <li>
      <a href="http://localhost:52201/Admin/Home.aspx">Home</a>
    </li>
      <li>
      <a href="http://localhost:52201/Admin/Login.aspx">Logout</a>
    </li>
                    </ul>
                </nav>
                   </div>
             <div >
			<h1>Insert Subject Information</h1>
		</div>
		<div>
  
  <ul>
    <li>
			<div>
				<table>
			<tr>
				<td>Subject Name</td>
				<td>
					<asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td>Subject ID</td>
				<td>
					<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
			</tr>
					<tr>
						<td>Subject Room</td>
						<td>
							<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
						</td>
					</tr>
			<tr>
				<td>Section</td>
				<td>
					<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
			</tr>
			
			<tr>
				<td>College</td>
				<td>
					<%--<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>--%>
					<asp:DropDownList ID="DropDownList2" runat="server">
						 <asp:ListItem Text="(Select College.)" Value="" />
						<asp:ListItem>Literature</asp:ListItem>
						<asp:ListItem>Faculty Of Science</asp:ListItem>
						<asp:ListItem>Hijawi Faculty Technology Engineering</asp:ListItem>
						<asp:ListItem>Business</asp:ListItem>
						<asp:ListItem>Sharia and Islamic studies</asp:ListItem>
						<asp:ListItem>Education</asp:ListItem>
						<asp:ListItem>Faculty Of law</asp:ListItem>
						<asp:ListItem>Faculty Of Medicine</asp:ListItem>
						<asp:ListItem>Faculty Of Pharmacy</asp:ListItem>

					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>Department</td>
				<td>
					<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td>Instructor Name</td>
				<td>
					<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
			</tr>
			<tr>
				<td>Instructor ID</td>
				<td>
					<asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>
			</tr>
		</table>

			</div>
			<div class="button-group">
                <asp:Label ID="Label3" runat="server" ></asp:Label>
                <asp:Button Font-Size="14px" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                <asp:Button Font-Size="14px" ID="Button2" runat="server" Text="Reset" OnClick="Button2_Click" />
		</div>
           </li>
  </ul>

            </div>

            <div >
			
             <ul>
             <li>
        
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                     CellPadding="15" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Course_name" HeaderText="Course Name" SortExpression="Course_name"></asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>
				 <asp:BoundField DataField="CourseRoom" HeaderText="Course Room" ReadOnly="True" SortExpression="CourseRoom"></asp:BoundField>

                <asp:BoundField DataField="div" HeaderText="Section" SortExpression="div"></asp:BoundField>
              
                <asp:BoundField DataField="College" HeaderText="College" SortExpression="College"></asp:BoundField>
                <asp:BoundField DataField="Section" HeaderText="Department" SortExpression="Section"></asp:BoundField>
                <asp:BoundField DataField="Instructor_name" HeaderText="Instructor Name" SortExpression="Instructor_name"></asp:BoundField>
                <asp:BoundField DataField="Instructor_ID" HeaderText="Instructor ID" SortExpression="Instructor_ID"></asp:BoundField>
            </Columns>
        </asp:GridView>
                 
				 <asp:Label ID="Label1" runat="server" Text="Label" Enabled="false" Visible="false"></asp:Label>
				 <asp:Label ID="Label2" runat="server" Text="Label" Enabled="false" Visible="false"></asp:Label>
				 <br />
				 <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
				 <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox><br /><br />
                 <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Button4_Click" />
				 <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
	 </li>
                </ul>
                
                </div>
		</nav> 
		</div>
			 </div>
		 <footer class="footer">
	<p class="credits">
   copy; 2023 Tick Me. All rights reserved.</p>
</footer>	
		</form>
</body>
</html>
