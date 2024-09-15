import { it } from 'mocha';
import { analyzeArray } from '../ArrayAnalyzer.js';
import { expect } from 'chai';


describe.only('Test analyzeArray', () => {
    it('Should return object with specific properties', () => {
        const inputArray = [1, 20, 300, 40, 5];

        expect(analyzeArray(inputArray)).is.an('object').with.property('max');
        expect(analyzeArray(inputArray)).is.an('object').with.property('min');
        expect(analyzeArray(inputArray)).is.an('object').with.property('length');
    });

    it('Should return highest number', () => {
        const inputArray = [1, 20, 300, 40, 5];

        expect(analyzeArray(inputArray)).has.property('max', 300);
    });

    it('Should return lowest number', () => {
        const inputArray = [1, 20, 300, 40, 5];

        expect(analyzeArray(inputArray)).has.property('min', 1);
    });

    it('Should return length', () => {
        const inputArray = [1, 20, 300, 40, 5];

        expect(analyzeArray(inputArray)).has.property('length', 5);
    });

    it('Should return undefined, if empty array is given', () => {
        expect(analyzeArray([])).to.be.undefined;
    });

    it('Should return correct result, if single element array is given', () => {
        const inputArray = [1];
        
        expect(analyzeArray(inputArray)).has.property('min', 1);
        expect(analyzeArray(inputArray)).has.property('max', 1);
        expect(analyzeArray(inputArray)).has.property('length', 1);
    });

    it('Should return correct result, if equal elements array is given', () => {
        const inputArray = [1, 1, 1, 1];
        
        expect(analyzeArray(inputArray)).has.property('min', 1);
        expect(analyzeArray(inputArray)).has.property('max', 1);
        expect(analyzeArray(inputArray)).has.property('length', 4);
    });

    it('Should return undefined, if not an array is given', () => {
        expect(analyzeArray(true)).to.be.undefined;
        expect(analyzeArray(null)).to.be.undefined;
        expect(analyzeArray(undefined)).to.be.undefined;
        expect(analyzeArray(Infinity)).to.be.undefined;
        expect(analyzeArray('[1, 2, 3, 4]')).to.be.undefined;
        expect(analyzeArray('')).to.be.undefined;
        expect(analyzeArray(NaN)).to.be.undefined;
        expect(analyzeArray({aray: [1, 2, 3, 4]})).to.be.undefined;
    });
});