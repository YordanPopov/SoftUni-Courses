window.addEventListener('load', solve);

function solve() {
    let carModelInput = document.getElementById('car-model');
    let carYearInput = document.getElementById('car-year');
    let partNameInput = document.getElementById('part-name');
    let partNumInput = document.getElementById('part-number');
    let conditionInput = document.getElementById('condition');

    document.getElementById('next-btn')
        .addEventListener('click', () => {
            const currentDate = new Date();
            const currentYear = currentDate.getFullYear();
            let isValidYear = Number(carYearInput.value) > 1990 && currentYear > Number(carYearInput.value);

            if (!isValidYear || !carModelInput.value || !partNameInput.value || !partNumInput.value || !conditionInput.value) {
                return;
            }

            document.getElementById('part-info').style.display = 'block';
            document.getElementById('info-car-model').textContent = carModelInput.value;
            document.getElementById('info-car-year').textContent = carYearInput.value;
            document.getElementById('info-part-name').textContent = partNameInput.value;
            document.getElementById('info-part-number').textContent = partNumInput.value;
            document.getElementById('info-condition').textContent = conditionInput.value;
            document.getElementById('next-btn').disabled = true;

            carModelInput.value = '';
            carYearInput.value = '';
            partNameInput.value = '';
            partNumInput.value = '';
            conditionInput.value = '';
        });

    document.getElementById('edit-btn')
        .addEventListener('click', () => {
            carModelInput.value = document.getElementById('info-car-model').textContent;
            carYearInput.value = document.getElementById('info-car-year').textContent;
            partNameInput.value = document.getElementById('info-part-name').textContent;
            partNumInput.value = document.getElementById('info-part-number').textContent;
            conditionInput.value = document.getElementById('info-condition').textContent;
            document.getElementById('part-info').style.display = 'none';
            document.getElementById('next-btn').disabled = false;
        });

    document.getElementById('confirm-btn')
        .addEventListener('click', (e) => {
            document.getElementById('part-info').style.display = 'none';
            document.getElementById('confirm-order').style.display = 'block';
        });

    document.getElementById('new-btn')
        .addEventListener('click', () => {
            document.getElementById('confirm-order').style.display = 'none';
            document.getElementById('next-btn').disabled = false;
        });
};




