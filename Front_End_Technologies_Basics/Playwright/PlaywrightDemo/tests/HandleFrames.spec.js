import { expect, test } from '@playwright/test';

test('Frames', async ({ page }) => {
    await page.goto('https://ui.vision/demo/webtest/frames/');

    const allFrames = await page.frames();

    await page.waitForTimeout(3000);
    console.log(`Number of frames:${allFrames.length}`);

    const frame1 = await page.frame({ url: 'https://ui.vision/demo/webtest/frames/frame_1.html' });
    await frame1.locator('input[name="mytext1"]').fill('test');


    const frame5 = await page.frameLocator('//frame[@src="frame_5.html"]');
    await frame5.locator('//input[@name="mytext5"]').fill('test');
    await page.waitForTimeout(3000);
});

test.only('Inner/nested frames', async ({ page }) => {
    await page.goto('https://ui.vision/demo/webtest/frames/');

    const frame3 = await page.frame({ url: 'https://ui.vision/demo/webtest/frames/frame_3.html' });
    const childFrames = await frame3.childFrames();


    // await page.waitForTimeout(1000);
    // console.log(childFrames.length);

    const checkBox = await childFrames[0].locator('//*[@id="i6"]/div[3]/div');
    await checkBox.check();

    await expect(checkBox).toBeChecked();

});