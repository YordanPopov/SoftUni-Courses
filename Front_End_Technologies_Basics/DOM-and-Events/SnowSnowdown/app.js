window.addEventListener("load", solve);

function solve() {
  let nameInput = document.getElementById('snowman-name');
  let heightInput = document.getElementById('snowman-height');
  let locationInput = document.getElementById('location');
  let creatorInput = document.getElementById('creator-name');
  let specAttInput = document.getElementById('special-attribute');
  let addBtn = document.querySelector('button.add-btn');

  addBtn.addEventListener('click', add);

  function add(e) {
    e.preventDefault();

    if (nameInput.value == "" || heightInput.value == "" || locationInput.value == ""
      || creatorInput.value == "" || specAttInput.value == "") {
      return;
    }

    const li = document.createElement('li');
    li.classList.add('snowman-info');

    const div = document.createElement('div');
    div.classList.add('btn-container');

    const editBtn = document.createElement('button');
    editBtn.textContent = "Edit";
    editBtn.classList.add('edit-btn');

    const nextBtn = document.createElement('button');
    nextBtn.textContent = "Next";
    nextBtn.classList.add('next-btn');

    div.appendChild(editBtn);
    div.appendChild(nextBtn);

    let article = document.createElement('article');

    const infoFromInput = [
      { label: 'Name', value: nameInput.value },
      { label: 'Height', value: heightInput.value },
      { label: 'Location', value: locationInput.value },
      { label: 'Creator', value: creatorInput.value },
      { label: 'Attribute', value: specAttInput.value }
    ];

    infoFromInput.forEach(currentInput => {
      const p = document.createElement('p');
      p.textContent = `${currentInput.label}: ${currentInput.value}`
      article.appendChild(p);
    });

    li.appendChild(article);
    li.appendChild(div);
    document.querySelector('.snowman-preview').appendChild(li);
    document.querySelector('button.add-btn').disabled = true;

    let editedName = nameInput.value;
    let editedHeight = heightInput.value;
    let editedLocation = locationInput.value;
    let editedCreator = creatorInput.value;
    let editedAtt = specAttInput.value;

    nameInput.value = '';
    heightInput.value = '';
    locationInput.value = '';
    creatorInput.value = '';
    specAttInput.value = '';

    document.querySelector('button.edit-btn').addEventListener('click', () => {
      nameInput.value = editedName;
      heightInput.value = editedHeight;
      locationInput.value = editedLocation;
      creatorInput.value = editedCreator;
      specAttInput.value = editedAtt;

      li.remove();
      addBtn.disabled = false;
    });

    document.querySelector('button.next-btn').addEventListener('click', () => {
      let liShowList = document.createElement('li');
      let articleContent = document.createElement('article');
      articleContent = article;

      let sendBtn = document.createElement('button');
      sendBtn.classList.add('send-btn');
      sendBtn.textContent = 'Send';
      articleContent.appendChild(sendBtn);
      liShowList.appendChild(articleContent);

      li.remove();
      document.querySelector('.snow-list').appendChild(liShowList);

      sendBtn.addEventListener('click', () => {
        document.getElementById('hero').remove();
        let backBtn = document.createElement('button');
        backBtn.textContent = 'Back';
        document.getElementById('back-img').hidden = false;
        document.querySelector(".body").appendChild(backBtn);

        backBtn.addEventListener('click', () => {
          window.location.reload();
        });
      });
    });
  }
}
