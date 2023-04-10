// let arrayCount = []

let form = document.getElementById('myForm')
// console.log(form);
form.addEventListener('submit', (e) => {
    e.preventDefault()
    show();
})

$(document).ready(function () {
    $("input").focus(function () {
        $(this).css("background-color", "rgb(0,0,255,0.1)");
    });
    $("input").blur(function () {
        $(this).css("background-color", "white");
    });
});

function addRow() {
    // if (arrayCount.length < 5) 
    {
        let table = document.getElementById("tab");
        let row = table.insertRow();
        row.setAttribute("class", "bd")
        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        let cell3 = row.insertCell(2);
        let cell4 = row.insertCell(3);
        let cell5 = row.insertCell(4);
        let cell6 = row.insertCell(5);

        cell1.className = "count";
        cell2.innerHTML = `<input type="text" class="name form-control border-0 bg-light"  pattern="[A-Za-z ]{3,15}" placeholder="Name"> `;
        cell3.innerHTML = `<input type="text" class="sub form-control border-0 bg-light"  pattern="[A-Za-z ]{3,15}" placeholder="Sub">`;
        cell4.innerHTML = `<input type="number" class="mark form-control border-0 bg-light" min="1" max="100" placeholder="Marks">`;
        cell5.innerHTML = `<div class="d-flex"><button type="button" onclick="appbtn(this)" class="app">Approve</button><button type="button" onclick="rejbtn(this)" class="app ms-1">Reject</button></div>`;
        cell6.innerHTML = `<button type="button" onclick="removeBox(this)" class="btn btn-danger mx-5">Remove</button>`;
        // arrayCount.push('1')
    }
    // else {
    //     document.getElementById("plus").disabled = true
    //     alert("You already reached your limits !");
    // }
}

//For perform action on approve and reject button
function appbtn(btnaction) {
    btnaction.nextElementSibling.style.backgroundColor = ""
    btnaction.nextElementSibling.style.color = "black"
    btnaction.style.backgroundColor = "#198754"
    btnaction.style.color = "white"

    if (btnaction.style.backgroundColor == "rgb(25, 135, 84)") {
        // console.log(btnaction.parentNode.parentNode.parentNode)
        btnaction.parentNode.parentNode.parentNode.classList.add("showResult");
    }

}
function rejbtn(btnaction) {
    btnaction.previousElementSibling.style.backgroundColor = ""
    btnaction.previousElementSibling.style.color = "black"
    btnaction.style.backgroundColor = "#dc3545"
    btnaction.style.color = "white"

    if (btnaction.style.backgroundColor == "rgb(220, 53, 69)") {
        // console.log(btnaction.parentNode.parentNode.parentNode)
        btnaction.parentNode.parentNode.parentNode.classList.remove("showResult");
    }

}


// For remove the table row
function removeBox(del) {

    swal({
        title: "Are you sure?",
        text: "You want to delet this record?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal({
                    title: "Hurraahh!",
                    text: "Your record has been deleted",
                    icon: "success",
                });
                document.getElementById("plus").disabled = false
                del.parentNode.parentNode.remove(this);
                // show();
                // arrayCount.pop('1')
            } else {
                swal("Oops!", "Sorry, Your record is safe as it is.", "error");
            }
        });
    // // if (arrayCount.length <= 5) {
    // if (confirm("You really want to delet this record ?")) {
    //     document.getElementById("plus").disabled = false
    //     // document.getElementById("rem").remove();
    //     del.parentNode.parentNode.remove(this);
    //     // show();
    //     arrayCount.pop('1')
    // }
    // else {
    //     alert("You select Cancel, That's why your record remain as it is...");
    // }
    // // }
}

//For Data display
let num_arr = [];
let name_arr = [];
let sub_arr = [];
let mark_arr = [];

function validateForm() {
    let flag = true;
    let Name = document.getElementsByClassName('name');
    let Sub = document.getElementsByClassName('sub');
    let Mark = document.getElementsByClassName('mark');

    // console.log(Name[1])
    for (let i = 0; i < Name.length; i++) {

        // console.log(Name[i].value);
        if (Name[i].value == "" || Sub[i].value == "" || Mark[i].value == "") {
            { swal("oops!", "All inputs must be filled!", "warning"); }
            // alert("All inputs are must be filled!");
            flag = false;
            return flag
        }
        else {
            flag = true;
        }
    }
    if (flag) {
        document.getElementById('dis').style.display = 'table';
        document.getElementById('diss').style.display = 'table';
    }
}


