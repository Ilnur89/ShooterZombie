using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player_motor))]
public class Player_controller : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float looksaround = 3f;
    [SerializeField]
    private float lookCamera = 3f;

    Player_motor motor;
    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<Player_motor>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Calkulate velocity
        float xmov = Input.GetAxisRaw("Horizontal");
        float zmov = Input.GetAxisRaw("Vertical");
        Vector3 movegorizontal = transform.right * xmov;
        Vector3 movevertical = transform.forward * zmov;

        //Final movement vector
        Vector3 velosity = (movegorizontal + movevertical).normalized * speed;
        //Aply rotate
        motor.Move(velosity);

        //Calckulate rotation
        float ymov = Input.GetAxisRaw("Mouse X");
        
        Vector3 rotate = new Vector3(0f, ymov, 0f) * looksaround;

        //Aply Rotate
        motor.Rotate(rotate);

        //Calkulate camera rotation
        float xMov= Input.GetAxisRaw("Mouse Y");
        xMov = Mathf.Clamp(xMov, -90, 90);
        Vector3 rotatecamera = new Vector3(xMov,0f, 0f) * lookCamera;
        
        //Aply CameraRotate
        motor.RotateCamera(rotatecamera);
    }
}
