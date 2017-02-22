using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour {
	
    private float movex;
    private float movey;
	public float speed;
    Animator charmovement;

	// Use this for initialization
	void Start ()
    {
        charmovement = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");

        if (movex < 0)
        {
            charmovement.SetInteger("CharacterState", 4);//MoveLeft
        }
        else if (movex > 0)
        {
            charmovement.SetInteger("CharacterState", 3);//MoveRight
        }
        else if (movey > 0)
        {
            charmovement.SetInteger("CharacterState", 2);//MoveUp
        }
        else if (movey < 0)
        {
            charmovement.SetInteger("CharacterState", 1);//MoveDown
        }
        else
        {
            charmovement.SetInteger("CharacterState", 0);//Idle
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * speed, movey * speed);

    }
}
