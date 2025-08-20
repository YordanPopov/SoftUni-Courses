import { test, expect } from '@playwright/test';

let userId;

test('GET users', async ({ request }) => {
    const res = await request.get('https://reqres.in/api/users?page=2',
        { headers: { 'x-api-key': 'reqres-free-v1' } } // x-api-key: reqres-free-v1
    );

    console.log(await res.json());
    expect(res.status()).toBe(200);
});

test('Create user', async ({ request }) => {
    const res = await request.post('https://reqres.in/api/users',
        {
            data: { 'name': 'Jordan', 'job': 'QA' },
            headers: {
                'Accept': 'application/json',
                'x-api-key': 'reqres-free-v1'
            }
        }
    );

    console.log(await res.json());
    expect(res.status()).toBe(201);

    let data = await res.json();
    userId = data.id;
});

test('Update user', async ({ request }) => {
    const res = await request.put('https://reqres.in/api/users/' + userId,
        {
            data: { 'name': 'Jordan', 'job': 'TECH GOD' },
            headers: {
                'Accept': 'application/json',
                'x-api-key': 'reqres-free-v1'
            }
        }
    );

    console.log(await res.json());
    expect(res.status()).toBe(200);
});

test('Delete user', async ({ request }) => {
    const res = await request.delete('https://reqres.in/api/users?page=2',
        { headers: { 'x-api-key': 'reqres-free-v1' } } // x-api-key: reqres-free-v1
    );

    expect(res.status()).toBe(204);
});