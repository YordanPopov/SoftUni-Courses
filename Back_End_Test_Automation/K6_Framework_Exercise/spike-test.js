import { sleep } from 'k6';
import  http  from 'k6/http';

export const options = {
    stages: [
        {
            duration: '2m',
            target: 10000
        },
        {
            duration: '15s',
            target: 0
        }
    ]
};

export default function () {
    http.get('https://test.k6.io');
    sleep(1);
}