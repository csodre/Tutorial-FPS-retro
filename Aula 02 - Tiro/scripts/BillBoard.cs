using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private SpriteRenderer theSpr;
    void Start()
    {
        theSpr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerScript.instanciar.transform.position,-Vector3.forward);
    }
}
