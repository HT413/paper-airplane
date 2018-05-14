using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	private GameObject panelConfig, panelButtons;
	// TODO not sprite private Sprite sAirplane;
	enum E_Direction {DIR_LEFT, DIR_DOWN, DIR_RIGHT};

	// Use this for initialization
	void Start () {
		panelConfig = GameObject.Find("Canvas/grpOptions");
		panelButtons = GameObject.Find("Canvas/grpControls");

		// Add listeners to buttons
		Button btnGameStart = GameObject.Find("Canvas/grpOptions/btnStart").GetComponent<Button>();
		btnGameStart.onClick.AddListener(OnGameStart);

		// Hide airplane TODO
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Method called when "Start Game" button is pressed
	void OnGameStart(){
		// Change active state of panels as necessary
		panelConfig.gameObject.SetActive(false);
		panelButtons.gameObject.SetActive(true);
		// Add listeners to the control buttons
		Button btnLeft = GameObject.Find("Canvas/grpControls/btnLeft").GetComponent<Button>();
		btnLeft.onClick.AddListener(TurnLeft);
		Button btnRight = GameObject.Find("Canvas/grpControls/btnRight").GetComponent<Button>();
		btnRight.onClick.AddListener(TurnRight);
		Button btnDown = GameObject.Find("Canvas/grpControls/btnDown").GetComponent<Button>();
		btnDown.onClick.AddListener(TurnDown);
	}

	void TurnLeft(){
		Debug.Log("Left");
		TurnAirplane(E_Direction.DIR_LEFT);
	}

	void TurnRight(){
		Debug.Log("Right");
		TurnAirplane(E_Direction.DIR_RIGHT);
	}

	void TurnDown(){
		Debug.Log("Down");
		TurnAirplane(E_Direction.DIR_DOWN);
	}

	void TurnAirplane(E_Direction dir){
		switch(dir){
		case E_Direction.DIR_LEFT:
			break;

		case E_Direction.DIR_DOWN:
			break;

		default: // DIR_RIGHT
			break;
		}
	}
}
