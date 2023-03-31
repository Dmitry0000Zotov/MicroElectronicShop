function addToApp(params) {
    var equipId = parseInt(params.equipId);
    var userId = parseInt(params.userId);

        $.ajax({
            type: 'GET',
            url: '/ApplicationItems/Add',
            data: { "equipId": equipId, "userId": userId },
            success: function (response) {
                console.log("Success!");
                $('.toast').find('.toast-body').html("Оборудование успешно добавлено!");
                $('.toast').addClass("bg-success text-white")
                $('.toast').toast('show');

            },
            failure: function () {
                console.log("Failure!");
            },
            error: function (response) {
                console.log(response);
                $('.toast').find('.toast-body').html("Произошла ошибка при добавлении оборудования!");
                $('.toast').addClass("bg-danger text-white")
                $('.toast').toast('show');
            }
        });
}; 