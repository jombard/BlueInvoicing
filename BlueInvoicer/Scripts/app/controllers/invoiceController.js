var InvoiceController = function() {

    var selectedDates = [];

    var msPerDay = 1000 * 60 * 60 * 24;

    var dateDiffInDays = function (a, b) {
        var utc1 = Date.UTC(a.getFullYear(), a.getMonth(), a.getDate());
        var utc2 = Date.UTC(b.getFullYear(), b.getMonth(), b.getDate());
        return Math.floor((utc2 - utc1) / msPerDay);
    }

    var datepickerClick = function () {
        console.log("datepickerClick");
        $(this).dpDisplay();
        this.blur();
        return false;
    };

    var datepickerSelected = function (e, selectedDate, $td, state) {
        console.log("You " + (state ? "" : "un") + "selected " + selectedDate);
        if (state) {
            selectedDates.push(Date.parse(selectedDate));
        } else {
            var index = selectedDates.indexOf(Date.parse(selectedDate));
            if (index > -1) {
                selectedDates.splice(index, 1);
            }
        }
        selectedDates.sort();

        $.each(selectedDates,
            function(i, val) {
                $(".js-sample-invoice").after($("<div />").append(new Date(val).asString() + " 1 day"));
            });
    };

    var toggleWorkTypeOptions = function() {
        if ($("#chkWorkNormal").is(":checked")) {
            $(".js-work-normal").show();
            $(".js-work-overtime").hide();
        } else {
            $(".js-work-normal").hide();
            $(".js-work-overtime").show();
        }
    };
    var clearInputs = function() {
        $("#chkWorkNormal").prop("checked", true).trigger("change");
        $("#RateType").val("");
        $("#Rate").val("");
        $("#OvertimeRateType").val("");
        $("#OvertimeRate").val("");
    };

    var addToInvoice = function(e) {
        e.preventDefault();

        var sampleInvoiceDiv = $(".js-sample-invoice");

        clearInputs();
    };
    var eventHandlers = function() {
        $("#chkWorkNormal, #chkWorkOvertime").on("change", toggleWorkTypeOptions);

        $(".js-sample-invoice-add").on("click", addToInvoice);

    };
    var init = function() {
        $(".date-pick").datePicker({
            inline: true,
            selectMultiple: true,
            startDate: "01/01/2016"
        })
            .bind("click", datepickerClick)
            .bind("dateSelected", datepickerSelected);

        eventHandlers();
    };
    return {
        init: init
    }

}();