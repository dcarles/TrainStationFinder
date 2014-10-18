using System.Collections.Generic;
using TrainStationFinder.DataStructures;

namespace TrainStationFinder.Test
{
    public class FakeTrie<T> : ITrie<T>
    {
        private readonly Stack<KeyValuePair<string, T>> m_Stack;

        public FakeTrie()
        {
            m_Stack = new Stack<KeyValuePair<string, T>>();
        }

        public IEnumerable<T> Retrieve(string query)
        {
            foreach (var keyValuePair in m_Stack)
            {
                string key = keyValuePair.Key;
                T value = keyValuePair.Value;
                if (key.Contains(query)) yield return value;
            }
        }

        public void Add(string key, T value)
        {
            var keyValPair = new KeyValuePair<string, T>(key, value);
            m_Stack.Push(keyValPair);
        }
    }
}