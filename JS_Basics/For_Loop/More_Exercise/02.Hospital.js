function solve([period, ...patients]) {
    period = Number(period);
    patients = patients.map(Number);
    
    let doctors = 7;
    let treatedPatients = 0;
    let untreatedPatients = 0;

    for (let i = 1; i <= period; i++) {
        if (i % 3 === 0 && treatedPatients < untreatedPatients) {
            doctors++;
        }

        let currentPatients = patients[i - 1];

        if (currentPatients > doctors) {
            untreatedPatients += currentPatients - doctors;
            treatedPatients += doctors;
        } else {
            treatedPatients += currentPatients;
        }
    }

    console.log(`Treated patients: ${treatedPatients}.`);
    console.log(`Untreated patients: ${untreatedPatients}.`);
}

solve(['4', '7', '27', '9', '1']);