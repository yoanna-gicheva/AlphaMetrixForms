$("button[name='main-email-send']").on('click', function () {
    $(this).attr("name", "unique");
});
$("input[name='deleteForm']").on('click', function () {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this form!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {

            if (willDelete) {
                $.ajax({
                    async: true,
                    data: { "id": this.id },
                    type: "POST",
                    url: '/Form/Delete',
                    success: function () {
                        swal("Poof! Your form has been deleted!", {
                            icon: "success",
                        })
                            .then(() => {
                                window.location.replace("https://localhost:44366/User/MyForms")
                            });
                    }
                });

            } else {
                swal("Your form is safe!");
            }
        });
});
