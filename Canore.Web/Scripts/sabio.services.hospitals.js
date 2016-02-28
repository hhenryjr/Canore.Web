if (!sabio.services.hospitals){
    sabio.services.hospitals = {};
}

sabio.services.hospitals.addHospital = function (hospitalData, onSuccess, onError) {

    var url = "/api/Hospitals";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: hospitalData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.hospitals.updateObCase = function (id, obCaseData, onSuccess, onError) {

    var url = "/api/ObCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: obCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);

}

sabio.services.hospitals.getObCase = function (id, onSuccess, onError) {

    var url = "/api/ObCaseForm/" + id;
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

sabio.services.hospitals.getObCaseList = function (onSuccess, onError) {

    var url = "/api/ObCaseForm/";
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

sabio.services.hospitals.deleteObCase = function (id, onSuccess, onError) {

    var url = "/api/ObCaseForm/" + id;
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