using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSensivity = 100f;
    public Transform playerbody;
    float xrot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Xmouse = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float Ymouse = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xrot -= Ymouse;
        xrot = Mathf.Clamp(xrot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);
        playerbody.Rotate(Vector3.up * Xmouse);

    }
}
