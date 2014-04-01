﻿using UnityEngine;
using System.Collections;

public class LoadMissionFromMenu : MonoBehaviour
{
	[SerializeField] GameObject levelLoadSplashBaseAttack;
	[SerializeField] GameObject levelLoadSplashBaseDefense;
	[SerializeField] GameObject levelLoadSplashBaseVsBase;
	[SerializeField] GameObject levelLoadSplashVIPAttack;
	[SerializeField] GameObject levelLoadSplashVIPDefense;
	[SerializeField] GameObject tutorialLoadSplash;
	
	void OnClick()
	{
		int missionToLoad = PlayerPrefs.GetInt("Mission Scene Number", 0);

		if (missionToLoad == 3)
			tutorialLoadSplash.SetActive(true);
		else if (PlayerPrefs.GetInt("Mission Type", 0) == 1)
			levelLoadSplashBaseAttack.SetActive(true);

		StartCoroutine(WaitAndLoad());
	}
	
	IEnumerator WaitAndLoad()
	{
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel(PlayerPrefs.GetInt("Mission Scene Number", 0));
	}
}
