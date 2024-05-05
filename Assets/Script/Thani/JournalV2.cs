using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalV2 : MonoBehaviour
{
    [TextArea(10, 20)]
    [SerializeField] private string pageText;
    [Space]
    [SerializeField] private TextMeshProUGUI leftPage;
    [SerializeField] private TextMeshProUGUI rightPage;
    [Space]
    [SerializeField] private TextMeshProUGUI leftPagination;
    [SerializeField] private TextMeshProUGUI rightPagination;

    private void OnValidate()
    {
        UpdatePagination();

        if (leftPage.text == pageText)
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
        if (leftPage.pageToDisplay < 1)
        {
            leftPage.pageToDisplay = 1;
            return;
        }

        if (leftPage.pageToDisplay -2 > 1)
        {
            leftPage.pageToDisplay -=2;
        }
        else
        {
            leftPage.pageToDisplay = 1;
        }

        rightPage.pageToDisplay = leftPage.pageToDisplay+1;

        UpdatePagination();
    }

    public void NextPage()
    {
        if (rightPage.pageToDisplay >= rightPage.textInfo.pageCount)
        {
            return;
        }

        if (leftPage.pageToDisplay >= leftPage.textInfo.pageCount - 1)
        {
            leftPage.pageToDisplay = leftPage.textInfo.pageCount - 1;
            rightPage.pageToDisplay = leftPage.pageToDisplay + 1;
        }
        else
        {
            leftPage.pageToDisplay += 2;
            rightPage.pageToDisplay = leftPage.pageToDisplay + 1;
        }

        rightPage.pageToDisplay = leftPage.pageToDisplay + 1;

        UpdatePagination();
    }
}