function search() {
   const searchedText = document.querySelector('#searchText').value;
   const listOfTowns = document.querySelectorAll('#towns li');
   const result = document.getElementById('result');

   let matches = 0;
   for (const town of listOfTowns) {
      if ((town.textContent).toLowerCase().includes(searchedText.toLowerCase()) && searchedText != '') {
         matches++;
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
      } else {
         town.style.textDecoration = '';
         town.style.fontWeight = '';
      }
   }

   searchedText.textContent = '';
   result.textContent = `${matches} matches found`;
}