function show() {
    validateForm()

    let display = document.getElementById("dis")

    display.innerHTML = `<tr id="ohd">  <th>No.</th> <th>Name</th> <th>Subject</th> <th>marks</th>  </tr>`


    let num = document.querySelectorAll(".num");
    let name = document.querySelectorAll(".name");
    let sub = document.querySelectorAll(".sub");
    let mark = document.querySelectorAll(".mark");


    for (i = 0; i < num.length; i++) {
        num_arr.push(num[i].value);
    }
    for (i = 0; i < name.length; i++) {
        name_arr.push(name[i].value);
    }
    for (i = 0; i < sub.length; i++) {
        sub_arr.push(sub[i].value);
    }
    for (i = 0; i < mark.length; i++) {
        mark_arr.push(mark[i].value);
    }

    let count = 0;
    let mainTable = Array.from(document.getElementById('tab').getElementsByClassName('bd'));
    for (i = 1; i < name_arr.length + 1; i++) {


        let selected = (mainTable[i - 1].classList.contains('showResult'));
        if (selected) {
            count++;
            let row = display.insertRow(count);
            console.log(row);
            if (mark_arr[i - 1] < 35) {
                row.style.backgroundColor = "rgb(255,0,0,0.5)";
            }
            else {
                row.style.backgroundColor = "none";
            }

            let num_cell = row.insertCell(0);
            let name_cell = row.insertCell(1);
            let sub_cell = row.insertCell(2);
            let mark_cell = row.insertCell(3);

            num_cell.innerHTML = i;
            name_cell.innerHTML = name_arr[i - 1];
            sub_cell.innerHTML = sub_arr[i - 1];
            mark_cell.innerHTML = mark_arr[i - 1];

            // let write = document.getElementById("diss")
            // write.innerHTML = `<tr id="oohd">  <th>No.</th> <th>Name</th> <th>Percentage</th>  </tr>`
        }
    }
    getPercentage();
    num_arr.length = 0
    name_arr.length = 0
    sub_arr.length = 0
    mark_arr.length = 0
}


//For percentage table
function getPercentage() {
    // let display = document.getElementById("dis")
    let write = document.getElementById("diss")
    // console.log(display.rows.length)
    write.innerHTML = `<tr id="oohd">  <th>No.</th> <th>Name</th> <th>Percentage</th> </tr>`

    // const set = new Set(name_arr);
    // const duplicates = name_arr.filter(item => {
    //     if (set.has(item)) {
    //         set.delete(item);
    //     } else {
    //         return item;
    //     }
    // });
    // console.log(duplicates);

    const count = {};
    name_arr.forEach(element => {
        count[element] = (count[element] || 0) + 1;
    });
    // console.log(count);

    function uniq(name_arr) {
        var seen = {};
        return name_arr.filter(function (item) {
            return seen.hasOwnProperty(item) ? false : (seen[item] = true);
        });
    }

    let mark_array = document.querySelectorAll(".mark");
    let name_array = document.querySelectorAll(".name");
    let tempArrN = [];
    let tempArrM = [];
    tempArrN = name_arr
    tempArrM = mark_arr

    name_arr = uniq(name_arr)
    // console.log(name_arr)
    let marks = [];
    for (let i = 0; i < name_arr.length; i++) {
        // console.log(name_arr[i])
        var mark = 0;
        var counter = 0;
        for (let j = 0; j < tempArrN.length; j++) {

            if (name_arr[i] == name_array[j].value) {
                mark += parseInt(mark_array[j].value)
                counter++
            }
        }
        marks.push((mark / counter) + "%");
    }
    // console.log(name_arr)
    // console.log(marks)
    let num = document.querySelectorAll(".num");

    let mainTable = Array.from(document.getElementById('tab').getElementsByClassName('bd'));
    for (i = 0; i < num.length; i++) {
        num_arr.push(num[i].value);
    }
    // for (i = 0; i < name.length; i++) {
    //     name_arr.push(name[i].value);
    // }

    for (i = 1; i < name_arr.length + 1; i++) {
        let selected = (mainTable[i - 1].classList.contains('showResult'));
        if (selected) {
            let row = write.insertRow();

            if (mark_arr[i - 1] < 35) {
                row.style.backgroundColor = "rgb(255,0,0,0.5)";
            }
            else {
                row.style.backgroundColor = "none";
            }


            let num_cell = row.insertCell(0);
            let name_cell = row.insertCell(1);
            let per_cell = row.insertCell(2);


            num_cell.innerHTML = i;
            name_cell.innerHTML = name_arr[i - 1];
            per_cell.innerHTML = marks[i - 1];
        }
    }
}


//For SearchBar
function mySearch() {
    var input, filter, table, tr, tdName, tdSub, i, txtValue;
    input = document.getElementById("find");
    filter = input.value.toUpperCase();
    table = document.getElementById("dis");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 1; i < tr.length; i++) {
        tdName = tr[i].getElementsByTagName("td")[1];
        tdSub = tr[i].getElementsByTagName("td")[2];
        if (tdName) {
            txtValue = tdName.textContent || tdName.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
        if (tdSub) {
            txtValue = tdSub.textContent || tdSub.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            }
        }
    }
}

//Sort by name with help of Sort by Name button
function sort_N() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("dis");
    switching = true;

    while (switching) {
        switching = false;
        rows = table.rows;

        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("td")[1];
            y = rows[i + 1].getElementsByTagName("td")[1];

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

//Sort by name with help of Sort by Subject button
function sort_S() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("dis");
    switching = true;

    while (switching) {
        switching = false;
        rows = table.rows;

        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("td")[2];
            y = rows[i + 1].getElementsByTagName("td")[2];

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


