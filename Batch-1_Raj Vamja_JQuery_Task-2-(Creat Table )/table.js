// let form = document.getElementById('myForm')
// form.addEventListener('submit', (e) => {
//     e.preventDefault()
// })

// $(document).ready(function(){
//     $("#load").click(function(){
//       var number_of_rows = $('#rows').val();
//       var number_of_cols = $('#cols').val();
//       var table_body = '<table border="1">';
//       for(var i=0;i<number_of_rows;i++){
//         table_body+='<tr>';

//         for(var j=0;j<number_of_cols;j++){
//             table_body +='<td>';
//             table_body +='Table data';
//             table_body +='</td>';
//         }
//         table_body+='</tr>';
//       }
//         table_body+='</table>';
//        $('#tableDiv').html(table_body);
//     });
// });


$(document).ready(function() {
    $("#load").click(function() {
      var number_of_rows = $('#rows').val();
      var number_of_cols = $('#cols').val();
      var table = $('<table>');
      table.addClass('table')
      for (var i = 0; i < number_of_rows; i++) {
        var row = $('<tr>');
        for (var j = 0; j < number_of_cols; j++) {
          var cell = $('<td>', {'text': 'Row ' + (i+1) + ', Col ' + (j+1)});
          row.append(cell);
        }
        table.append(row);
      }
      $('#tab').html(table);
    });
  });
  