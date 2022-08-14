using System.Text.RegularExpressions;

namespace Task5
{
    internal class PhoneBookConsoleHost
    {
        #region Fields

        private readonly PhoneBook _phoneBook;
        private bool _isRun;

        #endregion

        #region Constructors

        private PhoneBookConsoleHost(int hashtableSize)
        {
            _phoneBook = new PhoneBook(hashtableSize);
        }

        #endregion

        #region Instance Methods

        public void Run()
        {
            _isRun = true;

            while (_isRun)
            {
                CallMenu();
            }
        }

        public void Stop()
        {
            _isRun = false;
        }

        private void CallMenu()
        {
            Console.Clear();

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add contact.");
            Console.WriteLine("2. Edit contact.");
            Console.WriteLine("3. Remove contact.");
            Console.WriteLine("4. Show all contacts.");
            Console.WriteLine("5. Exit.");

            var pressedKey = Console.ReadKey();

            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:

                    AddContact();

                    break;

                case ConsoleKey.D2:

                    EditContact();

                    break;

                case ConsoleKey.D3:

                    RemoveContact();

                    break;

                case ConsoleKey.D4:

                    ShowAllContacts();

                    break;

                case ConsoleKey.D5:

                    Stop();

                    break;

                default:
                    break;
            }
        }

        private void AddContact()
        {
            Console.Clear();

            var name = InputName();
            var phoneNumber = InputPhoneNumber();

            _phoneBook.AddContact(name, phoneNumber);
        }

        private void EditContact()
        {
            Console.Clear();

            var name = InputName();
            var phoneNumber = InputPhoneNumber();

            _phoneBook.EditContact(name, phoneNumber);
        }

        private void RemoveContact()
        {
            Console.Clear();

            var name = InputName();

            _phoneBook.RemoveContact(name);
        }

        private void ShowAllContacts()
        {
            Console.Clear();

            var contacts = _phoneBook.GetAllContacts();

            foreach (var contact in contacts)
            {
                Console.WriteLine("Name: {0} | Phone number: {1}", contact.Key, contact.Value);
            }

            Console.Write("Press any key for continue...");

            Console.ReadKey();
        }

        private string InputName()
        {
            var name = string.Empty;

            do
            {
                Console.Clear();

                Console.Write("Enter name: ");

                name = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(name));

            return name;
        }

        private string InputPhoneNumber()
        {
            var phoneNumber = string.Empty;

            do
            {
                Console.Clear();

                Console.Write("Enter phone number: ");

                phoneNumber = Console.ReadLine();
            }
            while (!ValidatePhoneNumber(phoneNumber));

            return phoneNumber!;
        }

        private bool ValidatePhoneNumber(string? phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            var pattern = @"^\+\d{12,}";

            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Builder

        public class PhoneBookConsoleHostBuilder
        {
            #region Fields

            private int _hashtableSize = 5;

            #endregion

            #region Instance Methods

            public PhoneBookConsoleHostBuilder SetHashtableSize(int hashtableSize)
            {
                if (hashtableSize < 1)
                {
                    throw new ArgumentException("Hashtable size should be more than 0!", nameof(hashtableSize));
                }

                _hashtableSize = hashtableSize;

                return this;
            }

            public PhoneBookConsoleHost Build()
            {
                return new PhoneBookConsoleHost(_hashtableSize);
            }

            #endregion
        }

        #endregion
    }
}