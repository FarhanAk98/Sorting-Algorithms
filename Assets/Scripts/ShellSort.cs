using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShellSort : MonoBehaviour
{
    int k = 1, i, l, N;
    Color white, green;
    Image b1, b2, t1, t2;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        N = SetTheBar.b.GetCount() / 2;
        k = N;
        i = k;
        l = k;
    }
    public void Alg()
    {
        if (Sorting.done)
        {
            b1 = SetTheBar.b.GetImg(l);
            int tempInd = SetTheBar.b.GetInd(b1);
            if (i >= N)
            {
                i = i - N + 1;
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
                if (b1.rectTransform.sizeDelta.y < b2.rectTransform.sizeDelta.y)
                {
                    SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                    SetTheBar.b.SetInd(b2, tempInd);
                    transform.GetComponent<Sorting>().Swap(b1, b2);
                }
                l = i;
            }
            else
            {
                k++;
                i = k;
                l = k;
                if(k > SetTheBar.b.GetCount())
                {
                    if (N <= 2)
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
                        if (N == 3)
                        {
                            N--;
                        }
                        else
                        {
                            N /= 2;
                        }
                        k = N;
                        i = k;
                        l = k;
                    }
                }
            }
        }
        else
        {
            transform.GetComponent<Sorting>().Swap(b1, b2);
        }
    }
}
