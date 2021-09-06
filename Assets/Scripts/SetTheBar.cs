using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SetTheBar : MonoBehaviour
{
    public Image img, Knob, Base;
    public GameObject Reset, Exit, V1, V2;
    public TextMeshProUGUI Value;
    [HideInInspector]
    public static Bar b = new Bar();
    List<int> Sizes = new List<int>();
    public TMP_Dropdown dp;
    public Slider sl, s2;
    public static bool StartSorting = false, init = false;
    int numberOfbars = 0;
    bool mid = false, md = false;
    void Start()
    {
        dp.interactable = true;
        sl.interactable = true;
        s2.interactable = false;
        s2.gameObject.SetActive(false);
        V1.gameObject.SetActive(true);
        V2.gameObject.SetActive(true);
        Exit.SetActive(true);
        Reset.SetActive(false);
        float size = 1800f / 460;
        for (int i = 1; i <= 460; i++)
        {
            Sizes.Add((int)((800f / 460) * i));
        }
        for(int i = 0; i < 460; i++)
        {
            int Temp = Sizes[i];
            int RandInd = Random.Range(i, Sizes.Count);
            Sizes[i] = Sizes[RandInd];
            Sizes[RandInd] = Temp;
        }
        for (int i = 1; i <= 460; i++)
        {
            Image bar = Instantiate(img, transform.position, Quaternion.identity);
            bar.transform.SetParent(this.transform);
            if (i == 1)
            {
                bar.rectTransform.position = new Vector3(-900f + size / 2, transform.position.y, transform.position.z);
            }
            else
            {
                bar.rectTransform.position = new Vector3((-900f + size / 2) + size * (i - 1), transform.position.y, transform.position.z);
            }
            bar.rectTransform.sizeDelta = new Vector2(size - (size / 200), Sizes[i - 1]);
            bar.transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2((size - (size / 200)) / 1.5f, Sizes[i - 1] / 1.2f);
            b.Add(bar, i);
        }
        init = true;
        numberOfbars = 460;
        Base.gameObject.SetActive(false);
        this.GetComponent<Sorting>().enabled = false;
    }
    void FixedUpdate()
    {
        Value.rectTransform.position = new Vector3(Knob.rectTransform.position.x, Value.rectTransform.position.y, Value.rectTransform.position.z);
        Value.text = sl.value.ToString();
        if (StartSorting)
        {
            if (!this.GetComponent<Sorting>().enabled)
            {
                this.GetComponent<Sorting>().enabled = true;
            }
            s2.interactable = true;
            s2.gameObject.SetActive(true);
            Reset.SetActive(true);
            Base.gameObject.SetActive(true);
            V1.gameObject.SetActive(false);
            V2.gameObject.SetActive(false);
            Exit.SetActive(false);
            sl.interactable = false;
            dp.gameObject.SetActive(false);
            dp.interactable = false;
        }
        else
        {
            this.GetComponent<Sorting>().enabled = false;
            Base.gameObject.SetActive(false);
            s2.interactable = false;
            s2.gameObject.SetActive(false);
            V1.gameObject.SetActive(true);
            V2.gameObject.SetActive(true);
            Reset.SetActive(false);
            Exit.SetActive(true);
            sl.interactable = true;
            dp.gameObject.SetActive(true);
            dp.interactable = true;
            if (numberOfbars != (int)sl.value && init)
            {
                init = false;
                numberOfbars = (int)sl.value;
                Initialise();
            }
        }
        if (mid && !md)
        {
            for(int i = 1; i <= b.GetCount(); i++)
            {
                b.GetImg(i).rectTransform.pivot = new Vector2(0.5f, 0.5f);
                b.GetImg(i).rectTransform.position = new Vector3(b.GetImg(i).rectTransform.position.x, -50f, b.GetImg(i).rectTransform.position.z);
            }
            md = true;
        }
        else if(!mid && !md)
        {
            for (int i = 1; i <= b.GetCount(); i++)
            {
                b.GetImg(i).rectTransform.pivot = new Vector2(0.5f, 0f);
                b.GetImg(i).rectTransform.position = new Vector3(b.GetImg(i).rectTransform.position.x, -540f, b.GetImg(i).rectTransform.position.z);
            }
            md = true;
        }
    }
    public void Middle()
    {
        if (!mid)
        {
            md = false;
        }
        else
        {
            md = true;
        }
        mid = true;
    }
    public void Bot()
    {
        if (mid)
        {
            md = false;
        }
        else
        {
            md = true;
        }
        mid = false;
    }
    void Initialise()
    {
        md = false;
        this.GetComponent<Sorting>().enabled = false;
        float size = 1800f / numberOfbars;
        Image bar;
        if(numberOfbars > b.GetCount())
        {
            while (b.GetCount() < numberOfbars)
            {
                bar = Instantiate(img, transform.position, Quaternion.identity);
                bar.transform.SetParent(this.transform);
                b.Add(bar, b.GetCount() + 1);
            }
        }
        else if( b.GetCount() > numberOfbars)
        {
            while (b.GetCount() > numberOfbars)
            {
                b.Remove(b.GetCount());
            }
        }
        for (int i = 1; i <= b.GetCount(); i++)
        {
            bar = b.GetImg(i);
            if (i == 1)
            {
                bar.rectTransform.position = new Vector3(-900f + size / 2, b.GetImg(i).rectTransform.position.y, b.GetImg(i).rectTransform.position.z);
            }
            else
            {
                bar.rectTransform.position = new Vector3((-900f + size / 2) + size * (i - 1), b.GetImg(i).rectTransform.position.y, b.GetImg(i).rectTransform.position.z);
            }
            bar.rectTransform.sizeDelta = new Vector2(size - (size / 200), Sizes[i - 1]);
            bar.transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2((size - (size / 200)) / 1.5f, Sizes[i - 1] / 1.2f);
        }
        init = true;
    }
    public void Shuffle()
    {
        md = false;
        for (int i = 0; i < 460; i++)
        {
            int Temp = Sizes[i];
            int RandInd = Random.Range(i, Sizes.Count);
            Sizes[i] = Sizes[RandInd];
            Sizes[RandInd] = Temp;
        }
        b.Clear();
        float size = 1800f / numberOfbars;
        for (int i = 1; i <= numberOfbars; i++)
        {
            Image bar = Instantiate(img, transform.position, Quaternion.identity);
            bar.transform.SetParent(this.transform);
            if (i == 1)
            {
                bar.rectTransform.position = new Vector3(-900f + size / 2, transform.position.y, transform.position.z);
            }
            else
            {
                bar.rectTransform.position = new Vector3((-900f + size / 2) + size * (i - 1), transform.position.y, transform.position.z);
            }
            bar.rectTransform.sizeDelta = new Vector2(size - (size / 200), Sizes[i - 1]);
            bar.transform.GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2((size - (size / 200)) / 1.5f, Sizes[i - 1] / 1.2f);
            b.Add(bar, i);
        }
    }
    public void Close()
    {
        Application.Quit();
    }
    public void StartSort()
    {
        transform.GetComponent<SelectionSort>().enabled = true; 
        transform.GetComponent<BubbleSort>().enabled = true;
        transform.GetComponent<InsertionSort>().enabled = true;
        transform.GetComponent<CocktailSort>().enabled = true;
        transform.GetComponent<MergeSort>().enabled = true;
        transform.GetComponent<RadixSort>().enabled = true;
        transform.GetComponent<ShellSort>().enabled = true;
        transform.GetComponent<HeapSort>().enabled = true;
        transform.GetComponent<QuickSort>().enabled = true;
        Sorting.Sorted = false;
        Sorting.done = true;
        StartSorting = true;
    }
    public void StopSort()
    {
        transform.GetComponent<SelectionSort>().enabled = false;
        transform.GetComponent<BubbleSort>().enabled = false;
        transform.GetComponent<InsertionSort>().enabled = false;
        transform.GetComponent<CocktailSort>().enabled = false;
        transform.GetComponent<MergeSort>().enabled = false;
        transform.GetComponent<RadixSort>().enabled = false;
        transform.GetComponent<ShellSort>().enabled = false;
        transform.GetComponent<HeapSort>().enabled = false;
        transform.GetComponent<QuickSort>().enabled = false;
        Sorting.Sorted = false;
        Sorting.done = true;
        Shuffle();
        StartSorting = false;
    }
    public class Bar
    {
        public Image Img;
        public int Ind;
        List<Bar> bars = new List<Bar>();
        public Bar()
        {
        }
        public Bar(Image img, int ind)
        {
            Img = img;
            Ind = ind;
        }
        public void Add(Image Img, int Ind)
        {
            bars.Add(new Bar(Img, Ind));
        }
        public void Remove(int ind)
        {
            ind--;
            Destroy(bars[ind].Img.gameObject);
            bars.Remove(bars[ind]);
        }
        public void Clear()
        {
            for(int i = 0; i < bars.Count; i++)
            {
                Destroy(bars[i].Img.gameObject);
            }
            bars.Clear();
        }
        public void SetInd(Image img, int ind)
        {
            for (int i = 0; i < bars.Count; i++)
            {
                if (img == bars[i].Img)
                {
                    bars[i].Ind = ind;
                }
            }
        }
        public int GetCount()
        {
            return bars.Count;
        }
        public int GetInd(Image img)
        {
            for(int i = 0; i < bars.Count; i++)
            {
                if (img == bars[i].Img)
                {
                    return bars[i].Ind;
                }
            }
            return 0;
        }
        public Image GetImg(int ind)
        {
            for (int i = 0; i < bars.Count; i++)
            {
                if (ind == bars[i].Ind)
                {
                    return bars[i].Img;
                }
            }
            return null;
        }
    }
}
