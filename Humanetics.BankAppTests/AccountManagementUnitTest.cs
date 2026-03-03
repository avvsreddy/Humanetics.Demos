using Humanetics.BackApp;
using Moq;
namespace Humanetics.BankAppTests
{
    public class AccountManagementUnitTest
    {

        private Account target = null;


        [SetUp]
        public void Setup() // This method will be called before each test method is executed. It is used to set up any necessary objects or state for the tests.
        {

            Moq.Mock<INotificationService> mockNotificationService = new Moq.Mock<INotificationService>();
            mockNotificationService.Setup(service => service.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            target = new Account(mockNotificationService.Object);
            target.Balance = 0;
            target.MinBalance = 0;
            target.AccountNumber = 123456;
            target.Pin = 1234;
            target.IsActive = true;
        }
        [TearDown]
        public void TearDown() // This method will be called after each test method is executed. It is used to clean up any resources or state that were set up in the Setup method.
        {
            target = null;
        }

        [Test]
        public void DepositTest_WithValidInput_MustReturnTrue()
        {
            //Account target = new Account();
            //target.Balance = 0;
            //target.AccountNumber = 123456;
            //target.Pin = 1234;
            //target.IsActive = true;

            bool result = target.Deposit(1000);
            //Assert.IsTrue(result);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        public void DepositTest_WithValidInput_MustIncreaseBalance()
        {
            //Account target = new Account();
            //target.Balance = 0;
            //target.AccountNumber = 123456;
            //target.Pin = 1234;
            //target.IsActive = true;
            bool result = target.Deposit(1000);
            Assert.That(target.Balance, Is.EqualTo(1000));

        }

        [Test]
        public void DepositTest_WithInactiveAccount_MustThrowException()
        {
            //Account target = new Account();
            target.IsActive = false;
            Assert.Throws<InvalidOperationException>(() => target.Deposit(1000));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void DepositTest_WithNegativeOrZeroAmount_MustThrowException(int amount)
        {
            //Account target = new Account();
            //target.IsActive = true;
            Assert.Throws<InvalidOperationException>(() => target.Deposit(amount));
        }

        [Test]
        public void WithdrawTest_WithValidInput_MustReturnTrue()
        {
            target.Balance = 10000;
            target.MinBalance = 1000;
            bool result = target.Withdraw(1000, 1234);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void WithdrawTest_WithValidInput_MustDecreaseBalance()
        {
            target.Balance = 10000;
            target.MinBalance = 1000;
            bool result = target.Withdraw(1000, 1234);
            Assert.That(target.Balance, Is.EqualTo(9000));

        }

        [Test]
        public void WithdrawTest_WithInactiveAccount_MustThrowException()
        {
            target.IsActive = false;
            target.Balance = 10000;
            target.MinBalance = 1000;
            Assert.Throws<InvalidOperationException>(() => target.Withdraw(1000, 1234));
        }

        [TestCase(0)]
        [TestCase(-100)]
        public void WithdrawTest_WithNegativeOrZeroAmount_MustThrowException(int amount)
        {
            target.Balance = 10000;
            target.MinBalance = 1000;
            Assert.Throws<InvalidOperationException>(() => target.Withdraw(amount, 1234));

        }

        [Test]
        public void WithdrawTest_WithInsufficientFunds_MustThrowException()
        {
            target.Balance = 10000;
            target.MinBalance = 1000;
            Assert.Throws<InvalidOperationException>(() => target.Withdraw(9500, 1234));
        }

        [Test]
        public void WithdrawTest_WithInvalidPin_MustThrowException()
        {
            target.Balance = 10000;
            target.MinBalance = 1000;
            Assert.Throws<InvalidOperationException>(() => target.Withdraw(1000, 4321));
        }
    }

    // Manual Mock class for INotificationService to be used in unit testing
    //class MockNotificationService : INotificationService
    //{
    //    public void SendEmail(string to, string subject, string body)
    //    {
    //        // Do nothing or log the email for testing purposes
    //    }
    //}

}