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

        public Character GetCharacterByName(bool isPlayer, string name)
        {
            // Search for a matching file name
            XmlDocument characterFile = new XmlDocument();

            if (isPlayer)
                characterFile.Load(Application.dataPath + "/GameData/Characters/" + name + ".xml");
            else
                characterFile.Load(Application.dataPath + "/GameData/Enemies/" + name + ".xml");

            if (characterFile == null)
                throw new NullReferenceException("The XML file load returned null");

            Character character = new Character();

            // Parse the character data
            XmlNode statsNode = characterFile.DocumentElement.SelectSingleNode("/Character/Stats");

            if(statsNode == null)
            {
                Debug.Log("The Stats node could not be found");
            }

            // Get all statistics from the XML
            character.Statistics.HealthPoints = int.Parse(statsNode.SelectSingleNode("HealthPoints").InnerText);
            character.Statistics.AttackPower = int.Parse(statsNode.SelectSingleNode("AttackPower").InnerText);
            character.Statistics.Defense = int.Parse(statsNode.SelectSingleNode("Defense").InnerText);
            character.Statistics.ApChargeRate = int.Parse(statsNode.SelectSingleNode("ApChargeRate").InnerText);
            character.Statistics.Range = float.Parse(statsNode.SelectSingleNode("Range").InnerText);

            // We must instantiate all of the spell classes relevant to this character from their configuration
            XmlNode allSpellsNode = characterFile.DocumentElement.SelectSingleNode("/Character/Spellbook");

            // Get the string qualified version of the class name
            foreach (XmlNode spellNode in allSpellsNode) {

                string className = "Spellbook.Abilities." + spellNode.InnerText;

                Type classType = Type.GetType(className);

                object obj = Activator.CreateInstance(classType);

                character.ListOfSpells.Spells.Add(obj as Spellbook.Abilities.Ability);
            }

            // Once spells are loaded, we then load in the tactics for this character.
            XmlNode allTacticsNode = characterFile.DocumentElement.SelectSingleNode("/Character/Tactics");

            foreach (XmlNode tacticNode in allTacticsNode)
            {
                string tacticClassName = "Tactics." + tacticNode.SelectSingleNode("Condition/Name").InnerText;

                Type tacticClassType = Type.GetType(tacticClassName);

                object obj = Activator.CreateInstance(tacticClassType);

                Tactics.Tactic tactic = obj as Tactics.Tactic;

                XmlNode parameterNode = tacticNode.SelectSingleNode("Condition/Parameter");

                tactic.SetParameter(parameterNode.InnerText);

                foreach(Spellbook.Abilities.Ability ability in character.ListOfSpells.Spells)
                {
                    if (ability.Name == tacticNode.SelectSingleNode("Spell").InnerText)
                    {
                        tactic.AbilityEquipped = ability;
                        character.Tactics.Add(tactic);
                        continue;
                    }
                }

                // Should perform a check here to make sure none of the tactics abilities are null
            }

            return character;
        }
    }
}
