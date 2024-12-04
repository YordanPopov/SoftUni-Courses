import { check, sleep } from 'k6';
import http from 'k6/http'

export const options = {
    vus: 10,
    duration: '30s',
    thresholds: {
        'http_req_duration': ['p(90)<1500', 'p(95)<1000'],
        'http_req_failed': ['rate<0.01']
    }
};

export default function() {
    const response = http.get('https://test.k6.io');
    check(response, {
        'HTTP status is 200': (r) => r.status === 200,
        'Homepage welcome header present': (r) => r.body.includes('Collection of simple web-pages suitable for load testing.')
    });
    sleep(2);
}