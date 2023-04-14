let table = new DataTable('#myTable');

$('#save').on('click', function () {

    var Id = $('#id').val();
    var name = $('#name').val();
    var contact = $('#contact').val();
    var email = $('#mail').val();
    var isValide = true;

    var reg_identity = /^[0-9]{1,}/
    var reg_alpha = /^[A-Za-z]+/
    var reg_mobile = /^[0-9]{10}$/
    var reg_mail = /^[A-Za-z0-9]+@+[A-Za-z]+\.+[A-Za-z]{2,}/

    // VALIDATION FOR ID
    if (Id == '') {
        $('#id').siblings("span").text("Please enter your id").css("color", "red")
        isValide = false
    }
    else if (!Id.match(reg_identity)) {
        $('#id').siblings("span").text("Please enter valid id number").css("color", "red")
        isValide = false
    }
    else {
        $('#id').siblings("span").text(" ")
    }

    // VALIDATION FOR NAME
    if (name == '') {
        $('#name').siblings("span").text("Please enter your name").css("color", "red")
        isValide = false
    }
    else if (!name.match(reg_alpha)) {
        $('#name').siblings("span").text("Name must be charactors").css("color", "red")
        isValide = false
    }
    else {
        $('#name').siblings("span").text(" ")
    }

    // VALIDATION FOR CONTACT NUMBER 
    if (contact == '') {
        $('#contact').siblings("span").text("Please enter your mobile number").css("color", "red")
        isValide = false
    }
    else if (!contact.match(reg_mobile)) {
        $('#contact').siblings("span").text("Mobile number mus be valid ex.(number should be 10 digits)").css("color", "red")
        isValide = false
    }
    else {
        $('#contact').siblings("span").text(" ")
    }

    // VALIDATION FOR EMAIL 
    if (email == '') {
        $('#mail').siblings("span").text("Please enter your email address").css("color", "red")
        isValide = false
    }
    else if (!email.match(reg_mail)) {
        $('#mail').siblings("span").text("Email format should be 'abc123@gmail.com'").css("color", "red")
        isValide = false
    }
    else {
        $('#mail').siblings("span").text(" ")
    }

    // FOR DATA BINDING
    if (isValide) {
        table.row.add([Id, name, contact, email, '<div class="d-flex"><td> <button type="button" id="Edit" class="Edit me-1 btn btn-outline-warning">Edit</button>|<button type="button" id="del" class="rem ms-1 btn btn-outline-danger">Delete</button></td></div>'])
        .draw(false);
       
        $('#exampleModal').modal('hide');
        $('#form').trigger('reset')
    }
    else{
        $('#exampleModal').modal('show');

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

