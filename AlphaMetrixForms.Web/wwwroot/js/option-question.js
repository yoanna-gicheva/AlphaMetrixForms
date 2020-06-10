$("button[name='addOption']").on("click", function addOption() {
    let orderNum = $(this).attr('id');
    document.getElementById('Current').value = orderNum;
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/OptionQuestion/CreateOption',
        success: function (partialView) {
            console.log("partialView: " + partialView);
            $('#detailsContainer').html(partialView);
        }
    });
});
$("button[name='deleteOption']").on("click", function deleteOption() {
    $(this).parent().remove();
    document.getElementById('Current').value = $(this).attr('id');
    let option = $(this).attr('value');
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: `/OptionQuestion/DeleteOption/${option}`,
        success: function (partialView) {
            console.log("partialView: " + partialView);
            $('#detailsContainer').html(partialView);
        }
    });
});

$("button[name='deleteOptionQuestion']").on('click', function () {
    $(this).parent().parent().remove();
    let orderNumber = $(this).attr('id');
    document.getElementById('Current').value = orderNumber;
    $.ajax({
        async: true,
        data: $('#form').serialize(),
        type: "POST",
        url: '/Form/DeleteQuestion',
        success: function (partialView) {
            $('#detailsContainer').empty();
            $('#detailsContainer').html(partialView);
        }
    });
});