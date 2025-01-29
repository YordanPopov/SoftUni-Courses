function attachEventsListeners() {
    let ratios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    function convert(value, unit) {
        let inDays = value / ratios[unit];
        return {
            days: inDays,
            hours: inDays * ratios.hours,
            minutes: inDays * ratios.minutes,
            seconds: inDays * ratios.seconds
        }
    }

    let inputDays = document.getElementById('days');
    let inputHours = document.getElementById('hours');
    let inputMinutes = document.getElementById('minutes');
    let inputSeconds = document.getElementById('seconds');

    document.querySelector('main').addEventListener('click', onConvert);

    function onConvert(event) {
        if (event.target.tagName === 'INPUT' && event.target.type === 'button') {
            let input = event.target.parentElement.querySelector('input[type="text"]');

            let time = convert(Number(input.value), input.id);
            inputDays.value = time.days;
            inputHours.value = time.hours;
            inputMinutes.value = time.minutes;
            inputSeconds.value = time.seconds;
        }
    }
}