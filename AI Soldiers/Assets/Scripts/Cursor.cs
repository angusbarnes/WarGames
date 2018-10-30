using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    [Header("Objects")]
    public GameObject Unit;
    public GameObject Hub;

    [Space(10)]
    [Header("Controls:")]
    public KeyCode deployUnit;
    public KeyCode deploySquad;
    public string xAxis = "Horizontal";
    public string yAxis = "Vertical";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = new Vector2(Input.GetAxis(xAxis), Input.GetAxis(yAxis)) * 15f;
        transform.Translate(direction * Time.deltaTime);

        if (Input.GetKeyDown(deployUnit)) {
            Instantiate(Unit, transform.position, Quaternion.identity);
        }
	}
}
