$(document).ready(function () {
    var tokenLogin = localStorage.getItem("access_token");
    if(tokenLogin == null || tokenLogin == 'undefined'){
        window.location = "./login.html";
    }else{ 
        var greeting = "Xin chào " + "<b>" + localStorage.getItem("user_mail")+ "</b>" + "<a href=\"logout.html\"> Đăng xuất</a>";
        $('#user-info').html(greeting);
    }
    

    //// Kiểm tra Họ và tên người đăng ký
    //$("#name").blur(function () {
    //    if ($(this).val()) {
    //        $("#error-name-register").text("");
    //    }
    //    else {
    //        $("#error-name-register").text("Họ và tên không được bỏ trống!");
    //        $("#name").focus;
    //        return false;
    //    }
    //});

    //// Kiểm tra Email người đăng ký
    //$("#email").blur(function () {
    //    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    //    if (!filter.test($("#email").val())) {
    //        $("#error-email-register").text("Email nhập không đúng định dạng!");
    //        $("#email").focus;
    //        return false;
    //    }
    //    else {
    //        $("#error-email-register").text("");
    //    }
    //});

    //// Kiểm tra Password
    //$("#password").blur(function () {
    //    if ($(this).val()) {
    //        $("#error-password-register").text("");
    //    }
    //    else {
    //        $("#error-password-register").text("Mật khẩu không được bỏ trống!");
    //        $("#password").focus;
    //        return false;
    //    }
    //});

    //// Kiểm tra Password và Re-Passwork có giống nhau hay không
    //$("#re-password").blur(function () {
    //    if ($("#password").val() !== $("#re-password").val()) {
    //        $("#error-re-password-register").text("Mật khẩu không trùng khớp!");
    //        $("#re-password").focus;
    //        return false;
    //    }
    //    else {
    //        $("#error-re-password-register").text("");
    //    }
    //});

    //// Kiểm tra tên Công ty đồng thời điền Domain
    //$("#comapanyName").blur(function () {
    //    if ($(this).val()) {
    //        $("#domain").val($("#comapanyName").val().toLowerCase());
    //        $("#error-company-name-register").text("");
    //        $("#error-domain-register").text("");
    //        $("#domain").removeClass("border-red");
    //    }
    //    else {
    //        $("#error-company-name-register").text("Tên công ty không được bỏ trống!");
    //        $("#comapanyName").focus;
    //        return false;
    //    }
    //});

    //// Kiểm tra Domain
    //var domain = $("#domain").blur(function () {
    //    if ($(this).val()) {
    //        $("#error-domain-register").text("");
    //    }
    //    else {
    //        $("#error-domain-register").text("Domain không được bỏ trống!");
    //        $("#domain").focus;
    //        return false;
    //    }
    //});

    //// Kiểm tra số điện thoại
    //$("#phone").blur(function () {
    //    if ($(this).val()) {
    //        $("#error-phone-register").text("");
    //    }
    //    else {
    //        $("#error-phone-register").text("Số điện thoại không được bỏ trống!");
    //        $("#phone").focus;
    //        return false;
    //    }
    //});

    //// Kiểm tra các trường
    //$('.checkRequired').blur(function () {
    //    var isValid = true;
    //    if ($(this)) {
    //         $.each($(this), function (index, item) {
    //            if (item) {
    //                var value = $(item).val().trim();
    //                if (value.length === 0) {
    //                    isValid = false;
    //                    $(item).addClass('border-red');
    //                } else {
    //                    $(item).removeClass('border-red');
    //                }
    //            }
    //        });
    //    }
    //    return isValid;
    //});

    // Ẩn hiện giao diện xác nhận Email
    // $("#submit-confirm-emai").click(function () {
    //     $(".confirmEmail").addClass("hidden");
    //     $(".confirmCode").removeClass("hidden");
    //     window.open("http://gmail.com", '_blank');
    // });

    // // Kiểm tra code xác nhận
    // $('[abc="code"]').keyup(function () {
    //     $(this).next(function () {
    //         $(this).focus();
    //     });
    // });

    // $($('[abc="code"]')).keyup(function (event) {
    //     if ($(this).next().length !== 0) {
    //         if ($(this).next()[0].value === "") {
    //             $(this).next().focus();
    //         }
    //     }
    // });
});
