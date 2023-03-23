
namespace Chainblock.Tests;

using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models;
using Chainblock.Models.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class ChainblockTests
{
    private IChainblock chainBlock;
    private ITransaction testTransaction;

    [SetUp]
    public void SetUp()
    {
        chainBlock = new ChainBlock();
        testTransaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 1000);
    }

    [Test]
    public void ConstructorShouldInitializeTransactionsCollection()
    {
        Type chainblockType = chainBlock.GetType();

        FieldInfo transactionsField = chainblockType
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(fi => fi.Name == "transactions");

        IDictionary<int, ITransaction> value = transactionsField.GetValue(chainBlock) as IDictionary<int, ITransaction>;

        Assert.IsNotNull(value);
    }

    [Test]
    public void AddShouldAppendTheTransactionToDataCollection()
    {
        chainBlock.Add(testTransaction);

        bool transactionAdded = chainBlock.Contains(testTransaction.Id);

        Assert.IsTrue(transactionAdded);
    }

    [Test]
    public void AddShouldIncreaseCount()
    {
        chainBlock.Add(testTransaction);

        int expectedCount = 1;
        int actualCount = chainBlock.Count;

        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void AddShouldThrowExceptionWhenAddingSameTransaction()
    {
        chainBlock.Add(testTransaction);

        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => chainBlock.Add(testTransaction));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionDuplicated, testTransaction.Id),
            exception.Message);
    }

    [Test]
    public void AddShouldThrowExceptionWhenAddingTransactionWithExistingId()
    {
        chainBlock.Add(testTransaction);

        ITransaction newTransaction = new Transaction(testTransaction.Id, TransactionStatus.Failed, "Ivan", "Kiro", 999);

        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => chainBlock.Add(newTransaction));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionDuplicated, testTransaction.Id),
            exception.Message);
    }

    [Test]
    public void ContainsByTransactionShouldReturnTrueWhenExists()
    {
        chainBlock.Add(testTransaction);

        bool transactionExists = chainBlock.Contains(testTransaction.Id);

        Assert.IsTrue(transactionExists);
    }

    [Test]
    public void ContainsByTransactionShouldReturnFalseWhenNotExists()
    {
        bool transactionExists = chainBlock.Contains(testTransaction.Id);

        Assert.IsFalse(transactionExists);
    }

    [Test]
    public void ContainsByIdShouldReturnTrueWhenExists()
    {
        chainBlock.Add(testTransaction);

        bool transactionExists = chainBlock.Contains(testTransaction.Id);

        Assert.IsTrue(transactionExists);
    }

    [Test]
    public void ContainsByIdShouldReturnFalseWhenNotExists()
    {
        bool transactionExists = chainBlock.Contains(testTransaction.Id);

        Assert.IsFalse(transactionExists);
    }

    [Test]
    public void CountShouldReturnSameNumberAsNumberOfTransactionsAreAdded()
    {
        int expectedCount = 2;

        ITransaction testTransaction2 = new Transaction(testTransaction.Id + 1, TransactionStatus.Successfull, "Pesho", "Gosho", 123);

        chainBlock.Add(testTransaction);
        chainBlock.Add(testTransaction2);

        Assert.AreEqual(expectedCount, chainBlock.Count);
    }

    [Test]
    public void CountShouldReturnZeroWhenNoTransactionsAreAdded()
    {
        int expectedCount = 0;

        Assert.AreEqual(expectedCount, chainBlock.Count);
    }

    [TestCase(TransactionStatus.Aborted, TransactionStatus.Unauthorised)]
    [TestCase(TransactionStatus.Aborted, TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Successfull)]
    public void ChangeTransactionStatusShouldChangeStatusCorrectly(TransactionStatus fromStatus, TransactionStatus toStatus)
    {
        testTransaction.Status = fromStatus;
        chainBlock.Add(testTransaction);

        chainBlock.ChangeTransactionStatus(testTransaction.Id, toStatus);

        ITransaction changedTransaction = chainBlock.GetById(testTransaction.Id);

        Assert.AreEqual(toStatus, changedTransaction.Status);
    }

    [Test]
    public void ChangeTransactionStatusShouldThrowExceptionWhenNonExistingTransactionId()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(
             () => chainBlock.ChangeTransactionStatus(testTransaction.Id, testTransaction.Status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionDoesNotExist, testTransaction.Id),
            exception.Message);
    }

    [Test]
    public void GetByIdShouldReturnCorrectTransactionWhenExists()
    {
        chainBlock.Add(testTransaction);

        ITransaction actualTransaction = chainBlock.GetById(testTransaction.Id);

        Assert.AreEqual(testTransaction, actualTransaction);
    }

    [Test]
    public void GetByIdShouldThrowExceptionWhenNonExistingTransactionId()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetById(testTransaction.Id));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionDoesNotExist, testTransaction.Id),
            exception.Message);
    }

    [Test]
    public void RemoveTransactionByIdShouldRemoveTransactionFromDataCollection()
    {
        chainBlock.Add(testTransaction);

        chainBlock.RemoveTransactionById(testTransaction.Id);

        bool transactionExists = chainBlock.Contains(testTransaction.Id);

        Assert.IsFalse(transactionExists);
    }

    [Test]
    public void RemoveTransactionByIdShouldThrowExceptionWhenNonExistingTransactionId()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.RemoveTransactionById(testTransaction.Id));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionDoesNotExist, testTransaction.Id),
            exception.Message);
    }

    [Test]
    public void RemoveTransactionByIdShouldDecreaseCount()
    {
        ITransaction testTransaction2 = new Transaction(2, TransactionStatus.Failed, "Aaa", "Bbb", 50);
        chainBlock.Add(testTransaction);
        chainBlock.Add(testTransaction2);

        chainBlock.RemoveTransactionById(testTransaction2.Id);

        int expectedCount = 1;

        Assert.AreEqual(expectedCount, chainBlock.Count);
    }

    [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Unauthorised)]
    public void GetByTransactionStatusShouldReturnTransactionsOrderedCorrecly(TransactionStatus getStatus, TransactionStatus otherStatus)
    {
        IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
        {
            new Transaction(1, getStatus, "Aaa", "Bbb", 100),
            new Transaction(2, getStatus, "Ccc", "Ddd", 500),
            new Transaction(3, otherStatus, "Eee", "Ggg", 700)
        };

        foreach (ITransaction tx in transactionsToAppend)
        {
            chainBlock.Add(tx);
        }

        IEnumerable<ITransaction> expectedTransactions = transactionsToAppend
            .Where(tx => tx.Status == getStatus)
            .OrderByDescending(tx => tx.Amount);

        IEnumerable<ITransaction> actualTransactions = chainBlock
            .GetByTransactionStatus(getStatus);

        CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
    }

    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    [TestCase(TransactionStatus.Successfull)]
    public void GetByTransactionStatusShouldThrowExceptionWhenCollectionIsEmpty(TransactionStatus status)
    {

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetByTransactionStatus(status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status),
            exception.Message);
    }

    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    public void GetByTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus(TransactionStatus status)
    {
        chainBlock.Add(testTransaction);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetByTransactionStatus(status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status),
            exception.Message);
    }

    [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Failed)]
    public void GetAllSendersWithTransactionStatusShouldReturnNamesOrderedCorrectly(TransactionStatus getStatus,
    TransactionStatus otherStatus)
    {
        IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
        {
            new Transaction(1, getStatus, "Ivan", "Peter", 100),
            new Transaction(2, getStatus, "Ivan", "Asen", 500),
            new Transaction(3, otherStatus, "Andrey", "Gosho", 700)
        };

        foreach (ITransaction tx in transactionsToAppend)
        {
            chainBlock.Add(tx);
        }

        IEnumerable<string> expectedOutput = transactionsToAppend
            .Where(tx => tx.Status == getStatus)
            .OrderBy(tx => tx.Amount)
            .Select(tx => tx.From)
            .ToArray();

        IEnumerable<string> actualOutput = chainBlock
            .GetAllSendersWithTransactionStatus(getStatus);

        CollectionAssert.AreEqual(expectedOutput, actualOutput);
    }

    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    [TestCase(TransactionStatus.Successfull)]
    public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenCollectionIsEmpty(TransactionStatus status)
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetAllSendersWithTransactionStatus(status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status),
            exception.Message);
    }

    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    public void GetAllSendersWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus(TransactionStatus status)
    {
        chainBlock.Add(testTransaction);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetAllSendersWithTransactionStatus(status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status),
            exception.Message);
    }

    [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Failed, TransactionStatus.Failed)]
    public void GetAllReceiversWithTransactionStatusShouldReturnNamesOrderedCorrectly(TransactionStatus getStatus, TransactionStatus otherStatus)
    {
        IEnumerable<ITransaction> transactionsToAppend = new List<ITransaction>()
        {
            new Transaction(1, getStatus, "Ivan", "Peter", 100),
            new Transaction(2, getStatus, "Ivan", "Peter", 500),
            new Transaction(3, otherStatus, "Andrey", "Gosho", 700)
        };

        foreach (ITransaction tx in transactionsToAppend)
        {
            chainBlock.Add(tx);
        }

        IEnumerable<string> expectedOutput = transactionsToAppend
            .Where(tx => tx.Status == getStatus)
            .OrderBy(tx => tx.Amount)
            .Select(tx => tx.To)
            .ToArray();

        IEnumerable<string> actualOutput = chainBlock
            .GetAllReceiversWithTransactionStatus(getStatus);

        CollectionAssert.AreEqual(expectedOutput, actualOutput);
    }

    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    [TestCase(TransactionStatus.Successfull)]
    public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenCollectionIsEmpty(TransactionStatus status)
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetAllReceiversWithTransactionStatus(status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status),
            exception.Message);
    }

    [TestCase(TransactionStatus.Aborted)]
    [TestCase(TransactionStatus.Failed)]
    [TestCase(TransactionStatus.Unauthorised)]
    public void GetAllReceiversWithTransactionStatusShouldThrowExceptionWhenThereAreNoTransactionsWithGivenStatus(TransactionStatus status)
    {
        chainBlock.Add(testTransaction);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
             () => chainBlock.GetAllReceiversWithTransactionStatus(status));

        Assert.AreEqual(
            string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status),
            exception.Message);
    }

    //TODO Same amount
    [Test]
    public void GetAllOrderedByAmountDescThenByIdShouldReturnTransactionsOrderedCorrectly()
    {
        ICollection<ITransaction> transactionsToAppend = new HashSet<ITransaction>()
        {
            new Transaction(1, TransactionStatus.Failed, "Aaa", "Bbb", 100),
            new Transaction(2, TransactionStatus.Successfull, "Ccc", "Gosho", 1500),
            new Transaction(3, TransactionStatus.Successfull, "Eee", "Ggg", 700)
        };

        foreach (ITransaction tx in transactionsToAppend)
        {
            chainBlock.Add(tx);
        }

        IEnumerable<ITransaction> expectedOutput = transactionsToAppend
            .OrderByDescending(tx => tx.Amount)
            .ThenBy(tx => tx.Id);

        IEnumerable<ITransaction> actualOutput = chainBlock
            .GetAllOrderedByAmountDescendingThenById();

        CollectionAssert.AreEqual(expectedOutput, actualOutput);
    }

    [Test]
    public void GetAllOrderedByAmountDescThenByIdShouldReturnEmptyCollectionWhenNoTransactions()
    {
        IEnumerable<ITransaction> actualTransactions = chainBlock
            .GetAllOrderedByAmountDescendingThenById();

        CollectionAssert.IsEmpty(actualTransactions);
    }
}

