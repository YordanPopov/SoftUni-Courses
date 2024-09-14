import { expect } from 'chai';
import { isSymmetric } from '../CheckForSymmetry.js';

describe('Test isSymmetric function', () => {
    it('Should return true, if an empty array is given', () => {
        expect(isSymmetric([])).to.be.true;
    });

    it('Should return false, if a non-array value is given', () => {
        expect(isSymmetric(424)).to.be.false;
        expect(isSymmetric({})).to.be.false;
        expect(isSymmetric(undefined)).to.be.false;
        expect(isSymmetric(null)).to.be.false;
        expect(isSymmetric("string")).to.be.false;
        expect(isSymmetric(NaN)).to.be.false;
        expect(isSymmetric(Infinity)).to.be.false;
    });

    it('Should return false, if a non-symmetric array is given', () => {
        expect(isSymmetric([1, 2, 3, 4])).to.be.false;
    });

    it('Should return true, if a symmetric array with odd length is given', () => {
        expect(isSymmetric([1, 2, 3, 2, 1])).to.be.true;
    });

    it('Should return true, if a symmetric array with even length is given', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.be.true;
    });

    it('Should return true, if a single element array is given', () => {
        expect(isSymmetric([1])).to.be.true;
    });

    it('Should return false, if a mix data types array is given', () => {
        expect(isSymmetric(['1', '2', '3', 2, 1])).to.be.false;
    });
});