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
          <td class="d-flex"> <button type="button" onclick="appbtn(this)" class="app">Approve</button><button type="button" onclick="rejbtn(this)" class="app ms-1">Reject</button></td>
          <td><button type="button" class="btnDel btn btn-danger me-3">Remove</button></td>
        </tr> `);
    });

    // Remove table row usig JQuery .remove() method
    $(".table").on('click', '.btnDel', function () {
        swal({
            title: "Are you sure?",
            text: "You want to delet this record?",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $(this).closest('tr').remove();
                    swal({
                        title: "Hurraahh!",
                        text: "Your record has been deleted",
                        icon: "success",
                    });
                } else {
                    swal("Oops!", "Sorry, Your record is safe as it is.", "error");
                }
            });
    });

    // For storing object in array and print the table
    $('#load').on('click', function () {
        var data = [];
        $('#tab tr').each(function () {
            var obj = {};
            $(this).find('td:lt(4)').each(function (ind) {
                if (ind >= 1 && ind <= 3) {
                    var key = $('#tab th').eq(ind).text();
                    var value = $(this).find("input").val();
                    if (value.trim() == '') {
                        $("#dis").hide();
                        Swal.fire({
                            icon: 'warning',
                            title: 'All inputs must be filled...',
                            showClass: {
                              popup: 'animate__animated animate__fadeInDown'
                            },
                            hideClass: {
                              popup: 'animate__animated animate__fadeOutUp'
                            }
                          })                        
                    }
                    obj[key] = value;
                }
            });
            data.push(obj);
        });
        var $headerRow = $('<tr>').attr('id', 'ohd');
        $headerRow.append($('<th>').text('Name'));
        $headerRow.append($('<th>').text('Subject'));
        $headerRow.append($('<th>').text('Marks'));
        var $outputTableBody = $('#dis');
        $outputTableBody.empty();
        $outputTableBody.append($headerRow);
        $('#tab tr.showResult').each(function () {
            var index = $(this).index();
            var rowData = data[index];
            if (rowData) {
                var $row = $('<tr>');
                $row.append($('<td>').text(rowData.Name));
                $row.append($('<td>').text(rowData.Subject));
                $row.append($('<td>').text(rowData.Mark));
                if (rowData.Mark < 35) {
                    $row.css('background-color', 'rgb(255,0,0,0.5)');
                }
                $outputTableBody.append($row);
            }
        });
    });
});

// For print the percentages table
$('#load').on('click', function () {
    var data = [];
    $('#tab tr').each(function () {
        var obj = {};
        $(this).find('td:lt(4)').each(function (ind) {
            if (ind >= 1 && ind <= 3) {
                var key = $('#tab th').eq(ind).text();
                var value = $(this).find("input").val();
                if (value.trim() == '') {
                    $("#diss").hide();
                }
                obj[key] = value;
            }
        });
        data.push(obj);
    });
    var $outputTablebody = $('#diss');
    $outputTablebody.empty();
    var $headerRow = $('<tr>');
    var $headerRow = $('<tr>').attr('id', 'oohd');
    $headerRow.append($('<th>').text('Name'));
    $headerRow.append($('<th>').text('Subject'));
    $headerRow.append($('<th>').text('Percentage'));
    $outputTablebody.append($headerRow);
    $('#tab tr.showResult').each(function () {
        var index = $(this).index();
        var rowData = data[index];
        if (rowData) {
            var $row = $('<tr>');
            $row.append($('<td>').text(rowData.Name));
            $row.append($('<td>').text(rowData.Subject));
            // For Calculate percentage and add to output table
            var percentage = (rowData.Mark / 100) * 100;
            $row.append($('<td>').text(percentage.toFixed(2) + '%'));
            if (rowData.Mark < 35) { $row.find('td').css('background-color', 'rgb(255,0,0,0.5)'); }
            $outputTablebody.append($row);
        }
    });
});
// For add showResult class
function appbtn(btnaction) {
    $(btnaction).next().css('backgroundColor', '');
    $(btnaction).next().css('color', 'black');
    $(btnaction).css('backgroundColor', '#198754');
    $(btnaction).css('color', 'white');
    if ($(btnaction).css('backgroundColor') == 'rgb(25, 135, 84)') {
        $(btnaction).parents('.bd').addClass('showResult');
    }
}

function rejbtn(btnaction) {
    $(btnaction).prev().css('backgroundColor', '');
    $(btnaction).prev().css('color', 'black');
    $(btnaction).css('backgroundColor', '#dc3545');
    $(btnaction).css('color', 'white');
    if ($(btnaction).css('backgroundColor') == 'rgb(220, 53, 69)') {
        $(btnaction).parents('.bd').removeClass('showResult');
    }
}
//For SearchBar
$(document).ready(function () {
    $("#find").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#dis tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

//sort by name with help of button
$('#btn1').on('click', function() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = $('#dis')[0];
    switching = true;
  
    while (switching) {
      switching = false;
      rows = table.rows;
      for (i = 1; i < (rows.length - 1); i++) {
        shouldSwitch = false;
        x = $(rows[i]).find('td:first-child');
        y = $(rows[i + 1]).find('td:first-child');
        if (x.text().toLowerCase() > y.text().toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      }
      if (shouldSwitch) {
        rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
        switching = true;
      }
    }
  });
  

//sort by subject with help of button
function sort_S() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("dis");
    switching = true;

    while (switching) {

        switching = false;
        rows = table.rows;

        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[2];
            y = rows[i + 1].getElementsByTagName("TD")[2];

            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}