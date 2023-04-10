let form = document.getElementById('myForm')
form.addEventListener('submit', (e) => {
    e.preventDefault()
})
// Add table rows using JQuery .append() method
$(document).ready(function () {
    $("#plus").click(function () {
        $(".table").append(`<tr class="bd">
          <td class="count"></td>
          <td><input type="text" class="name form-control" pattern="[A-Za-z\s]{3,15}" placeholder="Name"></td>
          <td><input type="text" class="sub form-control" pattern="[A-Za-z\s]{3,30}" placeholder="Sub"></td>
          <td><input type="number" class="mark form-control" min="1" max="100" placeholder="Marks"></td>
          <td class="d-flex"> <button type="button" class="app">Approve</button><button type="button" class="app ms-1">Reject</button></td>
          <td><button type="button" class="btnDel btn btn-danger me-3">Remove</button></td>
        </tr> `);
    });

    // Remove table row usig JQuery .remove() method
    $(".table").on('click', '.btnDel', function () {
        $(this).closest('tr').remove();
    });

    // For storing object in array
    $('#load').on('click', function () {
        var data = [];
        $('#tab tr').each(function () {
            var obj = {};
            $(this).find('td:lt(4)').each(function (ind) {
                if (ind >= 1 && ind <= 3) {
                    var key = $('#tab th').eq(ind).text();
                    var value = $(this).find("input").val();
                    obj[key] = value;
                }
            });
            data.push(obj);
        });
        console.log(data);
    });
});

// For Timer
$(document).ready(function () {
    var timer = null, timeLeft = 360, interval = null;
    function startTimer() {
        clearTimeout(timer); // For clear the existing timeout (if any)

        timer = setTimeout(function () {
            swal.fire({
                title: 'Session time out!', icon: "warning", showDenyButton: true, text: "Do you want to restart the session? If yes press Save...",confirmButtonText: 'Save', denyButtonText: `Don't save`, allowOutsideClick: false })
                .then((result) => {
                    if (result.isConfirmed) {
                        timeLeft = 360; // restart timer
                        $("#timer").text(formatTime(timeLeft));
                        startTimer();
                    } else if (result.isDenied) {
                        $("#timer").hide(); // after press Don't save timer will disappear
                        swal.fire({icon: "success", title: 'Hurraahh!', text: "Now you can continue...", allowOutsideClick: false})
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