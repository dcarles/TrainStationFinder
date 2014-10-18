﻿using System.IO;

namespace TrainStationFinder.DemoApp
{
    internal class WordPosition
    {
        private readonly long m_CharPosition;
        private readonly string m_FileName;

        public WordPosition(long charPosition, string fileName)
        {
            m_CharPosition = charPosition;
            m_FileName = fileName;
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public long CharPosition
        {
            get { return m_CharPosition; }
        }

        public override string ToString()
        {
            return
                string.Format(
                    "( Pos {0} ) {1}",
                    CharPosition,
                    Path.GetFileName(FileName));
        }
    }
}