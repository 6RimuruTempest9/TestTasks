namespace Task5
{
    internal class PhoneBook
    {
        #region Fields

        private readonly Hashtable<string, string> _contacts;

        #endregion

        #region Constructors

        public PhoneBook(int hashtableSize)
        {
            _contacts = new Hashtable<string, string>(hashtableSize);
        }

        #endregion

        #region Indexer

        public string this[string name]
        {
            get
            {
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return _contacts[name];
            }
        }

        #endregion

        #region Instance Methods

        public void AddContact(string name, string phoneNumber)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (phoneNumber is null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            _contacts.Add(name, phoneNumber);
        }

        public void EditContact(string name, string phoneNumber)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (phoneNumber is null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            _contacts.Edit(name, phoneNumber);
        }

        public bool RemoveContact(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _contacts.Remove(name);
        }

        public IDictionary<string, string> GetAllContacts()
        {
            return _contacts.GetAllKeyValuePairs();
        }

        #endregion
    }
}