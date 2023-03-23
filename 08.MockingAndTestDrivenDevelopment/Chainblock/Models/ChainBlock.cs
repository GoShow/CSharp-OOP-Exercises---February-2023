using Chainblock.Enums;
using Chainblock.Exceptions;
using Chainblock.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Models;

public class ChainBlock : IChainblock
{
    IDictionary<int, ITransaction> transactions;

    public ChainBlock()
    {
        transactions = new Dictionary<int, ITransaction>();
    }

    public int Count
        => transactions.Count;

    public void Add(ITransaction tx)
    {
        if (Contains(tx.Id))
        {
            throw new ArgumentException(string.Format(ChainblockExceptionMessages.TransactionDuplicated, tx.Id));
        }

        transactions.Add(tx.Id, tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new ArgumentException(string.Format(ChainblockExceptionMessages.TransactionDoesNotExist, id));
        }

        transactions[id].Status = newStatus;
    }

    public bool Contains(ITransaction tx)
        => Contains(tx.Id);

    public bool Contains(int id)
        => transactions.ContainsKey(id);

    public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        => this.transactions.Values
            .OrderByDescending(tx => tx.Amount)
            .ThenBy(tx => tx.Id);

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        if (!transactions.Any())
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status));
        }

        IEnumerable<string> result = transactions.Values
            .Where(tx => tx.Status == status)
            .OrderBy(tx => tx.Amount)
            .Select(tx => tx.To);

        if (!result.Any())
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status));
        }

        return result;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        if (!transactions.Any())
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status));
        }

        IEnumerable<string> result = transactions.Values
            .Where(tx => tx.Status == status)
            .OrderBy(tx => tx.Amount)
            .Select(tx => tx.From);

        if (!result.Any())
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status));
        }

        return result;
    }

    public ITransaction GetById(int id)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionDoesNotExist, id));
        }

        return transactions[id];
    }

    public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!transactions.Any())
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status));
        }

        IEnumerable<ITransaction> result = transactions.Values
            .Where(t => t.Status == status)
            .OrderByDescending(t => t.Amount);

        if (!result.Any())
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionsWithStatusDoesNotExist, status));
        }

        return result;
    }

    public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        throw new NotImplementedException();
    }

    public void RemoveTransactionById(int id)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new InvalidOperationException(string.Format(ChainblockExceptionMessages.TransactionDoesNotExist, id));
        }

        transactions.Remove(id);
    }
}
