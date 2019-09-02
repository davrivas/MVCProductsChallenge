function setBootstrapTable() {
    $('#productsTable').DataTable();
    $('#productsTable_filter').hide();
}

$(document).ready(function () {
    setBootstrapTable();
});

$('#addProductButton').click(function () {
    var url = $('#addProductButton').data('url');
    window.location = url;
});


$(document).on('click', '.update', function () {
    var url = $(this).data('url');
    window.location = url;
});

$(document).on('click', '.delete', function () {
    var url = $(this).data('url');
    window.location = url;
});

$('#searchButton').click(function () {
    var identifier = $('#identifier').val();
    var description = $('#description').val();
    var action = $(this).data('url');
    var url = action + "?identifier=" + identifier + "&description=" + description;

    $.post(url, function (data) {
        $('#productsTable').remove();
        $('#productsTable_wrapper').remove();

        var $data = $(data);
        $($data).insertAfter('#addSearch');

        setBootstrapTable();
    });
});