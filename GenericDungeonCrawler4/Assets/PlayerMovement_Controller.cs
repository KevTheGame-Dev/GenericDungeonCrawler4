using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Controller : MonoBehaviour {

    GameObject Player;
    Transform Player_Transform;
    SpriteRenderer Player_Sprite;

    bool LB_singlePress = true;

    void Start()
    {
        this.Player = GameObject.FindGameObjectWithTag("Player");
        this.Player_Transform = this.Player.GetComponent<Transform>();
        this.Player_Sprite = this.Player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Player_Position = this.Player_Transform.position;
        Vector2 tempMov = new Vector2(0, 0);
        tempMov.x += Input.GetAxis("LeftJoystick_Horizontal") / 15;
        tempMov.y += -1 * Input.GetAxis("LeftJoystick_Vertical") / 15;

        this.Player_Transform.position = Player_Position + tempMov;

        //Rotate Player
        if (tempMov != Vector2.zero)
        {
            float angle = Mathf.Atan2(tempMov.y, tempMov.x) * Mathf.Rad2Deg;
            this.Player_Transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        Debug.DrawLine(this.Player_Transform.position, this.Player_Transform.right * 150, Color.yellow);

        
        bool LB = Input.GetButtonDown("Xbox_A");
        if (LB && this.LB_singlePress)
        {
            Vector3 player_right = this.Player_Transform.right;
            player_right.Normalize();
            player_right.x = player_right.x * 2;
            player_right.y = player_right.y * 2;
            this.Player_Transform.position += new Vector3(player_right.x, player_right.y, 0);
            this.LB_singlePress = false;
        }
        else
        {
            this.LB_singlePress = true;
        }
    }
}
