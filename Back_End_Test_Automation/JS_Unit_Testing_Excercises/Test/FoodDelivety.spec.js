import { describe } from 'mocha';
import { foodDelivery } from '../FoodDelivery.js';
import { expect } from 'chai';

describe('Test foodDelivery', () => {
    describe('Test getCategory', () => {
        it('Should return correct message, if valid input is given', () => {
            expect(foodDelivery.getCategory('Vegan'))
                .to.be.equal('Dishes that contain no animal products.');

            expect(foodDelivery.getCategory('Vegetarian'))
                .to.be.equal('Dishes that contain no meat or fish.');

            expect(foodDelivery.getCategory('Vegetarian'))
                .to.be.equal('Dishes that contain no meat or fish.');

            expect(foodDelivery.getCategory('Gluten-Free'))
                .to.be.equal('Dishes that contain no gluten.');

            expect(foodDelivery.getCategory('All'))
                .to.be.equal('All available dishes.');
        });

        it('Should throw error, if empty string is given', () => {
            expect(() => { foodDelivery.getCategory('') }).throw('Invalid Category!');
        });

        it('Should throw error, if non correct value is given', () => {
            expect(() => { foodDelivery.getCategory('Test') }).throw('Invalid Category!');
        });
    });

    describe('Test addMenuITem', () => {

        let menuItem = [];

        beforeEach(()=> {
            menuItem = [
                {
                    name: 'Box',
                    price: 10
                },
                {
                    name: 'Box2',
                    price: 15
                },
                {
                    name: 'Box3',
                    price: 20
                },
                {
                    name: 'Box3',
                    price: 30
                }
            ];
        });
        it('Should return correct result, if correct values are given', () => {
            const actualResult = foodDelivery.addMenuItem(menuItem, 20);

            expect(actualResult).to.be.equal('There are 3 available menu items matching your criteria!')
        });

        it('Should throw error, if non-array of objects for menuItem is given', () => {
            expect(() => { foodDelivery.addMenuItem(10, 20) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(true, 20) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(NaN, 20) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem({ name: 'box', price: 10 }, 20) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem('[{name: box, price: 10}]', 20) }).Throw('Invalid Information!');
        });

        it('Should throw error, if not a number for maxPrice is given', () => {
            expect(() => { foodDelivery.addMenuItem(menuItem, '20') }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(menuItem, '') }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(menuItem, false) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(menuItem, [100]) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(menuItem, { number: 10 }) }).Throw('Invalid Information!');
        });

        it('Should throw error, if empty array of objects for menuItem is given', () => {
            expect(() => { foodDelivery.addMenuItem([], 20) }).Throw('Invalid Information!');
        });

        it('Should throw error, if number less than 5 for maxPrice is given', () => {
            expect(() => { foodDelivery.addMenuItem(menuItem, 4) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(menuItem, 0) }).Throw('Invalid Information!');
            expect(() => { foodDelivery.addMenuItem(menuItem, -1) }).Throw('Invalid Information!');
        });
    });

    describe('Test calculateOrderCost', () => {
        let shipping = [];
        let addons = [];

        beforeEach(() => {
            shipping = ['standard', 'express', 'standard'];
            addons = ['sauce', 'beverage', 'sauce'];
        });

        it('Should return correct result, if discount value is true', () => {
            const expectedResult = 'You spend $14.03 for shipping and addons with a 15% discount!';

            const actualResult = foodDelivery.calculateOrderCost(shipping, addons, true);

            expect(actualResult).to.be.equal(expectedResult);
        });

        it('Should return correct result, if discount value is false', () => {
            const expectedResult = 'You spend $16.50 for shipping and addons!';

            const actualResult = foodDelivery.calculateOrderCost(shipping, addons, false);

            expect(actualResult).to.be.equal(expectedResult);
        });

        it('Should throw error, if not a boolean type for discount is given', () => {

            expect(() => { foodDelivery.calculateOrderCost(shipping, addons, 10) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, addons, 'true') }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, addons, '') }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, addons, ['true']) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, addons, { type: true }) }).throw('Invalid Information!');
        });

        it('Should throw error, if non-array type for shipping is given', () => {
            expect(() => { foodDelivery.calculateOrderCost('shipping', addons, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost("['standard', 'express']", addons, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(101201, addons, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(false, addons, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost({ arr: "['standard', 'express']" }, addons, true) }).throw('Invalid Information!');
        });

        it('Should throw error, if non-array type for addons is given', () => {
            expect(() => { foodDelivery.calculateOrderCost(shipping, 15221, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, "['sauce', 'sauce']", true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, true, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, NaN, true) }).throw('Invalid Information!');
            expect(() => { foodDelivery.calculateOrderCost(shipping, { type: 'sauce' }, true) }).throw('Invalid Information!');
        });

    });
});