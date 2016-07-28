using UnityEngine;
using System.Collections;

public class BasicRangedHeal : CombatAction {

    private Combatant target;

    public override void Awake()
    {

        base.Awake();

        this.target = this.gameObject.GetComponent<Combatant>().Target;
    }

    // Use this for initialization
    void Start () {
        SpawnHealSpell();
	}

    private void SpawnHealSpell()
    {
        Object prefab = Resources.Load("Prefabs/BasicRangedHeal");

        Object obj = Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);

        GameObject go = obj as GameObject;

        Spells.BasicHeal healSpell = go.GetComponent<Spells.BasicHeal>();
        healSpell.Source = this.combatant;
        healSpell.Target = this.combatant.Target;
        healSpell.HealStrength = 10;

        complete = true;
    }
}
