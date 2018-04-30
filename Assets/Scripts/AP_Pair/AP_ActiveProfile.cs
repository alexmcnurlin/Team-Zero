using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AP_ActiveProfile : MonoBehaviour {

	InputField inputField;

	void Awake()
	{
		inputField = GetComponentInChildren<InputField> ();
	}

	public void SetActiveProfileName()
	{
		string profileName = inputField.text;
		Debug.Log ("profile name = " + profileName);

		PlayerPrefs.SetString ("profile", profileName);
	}
}
