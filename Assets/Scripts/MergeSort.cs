using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeSort : MonoBehaviour
{
    int i, j, k, l;
    float MinH;
    Image b1, b2;
    Rem r2;
    void OnEnable()
    {
        r2 = new Rem();
        i = 1;
        j = SetTheBar.b.GetCount();
        AddR(i, j);
        MinH = 800f;
        i = r2.GetA(r2.Count() - 1);
        j = r2.GetB(r2.Count() - 1);
        k = i;
        b1 = SetTheBar.b.GetImg(k);
        b2 = SetTheBar.b.GetImg(k);
        MinH = b1.rectTransform.sizeDelta.y;
        l = k + 1;
    }
    void AddR(int i, int j)
    {
        if (j - i > 2)
        {
            r2.AddRem(i, j);
            if ((j - i + 1) % 2 == 0)
            {
                AddR(i + ((j - i + 1) / 2), j);
            }
            else
            {
                AddR(i + ((j - i + 1) / 2) + 1, j);
            }
            AddR(i, j - ((j - i + 1) / 2));
        }
        else
        {
            r2.AddRem(i, j);
        }
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            if (l <= j)
            {
                if (MinH > SetTheBar.b.GetImg(l).rectTransform.sizeDelta.y)
                {
                    b2 = SetTheBar.b.GetImg(l);
                    MinH = b2.rectTransform.sizeDelta.y;
                }
                l++;
            }
            else
            {
                if (b1 == b2)
                {
                    k++;
                    b1 = SetTheBar.b.GetImg(k);
                    b2 = SetTheBar.b.GetImg(k);
                    MinH = b1.rectTransform.sizeDelta.y;
                    l = k + 1;
                    if (k == j)
                    {
                        r2.Remove(r2.Count() - 1);
                        if (r2.Count() > 0)
                        {
                            i = r2.GetA(r2.Count() - 1);
                            j = r2.GetB(r2.Count() - 1);
                            k = i;
                            b1 = SetTheBar.b.GetImg(k);
                            b2 = SetTheBar.b.GetImg(k);
                            MinH = b1.rectTransform.sizeDelta.y;
                            l = k + 1;
                        }
                        else
                        {
                            Sorting.Sorted = true;
                        }
                    }
                }
                else
                {
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
                b1 = SetTheBar.b.GetImg(k);
                b2 = SetTheBar.b.GetImg(k);
                MinH = b1.rectTransform.sizeDelta.y;
                l = k + 1;
                if (k == j)
                {
                    r2.Remove(r2.Count() - 1);
                    if (r2.Count() > 0)
                    {
                        i = r2.GetA(r2.Count() - 1);
                        j = r2.GetB(r2.Count() - 1);
                        k = i;
                        b1 = SetTheBar.b.GetImg(k);
                        b2 = SetTheBar.b.GetImg(k);
                        MinH = b1.rectTransform.sizeDelta.y;
                        l = k + 1;
                    }
                    else
                    {
                        Sorting.Sorted = true;
                    }
                }
            }
        }
    }
}
