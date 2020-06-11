let counter = -1;
let questionsNum = $("div[name='main']").attr('id')
if (questionsNum > 0) {
    counter = questionsNum - 1;
}
$("button[name='preview']").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Form/FormPreview',
        success: function (data) {
            $("#previewContainer").html(data); // #temp is the empty div
            $("#previewForm").modal('show');
        }
    });
});
$("button[name='main-email-send']").on('click', function () {
    $(this).attr("name", "unique");
});
$("div[name='main']").on("click", function () {
    var $buttons = $("div[name='inside']");
    var $buttonToHide = $("div[name='main']");
    if ($buttons.hasClass("invisible")) {
        $buttons.removeClass("invisible");
        $buttons.addClass("visible");
        $buttonToHide.hide();
    }
});
$("button[name='add']").on("click", function () {
    var $buttonsToHide = $("div[name='inside']");
    var $buttonToShow = $("div[name='main']");
    $buttonsToHide.removeClass("visible");
    $buttonsToHide.addClass("invisible");
    $buttonToShow.show();
});
$("button[name='textQuestion']").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/TextQuestion/CreateTextQuestion',
        success: function (partialView) {
            $('#detailsContainer').html(partialView);
        }
    });
});
$("button[name='optionsQuestion']").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/OptionQuestion/CreateOptionQuestion',
        success: function (partialView) {
            $('#detailsContainer').html(partialView);
        }
    });
});
$("button[name='documentQuestion']").on('click', function () {
    //counter++;
    //document.getElementById('Current').value = counter;
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/DocumentQuestion/CreateDocumentQuestion',
        success: function (partialView) {
            $('#detailsContainer').html(partialView);
        }
    });
});
$('form').submit(function (e) {
    e.preventDefault();
    let edit = document.getElementById('EditMode').value;
    console.log(edit);
    if (edit) {
        $.ajax({
            async: true,
            data: $('#form').serialize(),
            type: "POST",
            url: '/Form/SaveChanges',
            success: function () {
                swal({
                    title: "Success!",
                    text: "Changes were saved successfully!",
                    icon: "success",
                    button: "Ok!",
                });
            },
            error: function (xhr) {
                swal(xhr.responseJSON.responseText);
            }
        });
    }
});

$("input[name='createForm']").on('click', function () {
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Form/Create',
        success: function () {
            swal("Amazing! You just created a form!", {
                icon: "success",
            })
                .then(() => {
                    window.location.replace("https://localhost:44366/User/MyForms")
                });
        },
        error: function (xhr) {
            swal(xhr.responseJSON.responseText);
        }
    });
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