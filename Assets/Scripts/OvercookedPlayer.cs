using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class OvercookedPlayer : MonoBehaviour {

	private Rigidbody rigidBody;

	bool movingLeft;
	bool movingRight;

	private float playerSpeed = 0.1f;
	private float jumpForce = 350f;

	private bool isInSphere;

	private void Start (){
		rigidBody = GetComponent<Rigidbody> ();
	}

	public void DpadInput (string input) {

	}

	public void ButtonInput (JToken data){
		
		switch (data["element"].ToString()) {
		case "dpad-section":
			Debug.Log("DPAD");

			if (isInSphere) {
				if (Camera.main.backgroundColor == Color.yellow) {
					Camera.main.backgroundColor = Color.blue;
				} else {
					Camera.main.backgroundColor = Color.yellow;
				}
			}
			break;
		case "interact-button":
			Debug.Log("INTARACT");
			break;
		}

	}

	private void FixedUpdate(){
		if (movingLeft && !movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector3 (-playerSpeed, 0, 0)); 
		} else if (!movingLeft && movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector3 (playerSpeed, 0, 0)); 
		}
	}

	//Track if the player capsule is currently inside the transparent sphere or not
	void OnTriggerEnter(Collider trigger){
		if (trigger.tag == "PlatformSphere") {
			isInSphere = true;
		}
	}

	void OnTriggerExit(Collider trigger){
		if (trigger.tag == "PlatformSphere") {
			isInSphere = false;
		}
	}
}
