using System;

namespace CodeBase.Data
{
    [Serializable]
    public class GameData
    {
        public int Level;
        public int MaxLevel;

        public void ExtendLevel()
        {
            if (Level + 1 > MaxLevel) 
                return;

            Level++;
        }
    }
}