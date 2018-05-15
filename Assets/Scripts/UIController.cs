using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	private GameObject panelConfig, panelButtons;
	private SpriteRenderer airplaneRenderer;
	enum E_Direction {DIR_LEFT = 0, DIR_DOWN = 1, DIR_RIGHT = 2};
	private Sprite[] airplaneSprites;

	// Use this for initialization
	void Start () {
		panelConfig = GameObject.Find("Canvas/grpOptions");
		panelButtons = GameObject.Find("Canvas/grpControls");

		// Add listeners to buttons
		Button btnGameStart = GameObject.Find("Canvas/grpOptions/btnStart").GetComponent<Button>();
		btnGameStart.onClick.AddListener(OnGameStart);

		// Hide airplane
		airplaneRenderer = GameObject.Find("Airplane").GetComponent<SpriteRenderer>();
		airplaneRenderer.gameObject.SetActive(false);

		airplaneSprites = new Sprite[3];
		airplaneSprites[(int) E_Direction.DIR_LEFT] = Resources.Load<Sprite>("Sprites/plane_left");
		airplaneSprites[(int) E_Direction.DIR_DOWN] = Resources.Load<Sprite>("Sprites/plane_down");
		airplaneSprites[(int) E_Direction.DIR_RIGHT] = Resources.Load<Sprite>("Sprites/plane_right");
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
		// Show the airplane
		airplaneRenderer.gameObject.SetActive(true);
		TurnRight();
	}

	void TurnLeft(){
		TurnAirplane(E_Direction.DIR_LEFT);
	}

	void TurnRight(){
		TurnAirplane(E_Direction.DIR_RIGHT);
	}

	void TurnDown(){
		TurnAirplane(E_Direction.DIR_DOWN);
	}

	void TurnAirplane(E_Direction dir){
		switch(dir){
		case E_Direction.DIR_LEFT:
			airplaneRenderer.sprite = airplaneSprites[(int) E_Direction.DIR_LEFT];
			PlayerController.DoTurn(true);
			break;

		case E_Direction.DIR_DOWN:
			airplaneRenderer.sprite = airplaneSprites[(int) E_Direction.DIR_DOWN];
			PlayerController.DoDown();
			break;

		default: // DIR_RIGHT
			airplaneRenderer.sprite = airplaneSprites[(int) E_Direction.DIR_RIGHT];
			PlayerController.DoTurn(false);
			break;
		}
	}
}
