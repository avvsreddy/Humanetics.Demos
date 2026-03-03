using System.Net.Mail;

namespace Humanetics.BackApp
{
    public class Account
    {
        public int Balance { get; set; }
        public int AccountNumber { get; set; }
        public int Pin { get; set; }

        public bool IsActive { get; set; }

        public int MinBalance { get; set; }


        private INotificationService notificationService;

        public Account(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public bool Deposit(int amount)
        {

            // Check if the account is active else throw an exception
            if (!IsActive)
            {
                throw new InvalidOperationException("Account is not active.");
            }

            // Check if the amount is positive and non zero else throw an exception
            if (amount <= 0)
            {
                throw new InvalidOperationException("Deposit amount must be positive and non-zero.");
            }

            // If all checks are passed, add the amount to the balance and return true
            Balance += amount;

            // after adding the amount to the balance, must notify the user about the new balance and the amount deposited by email
            //NotificationService notificationService = new NotificationService();
            notificationService.SendEmail("to@example.com", "Deposit Notification", $"You have deposited {amount}. Your new balance is {Balance}.");

            return true;

        }

        public bool Withdraw(int amount, int pin)
        {
            // Check if the account is active else throw an exception
            if (!IsActive)
            {
                throw new InvalidOperationException("Account is not active.");
            }
            // Check if the amount is positive and non zero else throw an exception
            if (amount <= 0)
            {
                throw new InvalidOperationException("Withdrawal amount must be positive and non-zero.");
            }
            // Check if the balance after withdrawal is greater than or equal to the minimum balance else throw an exception
            if (Balance - amount < MinBalance)
            {
                throw new InvalidOperationException("Insufficient funds. Minimum balance requirement not met.");
            }
            if (pin != this.Pin)
            {
                throw new InvalidOperationException("Invalid PIN.");
            }
            // If all checks are passed, subtract the amount from the balance and return true
            Balance -= amount;

            //NotificationService notificationService = new NotificationService();
            notificationService.SendEmail("to@example.com", "Withdrawal Notification", $"You have withdrawn {amount}. Your new balance is {Balance}.");
            return true;
        }
    }



    public interface INotificationService
    {
        void SendEmail(string to, string subject, string body);
    }

    public class MailService : INotificationService
    {
        public void SendEmail(string to, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp.example.com");
            MailMessage mailMessage = new MailMessage("from@example.com", to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            client.Send(mailMessage);

        }
    }
}
