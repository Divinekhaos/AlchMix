using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD_TestMovePotion : MonoBehaviour
{
    private Rigidbody pRB;
    // Start is called before the first frame update
    public Renderer FillMaterial;
    float Value = 0.8f;
    public GameObject pEfect;

    void Start()
    {
        pEfect.SetActive(false);
        pRB = GetComponent<Rigidbody>();
        FillMaterial = GameObject.Find("FillMat").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("Throwing Pot up");
            pRB.AddForce(Vector3.up * 250);
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z + 5);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Throwing Pot up");
            pRB.AddForce(Vector3.left * 150);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("Throwing Pot up");
            pRB.AddForce(Vector3.right * 150);
        }

        if (Input.GetKey(KeyCode.X))
        {
            Value += 0.01f;
            FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
            print("Up");
        }

        if (pEfect.active)
        {
            Value -= 0.005f;
            FillMaterial.sharedMaterial.SetFloat("_FillAmount", Value);
            print("Down");
        }
        

        if (Value <= 0.3f)
        {
            pEfect.SetActive(false);
        }
        else if (Value > 0.3f && Input.GetKeyDown(KeyCode.Z))
        {
            pEfect.SetActive(true);

        }
    }
}
