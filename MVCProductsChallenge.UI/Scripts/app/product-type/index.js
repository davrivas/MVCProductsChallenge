$('#addProductTypeButton').click(function () {
    var url = $('#addProductTypeButton').data('url');
    window.location = url;
});

$('.update').click(function () {
    var url = $(this).data('url');
    window.location = url;
});