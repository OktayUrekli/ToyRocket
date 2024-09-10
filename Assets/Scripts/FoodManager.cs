using TMPro;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI foodCountTxt;

    int foodCount = 0;

    public int FoodCount { get { return foodCount; } set { foodCount = value; } }

    void Start()
    {
        UpdateFoodCountText();
    }

    public void UpdateFoodCountText()
    {
        foodCountTxt.text = foodCount.ToString();
    }
}
