using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour {

    public Text textVida;
    public Text textPont;
    public Text textGO;
    public Text textAlrta;
    public Button Restart;
    public GameObject player;
   /* public Transform spawn;
    public GameObject inteligencia;
    
    public GameObject enxame;*/

    private bool gameOver = false;

    // Use this for initialization
    void Start () {
        Restart.onClick.AddListener(Reset);
	}
	
	// Update is called once per frame
	void Update () {
        textVida.text = "Vida: " + GameManager.Instance.vida.ToString();
        textPont.text = "Score: " + GameManager.Instance.pontuaçao.ToString() + "L";
        if (GameManager.Instance.vida <= 0 && gameOver == false) {
            textGO.text = "GameOver";
            Restart.gameObject.SetActive(true);
            player.GetComponent<MouseLook>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;
            gameOver = true;
            //mais coisas quando o jogo acaba
        }
    }
    void Reset() {
        Debug.Log("Button Press");
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        GameManager.Instance.vida = 10;
        GameManager.Instance.pontuaçao = 0;
        textGO.text = "";
        gameOver = false;
        Restart.gameObject.SetActive(false);
        player.GetComponent<MouseLook>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;

        /*player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;*/
    }

    public void EscreverAlerta(string mensagem) {
        textAlrta.text = mensagem;
        StartCoroutine(Apagar(2));
    }
    IEnumerator Apagar(float tempo) {
        yield return new WaitForSeconds(tempo);
        textAlrta.text = "";
    }
}
