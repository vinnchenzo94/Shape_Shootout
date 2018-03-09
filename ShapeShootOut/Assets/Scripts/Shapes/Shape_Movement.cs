using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Movement : MonoBehaviour {

    
    public float movement_speed, jump_force, max_speed, dash_speed;
    Rigidbody2D shape_rigidbody;
    int num_jumps = 0;
    bool dashed = false;
	
    public void Activate()
    {
        shape_rigidbody = this.transform.parent.GetComponent<Rigidbody2D>();
    }

	public void Move(string _prefix)
    {
        float x = Input.GetAxis(_prefix + "_LStick_X");
        if(shape_rigidbody != null)
        {
            float y = shape_rigidbody.velocity.y;
            shape_rigidbody.velocity = new Vector3(x * movement_speed, y, 0);
        }
    }

    public void Jump(string _prefix)
    {
        if((Input.GetButtonDown(_prefix + "_A") || Input.GetButtonDown(_prefix + "_LBump"))  && shape_rigidbody != null && num_jumps < 2)
        {
            print("BUMP");
            Vector3 vel = shape_rigidbody.velocity;
            vel.y = 0;
            shape_rigidbody.velocity = vel;
            shape_rigidbody.AddForce(this.transform.up * jump_force, ForceMode2D.Impulse);
            num_jumps++;
        }
    }

    public void Dash(string _prefix)
    {
        //will not work while setting velocity as code in Move overights the x velocity
        /*if((Input.GetButtonDown(_prefix + "_RBump") && shape_rigidbody != null && dashed == false))
        {
            shape_rigidbody.AddForce( shape_rigidbody.velocity.normalized * dash_speed, ForceMode2D.Impulse);
            dashed = true;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        num_jumps = 0;
        dashed = false;
    }
}
