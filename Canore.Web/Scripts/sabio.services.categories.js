if (!sabio.services.categories) {
    sabio.services.categories = {};
}

//OBSTETRICAL
sabio.services.categories.getObCategory = function (id, onSuccess, onError) {

    var url = "/api/Categories/ObCategory" + id;
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

sabio.services.categories.getObCategoryList = function (onSuccess, onError) {

    var url = "/api/Categories/ObCategories";
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

//GYNECOLOGY
sabio.services.categories.getGynCategory = function (id, onSuccess, onError) {

    var url = "/api/Categories/GynCategory" + id;
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

sabio.services.categories.getGynCategoryList = function (onSuccess, onError) {

    var url = "/api/Categories/GynCategories";
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
