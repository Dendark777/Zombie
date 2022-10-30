using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentTail : MonoBehaviour
{
    
    public List <Content> content;

   
}

public enum Content
{
    none,
    home,
    barrier,
    find,
    wallLeft,
    wallRight,
    wallUp,
    wallDown,
    windowsLeft,
    windowsRight,
    windowsUp,
    windowsDown,
    doorLeft,
    doorRight,
    doorUp,
    doorDown,
    barricade,
    car,
    doorCar,
}