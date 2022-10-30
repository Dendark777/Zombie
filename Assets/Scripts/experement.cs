using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class experement : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var item in this.GetComponent<ContentTail>().content)
        {
            print(item);
        }
        print("  ");
    }

    
}
