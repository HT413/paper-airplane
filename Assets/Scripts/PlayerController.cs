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
			dx = -4.0f;
		} else{
			dx = 4.0f;
		}
	}

	public static void DoDown(){
		isFallingDown = true;
		dx = 0.0f;
	}
}
