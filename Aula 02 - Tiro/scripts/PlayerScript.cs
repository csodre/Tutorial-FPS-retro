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
    public Camera camView;
    public GameObject bulletImpact;
    public int currentAmmo;
    public static PlayerScript instanciar;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        instanciar = this;
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
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.eulerAngles.z-mouseInput.x);
        camView.transform.localRotation = Quaternion.Euler(camView.transform.localRotation.eulerAngles+ new Vector3(0,mouseInput.y,0));

        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo >0)
            {
                //CRIAR UM PONTO NO CENTRO DA TELA
                Ray ray = camView.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                //CRIAR A LINHA DE COLISAO
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //se colidir
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                }
                else
                {   
                    //Se não
                    Debug.Log("a bagaça nao esta colidindo");
                }
                currentAmmo--;

            }           
           
        }//FIM DO INPUT                                  
       
    }//FIM UPDATE


}

