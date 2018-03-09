using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Register : MonoBehaviour {

    public int players_registered = 0;

    bool player_1_assigned, player_2_assigned, player_3_assigned, player_4_assigned;

    public string[] player_prefixes;
    public Transform[] player_spawns;
    public GameObject player_object;
    public Color[] player_colors;

    public GameObject circle_object;
	
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
            if (Assign_Player(2))
            {
                player_3_assigned = true;
            }
        }
        if(Input.GetButtonDown("J4_Start") && player_4_assigned == false)
        {
            if (Assign_Player(3))
            {
                player_4_assigned = true;
            }
        }
    }

    bool Assign_Player(int _player)
    {
        //spawn player
        GameObject player_inst = Instantiate(player_object, player_spawns[_player].position, Quaternion.identity) as GameObject;
        player_inst.layer = LayerMask.NameToLayer(player_prefixes[_player]);
        Player_Controller player_inst_controller = player_inst.GetComponent<Player_Controller>();
        player_inst_controller.Set_Prefix(player_prefixes[_player]);
        player_inst_controller.Set_Color(player_colors[_player]);
        player_inst_controller.Set_Shape(circle_object);
        players_registered++;
        return true;
    }
}
