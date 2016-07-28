using UnityEngine;
using System.Collections;
using Actions;
using System;

public class AttackMelee : CombatAction, ITargetedAction {

    private bool hasHit;

    private Vector3 originalPosition;

    private Combatant target;

    public override void Awake() {

        base.Awake();

        originalPosition = this.combatant.gameObject.transform.position;
    }

    void Start()
    {
      
    }
	
	// Update is called once per frame
	void Update () {

        if (!hasHit)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.gameObject.transform.position, (BattleConstants.MovementSpeed * 10) * Time.deltaTime);

            if(this.transform.position == this.gameObject.GetComponent<Combatant>().Target.transform.position)
            {
                SpawnAttackSpell();
            }
        }
        else
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.originalPosition, (BattleConstants.MovementSpeed * 10) * Time.deltaTime);

            if(this.transform.position == this.originalPosition)
            {
                complete = true;
            }
        }
	}

    private void SpawnAttackSpell()
    {
        UnityEngine.Object prefab = Resources.Load("Prefabs/AttackMelee");

        UnityEngine.Object obj = Instantiate(prefab, this.gameObject.GetComponent<Combatant>().Target.transform.position, Quaternion.identity);

        GameObject go = obj as GameObject;

        go.GetComponent<Spells.AttackMelee>().Source = this.combatant;

        hasHit = true;
    }


    /*void OnTriggerExit(Collider col)
    {
        if (col.gameObject == target.gameObject)
        {
            complete = true;
        }
    }*/

    public void SetTarget(Combatant combatant)
    {
        this.target = combatant;
    }
}
