using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

namespace DAO
{
    class PartyConfigurationDaoXML : IPartyConfigurationDao
    {
        public GameData.PartyConfiguration GetCurrentConfiguration()
        {
            // Search for a matching file name
            XmlDocument partyFile = new XmlDocument();
            partyFile.Load(Application.dataPath + "/GameData/Party.xml");

            if (partyFile == null)
                throw new NullReferenceException("The XML file load returned null");

            // Initialise the Party Configuration
            GameData.PartyConfiguration partyConfig = new GameData.PartyConfiguration();

            // For each character in the party, retrieve their data and add them to the party config object
            XmlNode charactersNode = partyFile.DocumentElement.SelectSingleNode("/Party/Characters");

            foreach(XmlNode characterNode in charactersNode.ChildNodes)
            {
                GameData.Character character = new GameData.Character();

                CharacterDaoXML characterXml = new CharacterDaoXML();

                character = characterXml.GetCharacterByName(true, characterNode.ChildNodes.Item(0).InnerText);

                // Add the character to the party list
                partyConfig.CharactersInParty.Add(character);

                switch(characterNode.ChildNodes.Item(1).InnerText)
                {
                    case "Front":
                        partyConfig.FrontRow.Add(character);
                        break;
                    case "Middle":
                        partyConfig.MiddleRow.Add(character);
                        break;
                    case "Back":
                        partyConfig.BackRow.Add(character);
                        break;
                    default:
                        break;
                }
            }

            return partyConfig;
        }

        public GameData.PartyConfiguration GetConfigByName(string groupName)
        {
            // Search for a matching file name
            XmlDocument partyFile = new XmlDocument();
            partyFile.Load(Application.dataPath + "/GameData/Enemies/Groups/" + groupName + ".xml");

            if (partyFile == null)
                throw new NullReferenceException("The XML file load returned null");

            // Initialise the Party Configuration
            GameData.PartyConfiguration partyConfig = new GameData.PartyConfiguration();

            // For each character in the party, retrieve their data and add them to the party config object
            XmlNode charactersNode = partyFile.DocumentElement.SelectSingleNode("/Party/Characters");

            foreach (XmlNode characterNode in charactersNode.ChildNodes)
            {
                GameData.Character character = new GameData.Character();

                CharacterDaoXML characterXml = new CharacterDaoXML();

                character = characterXml.GetCharacterByName(false, characterNode.ChildNodes.Item(0).InnerText);

                // Add the character to the party list
                partyConfig.CharactersInParty.Add(character);

                switch (characterNode.ChildNodes.Item(1).InnerText)
                {
                    case "Front":
                        partyConfig.FrontRow.Add(character);
                        break;
                    case "Middle":
                        partyConfig.MiddleRow.Add(character);
                        break;
                    case "Back":
                        partyConfig.BackRow.Add(character);
                        break;
                    default:
                        break;
                }
            }

            return partyConfig;
        }
    }
}
