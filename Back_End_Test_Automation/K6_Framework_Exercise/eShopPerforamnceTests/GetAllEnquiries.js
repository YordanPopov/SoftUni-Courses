import { check, sleep } from 'k6';
import http from 'k6/http'

export const options = {
    stages: [
        { duration: '15s', target: 10 },
        { duration: '30s', target: 10 },
        { duration: '10s', target: 0 }
    ]
}

export default function(){
    const res = http.get('http://localhost:5000/api/enquiry/');
    const data = res.json();

    const isArray = Array.isArray(data);
    const hasElements = isArray && data.length === 20;

    check(res, {
        'HTTP Status code is 200': (r) => r.status === 200,
        'Response is an array': () => isArray,
        'Array has 20 elements': () => hasElements
    });

    sleep(1)
}