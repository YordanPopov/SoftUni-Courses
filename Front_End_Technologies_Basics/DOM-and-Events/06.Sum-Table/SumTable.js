function sumTable() {
    let tdELements = document.querySelectorAll('table tbody tr td:last-child');

    let sum = 0;
    tdELements.forEach((td) => {
        sum += Number(td.textContent);
    })

    document.getElementById('sum').textContent = sum;
}