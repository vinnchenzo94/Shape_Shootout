using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public string prefix;
    Color color;
    GameObject shape;
    Shape_Movement movement;
    Shape_Weapon weapon;
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
        if (shape != null)
        {
            shape.transform.SetParent(this.transform);
            shape.layer = this.gameObject.layer;
            movement = shape.GetComponent<Shape_Movement>();

            if (movement != null)
            {
                movement.Activate();
                weapon = movement.GetComponentInChildren<Shape_Weapon>();
                if(weapon != null)
                {
                    weapon.gameObject.layer = this.gameObject.layer;
                    weapon.color = color;
                }
            }
            else
            {
                Debug.Log("Movement in " + this.transform.name + "." + this.name + " is null");
            }

            SpriteRenderer[] shape_renderers = shape.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < shape_renderers.Length; i++)
            {
                if (shape_renderers[i] != null)
                {
                    shape_renderers[i].color = color;
                }
            }
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
        if (movement != null)
        {
            movement.Move(prefix);
            movement.Jump(prefix);
            movement.Dash(prefix);
        }
        if (weapon != null)
        {
            weapon.Rotate_Weapon(prefix);
            weapon.Fire(prefix);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Shape_Pickup pickup = collision.gameObject.GetComponent<Shape_Pickup>();
        if(pickup != null)
        {
            Set_Shape(pickup.Get_Shape());
            Destroy(pickup.gameObject);
        }
        else
        {
            movement.On_Parent_Collision(collision);
        }
    }
}
