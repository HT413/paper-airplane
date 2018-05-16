using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.Translate(Vector3.right * ((2.0f * Random.value) - 1.0f) * 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerController.isFallingDown)
			transform.Translate(Vector3.up * Time.deltaTime * 3.0f);
		else
			transform.Translate(Vector3.up * Time.deltaTime);

		// Check if object is now off screen
		if(transform.position.y >= 10.0f)
			Destroy(gameObject);
	}
}
