using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bwonk_Death : Death {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Die()
    {
        print(this.gameObject.name + " has been defeated!");
        base.Die();
    }
}
