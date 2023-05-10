using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject UiCanvasGame;
    public GameObject UiCanvasRestart;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LoseTxt;

    [Header("Other")] 
    public ScoreScript scoreScript;
    public PuckScript puckScript;
    public PlayerMovement playerMovement;
    public AiScript aiScript;
    

    public void ShowRestartCanvas(bool aiWon)
    {
        Time.timeScale = 0;
        UiCanvasGame.SetActive(false);
        UiCanvasRestart.SetActive(true);

        if (aiWon)
        {
            WinTxt.SetActive(false);
            LoseTxt.SetActive(true);
        }
        else
        {
            WinTxt.SetActive(true);
            LoseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        
        UiCanvasGame.SetActive(true);
        UiCanvasRestart.SetActive(false);
        
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPostion();
        aiScript.ResetPostion();
        
    }
    
    
}
