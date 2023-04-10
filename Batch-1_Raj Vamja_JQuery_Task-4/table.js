$(document).ready(function () {
    $('#loading').show();
    $.ajax({
        url: "https://api.publicapis.org/entries",
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#loading').hide();
            var apiData = result.entries;
            // Create the table rows and columns dynamically
            console.log(apiData);
            for (var i = 0; i < apiData.length; i++) {
                var row = $("<tr>");
                var apiCell = $("<td>").text(apiData[i].API);
                var descriptionCell = $("<td>").text(apiData[i].Description);
                var authCell = $("<td>").text(apiData[i].Auth);
                var corsCell = $("<td>").text(apiData[i].Cors);
                var linksCell = $("<td>").text(apiData[i].Link);
                var categoryCell = $("<td>").text(apiData[i].Category);
                row.append(apiCell, descriptionCell, authCell, corsCell, linksCell, categoryCell);
                $("#tab tbody").append(row);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
});

// For Timer
$(document).ready(function () {
    var timer = null, timeLeft = 360, interval = null;
    function startTimer() {
        clearTimeout(timer); // For clear the existing timeout (if any)
        
            timer = setTimeout(function () {
                swal.fire({
                    title: 'Session time out!', icon: "warning", showDenyButton: true, text: "Do you want to restart the session? If yes then press Save...", confirmButtonText: 'Save', denyButtonText: `Don't save`, allowOutsideClick: false
                })
                    .then((result) => {
                        if (result.isConfirmed) {
                            timeLeft = 360; // restart timer
                            $("#timer").text(formatTime(timeLeft));
                            startTimer();
                        } else if (result.isDenied) {
                            $("#timer").hide(); // after press Don't save timer will disappear
                            swal.fire({ icon: "success", title: 'Hurraahh!', text: "Now you can continue...", allowOutsideClick: false })
                        }
                    })
                }, timeLeft * 1000);
            clearInterval(interval); // clear the existing interval (if any)

            // For update timer display every second
            interval = setInterval(function () {
                timeLeft--;
                if (timeLeft >= 0) {
                    $("#timer").text(formatTime(timeLeft));
                } else {
                    clearInterval(interval);
                }
            }, 1000);
        }
        startTimer(); // For start the timer initially
        // For Time formating
        formatTime = (time) => `${disTime(Math.floor(time / 60))}:${disTime(time % 60)}`;
        // For zero to single-digit numbers
        disTime = (number) => (number < 10 ? "0" + number : number);
    });
