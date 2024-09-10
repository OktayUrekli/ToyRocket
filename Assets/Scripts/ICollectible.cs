using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ICollectible
{
    public int ObjectCount { get; set; }

    public void CollectObject();
    public void UseObject();






}
