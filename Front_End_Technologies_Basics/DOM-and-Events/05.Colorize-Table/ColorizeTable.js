function colorize() {
    let rowElements = document.querySelectorAll('table tr:nth-child(even)');

    rowElements.forEach((tr) => {
        tr.style.backgroundColor = 'Teal';
    });
}