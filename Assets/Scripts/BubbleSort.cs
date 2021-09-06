using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSort : MonoBehaviour
{
    bool bubblesLeft = false;
    Color white, green;
    int k = 1;
    Image b1, b2, t1, t2;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        k = 1;
        bubblesLeft = false;
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            int i = k + 1;
            b1 = SetTheBar.b.GetImg(k);
            b2 = SetTheBar.b.GetImg(i);
            if(t1 != null && t2 != null)
            {
                t1.color = white;
                t2.color = white;
            }
            b1.color = green;
            b2.color = green;
            t1 = b1;
            t2 = b2;
            int tempInd = SetTheBar.b.GetInd(b1);
            if (b2.rectTransform.sizeDelta.y < b1.rectTransform.sizeDelta.y)
            {
                bubblesLeft = true;
                SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                SetTheBar.b.SetInd(b2, tempInd);
                transform.GetComponent<Sorting>().Swap(b1, b2);
            }
            else
            {
                if (k + 1 == SetTheBar.b.GetCount())
                {
                    if (!bubblesLeft)
                    {
                        if (t1 != null && t2 != null)
                        {
                            t1.color = white;
                            t2.color = white;
                        }
                        Sorting.Sorted = true;
                    }
                    else
                    {
                        bubblesLeft = false;
                        k = 1;
                    }
                }
                else
                {
                    k++;
                }
            }
        }
        else
        {
            transform.GetComponent<Sorting>().Swap(b1, b2);
            if (Sorting.done)
            {
                if (k + 1 == SetTheBar.b.GetCount())
                {
                    if (!bubblesLeft)
                    {
                        Sorting.Sorted = true;
                    }
                    else
                    {
                        bubblesLeft = false;
                        k = 1;
                    }
                }
                else
                {
                    k++;
                }
            }
        }
    }
}
