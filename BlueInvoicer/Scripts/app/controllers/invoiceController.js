var InvoiceController = function() {

    var toggleContracts = function (e) {
        console.log("toggle contracts");
    };

    var init = function() {
        $("select#ClientId").on("change", toggleContracts);
    };

    return {
        init: init
    }

}();