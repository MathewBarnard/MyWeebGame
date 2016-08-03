using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    interface IPartyConfigurationDao
    {
        GameData.PartyConfiguration GetCurrentConfiguration();

        GameData.PartyConfiguration GetConfigByName(string name);
    }
}
