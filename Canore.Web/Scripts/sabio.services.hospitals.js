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

sabio.services.hospitals.updateHospital = function (id, hospitalData, onSuccess, onError) {

    var url = "/api/Hospitals/" + id;
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: hospitalData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "PUT"
    };

    $.ajax(url, settings);

}

sabio.services.hospitals.getHospital = function (id, onSuccess, onError) {

    var url = "/api/Hospitals/" + id;
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

sabio.services.hospitals.getHospitalList = function (onSuccess, onError) {

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

sabio.services.hospitals.deleteHospital = function (id, onSuccess, onError) {

    var url = "/api/Hospitals/" + id;
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