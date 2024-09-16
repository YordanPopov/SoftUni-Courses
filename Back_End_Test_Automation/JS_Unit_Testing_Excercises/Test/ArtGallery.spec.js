import { describe, it } from 'mocha'
import { artGallery } from '../ArtGallery.js'
import { expect } from 'chai';

describe('Test ArtGallery app', () => {
    describe('Test addArtWork', () => {
        it('Should return valid message, if valid input is given', () => {
            const title = 'TestTitle';
            const dimensions = '30 x 40';
            const artist = 'Van Gogh';
            const expectedResult = `Artwork added successfully: '${title}' by ${artist} with dimensions ${dimensions}.`;

            const actualResult =artGallery.addArtwork(title, dimensions, artist);

            expect(actualResult).to.be.equal(expectedResult);
        });

        it('Should throw error, if not a valid artist is given ', () => {
            const title = 'TestTitle';
            const dimensions = '30 x 40';
            const artist = 'ErrorArtist';

            expect(() => {artGallery.addArtwork(title, dimensions, artist)}).to.throw('This artist is not allowed in the gallery!');
        });

        it('Should throw error, if not a string title is given ', () => {
            const dimensions = '30 x 40';
            const artist = 'Van Gogh';

            expect(() => {artGallery.addArtwork(4, dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(true, dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(null, dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(undefined, dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork([], dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork({}, dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(NaN, dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(['title'], dimensions, artist)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork({title: 'title'}, dimensions, artist)}).to.throw('Invalid Information!');
        });

        it('Should throw error, if not a string for dimensions is given', () => {
            const title = 'TestTitle';
            const artist = 'Van Gogh';

            expect(() => {artGallery.addArtwork(title, 1, artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, true, artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, null, artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, undefined, artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, [], artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, {}, artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, NaN, artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, '', artist)}).to.throw('Invalid Dimensions!');
        });

        it('Should throw error, if dimensions in not specific format is given', () => {
            const title = 'TestTitle';
            const artist = 'Van Gogh';

            expect(() => {artGallery.addArtwork(title, 'width x height', artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, '30x40', artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, '30-40', artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, '30 40', artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, '30/40', artist)}).to.throw('Invalid Dimensions!');
            expect(() => {artGallery.addArtwork(title, '30 x 40 x 30', artist)}).to.throw('Invalid Dimensions!');
        });

        it('Should throw error if dimensions are negative numbers', () => {
            const title = 'TestTitle';
            const artist = 'Van Gogh';
            const dimensions = '-30 x -40';

            expect(() => {artGallery.addArtwork(title, dimensions, artist)}).to.throw('Invalid Dimensions!');
        });

        it('Should throw error, if empty string for artist is given', () => {
            const title = 'TestTitle';
            const dimensions = '30 x 40';
            const artist = '';

            expect(() => {artGallery.addArtwork(title, dimensions, artist)}).to.throw('This artist is not allowed in the gallery!');
        });

        it('Should throw error, if not a string dor artist is given', () => {
            const title = 'TestTitle';
            const dimensions = '30 x 40';

            expect(() => {artGallery.addArtwork(title, dimensions, 100)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(title, dimensions, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(title, dimensions, null)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(title, dimensions, undefined)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(title, dimensions, NaN)}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(title, dimensions, ['Van Gogh'])}).to.throw('Invalid Information!');
            expect(() => {artGallery.addArtwork(title, dimensions, {name: 'Van Gogh'})}).to.throw('Invalid Information!');
        });
    });

    describe('Test calculateCosts', () => {
        it('Should return correct message with price, if false for sponsor is given', () => {
            expect(artGallery.calculateCosts(50, 50, false)).to.be.equal('Exhibition and insurance costs are 100$.');
            expect(artGallery.calculateCosts(49.5, 49.5, false)).to.be.equal('Exhibition and insurance costs are 99$.');
        });

        it('Should return correct message with price, if true for sponsor is given', () => {
            const expectedMessage = 'Exhibition and insurance costs are 90$, reduced by 10% with the help of a donation from your sponsor.';

            expect(artGallery.calculateCosts(50, 50, true)).to.be.equal(expectedMessage);
        });

        it('Should throw error if exhibitionCosts is not a number', () => {
            expect(() => {artGallery.calculateCosts('', 50, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts('50', 50, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(true, 50, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(undefined, 50, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts([50], 50, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts({number: 50}, 50, true)}).to.throw('Invalid Information!');
        });

        it('Should throw error if exhibitionCosts is negative number', () => {
            expect(() => {artGallery.calculateCosts(-50, 50, true)}).to.throw('Invalid Information!');
        });

        it('Should throw error if insuranceCosts is not a number', () => {
            expect(() => {artGallery.calculateCosts(50, '50', true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, '', true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, true, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, undefined, true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, [50], true)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, {number: 50}, true)}).to.throw('Invalid Information!');
        });

        it('Should throw error if insuranceCosts is negative number', () => {
            expect(() => {artGallery.calculateCosts(50, -50, true)}).to.throw('Invalid Information!');
        });

        it('Should throw error if sponsor is not boolean', () => {
            expect(() => {artGallery.calculateCosts(50, 50, 1)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, 0)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, null)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, undefined)}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, [true])}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, 'true')}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, '')}).to.throw('Invalid Information!');
            expect(() => {artGallery.calculateCosts(50, 50, {value: true})}).to.throw('Invalid Information!');
        });
    });

    describe('Test organizeExhibits', () => {
        it('Should return correct message, if number of artworks are less than 5', () => {
            expect(artGallery.organizeExhibits(20, 5))
            .to.be.equal('There are only 4 artworks in each display space, you can add more artworks.');
            expect(artGallery.organizeExhibits(20, 6))
            .to.be.equal('There are only 3 artworks in each display space, you can add more artworks.');
        });

        it('Should return correct message, if number of artworks are bigger than 5', () => {
            expect(artGallery.organizeExhibits(36, 3))
            .to.be.equal('You have 3 display spaces with 12 artworks in each space.');
        });

        it('Should return correct message, if number of artworks are equal to 5', () => {
            expect(artGallery.organizeExhibits(25, 5))
            .to.be.equal('You have 5 display spaces with 5 artworks in each space.');
        });

        it('Should throw error, if artWorksCount is not a number', () => {
            expect(() => {artGallery.organizeExhibits(null, 5)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits('25', 5)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits('', 5)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits(undefined, 5)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits([25], 5)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits({}, 5)}).to.throw('Invalid Information!');
        });

        it('Should throw error, if artWorksCount is negative number', () => {
            expect(() => {artGallery.organizeExhibits(-25, 5)}).to.throw('Invalid Information!');
        });

        it('Should throw error, if displaySpacesCount is not a number', () => {
            expect(() => {artGallery.organizeExhibits(25, null)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits(25, '5')}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits(25, '')}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits(25, undefined)}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits(25, [5])}).to.throw('Invalid Information!');
            expect(() => {artGallery.organizeExhibits(25, {})}).to.throw('Invalid Information!');
        });
    });
});