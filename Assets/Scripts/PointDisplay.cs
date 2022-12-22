using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointDisplay : MonoBehaviour
{
    //PointCounter PointCounter;

    public GameObject pointText;
    public GameObject pointContainer;

    public GameObject pointDisplayText;
    public int totalPoints = 0;

    public int pointNumber;

    void Start()
    {

    }

    void Update()
    {
        pointDisplayText.GetComponent<TextMeshProUGUI>().text = "Points: " + totalPoints;
    }

    public void DisplayPoints(int ringNumber)
    {
        GameObject currentPointDisplay = Instantiate(pointText, pointContainer.transform.position, Quaternion.identity, pointContainer.transform);
        

        TextMeshProUGUI currentPointDisplayText = currentPointDisplay.GetComponent<TextMeshProUGUI>();


        if (ringNumber == 1)
        {
            currentPointDisplayText.color = new Color32(247, 248, 77, 255);
            pointNumber = 5;
        }
        else if (ringNumber == 2)
        {
            currentPointDisplayText.color = new Color32(255, 39, 14, 255);
            pointNumber = 4;
        }
        else if (ringNumber == 3)
        {
            currentPointDisplayText.color = new Color32(55, 174, 193, 255);
            pointNumber = 3;
        }
        else if (ringNumber == 4)
        {
            currentPointDisplayText.color = new Color32(0, 0, 0, 255);
            pointNumber = 2;
        }
        else if (ringNumber == 5)
        {
            currentPointDisplayText.color = new Color32(246, 246, 246, 255);
            pointNumber = 1;
        }

        totalPoints += pointNumber;

        currentPointDisplayText.text = "+" + pointNumber.ToString();
    }
}
