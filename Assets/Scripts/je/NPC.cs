using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	// used to determine which quest/chat to relate to this non-player character
	[SerializeField] Dialog.Role npcRole;
	// the dialog associated with the NPC
	Dialog d;

	void Start ()
	{
		d = JsonUtility.FromJson<Dialog> (Dialog.dialogData [npcRole]);
		//		d.dialogType = Dialog.DialogType.Quest;
		//			Debug.Log (string.Join (" ", d.casualChat));
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "MainPlayer") {
			Debug.Log ("PLAYER COLLIDED W ENEMY");		
//			Debug.Log (string.Join (" ", d.casualChat));
			Debug.Log ("CHAT ON INITIAL QUEST ASSIGNMENT: " + string.Join (" ", d.assignChat));
			Debug.Log ("CHAT AFTER ASSIGNING: " + string.Join (" ", d.postAssignmentChat));
			Debug.Log ("CHAT AFTER COMPLETING QUEST: " + string.Join (" ", d.completionChat));
			Debug.Log ("FINAL CHAT: " + string.Join (" ", d.postCompletionChat));
			Debug.Log ("REWARD FOR QUEST COMPLETION: " + d.rewardAmount);
		}
	}

	public string[] CasualChat ()
	{
		return d.casualChat;
	}

	public void CollideWithObject (object[] temp)
	{
//		string type = (string)temp [0];
//		float speed = (float)temp [1];
//		velocity *= speed * 2;
	}
}
