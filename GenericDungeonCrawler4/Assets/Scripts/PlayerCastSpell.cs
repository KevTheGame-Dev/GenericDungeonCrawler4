using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastSpell : MonoBehaviour {

    public GameObject SPELL_SHADOW;


    public float Cast_Delay;
    float timeSinceLastCast;

    // Use this for initialization
    void Start () {
        this.timeSinceLastCast = this.Cast_Delay + 1;
    }
	
	// Update is called once per frame
	void Update () {
        this.timeSinceLastCast += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (this.timeSinceLastCast >= this.Cast_Delay)
            {
                var shadowSpell = (GameObject)Instantiate(SPELL_SHADOW);
                this.timeSinceLastCast = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
