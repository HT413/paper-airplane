using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorController : MonoBehaviour {
	public static List<GameObject> items;

	// Use this for initialization
	void Start () {
		items = new List<GameObject>();
		transform.Translate(Vector3.right * ((2.0f * Random.value) - 1.0f) * 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(UIController.IsGameOver)
			Destroy(gameObject);
		if(!UIController.IsGameRunning)
			return;
		if(PlayerController.isFallingDown)
			transform.Translate(Vector3.up * Time.deltaTime * PlayerController.FALL_DOWN_SPEEDUP * PlayerController.G_GRAVITY * PlayerController.gameTimeModifier);
		else
			transform.Translate(Vector3.up * Time.deltaTime * PlayerController.G_GRAVITY * PlayerController.gameTimeModifier);

		// Check if object is now off screen
		if(transform.position.y > 15.0f)
			Destroy(gameObject);
	}
}
