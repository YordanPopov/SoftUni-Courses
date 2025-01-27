function toggle() {
    const extraText = document.getElementById('extra');
    const button = document.getElementsByClassName('button')[0];

    if (extraText.style.display === 'none') {
        button.textContent = 'Less';
        extraText.style.display = 'block';
    } else {
        button.textContent = 'More';
        extraText.style.display = 'none';
    }
}
