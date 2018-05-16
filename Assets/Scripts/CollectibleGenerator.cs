using UnityEngine;
using System.Collections;

public class CollectibleGenerator : MonoBehaviour {
	static float lastFloorGenerateTime = -999.9f;
	static float currentGameTime = -999.9f;
	const float FLOOR_GENERATE_DT = 6.0f;
	static float lastStarGenerateTime = FLOOR_GENERATE_DT / 2.0f; // Half floor generate time
	const float STAR_GENERATE_DT = 3.0f * FLOOR_GENERATE_DT; // Thrice floor generate time

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!UIController.IsGameRunning)
			return;
		if(currentGameTime < 0){
			currentGameTime = 0.0f;
			Instantiate(Resources.Load("Prefabs/Floor"), Vector3.down * FLOOR_GENERATE_DT * 2.0f, Quaternion.identity);
		}
		if(PlayerController.isFallingDown)
			currentGameTime += Time.deltaTime * 3.0f;
		else
			currentGameTime += Time.deltaTime;
		if((currentGameTime - lastFloorGenerateTime) >= FLOOR_GENERATE_DT){
			lastFloorGenerateTime = currentGameTime;
			Instantiate(Resources.Load("Prefabs/Floor"), Vector3.down * FLOOR_GENERATE_DT * 3.0f, Quaternion.identity);
		}
		if((currentGameTime - lastStarGenerateTime) >= STAR_GENERATE_DT){
			lastStarGenerateTime = currentGameTime;
			Instantiate(Resources.Load("Prefabs/Star"), Vector3.down * FLOOR_GENERATE_DT * 3.0f, Quaternion.identity);
		}
	}
}
