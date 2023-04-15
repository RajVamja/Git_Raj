$(document).ready(function () {
    $('#mytable').DataTable({
        data: arr,
        columns: [
            { data: 'id' },
            { data: 'Email' },
            { data: 'Name' },
            { data: 'DOB' },
            { data: 'Registration' },
            { data: 'Full' },
            { data: 'Half' }
        ],
    });
});

arr = [
    {
        "id": "0",
        "Email": "Tiger Nixon",
        "Name": "System Architect",
        "DOB": "$320,800",
        "Registration": "2011/04/25",
        "Full": "Edinburgh",
        "Half": "5421"
    }]

f = 1
function submit() {

    check=true
    alldetails = {}
    id = f
    var Email = document.getElementById('Email').value
    var Name = document.getElementById('Name').value
    var DOB = document.getElementById('DOB').value
    var Registration = document.getElementById('Registrration').value
    var Full = document.getElementById('Full').value
    var Half = document.getElementById('half').value

    // DOB.getFullYear()
    let dobValue  = new Date(DOB).getFullYear()
    console.log(dobValue);

    var Registrationyear=new Date(Registration).getFullYear()
    console.log(Registrationyear)



    if (Email == "") {
        document.getElementById('emailval').innerText = 'Wrong Email'
        check=false

    }
    else
    {
        document.getElementById('emailval').innerText = ' '
        check=true

    }

    if (Name == "") {
        document.getElementById('nameval').innerText = 'Name cannot be empty '
        check=false
    }
    else
    {
        document.getElementById('nameval').innerText = ' '
        check=true

    }

    if (DOB == "") {
        document.getElementById('DOBval').innerText = 'DOB cannot be empty '
        check=false
    }
    else
    {
        document.getElementById('DOBval').innerText = ' '
        check=true

    }
    if (Registration == "") {
        document.getElementById('Registrrationval').innerText = 'Registration cannot be empty '
        check=false
    }
    else
    {
        document.getElementById('Registrrationval').innerText = ' '
        check=true

    }


    if(Registration == "" || DOB == "" || Name == "" || Email == "") 
    {
        check=false
    }
   
    if((Registrationyear-dobValue) < 15)
    {
        alert('Age should be greater than 15 ')
        check=false
    }
    else
    {
        document.getElementById('DOBval').innerText = ' '
        check=true

    }
    alldetails.id = id
    alldetails.Email = Email
    alldetails.Name = Name
    alldetails.DOB = DOB
    alldetails.Registration = Registration
    alldetails.Full = Full
    alldetails.Half = Half

    for(i=0;i<arr.length;i++)
    {
        // console.log(i)
        // console.log(arr[i].Name)
        if(arr[i].Name==Name || arr[i].Email==Email || arr[i].DOB==DOB || arr[i].Registration==Registration)
        {
            check=false
        }
        if(arr[i].Full==Full)
        {
            check=false
        }
        else if(arr[i].Full!=Full)
        {
            check=true
        }
    }

    if(check)
    {
        arr.push(alldetails)
        f = f + 1
        $('#mytable').DataTable().clear().draw();
        $('#mytable').DataTable().rows.add(arr).draw();
    }
    

}


$("#Full").change(function () {
    // alert( "Handler for .change() called." );
    var Full = document.getElementById('Full').value
    if (Full == "half") {
        half1 = document.getElementById('half')
        half1.removeAttribute('disabled');
    }
    else if (Full == "full") {
        half1 = document.getElementById('half')
        half1.setAttribute('disabled', '');
    }

});





// $(document).ready(function () {
//     $('#mytable').DataTable({
//         columns: [
//             { data: 'id' },
//             { data: 'Email' },
//             { data: 'Name' },
//             { data: 'DOB' },
//             { data: 'Registration' },
//             { data: 'Full' },
//             { data: 'Half' }
//         ],
//     });
// });

// var f = 1;

// function submit() {
//     var check = true;
//     var alldetails = {};
//     var id = f;
//     var Email = $('#Email').val();
//     var Name = $('#Name').val();
//     var DOB = $('#DOB').val();
//     var Registration = $('#Registration').val();
//     var Full = $('#Full').val();
//     var Half = $('#half').val();

//     var dobValue = new Date(DOB).getFullYear();
//     var Registrationyear = new Date(Registration).getFullYear();
//     var currentDate = new Date();
//     var currentYear = currentDate.getFullYear();
//     var age = currentYear - dobValue;

//     $('#emailval').text('');
//     $('#nameval').text('');
//     $('#DOBval').text('');
//     $('#Registrationval').text('');

//     if (Email == "") {
//         $('#emailval').text('Wrong Email');
//         check = false;
//     }

//     if (Name == "") {
//         $('#nameval').text('Name cannot be empty');
//         check = false;
//     }

//     if (DOB == "") {
//         $('#DOBval').text('DOB cannot be empty');
//         check = false;
//     }

//     if (Registration == "") {
//         $('#Registrationval').text('Registration cannot be empty');
//         check = false;
//     }

//     if (age < 15) {
//         alert('Age should be greater than 15');
//         check = false;
//     }

//     alldetails.id = id;
//     alldetails.Email = Email;
//     alldetails.Name = Name;
//     alldetails.DOB = DOB;
//     alldetails.Registration = Registration;
//     alldetails.Full = Full;
//     alldetails.Half = Half;

//     $('#mytable tbody tr').each(function () {
//         var row = $(this);
//         var rowData = row.find('td');
//         if (rowData.eq(2).text() == Name || rowData.eq(1).text() == Email || rowData.eq(3).text() == DOB || rowData.eq(4).text() == Registration) {
//             check = false;
//         }
//         if (rowData.eq(5).text() == Full) {
//             check = false;
//         } else if (rowData.eq(5).text() != Full) {
//             check = true;
//         }
//     });

//     if (check) {
//         $('#mytable').DataTable().row.add(alldetails).draw();
//         f++;
//     }
// }

// $("#Full").change(function () {
//     var Full = $('#Full').val();
//     if (Full == "half") {
//         $('#half').prop('disabled', false);
//     } else if (Full == "full") {
//         $('#half').prop('disabled', true);
//     }
// });