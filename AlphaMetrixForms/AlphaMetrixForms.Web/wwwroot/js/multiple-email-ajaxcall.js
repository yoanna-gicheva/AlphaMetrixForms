$(document).ready(function ($) {
    let data = [
    ]
    $("#essai").email_multiple({
        data: data
        //reset: true
    });
});
$("input[name='shareForm']").on('click', function () {
    let emailsList = $(".single-email-id")
        .map(function () {
            return this.innerText;
        })
        .get();
    let elmId = $("button[name='unique']").attr("id");
    console.log(elmId);
    var postData = { emails: emailsList, formId: elmId };
    $("button[name='unique']").attr("name", "main-email-send");
    $.ajax({
        async: true,
        data: postData,
        type: "POST",
        url: '/Form/Share',
        success: function () {
            window.location.reload();
        }
    });
});