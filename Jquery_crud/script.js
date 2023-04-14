let table = new DataTable('#dataTable');

$(document).on('click', '#save', function () {
    var id = $('#id').val();
    var name = $('#name').val();
    var contact = $('#contact').val();
    var email = $('#email').val();
    var dob = $('#dob').val();

    var isValid = true;

    // For validation
    var identity = /^[0-9]{1,}/;
    var alpha = /^[A-Za-z]+$/;
    var digit = /^[0-9]{10,}/;
    var emailaddress = /^[A-Za-z0-9]+@+[A-Za-z]+\.+[A-Za-z]{2,}/;

    // VALIDATION FOR ID
    if (id == '') {
        $('#id').siblings("span").text("Please enter your student id!").css("color", "red")
        isValid = false;
    }
    else if (!id.match(identity)) {
        $('#id').siblings("span").text("Please enter valid id (ex. id must be in 3 digits)").css("color", "red")
        isValid = false;
    }
    else {
        $('#id').siblings("span").text("")
    }

    // VALIDATION FOR NAME
    if (name == '') {
        $('#name').siblings("span").text("Please enter your name!").css("color", "red")
        isValid = false;
    }
    else if (!name.match(alpha)) {
        $('#name').siblings("span").text("Only charactors are allow").css("color", "red")
        isValid = false;
    }
    else {
        $('#name').siblings("span").text("")
    }

    // VALIDATION FOR CONTACT
    if (contact == '') {
        $('#contact').siblings("span").text("Please enter your contact number!").css("color", "red")
        isValid = false;
    }
    else if (!contact.match(digit)) {
        $('#contact').siblings("span").text("Only numbers are allow (ex. only 10 numbers are allow)").css("color", "red")
        isValid = false;
    }
    else {
        $('#contact').siblings("span").text("")
    }


    // VALIDATION FOR EMAIL
    if (email == '') {
        $('#email').siblings("span").text("Please enter your email!").css("color", "red")
        isValid = false;
    }
    else if (!email.match(emailaddress)) {
        $('#email').siblings("span").text("Please enter valid email address").css("color", "red")
        isValid = false;
    }
    else {
        $('#email').siblings("span").text("")
    }

    // VALIDATION FOR DATE  
    if (dob == '') {
        $('#dob').siblings("span").text("Please select the date of birth!").css("color", "red")
        isValid = false;
    }
    else {
        $('#dob').siblings("span").text("");
    }
    // FOR DATA BINDING
    if (isValid) {
        table.row.add([id, name, contact, email, dob, '<div class="d-flex"><td> <button type="button" id="Edit" class="Edit me-1 btn btn-outline-warning">Edit</button>|<button type="button" id="del" class="rem ms-1 btn btn-outline-danger">Delete</button></td></div>'])
            .draw(false);

        $('#form').trigger('reset');

    }
});

$(document).on('click', '#del', function () {
    var rem = $(this).parents('tr');
    table.row(rem).remove();
    table.draw();
})

$(document).on('click', '#Edit', function () {

    var edit_rec = $(this).parents('tr')
    table.row(edit_rec).remove()

    var id = edit_rec.find('td:eq(0)').text();
    var name = edit_rec.find('td:eq(1)').text();
    var contact = edit_rec.find('td:eq(2)').text();
    var email = edit_rec.find('td:eq(3)').text();
    var dob = edit_rec.find('td:eq(4)').text();

    $('#id').val(id)
    $('#name').val(name)
    $('#contact').val(contact)
    $('#email').val(email)
    $('#dob').val(dob)
})

function sort_name() {
    var tbody = $('#tBody');
    tbody.find('tr').sort(function (a, b) {
        if ($('#name').val() == 'asc') {
            return $('td:first', a).text().localeCompare($('td:first', b).text());
        }
        else {
            return $('td:first', b).text().localeCompare($('td:first', a).text());
        }
    }).appendTo(tbody);
}

function sort_name_desc() {
    var tbody = $('#tBody');
    tbody.find('tr').sort(function (b, a) {
        if ($('#name').val() == 'desc') {
            return $('td:first', a).text().localeCompare($('td:first', b).text());
        }
        else {
            return $('td:first', b).text().localeCompare($('td:first', a).text());
        }
    }).appendTo(tbody);
}
