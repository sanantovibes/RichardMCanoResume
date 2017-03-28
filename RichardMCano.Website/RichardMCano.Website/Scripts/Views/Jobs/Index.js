$(document).ready(function () {
    $(".btnJobsList").click(function () {
        window.location = baseUrl + 'Jobs/Detail?id=' + this.id;
    });
});