function extract(content) {
    let textHolder = document.querySelector('#content').textContent;

    const regex = /\(([^)]+)\)/g;
    let matches = [];
    let match;

    while ((match = regex.exec(textHolder)) !== null) {
        matches.push(match.at(1));
    }

    //console.log(matches.join('; '));

    return matches.join('; ');
}