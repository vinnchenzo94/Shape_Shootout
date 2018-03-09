using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

    public GameObject explosion;
    public bool explode;
    public float damage, move_speed;
    Rigidbody2D bullet_rigidbody;

	// Use this for initialization
	void Start () {
        bullet_rigidbody = GetComponent<Rigidbody2D>();
        Activate(this.transform.right);
	}

    public virtual void Activate(Vector3 _direction)
    {
        if(bullet_rigidbody == null)
        {
            bullet_rigidbody = GetComponent<Rigidbody2D>();
        }
        if(bullet_rigidbody != null)
        {
            this.transform.right = _direction;
            bullet_rigidbody.velocity = this.transform.right * move_speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Shape_Health health = collision.gameObject.transform.root.GetComponentInChildren<Shape_Health>();
        if(health != null)
        {
            health.Take_Health(damage);
        }
        Destroy(this.gameObject);
    }

}
