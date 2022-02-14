using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    public class ChainBlockTests
    {
        private IChainblock chainblock;



        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();
        }

        [TestCaseSource(nameof(Add_GetTransactionForIt))]
        public void Add_MethodShouldOnlyHaveUniqueValues(IEnumerable<ITransaction> transactions, int expectedCount)
        {
            foreach (var transaction in transactions)
            {
                chainblock.Add(transaction);
            }
            Assert.AreEqual(chainblock.Count, expectedCount);


        }
        [TestCaseSource(nameof(Contains_GetTransactionForIt))]
        public void Contains_ShouldReturnTrueIFTransactionExists(
            List<ITransaction> transactions,
            ITransaction targetTransaction,
            bool exists)
        {
            foreach (var tranasction in transactions)
            {
                chainblock.Add(tranasction);
            }

            bool doesExsist = chainblock.Contains(targetTransaction);
            Assert.IsTrue(doesExsist == exists);
        }
        [TestCaseSource(nameof(ChangeTransactionStatus_GetTransactions))]
        public void Change_TransactionStatusShouldChangeIfIdExists(List<ITransaction> transactions, int id, TransactionStatus newStatus)
        {
            foreach (var transaction in transactions)
            {
                chainblock.Add(transaction);
            }
            chainblock.ChangeTransactionStatus(id, newStatus);
            ITransaction myTransaction = chainblock.GetById(id);
            Assert.AreEqual(myTransaction.Status, newStatus);
        }

        private static IEnumerable<TestCaseData> ChangeTransactionStatus_GetTransactions()
        {
            yield return new TestCaseData(new List<ITransaction>
                {
                    new Transaction
                    {
                        Id = 1,
                        Amount = 400,
                        Status = TransactionStatus.Aborted,
                        From = "gogo",
                        To = "pesho"
                    },
                    new Transaction
                    {
                        Id = 2,
                        Amount = 2200,
                        Status = TransactionStatus.Failed,
                        From = "Kiro",
                        To = "Breika"
                    },

                },
                2,
                TransactionStatus.Successfull);
        }

        private static IEnumerable<TestCaseData> Contains_GetTransactionForIt()
        {
            yield return new TestCaseData(new List<ITransaction>
            {

            },
                new Transaction()
                {
                    Id = 14,
                    Status = TransactionStatus.Aborted,
                    From = "test",
                    To = "new",
                    Amount = 120
                },
                false);



            yield return new TestCaseData(new List<ITransaction>
            {
                new Transaction
                {
                    Id = 5,
                    Status = TransactionStatus.Successfull,
                    From = "asdasd",
                    To = "qweqwe",
                    Amount = 120
                }
            },
               new Transaction()
               {
                   Id = 5,
                   Status = TransactionStatus.Successfull,
                   From = "asdasd",
                   To = "qweqwe",
                   Amount = 120
               },
                true);
        }

        private static IEnumerable<TestCaseData> Add_GetTransactionForIt()
        {
            yield return new TestCaseData(
                new List<ITransaction>
                {
                    new Transaction
                    {
                        Id=1,
                        Status = TransactionStatus.Successfull,
                        From = "FromTest",
                        To = "Test",
                        Amount = 250
                    },
                    new Transaction
                    {
                        Id = 2,
                        Status = TransactionStatus.Aborted,
                        From = "BGTests",
                        To="EnTests",
                        Amount = 200
                    },
                    new Transaction
                    {
                        Id = 1,
                        Status = TransactionStatus.Unauthorized,
                        From = "Niko",
                        To="Stoicho",
                        Amount = 2020
                    }


                }, 2);
        }

    }
}
