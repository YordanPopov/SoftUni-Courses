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
    const enquiryID = '6750993e29b0e5c0abbf0b7d';
    const res = http.get('http://localhost:5000/api/enquiry/' + enquiryID);

    const data = res.json();

    check(res, {
        'HTTP status code is 200': (r) => r.status === 200,
        'Response is an object': () => typeof data === 'object',
        'Response contains _id field': () => '_id' in data,
        'Response contains status field': () => 'status' in data
    });

    sleep(1)
}