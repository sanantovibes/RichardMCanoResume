﻿////var baseUrl = "http://www.richardmcano.com/";
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
    $(".btnContact").click(function () {
        window.location = baseUrl + "Contact/Index";
    });
    $("#pdf").click(function () {
        window.open("http//richardmcano.com/Files/ResumePDFs/Richard_M_Cano_Resume_SoftwareDeveloper_Description_2016.pdf");
        return false;
    });
});