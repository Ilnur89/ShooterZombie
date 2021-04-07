using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_motor : MonoBehaviour
{
    [SerializeField]
    Camera cam;


    Vector3 velocity = Vector3.zero;
    Vector3 rotateAr = Vector3.zero;
    Vector3 camRotate = Vector3.zero;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    //Gets movement 
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Gets Rotation
    public void Rotate(Vector3 _rotate)
    {
        rotateAr = _rotate;
    }

    //Gets camera rotation
    public void RotateCamera(Vector3 _camerarot)
    {
        camRotate=_camerarot;
    }

    private void FixedUpdate()
    {
        PerformMove();
        PerformRotate();
    }

    //Perform move
    void PerformMove()
    {
        if (velocity!=Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Perform rotate
    void PerformRotate()
    {
        //rb.rotation = Quaternion.Euler(rotateAr);
       
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateAr));
        if (cam != null)
        {
           
          
            cam.transform.Rotate(-camRotate);
        }
    }
}
