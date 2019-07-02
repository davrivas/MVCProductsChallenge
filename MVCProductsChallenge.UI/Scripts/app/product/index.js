$('#addProductButton').click(function () {
    var url = $('#addProductButton').data('url');
    window.location = url;
});

$('.update').click(function () {
    var url = $(this).data('url');
    window.location = url;
});

$('#searchButton').click(function () {
    var identifier = $('#identifier').val();
    var description = $('#description').val();
    var action = $(this).data('url');
    var url = action + "?identifier=" + identifier + "&description=" + description;

    $.post(url, function (data) {
        $('#productsTable').html('');
        $('#productsTable').html(data);
    });
});