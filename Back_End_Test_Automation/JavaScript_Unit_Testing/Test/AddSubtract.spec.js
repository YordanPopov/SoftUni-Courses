import { it } from 'mocha';
import { createCalculator } from '../AddSubtract.js';
import { expect } from 'chai';

describe('Test createCalculator function', () => {
     let calculator;

     beforeEach(() => {
        calculator = createCalculator();
     });

    describe('Test "add" function', () => {
        it('Should return positive number, if only positive numbers are given', () => {          
            calculator.add(2);
            calculator.add(8);
            calculator.add(100);
            const result = calculator.get();

            expect(result).to.be.equal(110);
        });

        it('Should return correct value, if only negative numbers are given', () => { 
            calculator.add(-2);
            calculator.add(-8);
            calculator.add(-100);
            const result = calculator.get();

            expect(result).to.be.equal(-110);
        });

        it('Should return correct value, if positive and negative numbers are given', () => {
            calculator.add(-10);
            calculator.add(5);
            calculator.add(0);
            const result = calculator.get();

            expect(result).to.be.equal(-5);
        });
    });

    describe('Test "subtract" function', () => {
        it('Should return negative value, if only positive numbers are given', () => {
            calculator.subtract(10);
            calculator.subtract(5);
            calculator.subtract(10);

            const result = calculator.get();

            expect(result).to.be.equal(-25);
        });

        it('Should return positive number, if only negative numbers are given', () => {
            calculator.subtract(-10);
            calculator.subtract(-5);
            calculator.subtract(-10);

            const result = calculator.get();

            expect(result).to.be.equal(25);
        });

        it('Should return correct value, if positive and negative numbers are given', () => {
            calculator.subtract(-10);
            calculator.subtract(5);
            calculator.subtract(-10);

            const result = calculator.get();

            expect(result).to.be.equal(15);
        });
    });
        

    describe('Test "add" and "subtract" functions', () => {
        it('Should return correct value, if numbers represented as a string are given', () => {
            calculator.add('-10');
            calculator.subtract('5');
            calculator.add('0');
            const result = calculator.get();

            expect(result).to.be.equal(-15);
        });

        it('Should return correct values, if a mix of operations is given', () => {
            calculator.add(100);
            calculator.subtract(10);
            calculator.add(-20);
            calculator.subtract(-100);

            const result = calculator.get();

            expect(result).to.be.equal(170);
        });
    });
});