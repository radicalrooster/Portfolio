using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	public GameObject MainCanvas;
	public GameObject OptionsCanvas;
	
	public void selectLevel(string level)
	{
		SceneManager.LoadScene(level);
	}

	public void quitGame()
	{
		Application.Quit();
	}

	public void ToggleOptions()
	{
		MainCanvas.SetActive(!MainCanvas.activeSelf);
		
		if (!OptionsCanvas.activeSelf)
		{
			OptionsCanvas.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			OptionsCanvas.SetActive(false);
			Time.timeScale = 1f;
		}
	}

}
