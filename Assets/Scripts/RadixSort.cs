using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadixSort : MonoBehaviour
{
    bool Pass1 = true;
    int k = 1, i, l, dig = 1;
    Color white, blue, green;
    Image b1, b2, t1, t2;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        blue = new Color32(0, 40, 255, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        k = 1;
        dig = 1;
        Pass1 = true;
        i = k + 1;
        l = k;
        b1 = SetTheBar.b.GetImg(i);
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            if (Pass1)
            {
                if (l >= 1 && (int)((SetTheBar.b.GetImg(l).rectTransform.sizeDelta.y % Mathf.Pow(10, dig)) / Mathf.Pow(10, dig - 1)) >
                    (int)((b1.rectTransform.sizeDelta.y % Mathf.Pow(10, dig)) / Mathf.Pow(10, dig - 1)))
                {
                    if (t2 != null)
                    {
                        t2.color = white;
                    }
                    SetTheBar.b.GetImg(l).color = green;
                    t2 = SetTheBar.b.GetImg(l);
                    l--;
                }
                else
                {
                    if (l == k)
                    {
                        k++;
                        if (k == SetTheBar.b.GetCount())
                        {
                            dig++;
                            if (dig > 3)
                            {
                                Sorting.Sorted = true;
                            }
                            else
                            {
                                k = 1;
                                i = k + 1;
                                l = k;
                                b1 = SetTheBar.b.GetImg(i);
                                if (t1 != null)
                                {
                                    t1.color = white;
                                }
                                b1.color = blue;
                                t1 = b1;
                            }
                        }
                        else
                        {
                            i = k + 1;
                            l = k;
                            b1 = SetTheBar.b.GetImg(i);
                            if (t1 != null)
                            {
                                t1.color = white;
                            }
                            b1.color = blue;
                            t1 = b1;
                        }
                    }
                    else
                    {
                        l++;
                        Pass1 = false;
                    }
                }
            }
            else
            {
                if (i - 1 >= l)
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
                    if (k == SetTheBar.b.GetCount())
                    {
                        dig++;
                        if (dig > 3)
                        {
                            Sorting.Sorted = true;
                        }
                        else
                        {
                            k = 1;
                            i = k + 1;
                            l = k;
                            b1 = SetTheBar.b.GetImg(i);
                            if (t1 != null)
                            {
                                t1.color = white;
                            }
                            b1.color = blue;
                            t1 = b1;
                        }
                    }
                    else
                    {
                        i = k + 1;
                        l = k;
                        b1 = SetTheBar.b.GetImg(i);
                        if (t1 != null)
                        {
                            t1.color = white;
                        }
                        b1.color = blue;
                        t1 = b1;
                    }
                    Pass1 = true;
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
