function registerHeroes(heroesData) {
    let heroes = [];

    for (let hero of heroesData) {
        let [name, level, items] = hero.split(' / ');

        level = Number(level);
        items = items ? items.split(', ') : [];

        heroes.push({name, level, items });
    }

    heroes.sort((hero1, hero2) => hero1.level - hero2.level );

    for (let hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);    
    }
}

registerHeroes([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]);

registerHeroes([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]);