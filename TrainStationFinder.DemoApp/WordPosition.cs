using System.IO;

namespace TrainStationFinder.DemoApp
{
    internal class WordPosition
    {
        private readonly long m_CharPosition;
        private readonly string m_FileName;
        private readonly string m_Word;
        private int m_NextPosition;

        public WordPosition(long charPosition, string fileName, string word)
        {
            m_CharPosition = charPosition;
            m_FileName = fileName;
            m_Word = word;
            m_NextPosition = 3;
            
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public long CharPosition
        {
            get { return m_CharPosition; }
        }

        public string Word
        {
            get { return m_Word; }
        }

        public int NextPosition
        {
            get { return m_NextPosition; }
            set { m_NextPosition = value; }
        }


        public char NextCharacter 
        {
            get { 
                if(NextPosition < Word.Length)
                return Word[NextPosition];
                else
                    return '\0';
                } 
        }



        public override string ToString()
        {
            return
                string.Format(
                    "Station: {0}, next character '{1}' (Pos {2} in file {3})",
                    Word,
                    NextCharacter,
                    CharPosition,
                    Path.GetFileName(FileName));
        }
    }
}