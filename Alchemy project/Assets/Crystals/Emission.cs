using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]

public class Emission : MonoBehaviour
{

    new Renderer renderer;
    Color emissionColor;
    Material material;

    private float Cooking;
    private readonly bool IsCooked = false;

    public GameObject crystalLight;
    private bool emissionOn = false;
    private float rangeAmount;
    private float fluxAmount = 0.001f;
    
   
    

    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        emissionColor = material.GetColor("_EmissionColor");


        crystalLight.GetComponent<Light>().range = 0.12f;
        rangeAmount = crystalLight.GetComponent<Light>().range;

    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))  // Change to on-trigger stay for game
        {
            Cooking += Time.deltaTime;
            print(Cooking);

            if (Cooking >= 10)  
            {
                Activate(true, 1f);
                TurnOnLight();
            }
        }
        else
        {
            Cooking = 0;
        }

        if (emissionOn == true)
        {

            rangeAmount += fluxAmount;

            crystalLight.GetComponent<Light>().range = rangeAmount;

            if (rangeAmount >= 0.16f)
            
                fluxAmount = -fluxAmount; // One way to change positve to negative number (works other way round)
            

            if (rangeAmount <= 0.12f)
            
                fluxAmount  *= -1; // another way to change number from negative to positive.
            
        }
 
    }

    public void TurnOnLight()           //Function for turning on light source on crystals.
    {
        crystalLight.SetActive(true); 
    }
    

    public void Activate(bool on, float intensity)             //Access the Emissive material and enables/disables it.

    {
        if (on)
        {
            emissionOn = true;
            material.EnableKeyword("_EMISSION");
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

            material.SetColor("_EmissionColor", emissionColor * intensity);
        }

        else
        { 
            material.DisableKeyword("_EMISSION");
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

            material.SetColor("_EmissionColor", Color.black);
        }

    }

}
