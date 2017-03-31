////var baseUrl = "http://www.richardmcano.com/";
//var baseUrl = "http://localhost:62403/";
var baseUrl = location.protocol + "//" + location.host + "/";
var id = "6257B7B5-C4D0-4D00-ACB4-350A95861B7F";

$(document).ready(function () {
    //Navigation
    $(".btnOverview").click(function () {
        window.location = baseUrl + "Objective/Index";
    });
    $(".btnJobs").click(function () {
        window.location = baseUrl + "Jobs/Index";
    });
    $(".btnEducation").click(function () {
        window.location = baseUrl + "Education/Index";
    });
    $(".btnTechnicalSkills").click(function () {
        window.location = baseUrl + "TechnicalSkills/Index";
    });
});