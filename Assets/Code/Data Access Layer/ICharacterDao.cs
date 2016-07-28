using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameData;

namespace DAO
{
    public interface ICharacterDao
    {
        Character GetCharacterById(int i);

        Character GetCharacterByName(string name);
    }
}
