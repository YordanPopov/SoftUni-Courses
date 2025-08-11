import { test, expect } from '@playwright/test'

test('Upload single file', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com/');

    await page.locator('//input[@id="singleFileInput"]').setInputFiles('files\\testFile1.pdf');
    await page.locator('//form[@id="singleFileForm"]/button').click();

    await expect(page.locator('//p[@id="singleFileStatus"]')).toContainText('testFile1.pdf');

});

test('Upload multiple files', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com/');

    await page.locator('//input[@id="multipleFilesInput"]').setInputFiles(['files\\testFile1.pdf', 'files\\testFile2.pdf']);
    await page.locator('//form[@id="multipleFilesForm"]/button').click();

    await expect(page.locator('//p[@id="multipleFilesStatus"]')).toContainText('Multiple files selected:');
});

test('Remove files', async ({ page }) => {
    await page.goto('https://testautomationpractice.blogspot.com/');

    await page.locator('//input[@id="singleFileInput"]').setInputFiles('files\\testFile1.pdf');
    await page.locator('//form[@id="singleFileForm"]/button').click();

    await expect(page.locator('//p[@id="singleFileStatus"]')).toContainText('testFile1.pdf');

    await page.locator('//input[@id="singleFileInput"]').setInputFiles([]);
    await page.locator('//form[@id="singleFileForm"]/button').click();

    await expect(page.locator('//p[@id="singleFileStatus"]')).toHaveText('No file selected.');
});