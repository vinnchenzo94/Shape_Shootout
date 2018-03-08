using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Register : MonoBehaviour {

    public static Player_Register player_register;
    public int players_registered = 0;
    bool player_1_assigned, player_2_assigned, player_3_assigned, player_4_assigned;
    public Transform[] player_spawns;
    public GameObject[] player_objects;
	
	// Update is called once per frame
	void Update () {
        Monitor_Input();	
	}

    void Monitor_Input()
    {
        if(Input.GetButtonDown("J1_Start") && player_1_assigned == false)
        {
            if (Assign_Player(0))
            {
                player_1_assigned = true;
            }
        }
        if(Input.GetButtonDown("J2_Start") && player_2_assigned == false)
        {
            if (Assign_Player(1))
            {
                player_2_assigned = true;
            }
        }
        if(Input.GetButtonDown("J3_Start") && player_3_assigned == false)
        {
            if (Assign_Player(3))
            {
                player_3_assigned = true;
            }
        }
        if(Input.GetButtonDown("J4_Start") && player_4_assigned == false)
        {
            if (Assign_Player(2))
            {
                player_4_assigned = true;
            }
        }
    }

    bool Assign_Player(int _player)
    {
        //spawn player
        Instantiate(player_objects[_player], player_spawns[_player].position, Quaternion.identity);
        players_registered++;
        return true;
    }
}
