$(document).ready(function () {
    $(".btnEducationList").click(function () {
        window.location = baseUrl + 'Education/Detail?id=' + this.id;
    });
});