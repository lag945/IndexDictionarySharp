using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic
{
    public class IndexDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        readonly Dictionary<TKey, TValue> m_Dictionary = null;
        readonly List<TKey> m_List = null;

        public IndexDictionary() : this(0, null) { }

        public IndexDictionary(int capacity) : this(capacity, null) { }

        public IndexDictionary(IEqualityComparer<TKey> comparer) : this(0, comparer) { }

        public IndexDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            m_Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
            m_List = new List<TKey>(capacity);
        }

        public TValue this[TKey key]
        {
            get => m_Dictionary[key];
            set
            {
                if (!m_Dictionary.ContainsKey(key))
                    m_List.Add(key);
                m_Dictionary[key] = value;
            }
        }

        public ICollection<TKey> Keys => m_List;

        public ICollection<TValue> Values => m_Dictionary.Values;

        public int Count => m_Dictionary.Count;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            m_Dictionary.Add(key, value);
            m_List.Add(key);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            m_Dictionary.Add(item.Key, item.Value);
            m_List.Add(item.Key);
        }

        public void Clear()
        {
            m_Dictionary.Clear();
            m_List.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (m_Dictionary.ContainsKey(item.Key) && EqualityComparer<TValue>.Default.Equals(m_Dictionary[item.Key], item.Value))
            {
                return true;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return m_Dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            foreach (TKey key in m_Dictionary.Keys)
            {
                array[arrayIndex++] = new KeyValuePair<TKey, TValue>(key, m_Dictionary[key]);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            bool ret = m_Dictionary.Remove(key);
            m_List.Remove(key);
            return ret;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (m_Dictionary.ContainsKey(item.Key) && EqualityComparer<TValue>.Default.Equals(m_Dictionary[item.Key], item.Value))
            {
                m_Dictionary.Remove(item.Key);
                m_List.Remove(item.Key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            return m_Dictionary.TryGetValue(key, out value);
        }

        public bool TryGetValueByIndex(int index, [MaybeNullWhen(false)] out TValue value)
        {
            TKey key = m_List[index];
            return TryGetValue(key, out value);
        }

        public TValue GetValue(int index) => m_Dictionary[m_List[index]];

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_Dictionary.GetEnumerator();
        }
    }

}
