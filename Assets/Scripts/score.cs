﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;

public class score : MonoBehaviour {
	
	static int playerScore;
	static int highscore =0;
	public GUIText text_score ;
	public GUIText text_hscore ;


	// Use this for initialization
	IEnumerator Start () 
	{
				if (Application.loadedLevel == 1) {
						playerScore = 0;
					//yield  return new WaitForSeconds(3.0f);
						while(true) {
								yield return new WaitForSeconds(0.5f);
								playerScore++;
						}
	
				}

			if (Application.loadedLevel==2){
				highscore = PlayerPrefs.GetInt("highscore");
			
				text_score = GameObject.Find("score").GetComponent<GUIText>();
			
			
				text_score.text=(playerScore).ToString ();
			
			
				if(playerScore>highscore)
				{
					highscore=playerScore;
					PlayerPrefs.SetInt("highscore", highscore); // The first is the string name that refers to the saved score, the second is your score variable (int)
					PlayerPrefs.Save();
				}
				text_hscore = GameObject.Find("highscore").GetComponent<GUIText>();
				text_hscore.text="HighScore : "+ (highscore).ToString ();
				Debug.Log("postingscore");
				PostScores(playerScore);
				


			}

		}
		

	void Update(){
	
		if(Application.loadedLevel==1){
			GetComponent<GUIText>().text =  (playerScore).ToString ();
		}
	}


	public void PostScores(int playerScore)
	{
		//The LogEventRequest_postScore() has been created by the custom SDK based on 
		//the events you made on the Gamesparks Portal. 
		//Likewise the Set_score(scoreToBePassed) Attribute has been generated by 
		//the attributes set in the GameSparks portal
		new GameSparks.Api.Requests.LogEventRequest_postscore().Set_score(playerScore).Send((response) =>
	    {
			if (response.HasErrors)
			{
				Debug.Log("Failed");
			}
			else
			{
				Debug.Log("Score has been posted to gamesparks Successful");
			}
		});
	}

}



