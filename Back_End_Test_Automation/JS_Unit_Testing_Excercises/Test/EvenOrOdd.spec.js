import { isOddOrEven } from "../EvenOrOdd.js";
import { expect } from 'chai';

describe('Test isEvenOrOdd function', () => {
    it('Should return "odd", if string with odd length is given', () => {
        const input = 'aaa';

        const result = isOddOrEven(input);

        expect(result).to.be.equal('odd');
    });

    it('Should return "even", if string with even length is given', () => {
        const input = 'aaaa';

        const result = isOddOrEven(input);

        expect(result).to.be.equal('even');
    });

    it('Should return "even", if empty string is given', () => {
        const input = '';

        const result = isOddOrEven(input);

        expect(result).to.be.equal('even');
    });

    it('Should return different results, if multiple different strings are given', () => {
        expect(isOddOrEven('foo')).to.be.equal('odd');
        expect(isOddOrEven('foobar')).to.be.equal('even');
    });

    it('Should return "undefined", if not a string value is given', () => {
        expect(isOddOrEven(undefined), 'undefined').to.be.undefined;
        expect(isOddOrEven(120), 'number').to.be.undefined;
        expect(isOddOrEven(null), 'null').to.be.undefined;
        expect(isOddOrEven({}), 'empty object').to.be.undefined;
        expect(isOddOrEven([]), 'empty array').to.be.undefined;
        expect(isOddOrEven(['aaaa'], 'array with one element')).to.be.undefined;
        expect(isOddOrEven({input: 'aaaa'}, 'object with one prop')).to.be.undefined;
        expect(isOddOrEven(true), 'boolean').to.be.undefined;
    });
});