using UnityEngine;
using System.Collections;

public class OnStartGameClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStartClick()
    {
        Application.LoadLevel("main");
    }
}
