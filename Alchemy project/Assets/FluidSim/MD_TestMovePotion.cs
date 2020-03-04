using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_TestMovePotion : MonoBehaviour
{
    private Rigidbody pRB;
    // Start is called before the first frame update
    public Renderer FillMaterial, potFillMat;
    private float Value = 0.9f, v2 = 0.64f;  //-0.1
    public GameObject pEfect;

    private bool liqSpill;

    

    void Awake()
    {
        pEfect.SetActive(false);
        pRB = GetComponent<Rigidbody>();
        FillMaterial = GetComponent<Renderer>();
        potFillMat = GameObject.Find("PotFill").GetComponent<Renderer>();
        FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
        potFillMat.sharedMaterial.SetFloat("_FillAmount", v2);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.X) && Value > -0.1f )
        {
            Value -= 0.01f;
            FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
           // print("Up");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            liqSpill = true;
            pEfect.SetActive(true);
        }

        if (liqSpill && v2 > 0.38f)
        {
            v2 -= 0.003f;
            Value += 0.003f;
            FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
            potFillMat.sharedMaterial.SetFloat("_FillAmount", v2);
        }

        if(v2 <= 0.38f )
            pEfect.SetActive(false);

        if (Input.GetKeyDown(KeyCode.C)) //reset
        {
            Value = 0.9f;
            v2 = 0.64f;
            FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
            potFillMat.sharedMaterial.SetFloat("_FillAmount", v2);
            liqSpill = false ;
        }

        //if (pEfect.active)
        //{
        //    Value -= 0.005f;
        //    FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
        //    print("Down");
        //}


        //if (Value <= 0.3f)
        //{
        //    pEfect.SetActive(false);
        //}
        //else if (Value > 0.3f && Input.GetKeyDown(KeyCode.Z))
        //{
        //    pEfect.SetActive(true);

        //}
    }


    //if (Input.GetKeyDown(KeyCode.W))
    //{
    //    print("Throwing Pot up");
    //    pRB.AddForce(Vector3.up * 250);
    //    gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + 5);
    //}
    //if (Input.GetKeyDown(KeyCode.A))
    //{
    //    print("Throwing Pot up");
    //    pRB.AddForce(Vector3.left * 150);
    //}
    //if (Input.GetKeyDown(KeyCode.D))
    //{
    //    print("Throwing Pot up");
    //    pRB.AddForce(Vector3.right * 150);
    //}
}
