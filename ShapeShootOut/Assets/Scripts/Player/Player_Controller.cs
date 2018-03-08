using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public string prefix;
    Color color;
    GameObject shape;
    Shape_Movement movement;
    Rigidbody2D player_rigidbody;

    private void Start()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Set_Prefix(string _prefix)
    {
        prefix = _prefix;
    }
    
    public void Set_Shape(GameObject _shape)
    {
        if(shape != null)
        {
            Destroy(shape);
            movement = null;
        }
        shape = Instantiate(_shape, this.transform.position, Quaternion.identity) as GameObject;
        shape.transform.SetParent(this.transform);
        movement = shape.GetComponent<Shape_Movement>();

        if (movement != null)
        {
            movement.Activate();
        }
        else
        {
            Debug.Log("Movement in " + this.transform.name + "." + this.name + " is null");
        }

        SpriteRenderer[] shape_renderers = shape.GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0;i  < shape_renderers.Length; i++)
        {
            shape_renderers[i].color = color;
        }        
    }

    public void Set_Color(Color _color)
    {
        color = _color;
    }

    private void Update()
    {
        Handle_User_Input();
    }

    void Handle_User_Input()
    {
        if(movement != null)
        {
            movement.Move(prefix);
            movement.Jump(prefix);
        }
        else
        {
            print("MOVE IS NULl");
        }
    }

}
