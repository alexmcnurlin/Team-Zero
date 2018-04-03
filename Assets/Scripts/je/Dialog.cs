﻿using System;
using System.Collections.Generic;

[Serializable]
public class Dialog
{

	public enum DialogType
	{
		CasualChat,
		Quest,

	}

	public enum Role
	{
		FindSyrupQuest,
	}

	public static Dictionary<Role, string> dialogData = new Dictionary<Role, string> () { {
			Role.FindSyrupQuest, 
			@"{
				""assignChat"": [""Hello! My, my, you seem like a quite the depressed flapjack."",
					""Could I bother you with a favor? I myself am I bit sad lately."",
					""I made a fresh stack of pancakes but have no syrup to douse them in."",
					""If you collect a syrup bottle for me, I will reward you handsomely.""],
				""postAssignmentChat"": [""Have you found a syrup bottle for me yet?"",
					""Well what are you waiting for, there are steaming pancakes on the line!""],
				""completionChat"": [""Oh my goodness!"", ""I feel as though I have waited a lifetime for this syrup!"",
					""Thank you so much!!"", ""Please take these 5 gold coins as a reward!""],
				""postCompletionChat"": [""Hmm..."", ""I seem to have lost my appetite.""],
				""rewardAmount"": 5
			}"
		},
	};

	public DialogType dialogType;
	public string[] casualChat;
	public string[] assignChat;
	public string[] postAssignmentChat;
	public string[] completionChat;
	public string[] postCompletionChat;
	public int rewardAmount;
}