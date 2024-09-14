import { it } from 'mocha';
import { sum } from '../SumOfNumbers.js';
import { expect } from 'chai';

describe('Test the function sum', () => {
    it('Should return 0, if an empty array is given', () => {
        const inputArray = [];

        const result = sum(inputArray);

        expect(result).to.be.equal(0);
    });

    it('Should return the single element as a sum, if a single element array is given', () => {
        const inputArray = [10];

        const result = sum(inputArray);

        expect(result).to.be.equal(10);
    });

    it('Should return the total sum of an array, if a multi value array is given', () => {
        const inputArray = [1, 2, 3, 4, 5];
        const expectedResult = 15;

        const actualResult = sum(inputArray);

        expect(actualResult).to.be.equal(expectedResult);
    });

    it('Should return the total sum of an array, if a multi negative value array is given', () => {
        const inputArray = [-1, -2, -3, -4, -5,];
        const expectedResult = -15;

        const actualResult = sum(inputArray);

        expect(actualResult).to.be.equal(expectedResult);
    });

    it('Should return the total sum of an array, if a mixed value array is given', () => {
        const inputArray = [1, -2, 3, -4, 5];
        const expectedResult = 3;

        const actualResult = sum(inputArray);

        expect(actualResult).to.be.equal(expectedResult);
    });

    it('Should return total sum, if a decimal value array is given', () => {
        expect(sum([1.5, 2.5, 3.5])).to.be.equal(7.5);
    });
});