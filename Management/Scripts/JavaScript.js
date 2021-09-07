var eye = document.getElementById('look_orNot');
var pwd = document.getElementById('pwd_lookOrNot');
eye.onclick = function () {
    //var type = $('#pwd_lookOrNot').attr("type");
    if (pwd.type == "text") {
        pwd.type = "password";
        //$("#look_orNot").children(".glyphicon").toggleClass("glyphicon-eye-open");
        //$("#look_orNot").children(".glyphicon").toggleClass("glyphicon-eye-close");
        eye.className = "glyphicon glyphicon-eye-close"
    } else {
        pwd.type = "text";
        //$("#glyphicon").toggleClass("glyphicon-eye-open");
        //$("#glyphicon").toggleClass("glyphicon-eye-close");
        eye.className = "glyphicon glyphicon-eye-open";
    }
}