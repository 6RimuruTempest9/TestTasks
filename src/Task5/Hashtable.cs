namespace Task5
{
    internal class Hashtable<TKey, TValue>
        where TKey : class
        where TValue : class
    {
        #region Fields

        private readonly Node<TKey, TValue>[] _buckets;

        #endregion

        #region Constructor

        public Hashtable(int size)
        {
            if (size < 1)
            {
                throw new ArgumentException("Size should be more than 0!", nameof(size));
            }

            _buckets = new Node<TKey, TValue>[size];
        }

        #endregion

        #region Indexer

        public TValue this[TKey key]
        {
            get
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                if (!TryFindNodeByKey(key, out var node))
                {
                    throw new ArgumentOutOfRangeException(nameof(key), "Hashtable does not contain a value with this key.");
                }

                return node!.Value;
            }
        }

        #endregion

        #region Instance Methods

        public void Add(TKey key, TValue value)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var node = new Node<TKey, TValue>(key, value);

            var bucketIndex = GetBucketIndexByKey(key);

            var bucket = _buckets[bucketIndex];

            if (bucket is null)
            {
                _buckets[bucketIndex] = node;
            }
            else
            {
                var lastNode = GetLastNode(bucket);

                lastNode.Next = node;
            }
        }

        public void Edit(TKey key, TValue newValue)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (newValue is null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }

            if (!TryFindNodeByKey(key, out var node))
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Hashtable does not contain a value with this key.");
            }

            var newNode = new Node<TKey, TValue>(key, newValue);

            newNode.Next = node!.Next;

            var previousNode = GetPreviousNode(node!);

            if (previousNode is null)
            {
                var bucketIndex = GetBucketIndexByKey(key);

                _buckets[bucketIndex] = newNode;
            }
            else
            {
                previousNode.Next = newNode;
            }
        }

        public bool Remove(TKey key)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var isRemoved = default(bool);

            if (TryFindNodeByKey(key, out var node))
            {
                var previousNode = GetPreviousNode(node!);

                if (previousNode is null)
                {
                    var bucketIndex = GetBucketIndexByKey(key);

                    _buckets[bucketIndex] = node!.Next;
                }
                else
                {
                    previousNode.Next = node!.Next;
                }

                isRemoved = true;
            }

            return isRemoved;
        }

        public IDictionary<TKey, TValue> GetAllKeyValuePairs()
        {
            var keyValuePairs = new Dictionary<TKey, TValue>();

            foreach (var bucket in _buckets)
            {
                var currentNode = bucket;

                while (currentNode is not null)
                {
                    keyValuePairs.Add(currentNode.Key, currentNode.Value);

                    currentNode = currentNode.Next;
                }
            }

            return keyValuePairs;
        }

        private Node<TKey, TValue>? GetPreviousNode(Node<TKey, TValue> node)
        {
            var previousNode = default(Node<TKey, TValue>);
            var currentNode = GetBucketByKey(node.Key);

            while (currentNode != node)
            {
                previousNode = currentNode;
                currentNode = currentNode!.Next;
            }

            return previousNode;
        }

        private Node<TKey, TValue>? GetBucketByKey(TKey key)
        {
            var bucketIndex = GetBucketIndexByKey(key);

            return _buckets[bucketIndex];
        }

        protected virtual int GetBucketIndexByKey(TKey key)
        {
            return Math.Abs(HashCode.Combine(key) % _buckets.Length);
        }

        private Node<TKey, TValue> GetLastNode(Node<TKey, TValue> bucket)
        {
            var lastNode = bucket;

            while (lastNode.Next is not null)
            {
                lastNode = lastNode.Next;
            }

            return lastNode;
        }

        private bool TryFindNodeByKey(TKey key, out Node<TKey, TValue>? node)
        {
            node = default;

            var currentNode = GetBucketByKey(key);

            while (currentNode is not null)
            {
                if (currentNode.Key.Equals(key))
                {
                    node = currentNode;

                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        #endregion
    }
}