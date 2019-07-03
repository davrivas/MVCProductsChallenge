$(document).ready(function ($) {
    var $messageInfo = $('#messageInfo');

    if ($messageInfo.length) {
        var title = $messageInfo.data('title');
        var body = $messageInfo.data('body');

        if (title === "Success") {
            toastr.success(body, title);
        } else {
            toastr.error(body, title);
        }
    }
});