using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float leftRightSpeed = 4;
    public static bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    public float xSpeed = 10f;
    public float[] allowedPositions = { -2f, 0f, 2f }; // adjust this to set the allowed x positions

    private bool movingX = false;

    private float constant = (1f / Mathf.Sqrt(10));
    private float bonusSpeed = 0;


    
    void Start()
    {
        moveSpeed = 6f;
        leftRightSpeed = 4;
        canMove = false;
        isJumping = false;
        comingDown = false;
    }

    void Update()
    {

        bonusSpeed = constant * Mathf.Sqrt(LevelDistance.disRun) + 1f;
        
        if (canMove) //canMove
        {

            float inputX = Input.GetAxisRaw("Horizontal");
            
            if (inputX != 0 && !movingX)
            {
                movingX = true;
                float xPos = transform.position.x + inputX * 1.5f;
                xPos = Mathf.Clamp(xPos, -1.5f, 1.5f);
                
                Vector3 targetPosition = new Vector3(xPos, transform.position.y, transform.position.z);

                transform.position = targetPosition;
                StartCoroutine(delayXPlayerMovement());
                ////StartCoroutine(movePlayerSmoothly(targetPosition));
                
            }

            float inputY = Input.GetAxisRaw("Vertical");
            
            if (inputY == 1)
            {
                if (!isJumping)
                {
                    isJumping = true;
                    transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
                    StartCoroutine(delayYPlayerMovement());
                }
            }
            if (inputY == -1)
            {
                if (isJumping)
                {
                    StopCoroutine(delayYPlayerMovement());
                    transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
                    isJumping = false;
                }
            }
        }
        transform.Translate(Vector3.forward * Time.deltaTime * (moveSpeed + bonusSpeed), Space.World);
    }

    IEnumerator delayYPlayerMovement()
    {
        playerObject.GetComponent<Animator>().CrossFade("Jump", 0.1f);

        yield return new WaitForSeconds(0.5f);

        transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
        playerObject.GetComponent<Animator>().CrossFade("Standard Run", 0.1f);
        isJumping = false;
    }

    IEnumerator jumpSequence()
    {
        yield return new WaitForSeconds(0.35f);
        comingDown = true;
        yield return new WaitForSeconds(0.35f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().CrossFade("Standard Run", 0.1f);
    }

    IEnumerator delayXPlayerMovement()
    {
        yield return new WaitForSeconds(0.1f);
        movingX = false;
    }

    IEnumerator movePlayerSmoothly(Vector3 targetPosition)
    {
        while (transform.position.x != targetPosition.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, xSpeed * Time.deltaTime);
            
            yield return null;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * xSpeed, Space.World);
        Debug.Log("End coroutine");
        movingX = false;
    }

}
