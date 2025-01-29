function encodeAndDecodeMessages() {
    let buttons = document.querySelectorAll('#main button');
    let textHolders = document.querySelectorAll('#main textarea');

    buttons[0].addEventListener('click', function () {
        encode(textHolders[0].value);
    });

    buttons[1].addEventListener('click', function (event) {
        decode(textHolders[1].value);
    });

    function encode(text) {
        let encodedStr = '';

        for (let i = 0; i < text.length; i++) {
            encodedStr += String.fromCharCode(text.charCodeAt(i) + 1);
        }

        textHolders[1].value = encodedStr;
        textHolders[0].value = '';
    }

    function decode(text) {
        let decodedStr = '';

        for (let i = 0; i < text.length; i++) {
            decodedStr += String.fromCharCode(text.charCodeAt(i) - 1);
        }

        textHolders[1].value = decodedStr;
    }
}