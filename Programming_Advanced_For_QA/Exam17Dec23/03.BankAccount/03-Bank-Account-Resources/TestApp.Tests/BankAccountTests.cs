using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    private BankAccount account;

    [SetUp]
    public void SetUp()
    {
        this.account = new BankAccount(150);
    }
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Assert
        Assert.That(account.Balance, Is.EqualTo(150));
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Act
        account.Deposit(150);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(300));
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Act && Assert
        Assert.Throws<ArgumentException>(() => account.Deposit(-1));
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Act
        account.Withdraw(100);

        // Assert
        Assert.That(account.Balance, Is.EqualTo(50));
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Act && Assert
        Assert.Throws<ArgumentException>(() => account.Withdraw(-1));
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Act && Assert
        Assert.Throws<ArgumentException>(() => account.Withdraw(151));
    }
}
