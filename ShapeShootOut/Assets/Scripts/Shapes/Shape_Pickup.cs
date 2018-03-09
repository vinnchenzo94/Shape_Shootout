using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape_Pickup : MonoBehaviour {

    [SerializeField]
    private GameObject[] shape_objects;
    
    public GameObject Get_Shape()
    {
        return shape_objects[Random.Range(0, shape_objects.Length)];
    }
}
