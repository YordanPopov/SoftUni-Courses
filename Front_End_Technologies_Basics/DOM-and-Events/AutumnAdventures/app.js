window.addEventListener('load', solve);

function solve() {
    let hourInput = document.getElementById('time');
    let dateInput = document.getElementById('date');
    let placeInput = document.getElementById('place');
    let eventNameInput = document.getElementById('event-name');
    let contactsInput = document.getElementById('email');

    let checkList = document.getElementById('check-list');
    let upcomingList = document.getElementById('upcoming-list');
    let finishedList = document.getElementById('finished-list');

    let addEventBtn = document.getElementById('add-btn');

    addEventBtn.addEventListener('click', onAdd);
    function onAdd(e) {
        e.preventDefault();

        if (hourInput.value == "" || dateInput.value == "" || placeInput.value == "" || eventNameInput.value == "" || contactsInput.value == "") {
            return;
        }

        let liElement = document.createElement('li');
        liElement.classList.add('event-content');

        let articleElement = document.createElement('article');

        let timeParagraph = document.createElement('p');
        timeParagraph.textContent = `Begins: ${dateInput.value} at: ${hourInput.value}`;

        let placeParagraph = document.createElement('p');
        placeParagraph.textContent = `In: ${placeInput.value}`;

        let eventNameParagraph = document.createElement('p');
        eventNameParagraph.textContent = `Event: ${eventNameInput.value}`;

        let contactsParagraph = document.createElement('p');
        contactsParagraph.textContent = `Contact: ${contactsInput.value}`;

        let editBtn = document.createElement('button');
        editBtn.classList.add('edit-btn');
        editBtn.textContent = 'Edit';

        let continueBtn = document.createElement('button');
        continueBtn.classList.add('continue-btn');
        continueBtn.textContent = 'Continue';

        articleElement.appendChild(timeParagraph);
        articleElement.appendChild(placeParagraph);
        articleElement.appendChild(eventNameParagraph);
        articleElement.appendChild(contactsParagraph);
        liElement.appendChild(articleElement);
        liElement.appendChild(editBtn);
        liElement.appendChild(continueBtn);
        checkList.appendChild(liElement);

        let editedHour = hourInput.value;
        let editedDate = dateInput.value;
        let editedPlace = placeInput.value;
        let editedEventName = eventNameInput.value;
        let editedContacts = contactsInput.value;

        addEventBtn.disabled = true;
        hourInput.value = '';
        dateInput.value = '';
        placeInput.value = '';
        eventNameInput.value = '';
        contactsInput.value = '';

        editBtn.addEventListener('click', onEdit);
        function onEdit() {
            hourInput.value = editedHour;
            dateInput.value = editedDate;
            placeInput.value = editedPlace;
            eventNameInput.value = editedEventName;
            contactsInput.value = editedContacts;

            liElement.remove();
            addEventBtn.disabled = false;
        }

        continueBtn.addEventListener('click', onContinue);
        function onContinue() {
            let upcomingLiElement = document.createElement('li');
            upcomingLiElement.classList.add('event-content');

            let upcomingArticleElement = document.createElement('article');
            upcomingArticleElement = articleElement;

            let finishedBtn = document.createElement('button');
            finishedBtn.classList.add('finished-btn');
            finishedBtn.textContent = 'Move to Finished';

            upcomingLiElement.appendChild(upcomingArticleElement);
            upcomingLiElement.appendChild(finishedBtn);
            upcomingList.appendChild(upcomingLiElement);

            liElement.remove();
            addEventBtn.disabled = false;

            finishedBtn.addEventListener('click', onFinish);
            function onFinish() {
                let finishLiElement = document.createElement('li');
                finishLiElement.classList.add('event-content');

                let finishArticleElement = document.createElement('article');
                finishArticleElement = upcomingArticleElement;

                finishLiElement.appendChild(finishArticleElement);
                finishedList.appendChild(finishLiElement);

                upcomingLiElement.remove();

                document.getElementById('clear').addEventListener('click', () => {
                    finishLiElement.remove();
                });
            }
        }
    }
}




