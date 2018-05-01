using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
	public float barDisplay;
	//current progress
	public Vector2 pos = new Vector2 (45, 40);
	public Vector2 size = new Vector2 (76, 20);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	Player player;

	void Start ()
	{
		GameObject playerGameObject = GameObject.FindWithTag ("MainPlayer");
		player = null;
		if (player == null && playerGameObject != null) {
			player = playerGameObject.GetComponent<Player> ();
		}
	}

	void OnGUI ()
	{
		Texture2D red = new Texture2D (1, 1);
		red.SetPixel (0, 0, new Color (255, 59, 48));
		red.Apply ();
		GUIStyle textureStyle = new GUIStyle { normal = new GUIStyleState { background = red } };

		GUI.color = Color.red;
		//draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), GUIContent.none, textureStyle);

		GUI.color = Color.green;
		//draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), GUIContent.none, textureStyle);
		GUI.EndGroup ();
		GUI.EndGroup ();
	}

	void Update ()
	{
		if (player != null) {
			// health bar display valid value range is [0.0, 1.0] (float)
			barDisplay = ((float)player.GetHealth ()) / 100f;
		}
	}
}