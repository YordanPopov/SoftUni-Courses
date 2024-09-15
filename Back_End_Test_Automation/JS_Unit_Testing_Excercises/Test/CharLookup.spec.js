import { it } from 'mocha';
import { lookupChar } from '../CharLookup.js';
import { expect } from 'chai';

describe('Test LookupChar function', () => {
    it('Should return correct character, if both parameters have correct types and values', () => {
        expect(lookupChar('bar', 0)).to.be.equal('b');
        expect(lookupChar('bar', 1)).to.be.equal('a');
        expect(lookupChar('bar', 2)).to.be.equal('r');
    });

    it('Should return undefined, if not a string as first parameter is given', () => {
        expect(lookupChar(true, 1)).to.be.undefined;
        expect(lookupChar(null, 1)).to.be.undefined;
        expect(lookupChar(undefined, 1)).to.be.undefined;
        expect(lookupChar(NaN, 1)).to.be.undefined;
        expect(lookupChar([], 1)).to.be.undefined;
        expect(lookupChar(['bar'], 1)).to.be.undefined;
        expect(lookupChar({}, 1)).to.be.undefined;
        expect(lookupChar({type: 'string'}, 1)).to.be.undefined;
        expect(lookupChar(1002, 1)).to.be.undefined;
    });

    it('Should return undefined, if not a number as second parameter is given', () => {
        expect(lookupChar('bar', true)).to.be.undefined;
        expect(lookupChar('bar', NaN)).to.be.undefined;
        expect(lookupChar('bar', undefined)).to.be.undefined;
        expect(lookupChar('bar', [])).to.be.undefined;
        expect(lookupChar('bar', {})).to.be.undefined;
        expect(lookupChar('bar', [1])).to.be.undefined;
        expect(lookupChar('bar', Infinity)).to.be.undefined;
        expect(lookupChar('bar', '')).to.be.undefined;
        expect(lookupChar('bar', '1')).to.be.undefined;
    });

    it('Should return "Incorrect index", if second parameter is out of range', () => {
        expect(lookupChar('bar', -1)).to.be.equal('Incorrect index');
        expect(lookupChar('bar', 3)).to.be.equal('Incorrect index');        
    });

    it('Should return "Incorrect index", if empty string is given', () => {
        expect(lookupChar('', 0)).to.be.equal('Incorrect index'); 
    });

    it('Should return undefined, if decimal number as second parameter is given', () => {
        expect(lookupChar('bar', 1.2)).to.be.undefined;
    });
});