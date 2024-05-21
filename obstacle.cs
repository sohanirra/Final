using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour {
float maxX = 3.5f;
bool toRight;
bool toLeft;
public float speed;

public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       toRight = true; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3 (speed, 0, 0);
	if (transform.position.x >= maxX) {
	toLeft = true;
	toRight = false;

	}
	if (transform.position.x <= -maxX) {
	toLeft = false;
	toRight = true;
	}
	if (toRight) {
	   transform.position += move *Time.deltaTime;
	}
	else if (toLeft){
	     transform.position -= move *Time.deltaTime;
	}
    }
void OnTriggerEnter(Collider col){
	if (col.tag == "Player") {
	Destroy (player);
		}
	}
}
