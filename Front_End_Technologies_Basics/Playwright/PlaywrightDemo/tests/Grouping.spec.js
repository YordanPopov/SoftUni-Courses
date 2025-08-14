import { test } from '@playwright/test'
import { log } from 'console'

test.beforeAll(async () => {
    console.log('This is beforeAll Hook...');
});

test.afterAll(async () => {
    console.log('This is afterAll Hook...');
});

test.beforeEach(async () => {
    console.log('This is beforeEach Hook...');
});

test.afterEach(async () => {
    console.log('This is afterEach Hook...')
});

test.describe('Group 1', async () => {
    test('Test 1', async () => {
        console.log('Test 1');
    });

    test('Test 2', async () => {
        console.log('Test 2');
    });

    test('Test 3', async () => {
        console.log('Test 3');
    });
});

test.describe('Group 2', async () => {
    test('Test 1', async () => {
        console.log('Test 1');
    });

    test('Test 2', async () => {
        console.log('Test 2');
    });

    test('Test 3', async () => {
        console.log('Test 3');
    });
});


test.describe('Group 3', async () => {
    test('Test 1', async () => {
        console.log('Test 1');
    });

    test('Test 2', async () => {
        console.log('Test 2');
    });

    test('Test 3', async () => {
        console.log('Test 3');
    });
});
