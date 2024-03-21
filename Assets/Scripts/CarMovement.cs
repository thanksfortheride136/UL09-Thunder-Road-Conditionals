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
		if(!gameOver)
		{
			transform.Translate(speed * Time.deltaTime, 0, 0);
			float rotation = Input.GetAxis("Horizontal") * 100.0F;
			transform.Rotate(0, 0, -rotation);
			elapsedTime += Time.deltaTime;
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
			case "finishLine":
				gameOver = true;
				break;
			case "speedBoost1":
			case "speedBoost2":
			case "speedBoost3":
			case "speedBoost4":
				speed += 1.0f;
				speedText.text = "Speed: " + speed;
				break;

		}
	}

	void OnCollisionEnter2D(Collision2D otherObject)
	{
		Debug.Log ("Collision on " + otherObject.gameObject.name);

		// on any collision with an obstacle object,
		// increase damage by 1 and update the damageText display
		switch (otherObject.gameObject.name)
		{
			case "rock1":
			damage++;
			damageText.text = "Damage: " + damage;
			break;
		}

		if (damage >= 10)
		{
			gameOver = true;
			gameOverText.text = "Wrecked!";
		}
	}
}
