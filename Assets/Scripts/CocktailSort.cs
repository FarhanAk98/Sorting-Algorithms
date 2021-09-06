using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CocktailSort : MonoBehaviour
{
    bool bubblesLeft = false;
    int k = 1, l = 1;
    Color white, green;
    Image b1, b2, t1, t2;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        k = 1;
        l = 1;
        bubblesLeft = false;
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            int i = k + l;
            if (l > 0)
            {
                b1 = SetTheBar.b.GetImg(k);
                b2 = SetTheBar.b.GetImg(i);
            }
            else
            {
                b2 = SetTheBar.b.GetImg(k);
                b1 = SetTheBar.b.GetImg(i);
            }
            if (t1 != null && t2 != null)
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
                k += l;
                if (k + l > SetTheBar.b.GetCount() || k + l == 0)
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
                        l *= -1;
                        if (l > 0)
                        {
                            k = 1;
                        }
                        else
                        {
                            k = SetTheBar.b.GetCount() - 1;
                        }
                    }
                }
            }
        }
        else
        {
            transform.GetComponent<Sorting>().Swap(b1, b2);
            if (Sorting.done)
            {
                k += l;
                if (k + l > SetTheBar.b.GetCount() || k + l == 0)
                {
                    if (!bubblesLeft)
                    {
                        Sorting.Sorted = true;
                    }
                    else
                    {
                        bubblesLeft = false;
                        l *= -1;
                        if (l > 0)
                        {
                            k = 1;
                        }
                        else
                        {
                            k = SetTheBar.b.GetCount() - 1;
                        }
                    }
                }
            }
        }
    }
}
