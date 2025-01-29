function extractText() {
    let liElements = document.querySelectorAll('#items li');
    let textAreaElement = document.querySelector('#result');

    let text = "";
    for (const li of liElements) {
        text += `${li.textContent}\n`;
    }

    textAreaElement.value = text;
}