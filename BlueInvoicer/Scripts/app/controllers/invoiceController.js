var InvoiceController = function() {

    var selectedDates = [];

    var msPerDay = 1000 * 60 * 60 * 24;

    var dateDiffInDays = function (a, b) {
        var utc1 = Date.UTC(a.getFullYear(), a.getMonth(), a.getDate());
        var utc2 = Date.UTC(b.getFullYear(), b.getMonth(), b.getDate());
        return Math.floor((utc2 - utc1) / msPerDay);
    }

    var renderSampleInvoice = function() {
        var sampleInvoiceDiv = $(".js-sample-invoice");

        var currentDate = 0;
        var consecutiveDays = 0;
        $.each(selectedDates, function (i, val) {
            if (dateDiffInDays(new Date(currentDate), new Date(val)) > 0) {
                sampleInvoiceDiv.append($("<div />").append(new Date(val).asString() + " 1 day"));
                consecutiveDays = 0;
            } else {
                sampleInvoiceDiv.find("div:last").append(" - " + new Date(val).asString() + " " + ++consecutiveDays + "days");
            }
            currentDate = val;
        });
    };

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

        renderSampleInvoice();
    };

    var init = function() {
        $(".date-pick").datePicker({
            inline: true,
            selectMultiple: true,
            startDate: "01/01/2016"
        })
            .bind("click", datepickerClick)
            .bind("dateSelected", datepickerSelected);
    };

    return {
        init: init
    }

}();