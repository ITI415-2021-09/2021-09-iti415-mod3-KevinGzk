using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cam;
    public Rigidbody rb;
    public Vector3 movement;
    public float movingSpeed = 10f;
    public bool movingUp = false;
    public bool movingDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    
    void Update()
    {
        float a = 0;
        if(Input.GetButton("Jump"))
        {
            movingUp = true;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            movingDown = true;
        }
        else
        {
            movingUp = false;
            movingDown = false;
        }
        if(movingUp == true){
            a += Time.deltaTime * 100;
        }
        if(movingDown == true)
        {
            a -= Time.deltaTime * 100;
        }
        movement.x = Input.GetAxisRaw("Horizontal") * -1;
        movement.z = Input.GetAxisRaw("Vertical") * -1;
        movement.y = a;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movingSpeed * Time.fixedDeltaTime);
    }
}
