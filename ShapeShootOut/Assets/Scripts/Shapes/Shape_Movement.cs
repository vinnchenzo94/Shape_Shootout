using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Movement : MonoBehaviour {

    
    public float movement_speed, jump_force, max_speed;
    Rigidbody2D shape_rigidbody;
	
    public void Activate()
    {
        shape_rigidbody = this.transform.parent.GetComponent<Rigidbody2D>();
    }

	public void Move(string _prefix)
    {
        float x = Input.GetAxis(_prefix + "_LStick_X");
        if(shape_rigidbody != null)
        {
            //float y = shape_rigidbody.velocity.y;
            //shape_rigidbody.velocity = new Vector3(x * movement_speed, y, 0);
            shape_rigidbody.AddForce(new Vector3(x * movement_speed, 0, 0), ForceMode2D.Force);
            shape_rigidbody.velocity = Vector3.ClampMagnitude(shape_rigidbody.velocity, max_speed);
        }
    }

    public void Jump(string _prefix)
    {
        if(Input.GetButtonDown(_prefix + "_A") && shape_rigidbody != null)
        {
            shape_rigidbody.AddForce(this.transform.up * jump_force, ForceMode2D.Impulse);
        }
    }
}
