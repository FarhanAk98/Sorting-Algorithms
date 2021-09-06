using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSort : MonoBehaviour
{
    int k = 1, i;
    float MinH = 800f;
    Color green, blue, white;
    Image b1, b2, tempGreen;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        blue = new Color32(0, 40, 255, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        k = 1;
        i = k + 1;
        b1 = SetTheBar.b.GetImg(k);
        b2 = SetTheBar.b.GetImg(k);
        tempGreen = b2;
        MinH = b1.rectTransform.sizeDelta.y;
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            b1.color = blue;
            if (i <= SetTheBar.b.GetCount())
            {
                if(tempGreen != b1 && tempGreen != b2)
                {
                    tempGreen.color = white;
                }
                tempGreen = SetTheBar.b.GetImg(i);
                SetTheBar.b.GetImg(i).color = green;
                if (MinH > SetTheBar.b.GetImg(i).rectTransform.sizeDelta.y)
                {
                    b2.color = white;
                    b2 = SetTheBar.b.GetImg(i);
                    b2.color = blue;
                    MinH = b2.rectTransform.sizeDelta.y;
                }
                i++;
            }
            else
            {
                tempGreen.color = white;
                if (b1 == b2)
                {
                    b1.color = white;
                    b2.color = white;
                    k++;
                    i = k + 1;
                    b1 = SetTheBar.b.GetImg(k);
                    b2 = SetTheBar.b.GetImg(k);
                    MinH = b1.rectTransform.sizeDelta.y;
                    if (k == SetTheBar.b.GetCount())
                    {
                        Sorting.Sorted = true;
                    }
                }
                else
                {
                    tempGreen.color = white;
                    b1.color = white;
                    b2.color = white;
                    int tempInd = SetTheBar.b.GetInd(b1);
                    SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                    SetTheBar.b.SetInd(b2, tempInd);
                    transform.GetComponent<Sorting>().Swap(b1, b2);
                }
            }
        }
        else
        {
            transform.GetComponent<Sorting>().Swap(b1, b2);
            if (Sorting.done)
            {
                k++;
                i = k + 1;
                b1 = SetTheBar.b.GetImg(k);
                b2 = SetTheBar.b.GetImg(k);
                MinH = b1.rectTransform.sizeDelta.y;
                if (k == SetTheBar.b.GetCount())
                {
                    Sorting.Sorted = true;
                }
            }
        }
    }
}
