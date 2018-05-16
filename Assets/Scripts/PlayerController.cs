using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private static float dx = 0.0f;
	public static bool isFallingDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		transform.Translate(Vector3.right * dx * Time.deltaTime);
	}

	public static void DoTurn(bool isLeft){
		isFallingDown = false;
		if(isLeft){
			dx = -3.75f;
		} else{
			dx = 3.75f;
		}
	}

	public static void DoDown(){
		isFallingDown = true;
		dx = 0.0f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Floor")){
			Debug.Log("Hit floor!");
		}
		else if(other.tag.Equals("Star")){
			Debug.Log("Hit star!");
			Destroy(other.gameObject);
		}
	}
}
