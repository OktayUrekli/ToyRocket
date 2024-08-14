using UnityEngine;
using UnityEngine.UI;

public class LevelPanelManager : MonoBehaviour
{

    [SerializeField] GameObject[] levelPages;
    [SerializeField] Button leftButton, rightButton;

    int pageIndex;

    void Start()
    {
        foreach (var levelPage in levelPages) { levelPage.SetActive(false); }
        
        pageIndex = 0;
        levelPages[pageIndex].SetActive(true);
        leftButton.enabled = false;
    }

    public void LeftButton()
    {
        pageIndex--;
        if (pageIndex<0)
        {
            pageIndex = 0;
            leftButton.enabled = false;
        }
        else {
            rightButton.enabled = true;
            levelPages[pageIndex+1].SetActive(false);
            levelPages[pageIndex].SetActive(true);
        }

    }

    public void RightButton()
    {
        pageIndex++;
        if (pageIndex == levelPages.Length)
        {
            pageIndex = levelPages.Length - 1;
            rightButton.enabled = false;
        }
        else
        {
            leftButton.enabled = true;
            levelPages[pageIndex-1].SetActive(false);
            levelPages[pageIndex].SetActive(true);
        }

    }

}
