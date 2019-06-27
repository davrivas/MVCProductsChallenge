$('#addProductButton').click(function () {
    var url = $('#addProductButton').data('url');
    window.location = url;
});

$('.update').click(function () {
    var url = $(this).data('url');
    window.location = url;
});