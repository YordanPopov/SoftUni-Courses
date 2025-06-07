function solve([tabs, salary, ...websites]) {
    for (const website of websites) {
        if (website === 'Facebook') salary -= 150;
        else if (website === 'Instagram') salary -= 100;
        else if (website === 'Reddit') salary -= 50;

        if (salary <= 0) {
            console.log("You have lost your salary.");
            return;
        }
    }

    console.log(salary);
}

solve([10,
    750,
    "Facebook",
    "Dev.bg",
    "Instagram",
    "Facebook",
    "Reddit",
    "Facebook",
    "Facebook"]);