using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameData;
using System.Xml;
using UnityEngine;

namespace DAO
{
    public class CharacterDaoXML : ICharacterDao
    {
        public Character GetCharacterById(int i)
        {
            return null;
        }

        public Character GetCharacterByName(string name)
        {
            // Search for a matching file name
            XmlDocument characterFile = new XmlDocument();
            characterFile.Load(Application.dataPath + "/GameData/Characters/" + name + ".xml");

            if (characterFile == null)
                throw new NullReferenceException("The XML file load returned null");

            Character character = new Character();

            // Parse the character data
            XmlNode statsNode = characterFile.DocumentElement.SelectSingleNode("/Character/Stats");

            if(statsNode == null)
            {
                Debug.Log("The Stats node could not be found");
            }

            character.Statistics.HealthPoints = int.Parse(statsNode.SelectSingleNode("HealthPoints").InnerText);
            character.Statistics.AttackPower = int.Parse(statsNode.SelectSingleNode("AttackPower").InnerText);
            character.Statistics.Defense = int.Parse(statsNode.SelectSingleNode("Defense").InnerText);
            character.Statistics.ApChargeRate = int.Parse(statsNode.SelectSingleNode("AtbChargeRate").InnerText);
            character.Statistics.Range = int.Parse(statsNode.SelectSingleNode("Range").InnerText);

            return character;
        }
    }
}
