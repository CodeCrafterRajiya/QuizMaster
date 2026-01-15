
// Global timeout holder so each alert can manage its own timeout
var alertTimeout = null;

// Reusable function to handle Bootstrap alert close behavior
function setupAlertClose(alertId, fadeDuration = 1000) {
    console.log(alertId)
    var $alert = $jq('#' + alertId);

    // Attach click event to the close button inside the alert
    $alert.on('click', '.close-btn', function () {
        $alert.removeClass('show');   // Begin fade-out animation
        clearTimeout(alertTimeout);   // Clear existing timeout

        // Wait for CSS animation to finish, then hide
        setTimeout(function () {
            $alert.hide();
        }, fadeDuration);
    });
}


function showMessageToUser(msgalertId,deleteEditMessage, alertType) {
    // Log to see the alert type (success, error, etc.) and the message
    //  console.log('Alert Type:', alertType, 'Message:', deleteEditMessage);
    console.log(msgalertId)
    console.log(deleteEditMessage)
    console.log(alertType)
    // Get the alert box element
    var alertBox = $jq('#' + msgalertId);

    // Remove any existing background color classes to reset
    alertBox.removeClass('alert-success alert-danger alert-warning alert-info');

    // Add the appropriate alert class based on alertType (e.g., success, error, warning)
    switch (alertType) {
        case 'success':
            alertBox.addClass('bg-success bg-gradient'); // Green background for success
            break;
        case 'error':
            alertBox.addClass('bg-danger bg-gradient'); // Red background for error
            break;
    }

    // Set the message text inside the alert box
    alertBox.find('.alert-text').text(deleteEditMessage);

    // Show the alert box (ensure it is shown)
    alertBox.show();

    setTimeout(function () {
        alertBox.addClass('show');
    }, 100);
    setTimeout(function () {
        alertBox.removeClass('show');
        setTimeout(function () {
            alertBox.hide();
        }, 1000);
    }, 10000);
}