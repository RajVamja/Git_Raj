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

});