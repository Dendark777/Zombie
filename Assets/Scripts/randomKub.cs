using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class randomKub : MonoBehaviour, IPointerClickHandler
{
    public int rezult;
    public List<int> allChisla;
    public int componentInSecond;
    public int now = 0;
    public bool startCub = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        int finishChislo = 6; // максимальный результат на "кубике"
        componentInSecond = 40; // сколько значений показать за секунду
        allChisla = new List<int>();

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < finishChislo; j++)
            {
                allChisla.Add(j + 1);
            }
        }

        allChisla.Shuffle();

        if (startCub == false) startCub = true;
        else startCub = false;

        componentInSecond = 1000 / componentInSecond;
    }


    // Update is called once per frame
    void Update()
    {

        if (startCub == true)
        {
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/kub/" + allChisla[now]);
            this.rezult = allChisla[now];
            now++;
            if (now == allChisla.Count) now = 0;
            System.Threading.Thread.Sleep(componentInSecond);

            // затухание
            componentInSecond += 10;
            if (componentInSecond >= 200) startCub = false;
        }

    }
}
