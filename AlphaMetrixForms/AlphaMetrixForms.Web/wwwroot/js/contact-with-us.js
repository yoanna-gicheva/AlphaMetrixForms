$("button[name='submit']").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Home/ContactUs',
        success: function () {
            swal("We received your message! Thank you!", {
                icon: "success",
            })
                .then(() => {
                    window.location.replace("https://localhost:44366/Home/")
                });
        },
        error: function (xhr) {
            swal(xhr.responseJSON.responseText);
        },
    });
});