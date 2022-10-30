using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionExtensions
{
    public static bool IsEmpty<Content>(this List<Content> list)
    {
        return list == null || !list.Any();
    }
}