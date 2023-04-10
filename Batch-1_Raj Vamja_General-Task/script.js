function printContent() {
    document.getElementById("output").innerHTML = "";
    counter = 0;
    let inputs = document.querySelectorAll('input');
    for (let i = 0; i < inputs.length; i++) {
        let input = inputs[i];
        let inputValue = input.value;
        counter++
        // For create a para.
        let div = document.createElement('p');
        div.textContent = `${counter}. ${inputValue}`;
        // For append output on div
        document.getElementById("output").appendChild(div);
    }   
}
