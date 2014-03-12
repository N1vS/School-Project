<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agreement.aspx.cs" Inherits="Agreement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="rtl">

    <span style="font-size:50px; text-decoration:'underline'">דף הכללים והתנאים של אתר השליחויות</span>
    <br /><br /><br />
    1. בעת ההרשמה אתה מבטיח להכניס פרטים נכונים
    <br />
    2. הזמנות אשר תמלא יכללו פרטים נכונים
    <br />

    <br />

    <br />

    <br />

    <br />

     <br />
     אי קיום התנאים עלול לגרום לפיצוי כספי מצד הלקוח.
     <br /><br />
    בלחיצה על הכפתור תופנה אל עמוד ההרשמה
    <br />
     <asp:Button runat="server" ID="ButtonAgree" Text="אשר" 
            onclick="ButtonAgree_Click" />
    </div>

    </form>
</body>
</html>
