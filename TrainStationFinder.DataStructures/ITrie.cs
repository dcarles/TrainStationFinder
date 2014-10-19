using System.Collections.Generic;

namespace TrainStationFinder.DataStructures
{
    /// <summary>
    /// Interface to be implemented by a data structure 
    /// which allows adding values associated with string keys.
    /// The interface allows retrieveal of multiple values 
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface ITrie<TValue>
    {
        IEnumerable<TValue> Retrieve(string query);
        void Add(string key, TValue value);
    }
}