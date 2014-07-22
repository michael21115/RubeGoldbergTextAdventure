using UnityEngine;
using System.Collections;

public class CastleHartstone : MonoBehaviour {
	
	string currentRoom = "Entrance";
	string areaEntry = "";
	string Movement = "";
	string Items = "";
	string Look = "";
	bool torch = false;
	bool antechamber = false;

	void roomreset (){
		areaEntry = "";
		Movement = "";
		Items = "";
		Look = "";
	}
	
	void Update () {
		string textBuffer = "You are currently in: " + currentRoom + "\n\n" + areaEntry + "\n\n" + Look + "\n\n" + Movement + "\n\n" + Items;
		
		// Locations Begin Here //
		if (currentRoom == "Entrance") {
			areaEntry = "You are facing the Exterior of Castle Hartstone.";
			areaEntry += "\nRumor has it a monstrous beast roams these decayed halls.";
			areaEntry += "\nYou have been tasked to find the monster and defeat it.";
			Movement = "To the North [W] is a heavy-looking door.";
			Movement += "\nPress [L] to look around. Press [K] to finish looking around.";
			if (torch == false) {
				Items = "There's a lit [T]orch to the side of the entrance.";
			}
			else {
				Items = "You have taken the torch.";
			}
			
			if (Input.GetKeyDown(KeyCode.W)) {
				currentRoom = "Entryway";
				roomreset();
			}
			if (Input.GetKeyDown (KeyCode.T)){
				torch = true;
			}
		}
		
		else if (currentRoom == "Entryway") {
			areaEntry = "The light from the open door illuminates a few feet ahead of you,";
			areaEntry += "\nbut beyond that you can't see anything.";
			Movement = "To the North [W] is a dark hallway.";
			Movement += "\nTo the South [S] is the castle exterior.";
			Items = "";
			
			if (Input.GetKeyDown(KeyCode.W)) {
				currentRoom = "Dark Hallway";
				roomreset ();
			}
			if (Input.GetKeyDown(KeyCode.S)) {
				currentRoom = "Entrance";
				roomreset ();
			}
		}
		else if (currentRoom == "Dark Hallway") {
			if (torch == false) {
				areaEntry = "It's really dark.";
				areaEntry += "\nIf only you had something to light your way.";
			}
			else {
				areaEntry = "\nYour torch illuminates the dark passage.";
			}
			Movement = "To the North [W] the hall continues.";
			Movement += "\nTo the South [S] is the castle entryway.";
			
			if (Input.GetKeyDown (KeyCode.W)){
				if (torch == false) {
					Items = "You stumble around in the darkness.";
					Items += "\nA growling ahead of you causes you to move back.";
					Items += "\nYou think it would be best to find a light source before proceeding.";
				}
				else {
					if (antechamber == false){
						currentRoom = "ZevEvent";
						roomreset ();
					}
					else {
						currentRoom = "Antechamber";
						roomreset ();
					}
				}
			}
			
			if (Input.GetKeyDown(KeyCode.S)) {
				currentRoom = "Entryway";
				roomreset ();
			}
			
		}
		
		else if (currentRoom == "Antechamber"){
			areaEntry = "It seems the monster has moved on, leaving you alone in the castle's antechamber.";
			areaEntry += "\n\n[L]ook around for more details.";
			Movement = "To the North [W], a sturdy Iron Gate impedes your progress.";
			Movement += "\nTo the South [S] is a Dark Hallway, leading back to the castle's entrance.";
			Movement += "\nTo the East [A] you think you can make out the faint sound of seagulls.";
			Movement += "\nTo the West [D] you can hear something shuffling around.";

			if (Input.GetKeyDown (KeyCode.W)){
				Items = "This gate is sturdy, and quite locked. It has two key holes,leading you to believe there are\ntwo keys that need to be turned at the same time in order to open it.";
			}

			if (Input.GetKeyDown (KeyCode.S)){
				currentRoom = "SampleEnd";
				roomreset ();
			}
			if (Input.GetKeyDown (KeyCode.A)){
				currentRoom = "SampleEnd";
				roomreset ();
			}
			if(Input.GetKeyDown (KeyCode.D)){
				currentRoom = "SampleEnd";
				roomreset ();
			}
			
			if (Input.GetKeyDown (KeyCode.B)){
				Items = "Banners marked with the sigil of Rathemn. They're made of fine Fordinne silk.";
			}
			if (Input.GetKeyDown (KeyCode.I)){
				Items = "This gate has two keyholes; You can tell it needs both keys to open it.";
			}
			if (Input.GetKeyDown (KeyCode.F)){
				Items = "Strange sludge the monster was secreting. It has the consistency of tar.";
			}
		}
		
		else if (currentRoom == "ZevEvent"){
			textBuffer = "Using your torch to light the way, you manage to find the door. \n\nAhead of you, in the center of the castle's antechamber, you can make out a\ndark shadow moving in the darkness. You can tell it is some kind of hunched" +
				"\nmonster, like a wolf. Its breathing is heavy and ragged. You can practically\nhear its thick muscles tightening. Most unsettling of all is the viscous black\nsludge that seems to be oozing from its features. \nThe light of your torch causes the beast's attention to snap towards you." + 
					"\n\nYou freeze.\n\n" + 
					"The monster's eyes glow orange in the flickering torchlight. A part of you \nknows that this is the monster you are hunting. You can already tell you won't\nbe able to fight it as you are. It's too big, and too powerful. You're going to\nneed a weapon of some kind. For now your only hope is to remain still..." +
					"\nand pray it goes away. [Press Space]";
			if (Input.GetKeyDown(KeyCode.Space)) {
				int random = Random.Range (0, 3);
				if (random == 1){
					currentRoom = "ZevAttack";
					roomreset ();
				}
				else {
					currentRoom = "ZevLeave";
					roomreset ();
				}
			}
		}

		else if (currentRoom == "ZevAttack"){
			textBuffer = "Suddenly, the beast lets out a low growl and charges you!" + "\nYou scramble back through the doorway and slam it closed just in time.\n\n[Press Space]";
			if (Input.GetKeyDown (KeyCode.Space)){
				currentRoom = "Dark Hallway";
				antechamber = true;
				textBuffer = "You are currently in: " + currentRoom + "\n\n" + areaEntry + "\n\n" + Look + "\n\n" + Movement + "\n\n" + Items;
			}
		}

		else if (currentRoom == "ZevLeave"){
			textBuffer = "The monster seems to consider you for a moment...\n Before it turns away and disappears to the North.\n\n[Press Space]";
			if (Input.GetKeyDown (KeyCode.Space)){
				currentRoom = "Antechamber";
				antechamber = true;
				textBuffer = "You are currently in: " + currentRoom + "\n\n" + areaEntry + "\n\n" + Look + "\n\n" + Movement + "\n\n" + Items;
			}
		}

		else if (currentRoom == "SampleEnd"){
			areaEntry = "This is the end of the free sample! To continue playing, please pay $100~";
			Movement = "To restart, press Space";

			if (Input.GetKeyDown (KeyCode.Space)){
				currentRoom = "Entrance";
				torch = false;
				antechamber = false;
				roomreset ();
			}
		}
		
		// Look Module //
		if (Input.GetKeyDown(KeyCode.L)) {
			Look = "You look around.\n";
			if (currentRoom == "Entrance"){
				Look += "The crumbling stonework is riddled with creeping vines and overgrown";
				Look += "\nmoss. The castle was built in the third age as a fort for soldiers, but it fell";
				Look += "\ninto disrepair and monsters took root within it. Now it is rumored to be...";
				Look += "\nCursed.";}
			if (currentRoom == "Entryway") {
				Look += "The small bit of sunlight to your back illuminates dust and cobwebs,";
				Look += "\nbut beyond that the hall fades into an eerie blackness.";
				Look += "\nYou think you can hear something moving in the distance...";
				Look += "\nBut that just might be your imagination playing tricks on you.";
			}
			if (currentRoom == "Dark Hallway") {
				if (torch == true){
					Look += "A few rats scurry into hiding places as you wave your torch around.";
					Look += "\nOther than its complete lack of light, this hall is pretty unremarkable.";
				}
				else {
					Look += "It's too dark to see anything.";
				}
			}
			if (currentRoom == "Antechamber") {
				Look += "The walls on either side of you are wrapped in creeping vines coming from";
				Look += "\nthick cracks in the stonework. Decaying [B]anners hang from the rafters,";
				Look += "\nalthough they are out of your reach. On the floor is a trail of viscious black";
				Look += "\n[F]luid left by the beast you are tracking. The trail leads to the north, but";
				Look += "\nyou can see that path is blocked by an [I]ron gate.";
			}
		}
		
		if (Input.GetKeyDown(KeyCode.K)) {
			Look = "";	
		}
		
		// Display //
		GetComponent<TextMesh> ().text = textBuffer;
	}
}