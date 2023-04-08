let table = new DataTable('#tab'); //For dataTable

// For Add table rows
$(document).ready(function () {
    $("#plus").click(function () {
      Swal.fire({
        title: 'Enter Your Details',
        allowOutsideClick: false,
        html:
          '<input id="inp1" placeholder="Please Enter Your Name" class="swal2-input">' +
          '<input id="inp2" placeholder="Please Enter Your Age" class="swal2-input">' +
          '<input id="inp3" placeholder="Please Enter Your Designation" class="swal2-input">',
        preConfirm: function () {
          return new Promise(function (defined) {     //For defined formValues before add in tablerow
            defined ([
              $('#inp1').val(),
              $('#inp2').val(),
              $('#inp3').val()
            ]);
          });
        }
      }).then(function (formValues) {
        if (formValues.value) {
          var age = parseInt(formValues.value[1]);
          if (age >= 20 && age <= 100) {
            $('#tab').DataTable().row.add([
              formValues.value[0],
              formValues.value[1],
              formValues.value[2]
            ]).draw(false);     //redraw method in dataTable
          } else {
            Swal.fire({
              title: 'Invalid Age',    //For invalid age popup box
              allowOutsideClick: false,
              text: 'Please enter an Age between 20 to 100.',
              icon: 'error'
            });
          }
        }
      });
    });
  });
  