using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalV2 : MonoBehaviour
{
    [TextArea(10, 20)]
    [SerializeField] private string pageText;
    [Space]
    [SerializeField] private TMPro_Text leftPage;
    [SerializeField] private TMPro_Text rightPage;
    [Space]
    [SerializeField] private TMPro_Text leftPagination;
    [SerializeField] private TMPro_Text rightPagination;

    private void OnValidate()
    {
        UpdatePagination();

        if (leftSide.text == pageText)
        {
            return;
        }

        SetupContent();
    }

    private void Awake()
    {
        SetupContent();
        UpdatePagination();
    }

    private void SetupContent()
    {
        leftPage.text = pageText;
        rightPage.text = pageText;
    }
    private void UpdatePagination()
    {
        leftPagination.text = leftPage.pageToDisplay.ToString();
        rightPagination.text = rightPage.pageToDisplay.ToString();
    }

    public void PreviousPage()
    {
        if (leftSide.pageToDisplay < 1)
        {
            leftSide.pageToDisplay = 1;
            return;
        }

        if (leftSide.pageToDisplay -2 > 1)
        {
            leftSide.pageToDisplay -=2;
        }
        else
        {
            leftSide.pageToDisplay = 1;
        }

        rightSide.pageToDisplay = leftSide.pageToDisplay+1;

        UpdatePagination();
    }

    public void NextPage()
    {
        if (rightSide.pageToDisplay >= rightSide.textInfo.pageCount)
        {
            return;
        }

        if (leftSide.pageToDisplay >= leftSide.textInfo.pageCount - 1)
        {
            leftSide.pageToDisplay = leftSide.textInfo.pageCount - 1;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        }
        else
        {
            leftSide.pageToDisplay += 2;
            rightSide.pageToDisplay = leftSide.pageToDisplay + 1;
        }

        rightSide.pageToDisplay = leftSide.pageToDisplay + 1;

        UpdatePagination();
    }
}