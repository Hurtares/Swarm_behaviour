using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float vida = 10;
    public float pontuaçao = 0;


    public static GameManager Instance {
        get {
            return instance;
        }
    }

    private static GameManager instance = null;

    void Awake() {
        if (instance) {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void Reset() {
        SceneManager.LoadScene("CenaTeste");
        /*vida = 10;
        pontuaçao = 0;
        textGO.text = "";
        gameOver = false;
        Restart.gameObject.SetActive(false);
        player.GetComponent<MouseLook>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;*/
        

    }

}
