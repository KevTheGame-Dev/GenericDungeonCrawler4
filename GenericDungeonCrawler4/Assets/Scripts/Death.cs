using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    GameObject Owner;
    Health Owner_Health;

	// Use this for initialization
	void Start () {
        this.Owner = this.gameObject;
        this.Owner_Health = this.gameObject.GetComponent<Health>();
        if(this.Owner_Health == null)
        {
            throw new System.Exception("There must be a Health script attached to this GameObject too!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    virtual public void Die()
    {
        Destroy(this.gameObject);
    }
}
