using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPotion : MonoBehaviour
{

    public string PotionRequested = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            if (other.name == PotionRequested)
            {
                // Do Stuff
                print("Correct Potion");
                // Do More Stuff
                FindObjectOfType<QuestGiver>().questSelected = false;
            }
            else
            {
                print("WrongePotion");
                FindObjectOfType<QuestGiver>().questSelected = false;
            }
            Destroy(other.gameObject);
            
        }
        else
        {
            print("This isn't a potion");
        }
        
    }
}
