import { sleep } from 'k6';
import  http  from 'k6/http';

export const options = {
    stages: [
        {
            duration: "2h",
            target: 100000
        }
    ]
};

export default function () {
    http.get('https://test.k6.io');
    sleep(1);
}