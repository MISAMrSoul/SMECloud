$("#btnUpdateCompany").click(function(){
    //alert("OK");
    
    var companyName = $('#txtCompanyName').val();
    var address = $('#txtCompanyAddress').val();
    var taxCode = $('#txtTaxCode').val();
    
    var company = new Object();
    company ={
        CompanyName : companyName,
        Address : address,
        TaxCode : taxCode,
        UserID: localStorage.getItem("user_id")
    }
    
    $.ajax({
        url: "https://localhost:5001/api/company/addcompany",
        beforeSend: function (xhrObj) {
            xhrObj.setRequestHeader("Content-Type", "application/json");
            xhrObj.setRequestHeader("Ocp-Apim-Subscription-Key", "81873e87d2964e958be7dd07465b0f30");
            xhrObj.setRequestHeader("Authorization", "Bearer " + localStorage.getItem("access_token"));
        },
        method: "POST",
        dataType: "json",
        data: JSON.stringify(company),
        contentType: "application/json;charset=utf-8",
        success: function (data, textStatus, xhr) {
            console.log(data);
            if(data.success) {
                
                window.location = "./index.html";
                
            }
            else {               
                window.location = "./login.html";
            }
            
        },
        error: function (xhr, textStatus, errorThrown) {
            window.location = "./login.html";
            
        }
    });

})