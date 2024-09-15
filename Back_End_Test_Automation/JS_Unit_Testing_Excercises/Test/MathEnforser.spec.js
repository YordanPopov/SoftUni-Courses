import { it } from 'mocha';
import { mathEnforcer } from '../MathEnforser.js';
import { expect } from 'chai';

describe('Test mathEnforser', () => {
    describe('Test addFive', () => {
        it('Should return correct value, if a positive integer number is given', () => {
            const result = mathEnforcer.addFive(100);

            expect(result).to.be.equal(105);
        });

        it('Should return correct value, if a negative integer number is given', () => {
            const result = mathEnforcer.addFive(-100);

            expect(result).to.be.equal(-95);
        });

        it('Should return correct value, if a positive decimal number is given', () => {
            const result = mathEnforcer.addFive(105.5);

            expect(result).closeTo(110.5, 0.1);
        });

        it('Should return correct value, if a negative decimal number is given', () => {
            const result = mathEnforcer.addFive(-105.5);

            expect(result).closeTo(-100.5, 0.1);
        });

        it('Should return undefined, if a not number is given', () => {
            expect(mathEnforcer.addFive(true)).to.be.undefined;
            expect(mathEnforcer.addFive(undefined)).to.be.undefined;
            expect(mathEnforcer.addFive([2])).to.be.undefined;
            expect(mathEnforcer.addFive({number: 2})).to.be.undefined;
            expect(mathEnforcer.addFive('')).to.be.undefined;
            expect(mathEnforcer.addFive('2')).to.be.undefined;
        });
    });

    describe('Test subtractTen', () => {
        it('Should return correct value, if a positive integer number is given', () => {
            const result = mathEnforcer.subtractTen(100);

            expect(result).to.be.equal(90);
        });

        it('Should return correct value, if a negative integer number is given', () => {
            const result = mathEnforcer.subtractTen(-100);

            expect(result).to.be.equal(-110);
        });

        it('Should return correct value, if a positive decimal number is given', () => {
            const result = mathEnforcer.subtractTen(100.5);

            expect(result).closeTo(90.5, 0.1);
        });

        it('Should return correct value, if a negative decimal number is given', () => {
            const result = mathEnforcer.subtractTen(-100.5);

            expect(result).closeTo(-110.5, 0.1);
        });

        it('Should return undefined, if a not a number is given', () => {
            expect(mathEnforcer.subtractTen(true)).to.be.undefined;
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined;
            expect(mathEnforcer.subtractTen([2])).to.be.undefined;
            expect(mathEnforcer.subtractTen({number: 2})).to.be.undefined;
            expect(mathEnforcer.subtractTen('')).to.be.undefined;
            expect(mathEnforcer.subtractTen('2')).to.be.undefined;
        });
    });

    describe('Test sum', () => {
        it('Should return correct value, if a positive integer numbers are given', () => {
            expect(mathEnforcer.sum(100, 100)).to.be.equal(200);
        });

        it('Should return correct value, if a negative integer numbers are given', () => {
            expect(mathEnforcer.sum(-100, -100)).to.be.equal(-200);
        });

        it('Should return correct value, if a negative decimal numbers are given', () => {
            expect(mathEnforcer.sum(-100.5, -100.5)).closeTo(-201, 0.1);
        });

        it('Should return correct value, if a positive decimal numbers are given', () => {
            expect(mathEnforcer.sum(100.5, 100.5)).closeTo(201, 0.1);
        });

        it('Should return correct value, if a negative and positive numbers are given', () => {
            expect(mathEnforcer.sum(100, -100)).to.be.equal(0);
            expect(mathEnforcer.sum(-100, 100)).to.be.equal(0);
            expect(mathEnforcer.sum(100.5, -100.5)).closeTo(0, 0.1);
            expect(mathEnforcer.sum(-100.5, 100.5)).closeTo(0, 0.1);
        });

        it('Should return undefined, if a not a numbers are given', () => {
            expect(mathEnforcer.sum(100, true)).to.be.undefined;
            expect(mathEnforcer.sum(true, 100)).to.be.undefined;
            expect(mathEnforcer.sum(true, true)).to.be.undefined;
            expect(mathEnforcer.sum(100, '1')).to.be.undefined;
            expect(mathEnforcer.sum('1', 100)).to.be.undefined;
            expect(mathEnforcer.sum('1', '1')).to.be.undefined;
            expect(mathEnforcer.sum(100, undefined)).to.be.undefined;
            expect(mathEnforcer.sum(undefined, 100)).to.be.undefined;
            expect(mathEnforcer.sum(undefined, undefined)).to.be.undefined;
            expect(mathEnforcer.sum(100, [1])).to.be.undefined;
            expect(mathEnforcer.sum([1], 100)).to.be.undefined;
            expect(mathEnforcer.sum([1], [1])).to.be.undefined;
            expect(mathEnforcer.sum(100, null)).to.be.undefined;
            expect(mathEnforcer.sum(null, 100)).to.be.undefined;
            expect(mathEnforcer.sum(null, null)).to.be.undefined;
        });
    });
});