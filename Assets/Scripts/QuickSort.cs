using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSort : MonoBehaviour
{
    bool inPass2 = false, Pass1 = true, done = true, id = false, kd = false, left = false;
    int piv = 1, i, k = 1, Mi = 1, Ma = 1, M = 1;
    Color blue, green, white;
    Rem r;
    Image b1, b2, t1, t2, t3;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        blue = new Color32(0, 40, 255, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        Pass1 = true;
        done = true;
        id = false;
        kd = false;
        left = false;
        r = new Rem();
        piv = 1;
        k = 1;
        Mi = 1;
        Ma = 1;
        M = 1;
        i = SetTheBar.b.GetCount();
    }
    public void Alg()
    {
        if (done && Sorting.done)
        {
            if (left && r.Count() > 0)
            {
                Mi = r.GetA(r.Count() - 1);
                Ma = r.GetB(r.Count() - 1);
                M = Mi;
                r.Remove(r.Count() - 1);
                left = false;
            }
            else if(left && r.Count() == 0)
            {
                Sorting.Sorted = true;
            }
            else
            {
                Mi = M;
                Ma = i;
            }
            done = false;
        }
        else
        {
            if ((Ma - Mi >= 1) || !Sorting.done)
            {
                Alg2(Mi, Ma);
            }
            else
            {
                left = true;
                done = true;
            }
        }
    }
    public void Alg2(int Min, int Max)
    {
        if (Sorting.done && !done)
        {
            if (Max - Min == 1)
            {
                if (SetTheBar.b.GetImg(Min).rectTransform.sizeDelta.y > SetTheBar.b.GetImg(Max).rectTransform.sizeDelta.y)
                {
                    b1 = SetTheBar.b.GetImg(Min);
                    b2 = SetTheBar.b.GetImg(Max);
                    int tempInd = SetTheBar.b.GetInd(b1);
                    SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                    SetTheBar.b.SetInd(b2, tempInd);
                    transform.GetComponent<Sorting>().Swap(b1, b2);
                }
                left = true;
                done = true;
            }
            else
            {
                if (Pass1)
                {
                    done = false;
                    piv = Min + (Max - Min) / 2;
                    b1 = SetTheBar.b.GetImg(piv);
                    b2 = SetTheBar.b.GetImg(Max);
                    t1 = b1;
                    piv = Max;
                    int tempInd = SetTheBar.b.GetInd(b1);
                    SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                    SetTheBar.b.SetInd(b2, tempInd);
                    transform.GetComponent<Sorting>().Swap(b1, b2);
                    Pass1 = false;
                    inPass2 = true;
                }
                else
                {
                    t1.color = blue;
                    if (inPass2)
                    {
                        i = Min;
                        k = piv - 1;
                        b1 = SetTheBar.b.GetImg(i);
                        b2 = SetTheBar.b.GetImg(k);
                        id = false;
                        kd = false;
                        inPass2 = false;
                    }
                    if (i < piv && k >= Min && (!id || !kd))
                    {
                        if (SetTheBar.b.GetImg(i).rectTransform.sizeDelta.y > SetTheBar.b.GetImg(piv).rectTransform.sizeDelta.y && !id)
                        {
                            b1 = SetTheBar.b.GetImg(i);
                            id = true;
                        }
                        if (SetTheBar.b.GetImg(k).rectTransform.sizeDelta.y < SetTheBar.b.GetImg(piv).rectTransform.sizeDelta.y && !kd)
                        {
                            b2 = SetTheBar.b.GetImg(k);
                            kd = true;
                        }
                        if (!id)
                        {
                            i++;
                        }
                        if (!kd)
                        {
                            k--;
                        }
                        if (t2 != null && t3 != null)
                        {
                            t2.color = white;
                            t3.color = white;
                        }
                        if (SetTheBar.b.GetImg(i) != null && SetTheBar.b.GetImg(k) != null)
                        {
                            SetTheBar.b.GetImg(i).color = green;
                            SetTheBar.b.GetImg(k).color = green;
                            t2 = SetTheBar.b.GetImg(i);
                            t3 = SetTheBar.b.GetImg(k);
                        }
                    }
                    else
                    {
                        if (i >= k)
                        {
                            b1 = SetTheBar.b.GetImg(i);
                            b2 = SetTheBar.b.GetImg(piv);
                            if (Max - (i + 1) > 0)
                            {
                                r.AddRem(i + 1, Max);
                            }
                            i--;
                            done = true;
                            Pass1 = true;
                        }
                        if (t2 != null && t3 != null)
                        {
                            t2.color = white;
                            t3.color = white;
                        }
                        int tempInd = SetTheBar.b.GetInd(b1);
                        SetTheBar.b.SetInd(b1, SetTheBar.b.GetInd(b2));
                        SetTheBar.b.SetInd(b2, tempInd);
                        transform.GetComponent<Sorting>().Swap(b1, b2);
                    }
                }
            }
        }
        else if(!Sorting.done)
        {
            transform.GetComponent<Sorting>().Swap(b1, b2);
            if(Sorting.done && !Pass1)
            {
                inPass2 = true;
            }
        }
    }
}


class Rem
{
    int a, b;
    List<Rem> re = new List<Rem>();
    public Rem()
    {
    }
    public Rem(int A, int B)
    {
        a = A;
        b = B;
    }
    public void AddRem(int a, int b)
    {
        re.Add(new Rem(a, b));
    }
    public void Remove(int i)
    {
        re.Remove(re[i]);
    }
    public int Diff(int i)
    {
        return Mathf.Abs(re[i].a - re[i].b);
    }
    public int GetA(int i)
    {
        return re[i].a;
    }
    public int GetB(int i)
    {
        return re[i].b;
    }
    public int Count()
    {
        return re.Count;
    }
}