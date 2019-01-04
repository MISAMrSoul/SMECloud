$(document).ready(function () {
    $('.text-required').on('blur', validationJS.requiredValidation);
})

var validationJS = Object.create({
    requiredValidation: function (sender, e) {
        if (!$(this).val()) {
            $(this).addClass('required-border');
            $(this).parent().attr('title', "Thông tin này không được để trống");
            $(this).parent().addClass('wrap-control');
            var nextElement = $(this).next();
            if (!$(nextElement).hasClass('box-required-after')) {
                $(this).after('<div class="box-required-after">*</div>');
            }
            return false;
        } else {
            $(this).removeClass('required-border');
            $(this).next('.box-required-after').remove();
            $(this).parent().removeAttr('title');
            return true;
        }
        
    }
})