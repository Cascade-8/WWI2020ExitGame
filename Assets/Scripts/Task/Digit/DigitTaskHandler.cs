using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DigitTaskHandler : MonoBehaviour
{
    public GameObject digitAreas;
    public GameObject InputAres;

    public string[] digitStrings;
    // Start is called before the first frame update
    void Start()
    {
        digitStrings = new string[4];
        CreateBinaryCode();
    }
    public void CreateBinaryCode()
    {
        // string.PadLeft(8,'0');
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            int randomValue = random.Next(65, 90);
            digitStrings[i] = Convert.ToString(randomValue, 2);
        }

        FormatDigits();
    }

    private void FormatDigits()
    {
        for (int i = 0; i < 4; i++)
        {
            char[] temp = digitStrings[i].ToCharArray();
            digitStrings[i] = temp[0]+"";
            for (int j = 1; j < 7; j++)
            {
                digitStrings[i] = digitStrings[i] + "  " + temp[j];
            }
        }

        loadStringsToArea();
    }
    private void loadStringsToArea()
    {
        for (int i = 0; i < 4; i++)
        {
            digitAreas.transform.GetChild(i).GetComponent<Text>().text = digitStrings[i];
        }
    }
}
