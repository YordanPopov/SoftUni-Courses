import { describe, it } from 'mocha';
import { workforceManagement } from '../WorkforceManagment.js';
import { expect } from 'chai';

describe.only('Test workforceManagment', () => {
    describe('Test recruitStaff', () => {
        it('Should return correct message, if experience is greater than or equal to 4', () => {
            const expectedResult = 'John has been successfully recruited for the role of Developer.';

            expect(workforceManagement.recruitStaff('John', 'Developer', 4)).to.be.equal(expectedResult);
            expect(workforceManagement.recruitStaff('John', 'Developer', 40)).to.be.equal(expectedResult);
        });

        it('Should return correct message, if experience is lower than 4', () => {
            const expectedResult = 'John is not suitable for this role.'

            expect(workforceManagement.recruitStaff('John', 'Developer', 3)).to.be.equal(expectedResult);
            expect(workforceManagement.recruitStaff('John', 'Developer', 0)).to.be.equal(expectedResult);
        });

        it('Should throw error, if role is not Developer', () => {
            expect(() => { workforceManagement.recruitStaff('John', 'Tester', 4) }).throw('We are not currently hiring for this role.');
            expect(() => { workforceManagement.recruitStaff('John', 'developer', 4) }).throw('We are not currently hiring for this role.');
            expect(() => { workforceManagement.recruitStaff('John', '', 4) }).throw('We are not currently hiring for this role.');
        });
    });

    describe('Test computeWages', () => {
        it('Should return correct totalPayment, if houseWorked is less than or equal to 160', () => {
            expect(workforceManagement.computeWages(100)).to.be.equal(1800);
            expect(workforceManagement.computeWages(159)).to.be.equal(2862);
            expect(workforceManagement.computeWages(160)).to.be.equal(2880);
            expect(workforceManagement.computeWages(0)).to.be.equal(0);
            expect(workforceManagement.computeWages(100.3)).closeTo(1805.4, 0.01);
        });

        it('Should add 1500 to totalPayment, if houseWorked is more than 160', () => {
            expect(workforceManagement.computeWages(161)).to.be.equal(4398);
        });

        it('Should throw error, if not a number type is given', () => {
            expect(() => { workforceManagement.computeWages('100') }).Throw('Invalid hours');
            expect(() => { workforceManagement.computeWages([100]) }).Throw('Invalid hours');
            expect(() => { workforceManagement.computeWages(true) }).Throw('Invalid hours');
            expect(() => { workforceManagement.computeWages({ number: 100 }) }).Throw('Invalid hours');
        });

        it('Should throw error, if negative number is given', () => {
            expect(() => { workforceManagement.computeWages(-1) }).Throw('Invalid hours');
        });
    });

    describe('Test dismissEmployee', () => {
        let workforce = [];

        beforeEach(() => {
            workforce = ['Petar', 'Ivan', 'George'];
        });

        it('Should return correct result, if valid input parameters are given', () => {
            expect(workforceManagement.dismissEmployee(workforce, 0)).to.be.equal('Ivan, George');
            expect(workforceManagement.dismissEmployee(workforce, 1)).to.be.equal('Petar, George');
            expect(workforceManagement.dismissEmployee(workforce, 2)).to.be.equal('Petar, Ivan');
        });

        it('Should throw error, if invalid index is given', () => {
            expect(() => { workforceManagement.dismissEmployee(workforce, -1) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(workforce, 3) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(workforce, '0') }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(workforce, [1]) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(workforce, true) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(workforce, NaN) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(workforce, { index: 0 }) }).throw('Invalid input');
        });

        it('Should throw error, if non-array for first parameter is given', () => {
            expect(() => { workforceManagement.dismissEmployee(110, 0) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee('', 0) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee('["Peter", "Ivan"]', 0) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(true, 0) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee(NaN, 0) }).throw('Invalid input');
            expect(() => { workforceManagement.dismissEmployee({ names: ['Peter', 'Ivan', 'Gosho'] }, 0) }).throw('Invalid input');
        });
    });
}); 