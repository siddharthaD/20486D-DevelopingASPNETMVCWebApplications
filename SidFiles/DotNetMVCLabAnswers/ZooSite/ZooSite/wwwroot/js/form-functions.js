function calculateSum() {
    let rows = document.querySelectorAll("#totalAmount tr .sum");
    let sum = 0;

    for (let i = 0; i < rows.length; i++) {
        sum = sum + parseFloat(parseFloat(rows[i].innerHTML.substring(1, rows[i].innerHTML.length)).toFixed(2));
    }

    document.getElementById("sum").innerHTML = "Total: $" + sum;
}

$(function () {

});