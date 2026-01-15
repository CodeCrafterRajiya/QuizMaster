//code for hide header div in the financial report
//var $ = jQuery.noConflict();

//    $(document).ready(function () {
//       // $('#myDiv').hide();
//        $('#HideButton').click(function () {
//            $('#myDiv').hide();
//       // $('#myDiv').toggle();
//        });
//    });

//function onThemeChange(button) {
//    document.getElementsByTagName('body')[0].style.display = 'none';

//    // Get the value of the clicked button
//    var themeName = button.value;

//    let synclink = document.getElementsByClassName('cssfileTheam');
//    synclink.href = 'https://cdn.syncfusion.com/ej2/26.2.4/' + themeName + '.css';

//    // Apply dark mode class based on theme
//    if (themeName.includes('dark')) {
//        document.getElementsByClassName('TheamChangeColor').classList.add('e-dark');
//    } else {
//        document.getElementsByClassName('TheamChangeColor').classList.remove('e-dark');
//    }

//    setTimeout(function () { document.getElementsByTagName('body')[0].style.display = 'block'; }, 200);
//}






//-----------------------------------------------------------------------------------------------------------
//Use this code



//function onThemeChange(button) {
//    document.getElementsByTagName('body')[0].style.display = 'none';

//    // Get the value of the clicked button
//    var themeName = button.value;
//    console.log('Theme Name:', themeName); // Debugging information

//    // Update the CSS link
//    let synclinks = document.getElementsByClassName('cssfileTheam');
//    if (synclinks.length > 0) {
//        let synclink = synclinks[0]; // Assuming there is only one link with this class
//        console.log('Changing CSS link to:', 'https://cdn.syncfusion.com/ej2/25.2.4/' + themeName + '.css'); // Debugging information
//        synclink.href = 'https://cdn.syncfusion.com/ej2/25.2.4/' + themeName + '.css';
//    }

//    // Apply or remove dark mode class based on theme
//    let grids = document.getElementsByClassName('TheamChangeColor');
//    console.log('Number of grids:', grids.length); // Debugging information

//    for (let i = 0; i < grids.length; i++) {
//        if (themeName.includes('dark')) {
//            console.log('Adding e-dark class to grid:', grids[i]); // Debugging information
//            grids[i].classList.add('e-dark');
//            // Apply e-dark class to rows with e-altrow
//            applyDarkModeToRows(grids[i]);
//        } else {
//            console.log('Removing e-dark class from grid:', grids[i]); // Debugging information
//            grids[i].classList.remove('e-dark');
//            // Remove e-dark class from rows with e-altrow
//            removeDarkModeFromRows(grids[i]);
//        }
//    }

//    // Restore body display after a short delay
//    setTimeout(function () {
//        document.getElementsByTagName('body')[0].style.display = 'block';
//    }, 200);
//}

//// Function to apply e-dark class to rows with e-altrow
//function applyDarkModeToRows(grid) {
//    let rows = grid.querySelectorAll('tr.e-altrow'); // Select all rows with e-altrow class
//    rows.forEach(row => {
//        row.classList.add('e-dark'); // Add e-dark class
//    });
//}

//// Function to remove e-dark class from rows with e-altrow
//function removeDarkModeFromRows(grid) {
//    let rows = grid.querySelectorAll('tr.e-altrow'); // Select all rows with e-altrow class
//    rows.forEach(row => {
//        row.classList.remove('e-dark'); // Remove e-dark class
//    });
//}




