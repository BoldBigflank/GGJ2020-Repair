using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class OvercookedLogic : MonoBehaviour {

	public GameObject playerPrefab;

	public Dictionary<int, PlayerController> players = new Dictionary<int, PlayerController> (); 

	void Awake () {
		AirConsole.instance.onMessage += OnMessage;		
		AirConsole.instance.onReady += OnReady;		
		AirConsole.instance.onConnect += OnConnect;		
	}

	void OnReady(string code){
		//Since people might be coming to the game from the AirConsole store once the game is live, 
		//I have to check for already connected devices here and cannot rely only on the OnConnect event 
		List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
		foreach (int deviceID in connectedDevices) {
			AddNewPlayer (deviceID);
		}
	}

	void OnConnect (int device){
		AddNewPlayer (device);
	}

	private void AddNewPlayer(int deviceID){

		if (players.ContainsKey (deviceID)) {
			return;
		}

		//Instantiate player prefab, store device id + player script in a dictionary
		GameObject newPlayer = Instantiate (playerPrefab, transform.position, transform.rotation) as GameObject;
		players.Add(deviceID, newPlayer.GetComponent<PlayerController>());
	}

	void OnMessage (int from, JToken data){
		Debug.Log ("message: " + data);
		
		// message:
		// {
		//  	"element": "dpad-section",
		//		"data": {
		//			"key": "down",
		//			"pressed": true
		//		}
		// }

		// Buttons
		// message: {
		//   "element": "interact-button",
		//   "data": {
		//     "pressed": true
		//   }
		// }

		//When I get a message, I check if it's from any of the devices stored in my device Id dictionary
		// Interaction button
		if (players.ContainsKey (from) && data["element"] != null && data["data"] != null) {
			string element = data["element"].ToString();
			if (element == "dpad-section")
			{
				JToken dataElement = data["data"];
				bool pressed = (bool)dataElement["pressed"];
				if (dataElement["key"] != null)
				{
					string key = dataElement["key"].ToString();

					if (key == "up")
					{
						float v = (pressed) ? 1.0f : 0.0f;
						players[from].SetVelocityY(v);
					}
					else if (key == "down")
					{
						float v = (pressed) ? -1.0f : 0.0f;
						players[from].SetVelocityY(v);
					}
					else if (key == "left")
					{
						float v = (pressed) ? -1.0f : 0.0f;
						players[from].SetVelocityX(v);
					}
					else if (key == "right")
					{
						float v = (pressed) ? 1.0f : 0.0f;
						players[from].SetVelocityX(v);
					}
				}
				
			} else if (element == "interact-button")
			{
				players[from].Interact();
			}
		}
	}

	void OnDestroy () {
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;		
			AirConsole.instance.onReady -= OnReady;		
			AirConsole.instance.onConnect -= OnConnect;		
		}
	}
}
