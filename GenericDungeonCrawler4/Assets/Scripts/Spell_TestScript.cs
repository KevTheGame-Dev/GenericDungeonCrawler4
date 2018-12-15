using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_TestScript : MonoBehaviour {

    GameObject spell;
    Transform spell_Transform;
    Animator spell_Renderer;

    Vector3 origPos;
	// Use this for initialization
	void Start () {
        this.spell = GameObject.FindGameObjectWithTag("Spell");
        this.spell_Transform = this.spell.GetComponent<Transform>();
        this.spell_Renderer = this.spell.GetComponent<Animator>();
        this.origPos = this.spell_Transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        this.spell_Transform.position = this.spell_Transform.position + new Vector3(0, -0.2f, 0);
        if(Mathf.Abs(this.spell_Transform.position.y - this.origPos.y) > 10) {
            this.spell_Transform.position = this.origPos;
            this.spell_Renderer.Play("Spell_Down", -1, 0f);
        }
	}
}
