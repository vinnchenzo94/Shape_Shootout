using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Health : MonoBehaviour {

    public float health;

	public void Take_Health(float _amount)
    {
        health -= _amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
