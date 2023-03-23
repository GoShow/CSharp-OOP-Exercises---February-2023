namespace Chainblock.Tests;

using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models.Interfaces;
using Models;
using NUnit.Framework;
using System;

[TestFixture]
public class TransactionTests
{
    [Test]
    public void ConstructorShouldInitializeTransactionProperly()
    {
        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);

        Assert.IsNotNull(transaction);
    }

    [Test]
    public void ConstructorShouldInitializeIdProperly()
    {
        //Arrange
        int expectedId = 1;

        //Act
        ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);

        //Assert
        Assert.AreEqual(expectedId, transaction.Id);
    }

    [Test]
    public void ConstructorShouldInitializeStatusProperly()
    {
        TransactionStatus expectedStatus = TransactionStatus.Unauthorised;

        ITransaction transaction = new Transaction(1, expectedStatus, "Pesho", "Gosho", 1000);

        Assert.AreEqual(expectedStatus, transaction.Status);
    }

    [Test]
    public void ConstructorShouldInitializeSenderProperly()
    {
        string expectedSender = "Pesho";

        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedSender, "Gosho", 1000);

        Assert.AreEqual(expectedSender, transaction.From);
    }

    [Test]
    public void ConstructorShouldInitializeReceiverProperly()
    {
        string expectedReceiver = "Gosho";

        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", expectedReceiver, 1000);

        Assert.AreEqual(expectedReceiver, transaction.To);
    }

    [Test]
    public void ConstructorShouldInitializeAmountProperly()
    {
        decimal expectedAmont = 1000;

        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", expectedAmont);

        Assert.AreEqual(expectedAmont, transaction.Amount);
    }

    [TestCase(-100)]
    [TestCase(-1)]
    [TestCase(0)]
    public void IdSetterShouldThrowExceptionWithZeroOrNegativeId(int id)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => new Transaction(id, TransactionStatus.Successfull, "Pesho", "Gosho", 1000));

        Assert.AreEqual(TransactionExceptionMessages.IdNotPositiveNumber, exception.Message);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("     ")]
    public void SenderSetterShouldThrowExceptionWithNullOrWhiteSpaceString(string from)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => new Transaction(1, TransactionStatus.Successfull, from, "Gosho", 1000));

        Assert.AreEqual(TransactionExceptionMessages.SenderNullOrWhiteSpace, exception.Message);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("     ")]
    public void ReceiverSetterShouldThrowExceptionWithNullOrWhiteSpaceString(string to)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => new Transaction(1, TransactionStatus.Successfull, "Pesho", to, 1000));

        Assert.AreEqual(TransactionExceptionMessages.ReceiverNullOrWhiteSpace, exception.Message);
    }

    [TestCase(-500)]
    [TestCase(-0.0000000001)]
    [TestCase(0)]
    public void AmountSetterShouldThrowExceptionWithZeroOrNegativeAmount(decimal amount)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", amount));

        Assert.AreEqual(TransactionExceptionMessages.AmountNotPositiveNumber, exception.Message);
    }
}
