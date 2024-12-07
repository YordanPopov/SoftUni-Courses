import { check, sleep } from 'k6';
import http from 'k6/http';

export const options = {
    stages: [
        { duration: '10s', target: 10},
        { duration: '30s', target: 10},
        { duration: '15s', target: 0}
    ]
}

export default function () {
    const enquiryID = '67545ee0beb48f4d4953fa93';
    const updatedName = `user_${__VU}`;
    const updatedEmail = `user_${__VU}@example.com`;

    const payload = JSON.stringify({
        name: updatedName,
        email: updatedEmail,
        mobile: '+3591234567',
        comment: 'This is update request'
    });

    const adminToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjY3NTQ1ZWUwYmViNDhmNGQ0OTUzZjlkNyIsImlhdCI6MTczMzU4MzYyMCwiZXhwIjoxNzMzNjcwMDIwfQ.hEIKHOFuCQ9ABvjCiQkJiNT_8hUE00eAGzqBE-nIru0';

    const params = {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${adminToken}`
        }
    };

    const res = http.put(`http://localhost:5000/api/enquiry/${enquiryID}`, payload, params);

    check(res, {
        'HTTP status code is 200': (r) => r.status === 200,
        'Contains updated fields': (r) => {
            const body = res.json();
            return body.name === updatedName && body.email === updatedEmail;
        }
    });

    sleep(1);
}