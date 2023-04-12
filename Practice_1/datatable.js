let table = new DataTable('#myTable');

$(document).on('click', '#save', function () {

    var id = $('#id').val();
    var name = $('#name').val();
    var contact = $('#contact').val();
    var email = $('#email').val();

    if (id != "" && name != "" && contact != "" && email != "" && $('#check').is(":checked")) {
        table.row.add([id, name, contact, email, '<div class="d-flex"><td> <button type="button" id="Edit" class="Edit me-1 btn btn-outline-warning">Edit</button>|<button type="button" id="del" class="rem ms-1 btn btn-outline-danger">Delete</button></div></td>']).draw(false);
    }
})

$(document).on('click', '#save', function () {
    if ($('#check').is(':unchecked')) {
        alert('You should consider checkBox for save the data')
    }

    $('form')[0].reset();

})

$(document).on('click', '#del', function () {
    var remove_record = $(this).parents('tr')
    table.row(remove_record).remove()
    table.draw()
});

$(document).on('click', '#Edit', function () {
    var edit_record = $(this).parents('tr')
    table.row(edit_record).remove();

    var id = edit_record.find('td:eq(0)').text();
    var name = edit_record.find('td:eq(1)').text();
    var contact = edit_record.find('td:eq(2)').text();
    var email = edit_record.find('td:eq(3)').text();

    $('#id').val(id);
    $('#name').val(name);
    $('#contact').val(contact);
    $('#email').val(email);
})

$(document).ready(function () {
    $("#form").validate({

        rules: {

            id: {
                required: true,
                digits: true,
                maxlength: 3,
                minlength: 3,
            },
            name: {
                required: true,
                minlength: 3,
            },

            
            contact: {
                required: true,
                digits: true,
                maxlength: 10,
                minlength: 10,
            },
            email: {
                required: true,
                email: true,
            },
        },

        messages: {

            id: {
                required: "Please enter your id!",
                digits: "Please enter valid Id",
            },
            name: {
                required: "Please enter your name!",
            },
            contact: {
                required: "Please enter your contact number",
                digits: "Contact number should contains only numbers",
                maxlength: "Phone number field accept only 10 digits",
                minlength: "Phone number field accept only 10 digits",
            },
            email: {
                required: "Please enter your email address",
                email: "Please enter your valid email adredd",
            },
        },
    });
});