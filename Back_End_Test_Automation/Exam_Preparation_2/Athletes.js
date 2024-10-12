function solve(athletes) {
    function getAthletesBySport(sport) {
        return athletes.filter(athletе => athletе.sport === sport);
    }
  
    function addAthlete(id, name, sport, medals, country) {
        athletes.push({
            id: id,
            name: name,
            sport: sport,
            medals: medals,
            country: country
        });

        return athletes;
    }
  
    function getAthleteById(id) {
        let foundAthlete = null;

        athletes.forEach(athlete => {
            if (athlete.id === id) {
                foundAthlete = athlete;
            }
        });

        return foundAthlete ? foundAthlete : `Athlete with ID ${id} not found`;
    }
  
    function removeAthleteById(id) {
        const athleteIndex = athletes.findIndex(athlete => athlete.id === id);

        if (athleteIndex !== -1) {
            return athletes.filter(athlete => athlete.id !== id);
        } else {
            return `Athlete with ID ${id} not found`;
        }
    }
  
    function updateAthleteMedals(id, newMedals) {
        const athleteIndex = athletes.findIndex(athlete => athlete.id === id);

        if (athleteIndex !== -1) {
            athletes.forEach(athlete => {
                if (athlete.id === id) {
                    athlete.medals = newMedals;
                }
            })
        } else {
            return `Athlete with ID ${id} not found`;
        }

        return athletes;
    }
  
    function updateAthleteCountry(id, newCountry) {
        let foundAthlete = null;

        athletes.forEach(athlete => {
            if (athlete.id === id) {
                athlete.country = newCountry;
                foundAthlete = athlete;
            }
        });

        return foundAthlete ? athletes : `Athlete with ID ${id} not found`;
    }
  
    return {
        getAthletesBySport,
        addAthlete,
        getAthleteById,
        removeAthleteById,
        updateAthleteMedals,
        updateAthleteCountry
    };
}

let athletes = [
    { id: 1, name: "Usain Bolt", sport: "Sprinting", medals: 8, country: "Jamaica" },
    { id: 2, name: "Michael Phelps", sport: "Swimming", medals: 23, country: "USA" },
    { id: 3, name: "Simone Biles", sport: "Gymnastics", medals: 7, country: "USA" }
  ];

  const olympics = solve(athletes);
// console.log(olympics.getAthletesBySport('Swimming'));
// console.log(olympics.addAthlete(4, 'Katie Ledecky', 'Swimming', 7, 'USA'));
// console.log(olympics.getAthleteById(1));
// console.log(olympics.removeAthleteById(4));
// console.log(olympics.updateAthleteMedals(3, 12));
// console.log(olympics.updateAthleteCountry(4, 'USA'));
 
 
 
 
  
  
  