using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour {

    Transform player;
    private float movex;
    private float movey;
	public float speed;
    Animator charmovement;
    bool ifmoving = false;
    public bool canMove;

	// Use this for initialization
	void Start ()
    {
        charmovement = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        if (canMove == false)
        {
            charmovement.SetInteger("CharacterState", 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            return;
        }

        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");


        if (movex < 0)
        {
            charmovement.SetInteger("CharacterState", 4);//MoveLeftAnimation
            ifmoving = false;
        }
        else if (movex > 0)
        {
            charmovement.SetInteger("CharacterState", 3);//MoveRightAnimation
            ifmoving = false;
        }
        else if (movey > 0)
        {
            charmovement.SetInteger("CharacterState", 2);//MoveUpAnimation
            ifmoving = false;
        }
        else if (movey < 0)
        {
            charmovement.SetInteger("CharacterState", 1);//MoveDownAnimation
            ifmoving = false;
        }
        else if (ifmoving == true)
        {
            charmovement.SetInteger("CharacterState", 0);//IdleAnimation
        }
        else
        {
            ifmoving = true;
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * speed, movey * speed);//movecharacter

    }

}
