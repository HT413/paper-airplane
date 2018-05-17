using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private static float dx = 0.0f;
	public static bool isFallingDown = false;
	public static float G_GRAVITY = 1.8f;
	public static float gameTimeModifier;
	public static float DIFF_INCREASE_PER_SECOND = 0.01f;
	public static int starsCollected = 0;
	public static float FALL_DOWN_SPEEDUP = 2.5f;
	private static float moved = 0.0f;

	// Use this for initialization
	void Start () {
		gameTimeModifier = 1.0f;
		starsCollected = 0;
	}
	
	// Update is called once per frame
	void Update(){
		if(UIController.IsGameRunning){
			if(isFallingDown)
				gameTimeModifier += DIFF_INCREASE_PER_SECOND * Time.deltaTime * FALL_DOWN_SPEEDUP;
			else
				gameTimeModifier += DIFF_INCREASE_PER_SECOND * Time.deltaTime;
			moved += dx * Time.deltaTime * PlayerController.gameTimeModifier;
			transform.Translate(Vector3.right * dx * Time.deltaTime * PlayerController.gameTimeModifier);
		}
	}

	public static void DoTurn(bool isLeft){
		isFallingDown = false;
		if(isLeft){
			dx = -3.0f;
		} else{
			dx = 3.0f;
		}
	}

	public static void DoDown(){
		isFallingDown = true;
		dx = 0.0f;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("Floor")){
			SetGameOver();
		}
		else if(other.tag.Equals("Star")){
			starsCollected++;
			Destroy(other.gameObject);
		}
	}

	void SetGameOver(){
		// Reset everything
		transform.Translate(Vector3.left * moved);
		moved = 0.0f;
		gameTimeModifier = 1.0f;
		starsCollected = 0;

		UIController.IsGameRunning = false;
		UIController.IsGameOver = true;
	}
}
