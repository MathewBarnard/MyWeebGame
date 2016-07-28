using UnityEngine;
using System.Collections;

public class LoadCharacterXmlTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Create the data loader
        DAO.CharacterDaoXML characterLoader = new DAO.CharacterDaoXML();

        // Create the class to store the data within
        GameData.Character character = new GameData.Character();

        character = characterLoader.GetCharacterByName("Hero");

        if (character != null)
            Debug.Log("Pass");
        else
            Debug.Log("Fail");

        Debug.Log(character.Statistics.AttackPower);
        Debug.Log(character.Statistics.Defense);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
