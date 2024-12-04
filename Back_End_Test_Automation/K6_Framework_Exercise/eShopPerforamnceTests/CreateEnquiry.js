import { check, randomSeed, sleep } from 'k6';
import http from 'k6/http'

export const options = {
    stages: [
        { duration: '15s', target: 10 },
        { duration: '30s', target: 10 },
        { duration: '10s', target: 0 }
    ]
}

export default function(){
    const payload = JSON.stringify({
        name: `user_${__VU}`,
        email: `user_${__VU}@example.com`,
        mobile: '+0897799828',
        comment: "I'm testing this.",
        status: 'In Progress'
    });

    const params = {
        headers: {
            'Content-Type': 'application/json'
        }
    }

    const res = http.post('http://localhost:5000/api/enquiry/', payload, params);


    check(res, {
        'HTTP statuc code is 200': (r) => r.status === 200,
        'Response contains expected fields': (r) => {
            const body = r.json()
            return body.hasOwnProperty('_id') && body.hasOwnProperty('status')
        }
    });

    sleep(1)
}