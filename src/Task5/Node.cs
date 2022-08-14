namespace Task5
{
    internal class Node<TKey, TValue>
        where TKey : class
        where TValue : class
    {
        #region Fields

        private readonly TKey _key;
        private readonly TValue _value;

        #endregion

        #region Constructors

        public Node(TKey key, TValue value)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region Properties

        public TKey Key => _key;

        public TValue Value => _value;

        public Node<TKey, TValue>? Next { get; set; }

        #endregion
    }
}