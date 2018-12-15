using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void DealDamage(float damage, GameObject target) {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth == null) throw new System.Exception("Damage target must have a Health script!");

        targetHealth.removeHealth(damage);
    }
}
