using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    private int nbItem1, nbItem2, nbItem3;
    private int expectedItem1, expectedItem2, expectedItem3;

    public int NB_ITEMS;
    public bool isFinished;
    
    void Start()
    {
        isFinished = false;
        nbItem1 = 0;
        nbItem2 = 0;
        nbItem3 = 0;

        int remainingItems = NB_ITEMS;

        expectedItem1 = Random.Range(1, remainingItems - 2);
        remainingItems -= expectedItem1;

        expectedItem2 = Random.Range(1, remainingItems - 1);
        remainingItems -= expectedItem2;

        expectedItem3 = remainingItems;
    }

    private void updateIsFinished()
    {
        if (nbItem1 == expectedItem1 &&
            nbItem2 == expectedItem2 &&
            nbItem3 == expectedItem3)
        {
            isFinished = true;
        }
        isFinished = false;
    }

    public void addItem(string tagItem)
    {
        switch (tagItem)
        {
            case "item1":
                if(nbItem1 < expectedItem1)
                {
                    nbItem1++;
                }
                break;
            case "item2":
                if (nbItem2 < expectedItem2)
                {
                    nbItem2++;
                }
                break;
            case "item3":
                if (nbItem3 < expectedItem3)
                {
                    nbItem3++;
                }
                break;
        }
        this.updateIsFinished();
    }

    public int getNbItem1 ()
    {
        return nbItem1;
    }

    public int getNbItem2()
    {
        return nbItem2;
    }

    public int getNbItem3()
    {
        return nbItem3;
    }

    public int getExpectedItem1()
    {
        return expectedItem1;
    }

    public int getExpectedItem2()
    {
        return expectedItem2;
    }

    public int getExpectedItem3()
    {
        return expectedItem3;
    }
}
