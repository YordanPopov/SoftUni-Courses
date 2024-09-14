import { rgbToHexColor } from '../rgbToHex.js';
import { expect } from 'chai';

describe('Test rgbToHexColor function', () => {
    it('Should return color, if each parameters are in the expected range ', () => {
        expect(rgbToHexColor(100, 100, 100)).to.be.equal('#646464');
    });

    it('Should return color, if 0 as a parameters are given', () => {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
    });

    it('Should return color, if 255 as a parameters are given', () => {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
    });

    it('Should return undefined, if any ot the input parameters are of an invalid type', () => {
        expect(rgbToHexColor(-1, 256, 0)).to.be.undefined;
        expect(rgbToHexColor(-1, 0, 256)).to.be.undefined;
        expect(rgbToHexColor(-1, -1, -1)).to.be.undefined;
        expect(rgbToHexColor(256, -1, 0)).to.be.undefined;
        expect(rgbToHexColor(256, 256, -1)).to.be.undefined;
        expect(rgbToHexColor(256, 0, 256)).to.be.undefined;
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
        expect(rgbToHexColor(0, 256, 0)).to.be.undefined;
        expect(rgbToHexColor(0, -1, 256)).to.be.undefined;
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
        expect(rgbToHexColor(0, 256, -1)).to.be.undefined;
        expect(rgbToHexColor(-1, -1, 256)).to.be.undefined;
    });
});