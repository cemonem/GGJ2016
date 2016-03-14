using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Credits;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCreditsClick()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void OnBackClick()
    {
        Credits.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnStartClick()
    {
        Application.LoadLevel("Main");
    }
}
