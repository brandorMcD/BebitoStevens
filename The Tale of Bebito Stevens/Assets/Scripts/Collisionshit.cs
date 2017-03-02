using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionshit : MonoBehaviour {

    Transform player;
    Transform Npc;
    Transform Wall;

    float changenpcz;
    float changeplayerz;
    float changewallz;


    // Use this for initialization
    void Start () {
        GameObject player_col = GameObject.FindGameObjectWithTag("Player");
        GameObject npc_col = GameObject.FindGameObjectWithTag("Npc");
        GameObject wall_col = GameObject.FindGameObjectWithTag("Wall");

        player = player_col.transform;
        Npc = npc_col.transform;


        if (player.position.y > Npc.position.y)
        {
            changeplayerz =  transform.position.z + Npc.position.z;
        }
        else
        {
            changenpcz = transform.position.z + player.position.z;
        }

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 zplayerpos = transform.position;
        Vector3 znpcpos = transform.position;
        zplayerpos.z = player.position.z + changeplayerz;
        znpcpos.z = Npc.position.z + changenpcz;
        transform.position = zplayerpos;
        transform.position = znpcpos;	
	}
}
