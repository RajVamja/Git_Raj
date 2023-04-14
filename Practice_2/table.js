let table = new DataTable('#myTable');

// $(document).on('click', '#save', function () {
//     var id = $('.id').val();
//     var name = $('.name').val();
//     var contact = $('.contact').val();
//     var email = $('.email').val();

//     if (id != "" && name != "" && contact != "" && email != "") {
//         table.row.add([id, name, contact, email, '<div class="d-flex"><td> <button type="button" id="Edit" class="Edit me-1 btn btn-outline-warning">Edit </button>|<button type="button" id="del" class="rem ms-1 btn btn-outline-danger">Delete</button></div></td>']).draw(false);
//     }
// })

$(document).on('click', '#add', function () {
    $('#maintable').append(`<tr>
        <td><div class="mb-3"><input type="text" name="id" class="id form-control" id="id" required></div></td>
        <td><div class="mb-3"><input type="text" name="name" class="name form-control" id="name"  required></div></td>
        <td><div class="mb-3"><input type="text" name="contact" class="contact form-control" id="contact"  required></div></td>
        <td><div class="mb-3"><input type="text" name="email" class="email form-control" id="email" required></div></td>
        </tr>`);
});


$(document).on('click', '#save', function () {
    // Select all rows in the table
    var rows = $('form .table tbody tr');
    table.clear();

    // Iterate over each row
    rows.each(function () {
        // Extract the values for the columns
        var id = $(this).find('.id').val();
        var name = $(this).find('.name').val();
        var contact = $(this).find('.contact').val();
        var email = $(this).find('.email').val();

        console.log(id, name, contact, email);
        if (id != "" && name != "" && contact != "" && email != "") {
            table.row.add([id, name, contact, email, '<div class="d-flex"><td> <button type="button" id="Edit" class="Edit me-1 btn btn-outline-warning">Edit</button>|<button type="button" id="del" class="rem ms-1 btn btn-outline-danger">Delete</button></td></div>'])
                .draw(false);
        }
    });
    $('#form').trigger('reset');
});

$(document).on('click', '#del', function () {
    var delete_record = $(this).parents('tr')
    table.row(delete_record).remove();
    table.draw();
})


// For edit
$(document).on('click', '#Edit', function () {
    var edit_rec = $(this).parents('tr');
    table.row(edit_rec).remove()

    var id = edit_rec.find('td:eq(0)').text();
    var name = edit_rec.find('td:eq(1)').text();
    var contact = edit_rec.find('td:eq(2)').text();
    var email = edit_rec.find('td:eq(3)').text();

    $('#id').val(id);
    $('#name').val(name);
    $('#contact').val(contact);
    $('#email').val(email);
})


function Search() {
    let inputvalue = document.getElementById("searchbar").value.toUpperCase();
    let gettr = document.getElementById("myTable").rows;
    for (let i = 1; i < gettr.length; i++) {
        let gettd = gettr[i].cells[1];
        if (gettd) {
            let text = gettd.textContent.toUpperCase();
            if (text.indexOf(inputvalue) > -1) {
                gettr[i].style.display = ''
            }
            else {
                gettr[i].style.display = 'none'
            }

        }
    }
}
