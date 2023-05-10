using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public GameObject UiCanvasGame;
    public Text CountdownText;
    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AiScript aiScript;

    public float timeLeft = 5f;// Start is called before the first frame update
    void Start()
    {
        UiCanvasGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        {
            timeLeft -= Time.deltaTime;
            CountdownText.text = timeLeft.ToString("0");

            if (timeLeft > 0)
            {
                puckScript.enabled = false;
                aiScript.enabled = false;
                playerMovement.enabled = false;
            }

            else
            {
                puckScript.enabled = true;
                aiScript.enabled = true;
                playerMovement.enabled = true;
            }

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                CountdownText.gameObject.SetActive(false);
                UiCanvasGame.gameObject.SetActive(false);
            }
        
        }
    }
}
