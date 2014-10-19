using System.IO;

namespace TrainStationFinder.DataStructures
{
    public class WordPosition
    {
        private readonly long m_Line;
        private readonly string m_FileName;
        private readonly string m_Word;
        private int m_NextPosition;

        public WordPosition(long line, string fileName, string word)
        {
            m_Line = line;
            m_FileName = fileName;
            m_Word = word;
            m_NextPosition = 3;
            
        }

        public string FileName
        {
            get { return m_FileName; }
        }

        public long Line
        {
            get { return m_Line; }
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
                    "Station: {0}, next character '{1}' (Line {2} in file {3})",
                    Word,
                    NextCharacter,
                    Line,
                    Path.GetFileName(FileName));
        }
    }
}