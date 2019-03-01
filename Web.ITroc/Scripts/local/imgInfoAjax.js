function imageTrigger(id) {
    $.ajax({
        url: "/api/ApiCollection/GetAdInfoToModal?id=" + id,
        type: "GET",
        dataType: "json",
        success: function (data) {
            if (data && data[0]) {
                $('.carousel-inner').empty();
                $('.carousel-indicators').empty();
                $(".acordionTitre").empty();
                $(".green-text").empty();
                $(".collapseBody").empty();

                $(".acordionTitre").append('<strong>' + data[0].AdTitle + '</strong><i class="fas fa-angle-down rotate-icon"></i>');
                $(".green-text").append('<strong>' + data[0].AdCeate + '</strong>');
                $(".collapseBody").append(data[0].AdDescription);

                $('.carousel-inner').append('<div class="carousel-item active"><img class="d-block w-100 imgMax"  src="data:image/png;base64,' + data[0].Images[0] + '"alt="First slide"></div>');
                $('.carousel-indicators').append('<li data-target="#carousel-thumb" data-slide-to="0" class="active"><img class="d-block monimage2"  src="data:image/png;base64,' + data[0].Images[0] + '"></li>');

                for (var i = 0; i < data[0].Images.length; i++) {
                    $('.carousel-inner').append(
                        '<div class="carousel-item"><img class="d-block w-100 imgMax" src="data:image/png;base64,' +
                        data[0].Images[i] + '"alt="Second slide" ></div>');
                }
                for (var j = 1; j < data[0].Images.length; j++) {
                    $('.carousel-indicators').append('<li data-target="#carousel-thumb" data-slide-to="' + j + '"><img class="mx-auto d-block  monimage2 avatar z-depth-1 img-fluid"  src="data:image/png;base64,' + data[0].Images[j] + '"></li>');
                }


                //$('.smallimage').on("click", function () {
                //    $('.bigimage').attr('src', $(this).attr('src'));
                //});
            } else if (data[0] === undefined) {
                alert("NOK");
                //window.location.href = '/';
            }
        }
    });
}
