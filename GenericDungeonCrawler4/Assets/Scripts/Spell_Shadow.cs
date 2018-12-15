using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Shadow : MonoBehaviour {

    GameObject Spell;
    Transform Spell_Transform;
    Animator Spell_Animator;

    GameObject Player;
    Transform Player_Transform;
    PlayerMovement_Controller Player_MovementScript;

    public float Spell_Speed;
    public float Damage;
    public float KnockBack;
    public Vector3 Spell_OffSet = new Vector3(0, 0, 0);

    int Spell_Direction;
    Vector3 originalPos;

	// Use this for initialization
	void Start () {
        //Get references and set up variables
        this.Spell_Transform = this.transform;
        this.Spell = gameObject;

        this.Spell_Animator = this.Spell.GetComponent<Animator>();

        this.Player = GameObject.FindGameObjectWithTag("Player");
        this.Player_Transform = this.Player.GetComponent<Transform>();
        this.Player_MovementScript = Player.GetComponent<PlayerMovement_Controller>();

        this.Spell_Direction = this.Player_MovementScript.PLAYER_DIRECTION;

        //Set things up
        this.Spell_Transform.position = this.Player_Transform.position + this.Spell_OffSet;
        this.originalPos = this.Spell_Transform.position;
        Physics2D.IgnoreCollision(this.Player.GetComponent<Collider2D>(), this.Spell.GetComponent<Collider2D>());

    }
	
	// Update is called once per frame
	void Update () {
        switch (Spell_Direction)
        {
            case 0://DOWN
                this.Spell_Transform.position = this.Spell_Transform.position + new Vector3(0, -1, 0) * Spell_Speed;
                this.Spell_Animator.Play("Spell_Down");
                break;
            case 1://UP
                this.Spell_Transform.position = this.Spell_Transform.position + new Vector3(0, 1, 0) * Spell_Speed;
                this.Spell_Animator.Play("Spell_Up");
                break;
            case 2://RIGHT
                this.Spell_Transform.position = this.Spell_Transform.position + new Vector3(1, 0, 0) * Spell_Speed;
                this.Spell_Animator.Play("Spell_Right");
                break;
            case 3://LEFT
                this.Spell_Transform.position = this.Spell_Transform.position + new Vector3(-1, 0, 0) * Spell_Speed;
                this.Spell_Animator.Play("Spell_Left");
                break;
        }
        //print(this.Spell.GetComponent<SpriteRenderer>().sprite.name);
        if (Vector3.Distance(this.Spell_Transform.position, this.originalPos) > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //DO NOTHING
        }
        else if(col.gameObject.tag == "Enemy")
        {
            GameObject enemy = col.gameObject;
            //Deal damage
            Health enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.removeHealth(this.Damage);
            //Apply knockback
            ApplyKnockBack(enemy);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    private void ApplyKnockBack(GameObject enemy)
    {
        Transform enemyTransform = enemy.GetComponent<Transform>();

        switch (Spell_Direction)
        {
            case 0://DOWN
                enemyTransform.position = enemyTransform.position + new Vector3(0, -1, 0) * this.KnockBack;
                break;
            case 1://UP
                enemyTransform.position = enemyTransform.position + new Vector3(0, 1, 0) * this.KnockBack;
                break;
            case 2://RIGHT
                enemyTransform.position = enemyTransform.position + new Vector3(1, 0, 0) * this.KnockBack;
                break;
            case 3://LEFT
                enemyTransform.position = enemyTransform.position + new Vector3(-1, 0, 0) * this.KnockBack;
                break;
        }
    }
}
