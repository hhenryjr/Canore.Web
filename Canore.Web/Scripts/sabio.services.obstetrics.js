if (!sabio.services.obstetrics){
sabio.services.obstetrics = {};
}

sabio.services.obstetrics.createObCase = function (obCaseData, onSuccess, onError) {

    var url = "/api/ObCaseForm";
    var settings = {
        cache: false,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: obCaseData,
        dataType: "json",
        success: onSuccess,
        error: onError,
        type: "POST"
    };

    $.ajax(url, settings);
}

sabio.services.obstetrics.updateObCase = function (id, obCaseData, onSuccess, onError) {

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