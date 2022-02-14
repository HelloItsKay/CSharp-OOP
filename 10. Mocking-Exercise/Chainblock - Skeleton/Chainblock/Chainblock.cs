using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }
        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int Count => transactions.Count;
        public void Add(ITransaction tx)
        {
            if (!transactions.ContainsKey(tx.Id))
            {
                transactions.Add(tx.Id, tx);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        public bool Contains(ITransaction tx)

            => Contains(tx.Id);


        public bool Contains(int id)
            => transactions.ContainsKey(id);

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (transactions.ContainsKey(id))
            {
                throw  new ArgumentException();
            }

            transactions[id].Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            if (transactions.ContainsKey(id))
            {
                return null;
            }

            return transactions[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }
    }
}
