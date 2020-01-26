using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    LayerMask mel;
    LayerMask spawn;
	// Use this for initialization
	void Start () {
        mel = GameObject.Find("Mel").layer;
        spawn = GameObject.Find("Spawn").layer;
	}
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.Space)) { 
            Application.LoadLevel("Nivel1");
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            Application.LoadLevel("CenaTeste");
        }*/
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("colide" + other.gameObject.name);
        if(other.gameObject.layer == mel) {
            GameManager.Instance.pontuaçao += .5f;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.layer == spawn) {
            if (GameManager.Instance.pontuaçao >= 1.5f) {
                GameManager.Instance.pontuaçao = 0;
                GameManager.Instance.vida += 4;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else {
                //new UIControler().EscreverAlerta("percisa de pelo menos 1.5 litros");
                Debug.Log("percisa de pelo menos 1.5 litros");
            }
        }
    }
}
