using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	private GameObject panelConfig, panelButtons, panelScore, panelGameover;
	private Text txtScore, txtGameover;
	private SpriteRenderer airplaneRenderer;
	enum E_Direction {DIR_LEFT = 0, DIR_DOWN = 1, DIR_RIGHT = 2};
	private Sprite[] airplaneSprites;
	public static bool IsGameRunning = false, IsGameOver = false, IsPreparedGameOver = false;
	public static int score;

	// Use this for initialization
	void Start () {
		panelConfig = GameObject.Find("Canvas/grpOptions");
		panelButtons = GameObject.Find("Canvas/grpControls");
		panelScore = GameObject.Find("Canvas/grpScore");
		panelGameover = GameObject.Find("Canvas/grpGameOver");
		txtScore = GameObject.Find("Canvas/grpScore/txtScore").GetComponent<Text>();
		txtGameover = GameObject.Find("Canvas/grpGameOver/txtGameOver").GetComponent<Text>();

		// Add listeners to buttons
		Button btnGameStart = GameObject.Find("Canvas/grpOptions/btnStart").GetComponent<Button>();
		btnGameStart.onClick.AddListener(OnGameStart);

		// Hide airplane
		airplaneRenderer = GameObject.Find("Airplane").GetComponent<SpriteRenderer>();
		airplaneRenderer.gameObject.SetActive(false);

		// Hide panels
		panelScore.gameObject.SetActive(false);
		panelGameover.gameObject.SetActive(false);

		// Load airplane sprites
		airplaneSprites = new Sprite[3];
		airplaneSprites[(int) E_Direction.DIR_LEFT] = Resources.Load<Sprite>("Sprites/plane_left");
		airplaneSprites[(int) E_Direction.DIR_DOWN] = Resources.Load<Sprite>("Sprites/plane_down");
		airplaneSprites[(int) E_Direction.DIR_RIGHT] = Resources.Load<Sprite>("Sprites/plane_right");

		// Reset game vars
		PlayerController.gameTimeModifier = 1.0f;
		PlayerController.starsCollected = 0;

		// Other initializations
		IsGameRunning = false;
		IsGameOver = false;
		IsPreparedGameOver = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(IsGameOver && !IsPreparedGameOver){
			PrepareRestart();
			IsPreparedGameOver = true;
		}
		if(panelScore.gameObject.activeSelf){
			// Round to 2 decimal places
			score = (int) Mathf.Round((PlayerController.gameTimeModifier - 1.0f) * (100.0f / PlayerController.DIFF_INCREASE_PER_SECOND)) + 1000 * PlayerController.starsCollected;
			txtScore.text = string.Format("Score: {0}.{1}{2}", score / 100, (score / 10) % 10, score % 10);
		}
	}

	// Method called when "Start Game" button is pressed
	void OnGameStart(){
		// Change active state of panels as necessary
		panelConfig.gameObject.SetActive(false);
		panelGameover.gameObject.SetActive(false);
		panelButtons.gameObject.SetActive(true);
		panelScore.gameObject.SetActive(true);
		// Add listeners to the control buttons
		Button btnLeft = GameObject.Find("Canvas/grpControls/btnLeft").GetComponent<Button>();
		btnLeft.onClick.AddListener(TurnLeft);
		Button btnRight = GameObject.Find("Canvas/grpControls/btnRight").GetComponent<Button>();
		btnRight.onClick.AddListener(TurnRight);
		Button btnDown = GameObject.Find("Canvas/grpControls/btnDown").GetComponent<Button>();
		btnDown.onClick.AddListener(TurnDown);
		// Show the airplane
		airplaneRenderer.gameObject.SetActive(true);
		airplaneRenderer.sprite = airplaneSprites[(int) E_Direction.DIR_RIGHT];
		PlayerController.DoTurn(false);

		// Other initializations
		if(FloorController.items != null){
			foreach(GameObject o in FloorController.items){
				if(o != null)
					Destroy(o);
			}
			FloorController.items.Clear();
		}
		IsGameRunning = true;
		IsGameOver = false;
		IsPreparedGameOver = false;
		score = 0;
		CollectibleGenerator.lastFloorGenerateTime = -999.9f;
		CollectibleGenerator.currentGameTime = -999.9f;
	}

	void TurnLeft(){
		if(IsGameRunning)
			TurnAirplane(E_Direction.DIR_LEFT);
	}

	void TurnRight(){
		if(IsGameRunning)
			TurnAirplane(E_Direction.DIR_RIGHT);
	}

	void TurnDown(){
		if(IsGameRunning)
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

	void PrepareRestart(){
		// Display Game Over panel
		panelGameover.gameObject.SetActive(true);
		txtGameover.text = string.Format("Game Over!\nFinal Score: {0}", UIController.score / 100);
		GameObject.Find("Canvas/grpGameOver/btnRestart").GetComponent<Button>().onClick.AddListener(OnGameStart);
		// Hide things
		airplaneRenderer.gameObject.SetActive(false); // Airplane
		panelScore.gameObject.SetActive(false); // Score panel
	}
}
