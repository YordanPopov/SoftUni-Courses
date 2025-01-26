function solve() {
  let text = document.getElementById('text').value;
  let nameConvention = document.getElementById('naming-convention').value;
  let resultElement = document.getElementById('result');

  const words = text.trim().toLowerCase().split(" ");
  let result = '';
  switch (nameConvention) {
    case 'Camel Case':
      result = words.map((word, index) => {
        if (index === 0) {
          return word;
        } else {
          return word.charAt(0).toUpperCase() + word.slice(1);
        }
      }).join("");
      break;
    case 'Pascal Case':
      result = words.map((word) => {
        return word.charAt(0).toUpperCase() + word.slice(1);
      }).join("");
      break;
    default:
      result = "Error!";
      break;
  }

  resultElement.textContent = result;

}