function validate() {
    var Firstname = document.getElementById('&lt;%=txtFirstName.ClientID %>').value;
    var LastName = document.getElementById('&lt;%=txtLastName.ClientID %>').value;
    var Email = document.getElementById('&lt;%=txtEmail.ClientID %>').value;
    var Pin = document.getElementById('&lt;%=txtPin.ClientID %>').value;
    var WebUrl = document.getElementById('&lt;%=txtURL.ClientID %>').value;
    var City = document.getElementById('&lt;%=DropDownList1.ClientID %>').value;

    if (Firstname == "") {
        alert("Enter First Name");
        return false;
    }
    if (LastName == "") {
        alert("Enter Last Name");
        return false;
    }

    if (Email == "") {
        alert("Enter Email");
        return false;
    }
    var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/
    var EmailmatchArray = Email.match(emailPat);
    if (EmailmatchArray == null) {
        alert("Your email address seems incorrect. Please try again.");
        return false;
    }


    if (Pin == "") {
        alert("Enter Pin");
        return false;
    }
    var digits = "0123456789";
    var temp;

    for (var i = 0; i < document.getElementById("&lt;%=txtPin.ClientID %"); i++) {};
}