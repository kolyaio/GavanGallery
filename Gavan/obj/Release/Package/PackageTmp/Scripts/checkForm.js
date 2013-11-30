function checkForm() {
    var _name = document.getElementById("name").value;
    var _email = document.getElementById("email").value;
    var _password = document.getElementById("password").value;
    var _confirmpass = document.getElementById("confirmpass").value;
	var _agree = document.getElementById("agree").checked;
	
	var _str = "";
	var _flag=false;
	
	var cEmail = checkEmail();
	var cDot = checkDot();
	var validEmail = false;
	var validDot = false;
	
	function checkDot() {
	    var email = document.getElementById("email").value;
		for(var i=0;i<email.length;i++)
		{
			if(email.indexOf(".")==-1){return false;break;}
			else{validDot=true;}
		}
	}
	function checkEmail() {
	    var mail = document.getElementById("email").value;
		for(var i=0;i<mail.length;i++)
		{
			if(mail.indexOf("@")==-1){return false;break;}
			else {validEmail=true;}
		}
	}
	
	if(_name =="") {_str += "אנא מלא את שמך \n";_flag=true;}
	if(_password =="") 
	{_str += "שחכת לרשום סיסמה \n";_flag=true;}
	else {
		if(_confirmpass =="") {_str += "יש לרשום את הסיסמה שוב \n";_flag=true;}
	}
    if (_password != _confirmpass && (_password != "" && _confirmpass != "")) { _str += "הסיסמאות אינן תאומות \n"; _flag = true; }
	if (_password.length < 6) {_str += "הסיסמה צריך להיות לפחות בעלת 6 תווים";_flag = true;}
	if(_email =="" || cDot==false || cEmail==false){_str +=" כתובת דואר האלקטרוני אינה תקינה  \n";}
	if(_agree == 0) {_str += "יש להסכים לתקנון כדי להרשם \n";_flag=true;}

	if (_flag == true) { alert(_str); return false; }
	return true;
}

// מסתיר את התיבה הנגללת במקרה והמשתמש הנרשם הוא מורה
$(document).ready(function () {

    $('.studstaff input:radio').ready(function () {
        var selectedVal = $('.studstaff input:radio:checked').val();
        if (selectedVal == 1)
            $("#gradeli").css("display", "inline");
        else if (selectedVal == 2 || selectedVal == 3)
            $("#gradeli").css("display", "none");
    });

    $('.studstaff input:radio').change(function () {
        var selectedVal = $('.studstaff input:radio:checked').val();
        if (selectedVal == 1)
            $("#gradeli").css("display", "inline");
        else if (selectedVal == 2 || selectedVal == 3)
            $("#gradeli").css("display", "none");
    });
});