using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Weapon : MonoBehaviour {

    public Color color;
    public GameObject bullet;
    public Transform fire_point;
    Vector3 target = Vector3.zero;
    public float lerp_speed, fire_delay;
    float next_fire_time;

    private void Update()
    {
        this.transform.right = Vector3.MoveTowards(this.transform.right, target, lerp_speed * Time.deltaTime);
    }

    public virtual void Rotate_Weapon(string _prefix)
    {
        target = new Vector3(Input.GetAxis(_prefix + "_RStick_X"), -Input.GetAxis(_prefix + "_RStick_Y"), 0);
    }

    public virtual void Fire(string _prefix)
    {
        if (Input.GetButton(_prefix + "_RBump") && Time.fixedTime > next_fire_time && bullet != null && fire_point != null)
        {
            GameObject bullet_inst = Instantiate(bullet, fire_point.position, fire_point.rotation);
            SpriteRenderer bullet_renderer = bullet_inst.GetComponentInChildren<SpriteRenderer>();
            if(bullet_renderer != null)
            {
                bullet_renderer.color = color;
            }
            TrailRenderer trail = bullet_inst.GetComponent<TrailRenderer>();
            bullet_inst.layer = this.gameObject.layer;
            next_fire_time = Time.fixedTime + fire_delay;
        }
    }
}
