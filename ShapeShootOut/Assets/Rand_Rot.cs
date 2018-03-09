using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rand_Rot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.Rotate(new Vector3(0, Random.Range(0, 360), Random.Range(0, 360)));
        this.gameObject.layer = this.transform.parent.gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
