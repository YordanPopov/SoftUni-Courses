import { test, expect } from '@playwright/test';

test('User can add a task', async ({ page }) => {
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Task1');
    await page.click('#add-task');

    const taskText = await page.textContent('.task');
    expect(taskText).toContain('Task1');
});