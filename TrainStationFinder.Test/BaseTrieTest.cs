using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainStationFinder.DataStructures;

namespace TrainStationFinder.Test
{
    [TestClass]
    public abstract class BaseTrieTest
    {
        protected ITrie<int> Trie { get; private set; }       

        protected abstract ITrie<int> CreateTrie();

        public string[] Words40 = new[] {
                                        "Abbey Wood",
                                        "Aber",
                                        "Abercynon",
                                        "Aberdare",
                                        "Aberdeen",
                                        "Aberdour",
                                        "Aberdovey",
                                        "Abererch",
                                        "Abergavenny",
                                        "Abergele & Pensarn",
                                        "Aberystwyth",
                                        "Accrington",
                                        "Achanalt",
                                        "Achnasheen",
                                        "Achnashellach",
                                        "Acklington",
                                        "Acle",
                                        "Acocks Green",
                                        "Acton Bridge (Cheshire)",
                                        "Acton Central",
                                        "Acton Main Line",
                                        "Adderley Park",
                                        "Addiewell",
                                        "Addlestone",
                                        "Adisham",
                                        "Adlington (Cheshire)",
                                        "Adlington (Lancs)",
                                        "Adwick",
                                        "Aigburth",
                                        "Ainsdale",
                                        "Aintree",
                                        "Airbles",
                                        "Airdrie",
                                        "Albany Park",
                                        "Albrighton",
                                        "Alderley Edge",
                                        "Aldermaston",
                                        "Aldershot",
                                        "Aldrington",
                                        "Alexandra Palace"
                                        };

        [TestMethod]
        public void ExhaustiveAddTimeMeasurement()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            ITrie<int> trie = CreateTrie();
            foreach (var phrase in Words40)
            {
                trie.Add(phrase, phrase.GetHashCode());
            }

            stopwatch.Stop();
            Console.WriteLine("Time: {0} milliseconds", stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}