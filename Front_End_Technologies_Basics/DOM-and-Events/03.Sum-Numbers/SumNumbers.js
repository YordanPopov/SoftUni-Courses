function calc() {
    let firstNum = Number(document.querySelector('#num1').value);
    let secondNum = Number(document.querySelector('#num2').value);
    let resultBox = document.querySelector('#sum');

    let sum = firstNum + secondNum;
    resultBox.value = sum;
}
