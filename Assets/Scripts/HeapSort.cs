using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeapSort : MonoBehaviour
{
    bool Pass1 = true, Pass2 = false, MaxDone = true, Started = false, Sorted = false;
    int l = -1, r = -1, I = 10;
    Color white, green, blue;
    heap h = new heap();
    Image b1, b2, t2;
    void Start()
    {
        white = new Color32(202, 202, 202, 255);
        blue = new Color32(0, 40, 255, 255);
        green = new Color32(0, 255, 0, 255);
    }
    void OnEnable()
    {
        Pass1 = true;
        Pass2 = false;
        MaxDone = true;
        Started = false;
        Sorted = false;
        h = new heap();
        for (int i = 1; i <= SetTheBar.b.GetCount(); i++)
        {
            l = -1;
            r = -1;
            if(i * 2 <= SetTheBar.b.GetCount())
            {
                l = i * 2;
            }
            if (i * 2 + 1 <= SetTheBar.b.GetCount())
            {
                r = i * 2 + 1;
            }
            h.Add(i, l, r);
        }
        I = h.Count();
        Started = true;
    }
    public void Alg()
    {
        if (Started)
        {
            if (Sorting.done && !Sorted)
            {
                if (Pass1 && I > 0 && h.Count() > 2)
                {
                    b1 = SetTheBar.b.GetImg(h.GetP(I));
                    b2 = b1;
                    if (h.GetL(I) > 0 && h.GetR(I) > 0 && (b1.rectTransform.sizeDelta.y < SetTheBar.b.GetImg(h.GetL(I)).rectTransform.sizeDelta.y ||
                        b1.rectTransform.sizeDelta.y < SetTheBar.b.GetImg(h.GetR(I)).rectTransform.sizeDelta.y))
                    {
                        if (SetTheBar.b.GetImg(h.GetR(I)).rectTransform.sizeDelta.y < SetTheBar.b.GetImg(h.GetL(I)).rectTransform.sizeDelta.y)
                        {
                            b2 = SetTheBar.b.GetImg(h.GetL(I));
                            h.SwapPL(I);
                        }
                        else
                        {
                            b2 = SetTheBar.b.GetImg(h.GetR(I));
                            h.SwapPR(I);
                        }
                        MaxDone = false;
                        transform.GetComponent<Sorting>().Swap(b1, b2);
                    }
                    I--;
                    if (Sorting.done && I <= 0)
                    {
                        if (!MaxDone)
                        {
                            I = h.Count();
                            MaxDone = true;
                        }
                        else
                        {
                            Pass1 = false;
                        }
                    }
                }
                else if (h.Count() == 2)
                {
                    b1 = SetTheBar.b.GetImg(h.GetP(h.Count()));
                    b2 = SetTheBar.b.GetImg(h.GetP(1));
                    if(b2.rectTransform.sizeDelta.y > b1.rectTransform.sizeDelta.y)
                    {
                        transform.GetComponent<Sorting>().Swap(b1, b2);
                        Sorted = true;
                    }
                    else
                    {
                        Sorting.Sorted = true;
                    }
                }
                else if(h.Count() > 2)
                {
                    b1 = SetTheBar.b.GetImg(h.GetP(h.Count()));
                    b2 = SetTheBar.b.GetImg(h.GetP(1));
                    h.SwapPP(1, h.Count());
                    transform.GetComponent<Sorting>().Swap(b1, b2);
                    h.Remove(h.Count());
                    Pass2 = true;
                }
                if(t2 != null)
                {
                    t2.color = white;
                }
                b2.color = green;
                t2 = b2;
            }
            else
            {
                transform.GetComponent<Sorting>().Swap(b1, b2);
                if (Sorting.done && I <= 0)
                {
                    if (!MaxDone && Pass1)
                    {
                        I = h.Count();
                        MaxDone = true;
                    }
                    else if (Pass2 && !Pass1)
                    {
                        Pass1 = true;
                        Pass2 = false;
                        I = h.Count();
                    }
                    else
                    {
                        Pass1 = false;
                    }
                }
                else if(Sorting.done && Sorted)
                {
                    Sorting.Sorted = true;
                }
            }
        }
    }
    class heap
    {
        int P, l, r;
        List<heap> he = new List<heap>();
        public heap()
        {
        }
        public heap(int P, int l, int r)
        {
            this.P = P;
            this.l = l;
            this.r = r;
        }
        public void Add(int P, int l, int r)
        {
            he.Add(new heap(P, l, r));
        }
        public void Remove(int i)
        {
            for(int n = 0; n < he.Count; n++)
            {
                if (he[n].l == he[i - 1].P)
                {
                    he[n].l = -1;
                    break;
                }
                else if (he[n].r == he[i - 1].P)
                {
                    he[n].r = -1;
                    break;
                }
            }
            he.Remove(he[i - 1]);
        }
        public int GetL(int i)
        {
            return he[i - 1].l;
        }
        public int GetR(int i)
        {
            return he[i - 1].r;
        }
        public int GetP(int i)
        {
            return he[i - 1].P;
        }
        public int Count()
        {
            return he.Count;
        }
        public void SwapPP(int i, int j)
        {
            for (int n = 0; n < he.Count; n++)
            {
                if (he[n].l == he[j - 1].P)
                {
                    he[n].l = he[i - 1].P;
                }
                else if (he[n].r == he[j - 1].P)
                {
                    he[n].r = he[i - 1].P;
                }
            }
            int t = he[i - 1].P;
            he[i - 1].P = he[j - 1].P;
            he[j - 1].P = t;
        }
        public void SwapPL(int i)
        {
            int t = he[i - 1].P;
            he[i - 1].P = he[i - 1].l;
            he[i - 1].l = t;
            for (int n = 0; n < he.Count; n++)
            {
                if (n < (i - 1))
                {
                    if(he[n].l == t)
                    {
                        he[n].l = he[i - 1].P;
                    }
                    else if(he[n].r == t)
                    {
                        he[n].r = he[i - 1].P;
                    }
                }
                else if (he[n].P == he[i - 1].P && n >= i)
                {
                    he[n].P = t;
                    break;
                }
            }
        }
        public void SwapPR(int i)
        {
            int t = he[i - 1].P;
            he[i - 1].P = he[i - 1].r;
            he[i - 1].r = t;
            for (int n = 0; n < he.Count; n++)
            {
                if (n < (i - 1))
                {
                    if(he[n].l == t)
                    {
                        he[n].l = he[i - 1].P;
                    }
                    else if(he[n].r == t)
                    {
                        he[n].r = he[i - 1].P;
                    }
                }
                else if (he[n].P == he[i - 1].P && n >= i)
                {
                    he[n].P = t;
                    break;
                }
            }
        }
    }
}
