using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectProjectile : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI bulletCountTxt;

    int bulletCount = 0;

    public int BulletCount { get { return bulletCount; } set { bulletCount = value; } }

    void Start()
    {
        UpdateBulletCountText();
    }

    public void UpdateBulletCountText()
    {
        bulletCountTxt.text = bulletCount.ToString();
    }
}
