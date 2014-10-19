using System;
using System.Linq;
using TrainStationFinder.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TrainStationFinder.Test
{
    [TestClass]
    public class TrieTest : BaseTrieTest
    {
        protected override ITrie<int> CreateTrie()
        {
            return new Trie<int>();
        }
      

        [TestMethod]
        public void TestNotExactMatched()
        {
            ITrie<int> trie = new Trie<int>();
            trie.Add("aaabbb", 1);
            trie.Add("aaaccc", 2);

            var actual = trie.Retrieve("aab");
            CollectionAssert.AreEquivalent(Enumerable.Empty<int>().ToList(), actual.ToList());

        }

        [TestMethod]
        public void TestFoundSeveralStations()
        {
            ITrie<WordPosition> trie = new Trie<WordPosition>();

            var dartford = new WordPosition(1, "list", "DARTFORD");
            var dartmouth = new WordPosition(2, "list", "DARTMOUTH");
            var prefixToSearch = "DART";

            trie.Add("DARTFORD", dartford);
            trie.Add("DARTMOUTH", dartmouth);
            trie.Add("TOWER HILL", new WordPosition(3, "list", "TOWER HILL"));
            trie.Add("DERBY", new WordPosition(4, "list", "DERBY"));

            var actual = trie.Retrieve(prefixToSearch);
            var expected = new List<WordPosition> {
													dartford,
													dartmouth
													};
            CollectionAssert.AreEquivalent(expected, actual.ToList());

            foreach (var item in actual)
            {
                item.NextPosition = prefixToSearch.Length;
            }

            var expectedNextCharList = new List<char> { 'F', 'M' };


            var actualNextCharList = actual.Select(a => a.NextCharacter);

            CollectionAssert.AreEquivalent(expectedNextCharList, actualNextCharList.ToList());

        }

        [TestMethod]
        public void TestFoundSeveralStationsNoNextCharacter()
        {
            ITrie<WordPosition> trie = new Trie<WordPosition>();

            var liverpool = new WordPosition(1, "list", "LIVERPOOL");
            var liverpoolLimeStreet = new WordPosition(2, "list", "LIVERPOOL LIME STREET");
            var prefixToSearch = "LIVERPOOL";

            trie.Add("LIVERPOOL’", liverpool);
            trie.Add("LIVERPOOL LIME STREET", liverpoolLimeStreet);
            trie.Add("Tower hill", new WordPosition(3, "list", "Tower hill"));
            trie.Add("PADDINGTON", new WordPosition(4, "list", "PADDINGTON"));

            var actual = trie.Retrieve(prefixToSearch);
            var expected = new List<WordPosition> {
													liverpool,
													liverpoolLimeStreet
													};
            CollectionAssert.AreEquivalent(expected, actual.ToList());

            foreach (var item in actual)
            {
                item.NextPosition = prefixToSearch.Length;
            }

            var expectedNextCharList = new List<char> { '\0', ' ' };


            var actualNextCharList = actual.Select(a => a.NextCharacter);

            CollectionAssert.AreEquivalent(expectedNextCharList, actualNextCharList.ToList());

        }

        [TestMethod]
        public void TestNoStationsFound()
        {
            ITrie<WordPosition> trie = new Trie<WordPosition>();
            trie.Add("EUSTON", new WordPosition(1, "list", "EUSTON"));
            trie.Add("LONDON BRIDGE", new WordPosition(2, "list", "LONDON BRIDGE"));
            trie.Add("VICTORIA", new WordPosition(3, "list", "VICTORIA"));

            var actual = trie.Retrieve("KINGS CROSS");
            CollectionAssert.AreEquivalent(Enumerable.Empty<WordPosition>().ToList(), actual.ToList());

        }

        [TestMethod]
        public void TestEmptyTrie()
        {
            ITrie<WordPosition> trie = new Trie<WordPosition>();            

            var actual = trie.Retrieve("DART");
            CollectionAssert.AreEquivalent(Enumerable.Empty<WordPosition>().ToList(), actual.ToList());

        }


    }
}