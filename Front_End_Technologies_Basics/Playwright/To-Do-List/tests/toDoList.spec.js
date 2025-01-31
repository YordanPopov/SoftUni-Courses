import { test, expect } from '@playwright/test';

test('User can add a task', async ({ page }) => {
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Task1');
    await page.click('#add-task');

    const taskText = await page.textContent('.task');
    expect(taskText).toContain('Task1');
});

test('User can delete a task', async ({ page }) => {
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    await page.click('.task .delete-task');

    const tasks = await page.$$eval('.task', tasks =>
        tasks.map(task => task.textContent));
    expect(tasks).not.toContain('Test Task');
});

test('User can mark a task as completed', async ({ page }) => {
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    await page.click('.task .task-complete');

    const completedTask = await page.$('.task-complete');
    expect(completedTask).not.toBeNull();
});

test('User can filter tasks', async ({ page }) => {
    await page.goto('http://localhost:8080');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    await page.click('.task .task-complete');

    await page.selectOption('#filter', 'Completed');

    const incompleteTask = await page.$('.task:not(.completed)');
    expect(incompleteTask).toBeNull();
});

test('Demo test', async ({ page }) => {
    const tasksCount = 5;
    await page.goto('http://localhost:8080');
    for (let index = 0; index < tasksCount; index++) {
        await page.getByRole('textbox').fill(`Example value_${index}`);
        await page.getByRole('button', { name: 'Add Task' }).click();
        await page.waitForTimeout(500);
    }

    for (let index = 0; index < tasksCount; index++) {
        await page.locator(`#task-${index}`).getByRole('button', { name: 'Complete' }).click()
        await page.waitForTimeout(500);
    }
});