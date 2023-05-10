using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool isGolazo { get; private set; }
    private Rigidbody2D rig;

    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        isGolazo = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isGolazo)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                isGolazo = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                isGolazo = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private IEnumerator ResetPuck(bool aiGolazo)
    {
        yield return new WaitForSecondsRealtime(1);
        isGolazo = false;
        rig.velocity = rig.position = new Vector2(0, 0);
        if (aiGolazo)
            rig.position = new Vector2(-1, 0);
        else
            rig.position = new Vector2(1, 0);
    }

    public void CenterPuck()
    {
        rig.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rig.velocity = Vector2.ClampMagnitude(rig.velocity, maxSpeed);
    }
}

