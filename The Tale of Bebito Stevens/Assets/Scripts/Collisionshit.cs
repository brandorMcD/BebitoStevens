using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionshit : MonoBehaviour {

    Transform player;
    Transform Npc;
    Transform Wall;
    ArrayList NpcHolder;

    public TextBoxManager Dialogue;

    float changeNpcz;
    float changeplayerz;
    float changewallz; 
    bool playerygreater = false;
    public TextBoxManager activatetext;


    // Use this for initialization
    void Start () {
        
        GameObject player_col = GameObject.FindGameObjectWithTag("Player");
        GameObject[] npc_col = GameObject.FindGameObjectsWithTag("Npc");
        activatetext = FindObjectOfType<TextBoxManager>();
        //GameObject wall_col = GameObject.FindGameObjectWithTag("Wall");

        player = player_col.transform;
        for(int i = 0; i< 2; i++)
        {
            Npc = npc_col[i].transform;
        }
        




    }
	
	// Update is called once per frame
	void FixedUpdate () {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Debug.Log("In personal Space");
        if (col.gameObject.tag == "Npc")
        {
            Npc = col.gameObject.transform;
            Vector3 Npcpos = Npc.position;

            if (player.position.y > Npc.position.y)
            {
                if (playerygreater == false)
                {
                    //changeNpcz = -1;
                    //Debug.Log("Y is greater");
                    playerygreater = true;
                    Npcpos.z = -1;
                    Npc.position = Npcpos;
                }
            }
            if (player.position.y < Npc.position.y)
            {
                if (playerygreater == true)
                {
                    //changeNpcz = 1;
                    //Debug.Log("Y is less");
                    playerygreater = false;
                    Npcpos.z = 1;
                    Npc.position = Npcpos;
                }
            }
            //if (Input.GetKeyDown(KeyCode.E))
           // {

                //Debug.Log("E is pressed");
               // if (col.gameObject.tag == "Npc")
               // {
                    
                   // activatetext.EnableTextBox();
              //  }
            //}

        }


   }
    void OnTriggerExit2D(Collider2D col_exit)
    {
        if (col_exit.gameObject.tag == "Npc")
        {
            Debug.Log("Exit Successful");
            Npc = col_exit.gameObject.transform;
            Vector3 Npcset = Npc.position;
            Npcset.z = 1;
            Npc.position = Npcset;
            playerygreater = false;
        }
    }

}
