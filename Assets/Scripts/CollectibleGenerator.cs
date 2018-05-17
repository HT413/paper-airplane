using UnityEngine;
using System.Collections;

public class CollectibleGenerator : MonoBehaviour {
	public static float lastFloorGenerateTime = -999.9f;
	public static float currentGameTime = -999.9f;
	const float FLOOR_GENERATE_DT = 6.0f;
	static float lastStarGenerateTime = FLOOR_GENERATE_DT / 1.99f; // Half floor generate time
	const float STAR_GENERATE_DT = 3.0f * FLOOR_GENERATE_DT; // Thrice floor generate time

	// Use this for initialization
	void Start () {
		lastFloorGenerateTime = -999.9f;
		currentGameTime = -999.9f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!UIController.IsGameRunning)
			return;
		if(currentGameTime < 0){
			currentGameTime = 0.0f;
			lastFloorGenerateTime = 0.0f;
			for(int i = 1; i <= 6; i++){
				Instantiate(Resources.Load("Prefabs/Floor"), Vector3.down * FLOOR_GENERATE_DT * i * 0.5f * PlayerController.G_GRAVITY, Quaternion.identity);
			}
		}
		if(PlayerController.isFallingDown)
			currentGameTime += Time.deltaTime * PlayerController.FALL_DOWN_SPEEDUP * PlayerController.G_GRAVITY * PlayerController.gameTimeModifier;
		else
			currentGameTime += Time.deltaTime * PlayerController.G_GRAVITY * PlayerController.gameTimeModifier;
		if((currentGameTime - lastFloorGenerateTime) >= FLOOR_GENERATE_DT){
			lastFloorGenerateTime = currentGameTime;
			Instantiate(Resources.Load("Prefabs/Floor"), Vector3.down * FLOOR_GENERATE_DT * 3.0f * PlayerController.G_GRAVITY, Quaternion.identity);
		}
		if((currentGameTime - lastStarGenerateTime) >= STAR_GENERATE_DT){
			lastStarGenerateTime = currentGameTime;
			Instantiate(Resources.Load("Prefabs/Star"), Vector3.down * FLOOR_GENERATE_DT * 3.0f * PlayerController.G_GRAVITY, Quaternion.identity);
		}
	}
}
