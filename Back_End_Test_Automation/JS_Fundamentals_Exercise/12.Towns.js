/**
 * 
 * @param {Array} arrayData 
 */
function getTownsTable(arrayData) {
     const townData = [];

     for (let dataText of arrayData) {
        const splittedData = dataText.split(' | ');
        let townName = splittedData[0];
        let latitude = Number (splittedData[1]).toFixed(2);
        let longitude = Number (splittedData[2]).toFixed(2);

        townData.push({
            town: townName,
            latitude: latitude,
            longitude: longitude
        })
     }

     townData.forEach((town) => console.log(town));
}

getTownsTable(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
getTownsTable(['Plovdiv | 136.45 | 812.575']);