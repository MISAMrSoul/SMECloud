
$("#btnLogin").click(function(){   
    //alert("OK");
    var email = $('#txtEmail').val();
    var password = $('#txtPassword').val();
    
    var myData = new Object();
    myData ={
        Email : email,
        Password : password
    };

    $.ajax({
        url: "https://localhost:5001/api/account/login",
        // beforeSend: function (xhrObj) {
        //     xhrObj.setRequestHeader("Content-Type", "application/json");
        //     xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "81873e87d2964e958be7dd07465b0f30");
        // },
        method: "POST",
        //dataType: "json",
        data: JSON.stringify(myData),
        contentType: "application/json;charset=utf-8",
        success: function (data, textStatus, xhr) {
            //do when sc
            if(data.success) {
                //localStorage.setItem("user_id", data.data.userId);
                localStorage.setItem("access_token", data.data.token);
                localStorage.setItem("user_mail", myData.Email);
                window.location = "./index.html";
            }
            else {               
                window.location = "./login.html";
                $('#loginNotification').html("Đăng nhập thất bại,vui lòng kiểm tra lại thông tin!");
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            //do when er
            $('#loginNotification').html("Đăng nhập thất bại,vui lòng kiểm tra lại thông tin!");
        }
    });

});