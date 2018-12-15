using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Controller : MonoBehaviour {

    GameObject Player;
    GameObject Player_Shadow;
    Transform Player_Transform;
    Transform Shadow_Transform;
    Vector3 Shadow_Offset = new Vector3(0, -0.3f, 2.79f);
    SpriteRenderer Player_Sprite;
    Animator Player_Animator;

    //Camera control
    GameObject MainCamera;
    Transform MainCamera_Transform;
    Vector3 MainCamera_Offset = new Vector3(0, 0, -10);

    //Movement variables
    public float PLAYER_SPEED = 1;
    public int PLAYER_DIRECTION = 0;

    //Animation stuff
    bool isWalking = false;

    const int STATE_IDLE_BACK = 0;
    const int STATE_WALK_BACK = 1;
    const int STATE_IDLE_FORWARD = 2;
    const int STATE_WALK_FORWARD = 3;
    const int STATE_IDLE_RIGHT = 4;
    const int STATE_WALK_RIGHT = 5;
    const int STATE_IDLE_LEFT = 6;
    const int STATE_WALK_LEFT = 7;

    int currentAnimationState = 0;

    bool LB_singlePress = true;

    void Start()
    {
        this.Player = GameObject.FindGameObjectWithTag("Player");
        this.Player_Shadow = GameObject.FindGameObjectWithTag("Player_Shadow");
        this.Player_Transform = this.Player.GetComponent<Transform>();
        this.Shadow_Transform = this.Player_Shadow.GetComponent<Transform>();
        this.Player_Sprite = this.Player.GetComponent<SpriteRenderer>();

        this.Player_Animator = this.Player.GetComponent<Animator>();
        this.PLAYER_SPEED = 0.1f;

        this.MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        this.MainCamera_Transform = this.MainCamera.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Controller Input
        Vector2 Player_Position = this.Player_Transform.position;
        Vector3 Shadow_Position = this.Shadow_Transform.position;

        Vector2 tempMov = new Vector2(0, 0);
        tempMov.x += Input.GetAxis("LeftJoystick_Horizontal") / 15;
        tempMov.y += -1 * Input.GetAxis("LeftJoystick_Vertical") / 15;

        this.Player_Transform.position = Player_Position + tempMov;
        
        Vector3 shadowMov = new Vector3(tempMov.x, tempMov.y, 0);
        this.Shadow_Transform.position = Shadow_Position + shadowMov;

        ////Rotate Player
        //if (tempMov != Vector2.zero)
        //{
        //    float angle = Mathf.Atan2(tempMov.y, tempMov.x) * Mathf.Rad2Deg;
        //    this.Player_Transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //}
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

        //Keyboard Input - WALK
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeState(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeState(3);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            changeState(5);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changeState(7);
        }

        //Move player
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movePlayer(0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movePlayer(1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movePlayer(2);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movePlayer(3);
        }

        //Keyboard Input - IDLE
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            changeState(0);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            changeState(2);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            changeState(4);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            changeState(6);
        }


        this.Shadow_Transform.position = this.Player_Transform.position + this.Shadow_Offset;
        this.MainCamera_Transform.position = this.Player_Transform.position + this.MainCamera_Offset;

    }

    //Helper function to swap animation state
    void changeState(int state)
    {
        if(currentAnimationState == state) { return; }

        switch (state)
        {
            case STATE_IDLE_BACK:
                Player_Animator.SetInteger("State", STATE_IDLE_BACK);
                currentAnimationState = STATE_IDLE_BACK;
                break;
            case STATE_WALK_BACK:
                Player_Animator.SetInteger("State", STATE_WALK_BACK);
                currentAnimationState = STATE_WALK_BACK;
                break;
            case STATE_IDLE_FORWARD:
                Player_Animator.SetInteger("State", STATE_IDLE_FORWARD);
                currentAnimationState = STATE_IDLE_FORWARD;
                break;
            case STATE_WALK_FORWARD:
                Player_Animator.SetInteger("State", STATE_WALK_FORWARD);
                currentAnimationState = STATE_WALK_FORWARD;
                break;
            case STATE_IDLE_RIGHT:
                Player_Animator.SetInteger("State", STATE_IDLE_RIGHT);
                currentAnimationState = STATE_IDLE_RIGHT;
                break;
            case STATE_WALK_RIGHT:
                Player_Animator.SetInteger("State", STATE_WALK_RIGHT);
                currentAnimationState = STATE_WALK_RIGHT;
                break;
            case STATE_IDLE_LEFT:
                Player_Animator.SetInteger("State", STATE_IDLE_LEFT);
                currentAnimationState = STATE_IDLE_LEFT;
                break;
            case STATE_WALK_LEFT:
                Player_Animator.SetInteger("State", STATE_WALK_LEFT);
                currentAnimationState = STATE_WALK_LEFT;
                break;
        }
    }

    //Movement Helper Function
    //direction int: BACK = 0, FORWARD = 1, RIGHT = 2, LEFT = 3
    void movePlayer(int direction)
    {
        Vector3 tempMov = new Vector3(0, 0, 0);

        switch (direction)
        {
            case 0://DOWN
                tempMov = new Vector3(0, -1, 0);
                this.PLAYER_DIRECTION = 0;
                break;
            case 1://UP
                tempMov = new Vector3(0, 1, 0);
                this.PLAYER_DIRECTION = 1;
                break;
            case 2://RIGHT
                tempMov = new Vector3(1, 0, 0);
                this.PLAYER_DIRECTION = 2;
                break;
            case 3://LEFT
                tempMov = new Vector3(-1, 0, 0);
                this.PLAYER_DIRECTION = 3;
                break;
        }

        tempMov = tempMov * PLAYER_SPEED;

        this.Player_Transform.position = this.Player_Transform.position + tempMov;
    }
}
