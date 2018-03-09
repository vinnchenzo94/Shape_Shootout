using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Spawner : MonoBehaviour {

    public GameObject pickup;
    public Transform min, max;
    public float spawn_wave_delay, spawn_delay;
    public int num_to_spawn;
    bool running = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn()
    {
        while (running == true)
        {
            for (int i = 0; i < num_to_spawn; i++)
            {
                Vector3 position = new Vector3(Random.Range(min.position.x, max.position.x), this.transform.position.y, 0);
                Instantiate(pickup, position, Quaternion.identity);
                yield return new WaitForSeconds(spawn_delay);
            }
            yield return new WaitForSeconds(spawn_wave_delay);
        }
        
    }
    
}
