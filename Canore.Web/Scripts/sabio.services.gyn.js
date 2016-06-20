if (!sabio.services.gyn) {
    sabio.services.gyn = {};
}

sabio.services.gyn.createGynCase = function (gynCaseData, onSuccess, onError) {

    var url = "/api/GynCaseForm";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: gynCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.gyn.updateGynCase = function (id, gynCaseData, onSuccess, onError) {

    var url = "/api/GynCaseForm/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: gynCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);

}

sabio.services.gyn.getGynCase = function (id, onSuccess, onError) {

    var url = "/api/GynCaseForm/" + id;
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

sabio.services.gyn.getGynCaseList = function (onSuccess, onError) {

    var url = "/api/GynCaseForm/";
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

sabio.services.gyn.deleteGynCase = function (id, onSuccess, onError) {

    var url = "/api/GynCaseForm/" + id;
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

sabio.services.gyn.getHospitals = function (onSuccess, onError) {

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
