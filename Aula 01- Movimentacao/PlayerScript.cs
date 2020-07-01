using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D theRG;
    public float moveSpeed = 5.0f;
    private Vector2 moveInput;
    private Vector2 mouseInput;
    public float mouseSensitivity = 1.0f;
    public Transform camView;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //Movimentação do Player
       moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        Vector3 moveVertical = transform.right * moveInput.y;
        
        theRG.velocity = (moveHorizontal+moveVertical) * moveSpeed;

        //Movimentação da Camera
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"))*mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.y,transform.eulerAngles.z-mouseInput.x);
        camView.localRotation = Quaternion.Euler(camView.localRotation.eulerAngles+ new Vector3(0,mouseInput.y,0));
        
    }


}

