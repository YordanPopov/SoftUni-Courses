function lockedProfile() {
    let buttons = document.getElementsByTagName('button');

    for (const button of buttons) {
        button.addEventListener('click', (e) => {
            let divChildren = Array.from(e.target.parentElement.children);
            let locked = divChildren.at(2).checked;

            if (!locked) {
                let hiddenElement = e.target.previousElementSibling;

                if (button.textContent == 'Show more') {
                    hiddenElement.style.display = 'inline';
                    button.textContent = 'Hide it'
                } else {
                    hiddenElement.style.display = '';
                    button.textContent = 'Show more'
                }
            }
        });
    }
}