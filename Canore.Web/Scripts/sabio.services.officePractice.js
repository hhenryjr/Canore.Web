if (!sabio.services.officePractice) {
    sabio.services.officePractice = {};
}

sabio.services.officePractice.createOfficePracticeCase = function (officePracticeCaseData, onSuccess, onError) {

    var url = "/api/OfficePracticeCaseForm";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: officePracticeCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.officePractice.updateOfficePracticeCase = function (id, officePracticeCaseData, onSuccess, onError) {

    var url = "/api/OfficePracticeCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: officePracticeCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);

}

sabio.services.officePractice.getOfficePracticeCase = function (id, onSuccess, onError) {

    var url = "/api/OfficePracticeCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };

    $.ajax(url, settings);
}

sabio.services.officePractice.getOfficePracticeCaseList = function (onSuccess, onError) {

    var url = "/api/OfficePracticeCaseForm/";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };

    $.ajax(url, settings);
}

sabio.services.officePractice.deleteOfficePracticeCase = function (id, onSuccess, onError) {

    var url = "/api/OfficePracticeCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "DELETE"
    };

    $.ajax(url, settings);
}

sabio.services.officePractice.getHospitals = function (onSuccess, onError) {

    var url = "/api/Hospitals/";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "GET"
    };

    $.ajax(url, settings);
}
