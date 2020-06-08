$('form').submit(function (e) {
    e.preventDefault();
    var formData = new FormData(this);
    $.ajax({
        async: true,
        data: formData,
        type: "POST",
        url: '/Response/SubmitResponse',
        success: function () {
            swal("Perfect! You just submitted your answer!", {
                icon: "success",
            })
                .then(() => {
                    window.location.replace("https://localhost:44366/Form")
                });
        },
        error: function (xhr) {
            swal(xhr.responseJSON.responseText);
        },
        cache: false,
        contentType: false,
        processData: false
    });
});