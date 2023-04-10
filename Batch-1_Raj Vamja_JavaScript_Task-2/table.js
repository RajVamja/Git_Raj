let arrayCount = []

function addRow() {
    if (arrayCount.length < 5) {

        let table = document.getElementById("tab");
        let row = table.insertRow();
        let cell1 = row.insertCell(0);
        let cell2 = row.insertCell(1);
        let cell3 = row.insertCell(2);
        let cell4 = row.insertCell(3);
        let cell5 = row.insertCell(4);
        let cell6 = row.insertCell(5);



        cell1.className = "count";
        cell2.innerHTML = `<input type="text" class="name form-control border-0 bg-light"  pattern="[A-Za-z]{3-15}" placeholder="Name" required>`;
        cell3.innerHTML = `<input type="text" class="sub form-control border-0 bg-light"  pattern="[A-Za-z]{3-15}" placeholder="Sub" required>`;
        cell4.innerHTML = `<input type="number" class="mark form-control border-0 bg-light" min="1" max="100" placeholder="Marks" required>`;
        cell5.innerHTML = `<div class="d-flex"><button type="button" class="btn btn-outline-success">Approve</button><button type="button" class="btn btn-outline-danger ms-1">Reject</button></div>`;
        cell6.innerHTML = `<button type="button" onclick="removeBox(this)" class="btn btn-danger mx-5">Remove</button>`;
        arrayCount.push('1')
    }

    else {
        document.getElementById("plus").disabled = true
        alert("You already reached your limits !");
    }

}

function removeBox(del) {
    if (arrayCount.length <= 5) {
        document.getElementById("plus").disabled = false
        // document.getElementById("rem").remove();
        del.parentNode.parentNode.remove(this);
        arrayCount.pop('1')
    }

}


//For Data display

function show() {
    let display = document.getElementById("dis")
    display.innerHTML = ` <tr id="ohd">  <th>No.</th> <th>Name</th> <th>Subject</th> <th>marks</th>  </tr>`

    let num_arr = [];
    let name_arr = [];
    let sub_arr = [];
    let mark_arr = [];

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

    for (i = 1; i < name_arr.length + 1; i++) {

        let row = display.insertRow(i);

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

    }
    return false;

}


//For SearchBar
function mySearch() {
    // Declare variables
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

//sort by name with help of button
function sort_N() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("dis");
    switching = true;
 
    while (switching) {
    
      switching = false;
      rows = table.rows;
    
      for (i = 1; i < (rows.length - 1); i++) {
        shouldSwitch = false;
        x = rows[i].getElementsByTagName("TD")[1];
        y = rows[i + 1].getElementsByTagName("TD")[1];
       
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

//sort by subject with help of button
function sort_S() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("dis");
    switching = true;
 
    while (switching) {
    
      switching = false;
      rows = table.rows;
    
      for (i = 1; i < (rows.length - 1); i++) {
        shouldSwitch = false;
        x = rows[i].getElementsByTagName("TD")[2];
        y = rows[i + 1].getElementsByTagName("TD")[2];
       
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