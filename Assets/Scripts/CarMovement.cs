﻿/* Unity Game Programming
 * Thunder Road Project
 * Thunder Road Author
 * Project Date
 */

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CarMovement : MonoBehaviour 
{
	// declare public Text variables
	public TextMeshProUGUI speedText;
	public TextMeshProUGUI damageText;
	public TextMeshProUGUI timeText;
	public TextMeshProUGUI gameOverText;

	// declare class variables to track 
	// speed, damage, and elapsed time
	float speed = 1.0f;
	int damage = 0;
	float elapsedTime = 0;

	// this flag will become true when the game is over
	bool gameOver = false;

	// Use this for initialization
	void Start () 
	{
		// initialize all of the Text display messages
		speedText.text = "Speed: " + speed;
		damageText.text = "Damage: 0";
		timeText.text = "Time: 0";
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		// only process movement and new time if the
		// game is not yet over
		// ??replace this line with an if() statement ?? 
		{
			// Move the car in current direction at
			// the current speed.  Translation in the "X"
			// direction will move an object forward at
			// it's current rotation angle. Adjust the 
			// 0.02F scale factor to move faster or slower.
			transform.Translate(speed * Time.deltaTime, 0, 0);

			// Get steering left/right input.  Adjust
			// the 100.0F scale factor to turn faster
			// or slower
			float rotation = Input.GetAxis("Horizontal") * 100.0F;

			// rotate car left or right according to current input
			// (rotation will be 0 if no input)
			transform.Rotate(0, 0, -rotation);

			// add time since the last frame to our measure
			// of overall elapsed time
			elapsedTime += Time.deltaTime;

			// update the timeText message, converting float to int
			timeText.text = "Time: " + (int)elapsedTime;
		}
	}

	void OnTriggerEnter2D(Collider2D otherObject)
	{
		// get the name of the object we triggered
		string otherName = otherObject.gameObject.name;
		Debug.Log ("Trigger on " + otherName);

		// take different actions depending on the other 
		// object's name
		switch (otherName) 
		{
		   // ?? complete all cases of this switch statement ??
		}
	}

	void OnCollisionEnter2D(Collision2D otherObject)
	{
		Debug.Log ("Collision on " + otherObject.gameObject.name);

		// on any collision with an obstacle object,
		// increase damage by 1 and update the damageText display
		damage++;
		damageText.text = "Damage: " + damage;

		// ?? add an if() statement and logic to handle 
		// "Wrecked!" game over condition ??
	}
}
