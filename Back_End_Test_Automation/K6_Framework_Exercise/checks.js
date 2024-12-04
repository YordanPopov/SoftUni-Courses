import { check, sleep } from 'k6';
import http from 'k6/http'

export default function() {
    const response = http.get('https://test.k6.io');
    check(response, {
        'HTTP status is 200': (r) => r.status === 200,
        'Homepage welcome header present': (r) => r.body.includes('Collection of simple web-pages suitable for load testing.')
    });
    sleep(1);
}