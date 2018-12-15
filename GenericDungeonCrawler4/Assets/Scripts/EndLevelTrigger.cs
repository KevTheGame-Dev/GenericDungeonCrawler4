using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour {

    public Font winFont;
    bool triggered = false;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnGUI()
    {
        if (triggered)
        {
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 10, Screen.width / 2 + 10, Screen.height / 2 + 10), "You Win!");
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 15, Screen.width / 2 + 10, Screen.height / 2 + 20), "Press Escape to Exit!");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
