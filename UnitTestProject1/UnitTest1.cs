using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabSheet9;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            decimal finalBalance = 200m;

            //Act
            acc1.DepositMoney(200m);

            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestMulibleDeposits()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            decimal finalBalance = 200m;

            //Act
            acc1.DepositMoney(100m);
            acc1.DepositMoney(60m);
            acc1.DepositMoney(40m);

            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestNewAccountZeroBalance()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            decimal finalBalance = 0m;

            //Act


            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestWithdrawSufficientFunds()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            acc1.DepositMoney(200m);
            decimal finalBalance = 100m;

            //Act
            acc1.WithdrawMoney(100m);

            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestWithdrawInsufficientFunds()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            acc1.DepositMoney(100m);
            decimal finalBalance = 100m;

            //Act
            acc1.WithdrawMoney(200m);

            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestWithdrawSufficientFundsWithOverdraft()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            acc1.OverDraftLimit = 200m;
            decimal finalBalance = -100m;

            //Act
            acc1.WithdrawMoney(100m);

            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestWithdrawInsufficientFundsWithOverdraft()
        {
            //Arrange
            BankAccount acc1 = new BankAccount();
            acc1.OverDraftLimit = 200m;
            decimal finalBalance = 0m;

            //Act
            acc1.WithdrawMoney(300m);

            //Assert
            NUnit.Framework.Assert.AreEqual(finalBalance, acc1.Balance);
        }

    }
}
