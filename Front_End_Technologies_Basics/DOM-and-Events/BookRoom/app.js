window.addEventListener("load", solve);

function solve() {
    let roomSizeInput = document.getElementById('room-size');
    let timeSlotInput = document.getElementById('time-slot');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone-number');

    let bookRoomBtn = document.getElementById('book-btn');
    let editBtn = document.getElementById('edit-btn');
    let confirmBtn = document.getElementById('confirm-btn');
    let backBtn = document.getElementById('back-btn');

    bookRoomBtn.addEventListener('click', onShow);
    editBtn.addEventListener('click', onEdit);

    confirmBtn.addEventListener('click', () => {
        document.getElementById('preview').style.display = 'none';
        document.getElementById('confirmation').style.display = 'block';
    });

    backBtn.addEventListener('click', () => {
        document.getElementById('confirmation').style.display = 'none';
        bookRoomBtn.disabled = false;
    });

    function onShow(e) {
        e.preventDefault();
        if (roomSizeInput.value == "" || timeSlotInput.value == "" || fullNameInput.value == "" || emailInput.value == "" || phoneNumberInput.value == "") {
            return;
        }

        document.getElementById('preview-room-size').textContent = roomSizeInput.value;
        document.getElementById('preview-time-slot').textContent = timeSlotInput.value;
        document.getElementById('preview-full-name').textContent = fullNameInput.value;
        document.getElementById('preview-email').textContent = emailInput.value;
        document.getElementById('preview-phone-number').textContent = phoneNumberInput.value;

        document.getElementById('preview').style.display = 'block';
        bookRoomBtn.disabled = true;

        roomSizeInput.value = '';
        timeSlotInput.value = '';
        fullNameInput.value = '';
        emailInput.value = '';
        phoneNumberInput.value = '';
    }

    function onEdit() {
        roomSizeInput.value = document.getElementById('preview-room-size').textContent;
        timeSlotInput.value = document.getElementById('preview-time-slot').textContent;
        fullNameInput.value = document.getElementById('preview-full-name').textContent;
        emailInput.value = document.getElementById('preview-email').textContent;
        phoneNumberInput.value = document.getElementById('preview-phone-number').textContent;

        document.getElementById('preview').style.display = 'none';
        bookRoomBtn.disabled = false;
    }
}
