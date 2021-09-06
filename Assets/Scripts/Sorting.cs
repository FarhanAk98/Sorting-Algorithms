using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sorting : MonoBehaviour
{
    public Slider sl;
    public int speed;
    public static bool Sorted = false, done = true;
    Vector3 pos1, pos2;
    TMP_Dropdown dp;
    void OnEnable()
    {
        dp = this.GetComponent<SetTheBar>().dp;
    }
    void FixedUpdate()
    {
        if (!Sorted)
        {
            Time.fixedDeltaTime = 0.000001f;
            Time.timeScale = sl.value;
            if (dp.value == 0)
            {
                transform.GetComponent<SelectionSort>().Alg();
            }
            else if (dp.value == 1)
            {
                transform.GetComponent<BubbleSort>().Alg();
            }
            else if (dp.value == 2)
            {
                transform.GetComponent<InsertionSort>().Alg();
            }
            else if (dp.value == 3)
            {
                transform.GetComponent<CocktailSort>().Alg();
            }
            else if (dp.value == 4)
            {
                transform.GetComponent<MergeSort>().Alg();
            }
            else if (dp.value == 5)
            {
                transform.GetComponent<RadixSort>().Alg();
            }
            else if (dp.value == 6)
            {
                transform.GetComponent<ShellSort>().Alg();
            }
            else if (dp.value == 7)
            {
                transform.GetComponent<HeapSort>().Alg();
            }
            else if (dp.value == 8)
            {
                transform.GetComponent<QuickSort>().Alg();
            }
        }
    }
    public void Swap(Image b1, Image b2)
    {
        if (Time.timeScale < 0.01f)
        {
            Time.timeScale = 0.01f;
        }
        else
        {
            Time.timeScale = sl.value;
        }
        if (b1 != null && b2 != null)
        {
            b1.color = new Color32(255, 0, 0, 255);
            b2.color = new Color32(255, 0, 0, 255);
            if (done)
            {
                pos1 = b1.rectTransform.position;
                pos2 = b2.rectTransform.position;
                b1.transform.SetAsLastSibling();
                b2.transform.SetAsLastSibling();
                done = false;
            }
            else
            {
                b1.rectTransform.position = Vector3.MoveTowards(b1.rectTransform.position, pos2, speed * Time.deltaTime);
                b2.rectTransform.position = Vector3.MoveTowards(b2.rectTransform.position, pos1, speed * Time.deltaTime);
            }
            if (b1.rectTransform.position == pos2 && b2.rectTransform.position == pos1)
            {
                b1.color = new Color32(202, 202, 202, 255);
                b2.color = new Color32(202, 202, 202, 255);
                done = true;
            }
        }
    }
}
