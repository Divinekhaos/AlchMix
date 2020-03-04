using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItems : MonoBehaviour
{
    //this script should be attached to all ingredients
    private Transform objStart;

    void Start()
    {
        objStart = transform;
    }


    //This needs to be called where the couldren detects(trigger/collision) of object & on floor trigger/collision enter
    public void ResetItem()
    {
        gameObject.transform.position = objStart.position;
        gameObject.transform.rotation = objStart.rotation;
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
