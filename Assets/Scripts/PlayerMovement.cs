using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f; //Controls velocity multiplier
    public float jumpStrength = 5.0f; //Controls velocity multiplier
    public float floatStrength = 2.0f;
    
    Rigidbody rb; //Tells script there is a rigidbody, we can use variable rb to reference it in further script
    private Vector3 speedV = new Vector3();
    private bool isWalking = false;
    private float hitDistance = 0.0f;
    private bool onGround = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
    }


    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * speed; // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical") * speed; // w key changes value to 1, s key changes value to -1
        float yMove = Input.GetButtonDown("Jump") ? speed : 0f;

        var speedVector = new Vector3(xMove, rb.velocity.y, zMove); // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 
        
        if (Physics.Raycast(transform.position, Vector3.down, out var hit))
        {                
            hitDistance = hit.distance;
            if (hit.distance > 1.5f) 
            {
                // You are falling or at least x units above something.
                onGround = false;
            } else 
            {
                // You are not x units above something.
                onGround = true;
            }
        }

        if (onGround && Input.GetButtonDown("Jump"))
        {
            speedVector.y = jumpStrength;
        }
        
        // Character is trying to move while on the ground
        if ((speedVector.x != 0f || speedVector.z != 0f) && speedVector.y == 0f) 
        {
            speedVector.y = (yMove == 0f) ? floatStrength : yMove;
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        speedV = speedVector;
        rb.velocity = speedVector;
    }
}