using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTemp : MonoBehaviour {

    GameObject[] GreenSpawn;
    GameObject[] RedSpawn;

    public GameObject Green;
    public GameObject Red;

    public int GreenCount = 0;
    public int RedCount = 0;

    // Use this for initialization
    void Start () {
        GreenSpawn = GameObject.FindGameObjectsWithTag("Respawn");
        RedSpawn = GameObject.FindGameObjectsWithTag("Finish");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            Transform t = GreenSpawn[Random.Range(0, 6)].transform;
            Instantiate(Green, t.position, Quaternion.identity);
            GreenCount++;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            Transform t = RedSpawn[Random.Range(0, 6)].transform;
            Instantiate(Red, t.position, Quaternion.identity);
            RedCount++;
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            for (int i = 0; i < 10; i++) {
                Transform t = GreenSpawn[Random.Range(0, 6)].transform;
                Instantiate(Green, t.position, Quaternion.identity);
                GreenCount++;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            for (int i = 0; i < 10; i++) {
                Transform t = RedSpawn[Random.Range(0, 6)].transform;
                Instantiate(Red, t.position, Quaternion.identity);
                RedCount++;
            }
        }
    }
}
