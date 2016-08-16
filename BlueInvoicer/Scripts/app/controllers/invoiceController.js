var InvoiceController = function() {

    var selectedDates = [];

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
    var eventHandlers = function() {
        $("#chkWorkNormal, #chkWorkOvertime").on("change", toggleWorkTypeOptions);

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