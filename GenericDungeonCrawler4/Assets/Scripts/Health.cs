using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float Health_Max;
    public float Health_Current;


    public bool shouldDisplayHealth; // only turn on for player
    public Texture healthEmpty;
    public Texture healthBar;
    float healthBarFloat = 300;

	// Use this for initialization
	void Start () {
        this.Health_Current = this.Health_Max;
	}
	
	// Update is called once per frame
	void Update () {
        displayHealth();
	}

    private void OnGUI()
    {
        if (shouldDisplayHealth)
        {
            GUI.BeginGroup(new Rect(0, 0, healthBarFloat, 64));
            GUI.Box(new Rect(0, 0, healthBarFloat, 64), healthEmpty);
            GUI.BeginGroup(new Rect(0, 0, Health_Current / Health_Max * healthBarFloat, 64));
            GUI.Box(new Rect(0, 0, healthBarFloat, 64), healthBar);
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    public void addHealth(float increase) {
        Health_Current += increase;
        if (Health_Current > Health_Max) Health_Current = Health_Max;
    }

    public void removeHealth(float decrease) {
        Health_Current -= decrease;
        print(this.gameObject.name + " lost " + decrease + " health!");
        if (Health_Current <= 0) {
            this.gameObject.GetComponent<Death>().Die();
        };
    }
    
    public void displayHealth()
    {
        
    }
}
