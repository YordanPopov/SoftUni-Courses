window.addEventListener('load', solution);

function solution() {
  let employeeInput = document.getElementById('employee');
  let categoryOption = document.getElementById('category');
  let urgencyOption = document.getElementById('urgency');
  let teamOption = document.getElementById('team');
  let descInput = document.getElementById('description');
  let previewList = document.querySelector('.preview-list');
  let pendingList = document.querySelector('.pending-list');
  let resolvedList = document.querySelector('.resolved-list');

  let addBtn = document.getElementById('add-btn');

  addBtn.addEventListener('click', onAdd);

  function onAdd(e) {
    e.preventDefault();

    let isValidInput = employeeInput.value == '' ||
      categoryOption.value == '' ||
      urgencyOption.value == '' ||
      teamOption.value == '' ||
      descInput.value == '';

    if (isValidInput) {
      return;
    }

    let liElement = document.createElement('li');
    liElement.classList.add('problem-content');

    let articleElement = document.createElement('article');

    let employeeParagraph = document.createElement('p');
    employeeParagraph.textContent = `From: ${employeeInput.value}`;

    let categoryParagraph = document.createElement('p');
    categoryParagraph.textContent = `Category: ${categoryOption.value}`;

    let urgencyParagraph = document.createElement('p');
    urgencyParagraph.textContent = `Urgency: ${urgencyOption.value}`;

    let assignedParagraph = document.createElement('p');
    assignedParagraph.textContent = `Assigned to: ${teamOption.value}`;

    let descriptionParagraph = document.createElement('p');
    descriptionParagraph.textContent = `Description: ${descInput.value}`;

    let editButton = document.createElement('button');
    editButton.classList.add('edit-btn');
    editButton.textContent = 'Edit';

    let continueBtn = document.createElement('button');
    continueBtn.classList.add('continue-btn');
    continueBtn.textContent = 'Continue';

    articleElement.appendChild(employeeParagraph);
    articleElement.appendChild(categoryParagraph);
    articleElement.appendChild(urgencyParagraph);
    articleElement.appendChild(assignedParagraph);
    articleElement.appendChild(descriptionParagraph);

    liElement.appendChild(articleElement);
    liElement.appendChild(editButton);
    liElement.appendChild(continueBtn);

    previewList.appendChild(liElement);

    let editedEmployee = employeeInput.value;
    let editedCategoty = categoryOption.value;
    let editedUrgency = urgencyOption.value;
    let editedTeam = teamOption.value;
    let editedDesc = descInput.value;

    employeeInput.value = '';
    categoryOption.value = '';
    urgencyOption.value = '';
    teamOption.value = '';
    descInput.value = '';

    addBtn.disabled = true;

    editButton.addEventListener('click', onEdit);
    function onEdit() {
      employeeInput.value = editedEmployee;
      categoryOption.value = editedCategoty;
      urgencyOption.value = editedUrgency;
      teamOption.value = editedTeam;
      descInput.value = editedDesc;

      liElement.remove();
      addBtn.disabled = false;
    }

    continueBtn.addEventListener('click', onContinue);
    function onContinue() {
      let liElementContinue = document.createElement('li');
      liElementContinue.classList.add('problem-content');

      let articleContinueElement = document.createElement('article');
      articleContinueElement = articleElement;

      let resolveBtn = document.createElement('button');
      resolveBtn.classList.add('resolve-btn');
      resolveBtn.textContent = 'Resolve';

      liElementContinue.appendChild(articleContinueElement);
      liElementContinue.appendChild(resolveBtn);
      pendingList.appendChild(liElementContinue);

      liElement.remove();
      addBtn.disabled = true;

      resolveBtn.addEventListener('click', onResolve);
      function onResolve() {
        let liElementResolved = document.createElement('li');
        liElementResolved.classList.add('problem-content');

        let articleResolvedElement = document.createElement('article');
        articleResolvedElement = articleContinueElement;

        let clearBtn = document.createElement('button');
        clearBtn.classList.add('clear-btn');
        clearBtn.textContent = 'Clear';

        liElementResolved.appendChild(articleResolvedElement);
        liElementResolved.appendChild(clearBtn);
        resolvedList.appendChild(liElementResolved);

        liElementContinue.remove();

        clearBtn.addEventListener('click', onClear);
        function onClear() {
          liElementResolved.remove();
          addBtn.disabled = false;
        }
      }
    }
  }
}




