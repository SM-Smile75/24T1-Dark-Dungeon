using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalV2 : MonoBehaviour
{
    [TextArea(10, 20)]
    [SerializeField] private string pageText;
    [Space]
    [SerializeField] private TextMeshProUGUI leftText;
    [SerializeField] private TextMeshProUGUI rightText;
    [Space]
    [SerializeField] private TextMeshProUGUI leftStuffing;
    [SerializeField] private TextMeshProUGUI rightStuffing;

    private void OnValidate()
    {
        UpdatePages();
        
        if(leftText.text = pageText)
        {
            return;
        }

        SetUpPages();
    }

    private void Awake()
    {
        SetUpPages();
        UpdatePages();
    }

    private void SetUpPages()
    {
        leftText.text = pageText;
        rightText.text = pageText;
    }

    private void UpdatePages()
    {
        leftStuffing.text = leftPage.pageToDisplay.ToString();
        rightStuffing.text = rightPage.pageToDisplay.ToString();
    }

    public void PreviousPage()
    {
        if (leftPage.pageToDisplay < 1)
        {
            leftPage.pageToDisplay = 1;
            return;
        }

        if (leftPage.pageToDisplay -2 > 1)
        {
            leftPage.pageToDisplay -= 2;
        } else {
            leftPage.pageToDisplay = 1;
        }

        rightPage.pageToDisplay = leftPage.pageToDisplay + 1;
        UpdatePages();
    }

    public void NextPage()
    {
        if(rightPage.pageToDisplay >= rightPage.textInfo.pageCount)
        {
            return;
        }

        if(leftPage.pageToDisplay >= leftPage.textInfo.pageCount - 1)
        {
            leftPage.pageToDisplay = leftPage.textInfo.pageCount - 1;
            rightPage.pageToDisplay = leftPage.pageToDisplay + 1;
        } else {
            leftPage.pageToDisplay += 2;
            rightPage.pageToDisplay = leftPage.pageToDisplay + 1;
        }

        rightPage.pageToDisplay = leftPage.pageToDisplay + 1;
        UpdatePages();
    }
}