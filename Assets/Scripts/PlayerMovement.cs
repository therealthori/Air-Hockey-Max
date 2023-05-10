using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //All of the fields established to create the code
    private bool objectClicked = true;
    private bool objectMoved;
    
    //Vector2 playerSize;

    private Rigidbody2D rig;
    private Vector2 startingPostion;

    public Transform BoundaryHolder;
    Boundary playerBoundary;

    private Collider2D playerCollider;
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        //playerSize = gameObject.GetComponent<SpriteRenderer>().bounds.extents;
        
        rig = GetComponent<Rigidbody2D>();
        startingPostion = rig.position;
        playerCollider = GetComponent<Collider2D>();
        playerBoundary = new Boundary(BoundaryHolder.GetChild(0).position.y, BoundaryHolder.GetChild(1).position.y,
            BoundaryHolder.GetChild(2).position.x, BoundaryHolder.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()

        //Firstly, I used an If Statement to determine the position of the mouse when being click. Now, the position is determined by a collider using the Vector 2 position
        //     if(Input.GetMouseButton(0))
    // {
    //     Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         
    //     if (objectClicked)
    //     {
    //         objectClicked = false;
    //
    //         if (transform.position.x - playerSize.x <= mousePos.x &&
    //             mousePos.x <= transform.position.x + playerSize.x && 
    //             transform.position.y - playerSize.y <= mousePos.y &&
    //             mousePos.y <= transform.position.y + playerSize.y)
    //         {
    //             objectMoved = true;
    //         }
    //         else
    //         {
    //             objectMoved = false;
    //         }
    //     }
    //
    
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (objectClicked)
            {
                objectClicked = false;

                if (playerCollider.OverlapPoint(mousePos))
                {
                    objectMoved = true;
                }
                else
                {
                    objectMoved = false;
                }

            }

            if (objectMoved)
            {
                Vector2 clampedMousePos =
                    new Vector2(Mathf.Clamp(mousePos.x, playerBoundary.Left, playerBoundary.Right),
                        Mathf.Clamp(mousePos.y, playerBoundary.Down, playerBoundary.Up));
                rig.MovePosition(clampedMousePos);
            }
        }
        else
        {
            objectClicked = true;
        }
    }

    public void ResetPostion()
    {
        rig.position = startingPostion;
    }
} 
