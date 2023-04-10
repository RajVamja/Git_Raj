let table = new DataTable('#myTable');

$('#save').on('click', function () {

    var Id = $('#id').val();
    var name = $('#name').val();
    var contact = $('#contact').val();
    var email = $('#mail').val();
    var check = $('#check').val();
    if (Id != "" && name != "" && contact != "" && email != "") {
        table.row.add([Id, name, contact, email, check]).draw(false);
        $('#myTable tbody tr td').last().append('<div class="d-flex"><td> <button type="button" id="Edit" class="Edit me-1 btn btn-outline-warning">Edit</button>|<button type="button" id="del" class="rem ms-1 btn btn-outline-danger">Delete</button></div></td>');
    }
});

// Delete data from datatable
// function DeleteRow(btn) {
//     //when we delete the row of datatable
//     var remove = $(btn).parents('tr');
//     table.row(remove).remove()
//     table.draw()
// }

$(document).on('click', '#del', function () {
    let Row = $(this).parents('tr')
    table.row(Row).remove()
    table.draw()
})


// For reset records when submit the form
$("#exampleModal").on('hidden.bs.modal', function (e) {
    $("#exampleModal form")[0].reset();
});

$(document).on("click", "#Edit", function () {
    var currentRow = $(this).parents('tr');
    table.row(currentRow).remove()

    // Get the data from the row
    var Id = currentRow.find('td:eq(0)').text();
    var name = currentRow.find('td:eq(1)').text();
    var contact = currentRow.find('td:eq(2)').text();
    var email = currentRow.find('td:eq(3)').text();

    // Populate the modal form fields with the row data
    $('#id').val(Id);
    $('#name').val(name);
    $('#contact').val(contact);
    $('#mail').val(email);

    // Show the modal
    $('#exampleModal').modal('show');

});

$('#save').on('click', function() {
    $('#exampleModal').modal('hide');
})

$('input').on('blur', function () {
    if ($("#form").valid()) {
        $('#save').prop('disabled', false);
    } else {
        $('#save').prop('disabled', true);
    }
});