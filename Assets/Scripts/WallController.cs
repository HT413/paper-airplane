﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	private GameObject left;
	private GameObject right;
	// Use this for initialization
	void Start () {
		Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

		left = GameObject.Find("Wall_left");
		left.transform.position = new Vector3(-stageDimensions.x, 0, 0);

		right = GameObject.Find("Wall_right");
		right.transform.position = new Vector3(stageDimensions.x, 0, 0);
	}

	// Update is called once per frame
	void Update () {

	}
}
