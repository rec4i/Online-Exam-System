$(document).ready(function () {

    
    $('input[id=Giriş]').click(function () {
        $.ajax(
            {
                type: "POST",
                url: '/api/Users/authenticate',
                contentType: "application/json; charset=utf-8",
                data: '{"Username":"'+  $('input[id=Kullanıcı_Ad]').val() +'" ,"Password":"'+ $('input[id=Kullanıcı_Şifre]').val()+'"}'  ,
                success: function (response) {
                    console.log(response.role)
                    if(response.role=="Admin"){
                        window.location.href = '/CreateExam';
                    }
                    if(response.role=="User"){
                        window.location.href = '/CreateExam';
                    }
                    if(response.role=="il"){
                        window.location.href = '/CreateExam';
                    }
                    if(response.role=="ilçe"){
                        window.location.href = '/CreateExam';
                    }
                   
                },
                error: function (data) {
                    console.log(data);
                }
            }
        );
    })


})