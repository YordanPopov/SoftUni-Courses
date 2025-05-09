function calculateHours(archName, projectsCount) {
    let hoursForCreation = projectsCount * 3;
    let output = `The architect ${archName} will need ${hoursForCreation} hours to complete ${projectsCount} project/s.`;

    console.log(output); 
}

calculateHours("George", 4);
calculateHours("Sanya", 9);