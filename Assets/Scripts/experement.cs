using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class experement : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
       // print(this.GetComponent<ContentTail>().content);

        Debug.Log("234324");
    }

    
}
