function format(d) {
    var trs = `<table>
                <thead >
                    <tr >
                    <th style="text-align: center;">degree</th>
                    <th style="text-align: center;">field</th>
                    <th style="text-align: center;">startdate</th>
                    <th style="text-align: center;">passingyear</th>
                    </tr>
                </thead>
                <tbody>`;
    d.forEach(element => {
        trs += `<tr><td>${element.degree}</td><td>${element.field}</td><td>${element.startdate}</td><td>${element.passingyear}</td></tr>`;
    })
    trs += `</tbody></table>`;

    return trs;

}
var dataary = [];
var i = [];
var formdata =
{
    "id": 1.1,
    "firstName": "Vatsal",
    "lastName": "Patel",
    "DOB": "2002-04-06",
    "contactNo": "0123456789",
    "emailId": "chirag@gmail.com",
    "address": "India",
    "Education": [
        {
            "degree": "BE",
            "field": "CSE",
            "startdate": "03/04/2019",
            "passingyear": "06/2023"
        },
        {
            "degree": "12th",
            "field": "Science",
            "startdate": "03/04/2017",
            "passingyear": "06/2019"
        }
    ]
};
$(document).on({
    ajaxStart: function () { $("body").addClass("loading"); },
    ajaxStop: function () { $("body").removeClass("loading"); }
});

$(window).scroll(function () {
    var sticky = $("thead tr"),
        scroll = $(window).scrollTop();

    if (scroll >= 100) sticky.addClass('fixed');
    else sticky.removeClass('fixed');
});

var table, edu;
$(document).ready(function () {
    // $.ajax({
    //     method: "POST",
    //     url : "http://192.168.3.4:9510/post",
    //     data : formdata
    // });
    table = $('table').DataTable();
    $.ajax({
        method: "GET",
        // url: "https://api.publicapis.org/entries",
        url: "http://192.168.3.4:9510/get",
        dataType: "json",
        success: function (data) {
            // var str = data.entries;
            dataary = data;
            data.forEach(element => {
                table.row.add(["<button class='details-control'>+</button>", element.id, element.firstName, element.lastName, element.DOB, element.contactNo, element.emailId, element.address, "<button class='details-delete'>Delete</button>"]).draw();
            });
        }
        // success: function (data) {
        //     var str = data.entries;
        //     str.forEach(element => {
        //         table.row.add(["<button class='details-control'>+</button>",element.API,element.Description,element.Auth,element.Cors,element.Link,element.Category]).draw();
        //     });
        // }
    });
    $(".trigger").on('click', function () {
        $(".modal").addClass("show-modal");
    });

    $('.close-button').on('click', function () {
        $('.modal').removeClass("show-modal");
    });

    $('table tbody').on('click', 'td .details-control', function () {
        var tr = $(this).closest('tr');
        var index = tr.index();
        console.log(index);
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {
            // Open this row
            row.child(format(dataary[index].Education)).show();
            tr.addClass('shown');
        }
    });
    $('table tbody').on('click', 'td .details-delete', function () {
        // console.log($(this).parents('tr').children('td:eq(1)').html());
        var index = $(this).parents('tr').children('td:eq(1)').html();
        $.ajax({
            method: "POST",
            url: "http://192.168.3.4:9510/delete",
            data: {
                id: index
            },
            success: function (data) {
                window.location.reload();
            }
        });
    });
    console.log($('table tbody').html());
    // for (let index = 0; index < $('table tbody').length; index++) {
    //     i.push();
        
    // }
});



