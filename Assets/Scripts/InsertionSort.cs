using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertionSort : MonoBehaviour
{
    int k = 1, i;
    Image b1, b2;
    void OnEnable()
    {
        k = 2;
        i = k;
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            if(i > 1 && SetTheBar.b.GetImg(i).rectTransform.sizeDelta.y < SetTheBar.b.GetImg(i - 1).rectTransform.sizeDelta.y)
            {
                b1 = SetTheBar.b.GetImg(i);
                b2 = SetTheBar.b.GetImg(i - 1);
                int tempInd = SetTheBar.b.GetInd(b1);
                SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                SetTheBar.b.SetInd(b2, tempInd);
                transform.GetComponent<Sorting>().Swap(b1, b2);
            }
            else
            {
                k++;
                i = k;
                if (k > SetTheBar.b.GetCount())
                {
                    Sorting.Sorted = true;
                }
            }
        }
        else
        {
            transform.GetComponent<Sorting>().Swap(b1, b2);
            if (Sorting.done)
            {
                i--;
            }
        }
    }
}

