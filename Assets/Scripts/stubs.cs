using UnityEngine;
using System.Collections;

public class stubs : MonoBehaviour {
	string currentRoom = "Lobby";
	string areaEntry = "";
	string Movement = "";
	bool hasID = false;
	bool bank = false;

void Update () {
	string textBuffer = "You are currently in: " + currentRoom + "\n\n" + areaEntry + "\n\n" + Movement;

		if (currentRoom == "Lobby") {
			if (hasID == false) {
				areaEntry = "You see the security guard.";
			} 
			else {
				if (bank == true) {
					areaEntry = "The door to the bank is open. The security guard waves to you.";
				} 
				else {
					areaEntry = "The guard scans your ID and opens a secret door for you.";
				}
			}
			if (hasID == true) {
				if (bank == false) {
					Movement = "Press [W] to go to the elevators. \n Press [S] to go outside.\n Press [A] to head through the secret door.";
				} 
				else {
					Movement = "Press [W] to go to the elevators. \n Press [S] to go outside.\n Press [A] to go to the bank.";
				}
			} 
			else {
				Movement = "\nPress [W] to go to the elevators. \n Press [S] to go outside.";
			}

			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "Elevators";
			} 
			if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Outside"; 
			}
			if (hasID == true) {
				if (Input.GetKeyDown (KeyCode.A)) {
					currentRoom = "Bank";
				}
			}
		} 

		if (currentRoom == "Elevators") {
			areaEntry = "You wait in the elevator.";
			Movement = "Press [S] to exit the elevators.";

			if (Input.GetKeyDown (KeyCode.S)) {
				currentRoom = "Lobby";
			}
		}

		if (currentRoom == "Outside") {
			areaEntry = "It's hot out here.\n (oh hey it's your ID!)";
			hasID = true;
			Movement = "Press [W] to go back inside.";

			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "Lobby";
			}
		}

		if (currentRoom == "Bank") {
			areaEntry = "You find yourself in a wide bank vault.\nThere's a huge door in your way.";
			Movement = "Press [D] to return to the Lobby.";
			bank = true;

			if (Input.GetKeyDown (KeyCode.D)) {
				currentRoom = "Lobby";
			}
		}

	GetComponent<TextMesh> ().text = textBuffer;

	}
}
