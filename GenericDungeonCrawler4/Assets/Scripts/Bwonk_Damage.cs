using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bwonk_Damage : Damage {

    GameObject Bwonk;
    Transform Bwonk_Transform;

    GameObject Player;
    Transform Player_Transform;

    public float Attack_Power;
    public float Attack_Delay;
    public float Attack_Range;

    float timeSinceLastAttack;

	// Use this for initialization
	void Start () {
        this.Bwonk = this.gameObject;
        this.Bwonk_Transform = this.Bwonk.GetComponent<Transform>();

        this.Player = GameObject.FindGameObjectWithTag("Player");
        this.Player_Transform = this.Player.GetComponent<Transform>();

        timeSinceLastAttack = this.Attack_Delay + 1;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastAttack += Time.deltaTime;
		if(Vector3.Distance(this.Bwonk_Transform.position, this.Player_Transform.position) < this.Attack_Range)
        {
            if (timeSinceLastAttack >= Attack_Delay)
            {
                DealDamage(this.Attack_Power, Player);
                timeSinceLastAttack = 0;
            }
        }
	}

    public override void DealDamage(float damage, GameObject target)
    {
        print(this.Bwonk.name + " dealt " + damage + " damage to " + target.name + "!");
        base.DealDamage(damage, target);
    }
}
