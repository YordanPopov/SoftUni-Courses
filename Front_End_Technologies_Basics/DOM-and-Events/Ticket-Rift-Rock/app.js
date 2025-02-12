window.addEventListener("load", solve);

function solve() {
    let numberOfTicketsInput = document.getElementById('num-tickets');
    let seatingPreferenceOption = document.getElementById('seating-preference');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone-number');

    let ticketPreview = document.getElementById('ticket-preview');
    let purchaseSuccess = document.getElementById('purchase-success');

    let numOfTickets = document.getElementById('purchase-num-tickets');
    let seatingPreference = document.getElementById('purchase-seating-preference');
    let fullName = document.getElementById('purchase-full-name');
    let email = document.getElementById('purchase-email');
    let phoneNumber = document.getElementById('purchase-phone-number');

    let purchaseBtn = document.getElementById('purchase-btn');
    let editBtn = document.getElementById('edit-btn');
    let buyBtn = document.getElementById('buy-btn');
    let backBtn = document.getElementById('back-btn');

    purchaseBtn.addEventListener('click', showTicketPreview);
    editBtn.addEventListener('click', toEdit);

    buyBtn.addEventListener('click', () => {
        ticketPreview.style.display = 'none';
        purchaseSuccess.style.display = 'block';
    });

    backBtn.addEventListener('click', () => {
        purchaseSuccess.style.display = 'none';
        purchaseBtn.disabled = false;
    });


    function showTicketPreview() {
        if (numberOfTicketsInput.value === "" || seatingPreferenceOption.value === "seating-preference"
            || fullNameInput.value === "" || emailInput.value === "" || phoneNumberInput.value === "") {
            return;
        }

        numOfTickets.textContent = numberOfTicketsInput.value;
        seatingPreference.textContent = seatingPreferenceOption.value;
        fullName.textContent = fullNameInput.value;
        email.textContent = emailInput.value;
        phoneNumber.textContent = phoneNumberInput.value;

        ticketPreview.style.display = 'block';
        purchaseBtn.disabled = true;

        numberOfTicketsInput.value = '';
        seatingPreferenceOption.value = 'seating-preference';
        fullNameInput.value = '';
        emailInput.value = '';
        phoneNumberInput.value = ''
    };

    function toEdit() {
        numberOfTicketsInput.value = numOfTickets.textContent;
        seatingPreferenceOption.value = seatingPreference.textContent;
        fullNameInput.value = fullName.textContent;
        emailInput.value = email.textContent;
        phoneNumberInput.value = phoneNumber.textContent;

        purchaseBtn.disabled = false;
    };
}