using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Vector3 targetScale = new Vector3(1f, 1f, 1f);
    public Button growButton;
    public Button shrinkButton;
    public Button stopButton;
    // Update is called once per frame
    private bool isGrowPressed = false;
    private bool isShrinkPressed = false;
    private float localMultiplier = 0.1f;

    //Player controller 
    public float objSpeed = 1.0f;        // Movement speed
    public float jumpForce = 5.0f;    // Jumping force
    private bool isJumping = false;   // Track if player is currently jumping
    private Rigidbody rb;

    void Start()
    {
        growButton.onClick.AddListener(grow);
        shrinkButton.onClick.AddListener(shrink);
        stopButton.onClick.AddListener(stop);

        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        isJumping = false;
        MovePlayer();

        // Jump when space is pressed and the player is not already jumping
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }


    private void grow()
    {
        if (!isGrowPressed) // only do stuff if the button is freshly pressed
        {
            transform.localScale += (targetScale * localMultiplier);
            Debug.Log("Object " + gameObject.name +"'s size +.");
            isGrowPressed = true;
        }

        else // if isGrowPressed is true
            isGrowPressed = false;
    }

    private void shrink()
    {
        if (!isShrinkPressed) // only do stuff if the button is freshly pressed
        {
            transform.localScale -= (targetScale * localMultiplier);
            Debug.Log("Object " + gameObject.name +"'s size -.");
            isShrinkPressed = true;
        }
        else 
            isShrinkPressed = false;
    }


    private void stop()
    {
        rb.velocity = Vector3.zero;
    }


    // Destroy object if in contact with lava
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            Destroy(gameObject);
            Debug.Log("Object " + gameObject.name +" is destroyed on contact with lava.");
        }

        
    }


    private void MovePlayer()
    {   
        // since camera is fixed to look from the east
        float horizontal = -Input.GetAxis("Vertical");   // W / S / Up Arrow or Down Arrow
        float vertical = Input.GetAxis("Horizontal");       // A / D / left arrow / right arrow

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * objSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

}
