var $jq = jQuery.noConflict();
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

$jq(".CheckBlank").keyup(function () {
    var name = $jq(this).val();
    var FieldType = $jq(this).attr('type')

    $jq(' input, select').each(function () {
        var rawValue = $jq(this).val();  // Get the value without trim
        // Ensure it's a string and then trim
        var inputValue = (rawValue === undefined || rawValue === null) ? "" : String(rawValue).trim();

        var type = $jq(this).attr('type')

        console.log("value:" + inputValue + " " + "type:" + type)

        if ($jq(this).is('input')) {


            if (name == inputValue) {

                return false;
            }
            else if (inputValue.length > 0) {
                $jq(this).next('.spanError').html('');

            }
            else {
                $jq(this).next('.spanError').html('Required field.').css("color", "red");

            }
        }

    });
});


$jq('.checkDuplicate').keyup(delay(function () {
    $jq('#CaseNameValidation').val('');
    const context = $jq(this);

    var inputval = $jq.trim(context.val());
    var Data = context.attr("data");
    var shouldStop = false;
    if (inputval.length > 0) {

        $jq.ajax({
            type: "post",
            url: "/CheckDuplicateValue/CheckCaseNameExistorNot",
            data: { data: inputval, typeofdata: Data },

            success: function (data) {
                if (data != null) {

                    if (data.length > 0) {
                        context.parent().find('span').html(inputval + " already exist");
                        $jq('#CaseNameValidation').val(inputval);
                        //  console.log(data);
                        /* return false;*/
                        shouldStop = true; // Set shouldStop to true if data exists
                    }
                    else {
                        context.parent().find('span').html(" ");
                    }
                }
                else {
                    context.parent().find('span').html(" ");
                }
            },
            error: function (error) {

            },

        });
        if (shouldStop) {
            return false;
        }

    }
}, 300));
//function for check valid mobile number
$jq('.CheckValidNumber').keyup(delay(function () {
    const context = $jq(this);
    var InputValue = context.val();
    var NumberType = /^[6-9]{1}[0-9]{9}$/;

    if (!InputValue.match(NumberType)) {

        context.next('span').html('Kindly enter a valid phone number.');

    } else {
        context.next('span').html('');

    }
}, 1000));

//function for check valid text
$jq('.CheckValidText').keyup(delay(function () {
    const context = $jq(this);
    var InputText = context.val();
    InputText = (InputText === undefined || InputText === null) ? "" : String(InputText).trim();
    var TextType = /^[a-zA-Z ]*$/; // Corrected regex pattern

    if (InputText.trim().length == 0) {
        context.next('span').html('Name should not start with space');
        context.val(InputText.trim()); // Set the corrected value back to the input
    }
    else if (!InputText.match(TextType)) {

        context.next('span').html('Kindly use only letters and spaces. Numbers and symbols are not allowed.');

    }
    else {
        // Capitalize the first letter automatically
        InputText = InputText.charAt(0).toUpperCase() + InputText.slice(1);
        context.val(InputText); // Set the corrected value back to the input
        context.next('span').html('');

    }
}, 500));


//function to check valid password
$jq('.CheckValidPassword').keypress(delay(function () {
    const context = $(this);
    var InputValue = context.val();
    var regexPasword = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$jq%^&*-]).{8,}$jq";

    if (!InputValue.match(regexPasword)) {

        context.next('span').html('Please enter valid password ,Password must be contain lowercase,uppercase,number and spacial symbol');

    } else {
        context.next('span').html('');

    }
}, 1000));


//delay function
function delay(callback, ms) {
    var timer = 0;
    return function () {
        var context = this;
        clearTimeout(timer);
        timer = setTimeout(function () {
            callback.apply(context);
        }, ms || 0);
    };
}


//function for show messsage in CDR reports whether records found or not
function showMessageRecordFoundOrNot() {
    // Check if the value is not empty
    var alertBox = $jq('#ReportCustomeAlert');
    alertBox.find('.alert-text').text("No Record found");
    alertBox.show();
    setTimeout(function () {
        alertBox.addClass('show');
    }, 100);
    setTimeout(function () {
        alertBox.removeClass('show');
        setTimeout(function () {
            alertBox.hide();
        }, 1000);
    }, 5000);
}

