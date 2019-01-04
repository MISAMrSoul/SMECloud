$("#btnRegister").click(function(){
    //alert("OK");
    
    var email = $('#txtContactEmail').val();
    var password = $('#txtPassword').val();

    var phone = $('#txtContactMobile').val();
    var confirmPass = $('#txtRePassword').val();
    var fullname = $('#txtFullName').val();
    var user_input = new Object();
    user_input ={
        FullName : fullname,
        Email : email,
        PhoneNumber : phone,
        Password : password,
        ConfirmPassword : confirmPass
    }
    console.log(JSON.stringify(user_input));
    $.ajax({
        url: "https://localhost:5001/api/account/register",
        beforeSend: function (xhrObj) {
            xhrObj.setRequestHeader("Content-Type", "application/json");
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "81873e87d2964e958be7dd07465b0f30");
        },
        method: "POST",
        dataType: "json",
        data: JSON.stringify(user_input),
        contentType: "application/json;charset=utf-8",
        success: function (data, textStatus, xhr) {
            console.log(data);
            if(data.success) {
                $(".loader").hide();
                $('.loading-icon').hide();
                localStorage.setItem("user_id", data.data.userId);
                localStorage.setItem("access_token", data.data.token);
                localStorage.setItem("user_mail", user_input.Email);
                window.location = "./update-company.html";
            }
            else {               
                $('#registerNotification').html("Đăng kí thất bại, kiểm tra đầy đủ thông tin đã nhập!");
            }
            
        },
        error: function (xhr, textStatus, errorThrown) {
            $('#registerNotification').html("Đăng kí thất bại, kiểm tra đầy đủ thông tin đã nhập!");
            console.log(xhr.responseText);
            //window.location = "./login.html";
            
        }       
    });

})