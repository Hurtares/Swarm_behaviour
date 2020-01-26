using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quitGame : MonoBehaviour {

    public Button btnQuit;
	// Use this for initialization
	void Start () {
        btnQuit.onClick.AddListener(Quit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Quit() {
        Application.Quit();
        Debug.Log("QuitGame");
    }
}
