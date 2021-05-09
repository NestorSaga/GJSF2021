using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public  List<Transform> limites;

    public GameObject quadrante;

    public GameObject diablillo;


    float nextActionTime = 0.0f;
    float period = 4f;

    float offset = 0.5f;

    public PlayerController p1;
    public Player_2_Controller p2;

    bool startGame, wonOnce;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
    void Start()
    {
        limites = new List<Transform>();
        llenarLista();
        startGame = false;
        transform.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (Time.time > nextActionTime)
            {
                //Minions objetive
                nextActionTime += period;
                int random = Random.Range(0, limites.Count);
                Vector3 position = new Vector3(limites[random].position.x - offset * 2, offset, limites[random].position.z - offset * 2);
                //Vector3 position = limites[random].forward +  new Vector3(0,offset,0);

                int offTargetPlus = limites.Count - random + 2;
                int offTargetMinus = limites.Count - random - 2;
                if (limites.Count - random + 2 > limites.Count - 1) offTargetPlus = limites.Count;
                else if (limites.Count - random - 2 < 0) offTargetMinus = 0;

                //Spawn minions
                var d = Instantiate(diablillo, position, Quaternion.identity);


                if (period % 2 == 0)
                    d.GetComponent<DiablilloScript>().target = limites[offTargetPlus];
                else
                    d.GetComponent<DiablilloScript>().target = limites[offTargetMinus];
            }
        }   
    }

    void llenarLista()
    {
        foreach (Transform child in quadrante.transform)
        {
            limites.Add(child);
        }
    }

    public void StartGame()
    {
        startGame = true;
        UIManager.Instance.infoUI.SetActive(false);
        UIManager.Instance.gameUI.SetActive(true);
    }

    public void win()
    {

        if (wonOnce)
        {
            Debug.Log("WIN");
            UIManager.Instance.EndScreen(true);
            p1.GetComponent<PlayerInput>().enabled = false;
            p2.GetComponent<PlayerInput>().enabled = false;

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
                Application.Quit(0);

            if (Keyboard.current.escapeKey.wasPressedThisFrame)
                SceneManager.LoadScene(0);
        }
        else
        {
            p2.P2HP = p2.maxP2HP;
            wonOnce = true;
        }

        
    }

    public void lose()
    {
        Debug.Log("LOSE");
        UIManager.Instance.EndScreen(false);
        p1.GetComponent<PlayerInput>().enabled = false;
        p2.GetComponent<PlayerInput>().enabled = false;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Application.Quit(0);

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            SceneManager.LoadScene(0);
    }
}
