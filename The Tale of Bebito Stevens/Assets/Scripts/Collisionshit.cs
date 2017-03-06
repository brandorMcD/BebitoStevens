using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionshit : MonoBehaviour {

    Transform player;
    Transform Npc;
    //Transform Wall;

    float changenpcz;
    float changeplayerz;
    float changewallz;


    // Use this for initialization
    void Start () {
        GameObject player_col = GameObject.FindGameObjectWithTag("Player");
        GameObject npc_col = GameObject.FindGameObjectWithTag("Npc");
        //GameObject wall_col = GameObject.FindGameObjectWithTag("Wall");

        player = player_col.transform;
        Npc = npc_col.transform;


        if (player.position.y > Npc.position.y)
        {
            changeplayerz =  player.position.z - (Npc.position.z + 1);
            Debug.Log("Did this work");
        }


    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerpos = player.position;
        playerpos.z = player.position.z + changeplayerz;
        player.position = playerpos;
	}
}
