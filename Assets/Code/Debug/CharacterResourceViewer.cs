using UnityEngine;
using System.Collections;

public class CharacterResourceViewer : MonoBehaviour {

    public GameObject go;

    private Combatant character;
    private TextMesh text;
	
    void Awake()
    {
        character = go.GetComponent<Combatant>();
        this.gameObject.GetComponent<MeshRenderer>().sortingOrder = 3;
    }

	// Update is called once per frame
	void Update () {

        TextMesh textMesh = GetComponent<TextMesh>();

        if(character == null)
        {
            Debug.Log("Character instance is null");
        }
        else
        {
            textMesh.text = string.Empty;
            textMesh.text = "HP: " + character.Stats.HealthPoints + "\n" +
            "AP: " + (int)character.Stats.ActionPoints;
        }
	}
}
