using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	static float screenWidthScale;
	public static float screenHeightScale;

	// Use this for initialization
	void Start () {
		screenWidthScale = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
		screenHeightScale = screenWidthScale / Camera.main.aspect;
		transform.localScale = new Vector3(screenWidthScale / 6.0f, screenHeightScale / 6.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(!UIController.IsGameRunning)
			return;
		if(PlayerController.isFallingDown)
			transform.Translate(Vector3.up * Time.deltaTime * PlayerController.FALL_DOWN_SPEEDUP * PlayerController.G_GRAVITY * PlayerController.gameTimeModifier);
		else
			transform.Translate(Vector3.up * Time.deltaTime * PlayerController.G_GRAVITY * PlayerController.gameTimeModifier);
		// Check if object should be shifted down
		if(gameObject.transform.position.y >= screenHeightScale)
			gameObject.transform.Translate(new Vector3(0.0f, -2.0f * screenHeightScale, 0.0f));
	}
}
