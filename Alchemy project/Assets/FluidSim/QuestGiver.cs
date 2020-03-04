using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private string[] lOfPotion = { "Potion of Love", "Potion of Invisibility", "Potion of Enlargement", "Potion of Lust", "Potion of Polymorph" };
    public bool questSelected;


    void Update()
    {
        SelectQuest();
    }

    private void SelectQuest()
    {
        if (!questSelected)
        {
            questSelected = true;
            FindObjectOfType<CheckPotion>().PotionRequested = lOfPotion[Random.Range(0, lOfPotion.Length)];
            print("We need " + FindObjectOfType<CheckPotion>().PotionRequested);
            //Play animation?
        }

    }

}
