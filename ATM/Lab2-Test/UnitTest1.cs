using System;
using Xunit;
using static ATM.Program;
namespace Lab2_Test
{
    public class UnitTest1
    {
        [Fact]
        public void WillAddBalance()
        {
            int balance = 5000;
            string input = "5500";
            Assert.Equal(10500, Deposit(input, balance));
        }

        [Fact]
        public void DepositWillBreak()
        {
            int balance = 5000;
            string input = "hello";
            Action breakDeposit = (() => Deposit(input, balance));
            Exception e = Record.Exception(breakDeposit);
            Assert.IsType<FormatException> (e);
        }

        [Fact]
        public void WillNotOverdraw()
        {
            int balance = 5000;
            string input = "6000";
            Action breakWithdrawal = (() => Withdraw(input, balance));
            Exception e = Record.Exception(breakWithdrawal);
            Assert.IsType<ArgumentException>(e);
        }

        [Fact]
        public void WithdrawalWillBreak()
        {
            int balance = 5000;
            string input = "hi i don't follow instructions";
            Action breakWithdrawal = (() => Withdraw(input, balance));
            Exception e = Record.Exception(breakWithdrawal);
            Assert.IsType<FormatException>(e);
        }

        [Fact]
        public void WillWithdraw()
        {
            int balance = 5000;
            string input = "4000";
            Assert.Equal(1000, Withdraw(input, balance));
        }
    }
}
