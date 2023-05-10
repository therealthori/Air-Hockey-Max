using UnityEngine;

public class AiScript : MonoBehaviour
{
    public float MaxMovementSpeed;
    private Rigidbody2D rig;
    private Vector2 startingPosition;
    

    public Rigidbody2D Puck;

    public Transform PlayerBoundaryHolder;
    private Boundary playerBoundary;
    
    public Transform PuckBoundaryHolder;
    private Boundary puckBoundary;

    private Vector2 targetPosition;
    
    private bool inOpponentHalf;
    private float offsetYFromTarget;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        startingPosition = rig.position;
        
        playerBoundary = new Boundary(PlayerBoundaryHolder.GetChild(0).position.y, PlayerBoundaryHolder.GetChild(1).position.y,
            PlayerBoundaryHolder.GetChild(2).position.x, PlayerBoundaryHolder.GetChild(3).position.x);
        
        puckBoundary = new Boundary(PuckBoundaryHolder.GetChild(0).position.y, PuckBoundaryHolder.GetChild(1).position.y,
            PuckBoundaryHolder.GetChild(2).position.x, PuckBoundaryHolder.GetChild(3).position.x);
    }

    private void FixedUpdate()
    {
        if (!PuckScript.isGolazo)
        {
            float movementSpeed;
            
            if (Puck.position.y < puckBoundary.Down)
            {
                if (inOpponentHalf)
                {
                    inOpponentHalf = false;
                    offsetYFromTarget = Random.Range(-1f, 1f);
                }
                
                movementSpeed = MaxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x + offsetYFromTarget, playerBoundary.Left, playerBoundary.Right),
                    startingPosition.y);
            }
            else
            {
                movementSpeed = Random.Range(MaxMovementSpeed * 0.4f, MaxMovementSpeed);
                targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, playerBoundary.Left, playerBoundary.Right),
                    Mathf.Clamp(Puck.position.y, playerBoundary.Down, playerBoundary.Up));
            }

            rig.MovePosition(Vector2.MoveTowards(rig.position, targetPosition, movementSpeed * Time.fixedDeltaTime));

        }
    }
    
    public void ResetPostion()
    {
        rig.position = startingPosition;
    }
}
