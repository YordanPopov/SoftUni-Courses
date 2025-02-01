import { test, expect } from '@playwright/test';

test.describe('test suite', () => {
    test.describe.configure({ mode: 'parallel' });
    test.beforeEach('Open start URL', async ({ page }) => {
        await page.goto('http://localhost:8080');
    });

    test('User can add a task', async ({ page }) => {
        await page.fill('#task-input', 'Task1');
        await page.click('#add-task');

        const taskText = await page.textContent('.task');
        expect(taskText).toContain('Task1');
    });

    test('User can delete a task', async ({ page }) => {
        await page.fill('#task-input', 'Test Task');
        await page.click('#add-task');

        await page.click('.task .delete-task');

        const tasks = await page.$$eval('.task', tasks =>
            tasks.map(task => task.textContent));
        expect(tasks).not.toContain('Test Task');
    });

    test('User can mark a task as completed', async ({ page }) => {
        await page.fill('#task-input', 'Test Task');
        await page.click('#add-task');

        await page.click('.task .task-complete');

        const completedTask = await page.$('.task-complete');
        expect(completedTask).not.toBeNull();
    });

    test('User can filter tasks', async ({ page }) => {
        await page.fill('#task-input', 'Test Task');
        await page.click('#add-task');

        await page.click('.task .task-complete');

        await page.selectOption('#filter', 'Completed');

        const incompleteTask = await page.$('.task:not(.completed)');
        expect(incompleteTask).toBeNull();
    });
});

test.describe.only('Demo tests', () => {
    test.setTimeout(60_000);

    test.beforeEach('', async ({ page }) => {
        await page.goto('http://localhost:8080');
    });
    test('Demo test 1', async ({ page }) => {
        await expect(page.getByRole('heading', { name: 'To-Do List' })).toBeVisible();
        await expect(page.getByPlaceholder('New task')).toBeVisible();
        await expect(page.getByRole('button', { name: 'Add Task' })).toBeVisible();

        await page.getByRole('textbox').fill('Completed task');
        await page.getByRole('button', { name: 'Add Task' }).click();
        await page.getByRole('textbox').fill('task');
        await page.getByRole('button', { name: 'Add Task' }).click();

        await page
            .getByRole('listitem')
            .filter({ hasText: 'Completed' })
            .getByRole('button', { name: 'Complete' })
            .click();

        const completedTask = await page.$('.task.completed');
        expect(completedTask).not.toBeNull();

        const activeTask = await page.$('.task:not(.completed)');
        expect(activeTask).not.toBeNull();
    })

    test.only('Demo test_2', async ({ page }) => {
        const tasksCount = 5;

        for (let index = 0; index < tasksCount; index++) {
            //await page.getByRole('textbox').fill(`Example value_${index}`);
            await page.getByRole('textbox').pressSequentially(`Test-Task-${index}`, { delay: 150 });
            await page.getByRole('button', { name: 'Add Task' }).click();
        }

        await page.waitForTimeout(1500);

        for (let index = 0; index < tasksCount; index++) {
            await page.locator(`#task-${index}`).getByRole('button', { name: 'Complete' }).click();
            await page.waitForTimeout(500);
        }

        await page.waitForTimeout(1500);

        await page.selectOption('#filter', 'completed');

        const completedTasks = await page.$$eval('.task.completed',
            completedTasks => completedTasks.map(task => task.textContent)
        );
        expect(completedTasks.length).toEqual(5);

        for (let index = 0; index < completedTasks.length; index++) {
            await page.locator(`#task-${index}`).getByRole('button', { name: 'Delete' }).click();
            await page.waitForTimeout(500);
        }

        await page.waitForTimeout(1500);
        const task = await page.$('.task')
        expect(task).toBeNull();
    });
});

