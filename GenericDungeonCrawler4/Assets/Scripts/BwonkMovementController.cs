using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BwonkMovementController : MonoBehaviour {

    Transform Bwonk_Transform;

    GameObject Player;
    Transform Player_Transform;

    public float SEEK_DISTANCE;
    public float SPEED;

	// Use this for initialization
	void Start () {
        this.Bwonk_Transform = this.gameObject.GetComponent<Transform>();

        this.Player = GameObject.FindGameObjectWithTag("Player");
        this.Player_Transform = this.Player.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(this.Bwonk_Transform.position, this.Player_Transform.position) <= SEEK_DISTANCE)
        {
            Seek();
        }
        else
        {
            Wander();
        }
	}

    void Seek()
    {
        Vector3 playerDirection = this.Player_Transform.position - this.Bwonk_Transform.position;
        playerDirection.Normalize();
        Vector3 tempMove = playerDirection * SPEED;

        this.Bwonk_Transform.position = this.Bwonk_Transform.position + tempMove;
    }

    void Wander()
    {
        int moveDirection = Random.Range(0, 4);

        Vector3 tempMoveRand;
        switch (moveDirection)
        {
            case 0://DOWN
                tempMoveRand = new Vector3(0, -1, 0);
                break;
            case 1://UP
                tempMoveRand = new Vector3(0, 1, 0);
                break;
            case 2://RIGHT
                tempMoveRand = new Vector3(1, 0, 0);
                break;
            case 3://LEFT
                tempMoveRand = new Vector3(-1, 0, 0);
                break;
            default:
                tempMoveRand = new Vector3(0, -1, 0);
                break;
        }

        this.Bwonk_Transform.position = this.Bwonk_Transform.position + (tempMoveRand * SPEED);
    }
}
