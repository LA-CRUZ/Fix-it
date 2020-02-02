using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;  //its a must to access new UI in script

public class InputContentInTextCanva : MonoBehaviour
{
    private string nbItem;
    private string expectedItem;
    void Update()
    {
        string contentName = gameObject.name;
        //print(contentName);

        switch(contentName)
        {
            case "score item1 P1":
                expectedItem = GameObject.Find("PatternP1").GetComponent<Pattern>().getExpectedItem1().ToString();
                nbItem = GameObject.Find("PatternP1").GetComponent<Pattern>().getNbItem1().ToString();
                break;
            case "score item2 P1":
                expectedItem = GameObject.Find("PatternP1").GetComponent<Pattern>().getExpectedItem2().ToString();
                nbItem = GameObject.Find("PatternP1").GetComponent<Pattern>().getNbItem2().ToString();
                break;
            case "score item3 P1":
                expectedItem = GameObject.Find("PatternP1").GetComponent<Pattern>().getExpectedItem3().ToString();
                nbItem = GameObject.Find("PatternP1").GetComponent<Pattern>().getNbItem3().ToString();
                break;
            case "score item1 P2":
                expectedItem = GameObject.Find("PatternP2").GetComponent<Pattern>().getExpectedItem1().ToString();
                nbItem = GameObject.Find("PatternP2").GetComponent<Pattern>().getNbItem1().ToString();
                break;
            case "score item2 P2":
                expectedItem = GameObject.Find("PatternP2").GetComponent<Pattern>().getExpectedItem2().ToString();
                nbItem = GameObject.Find("PatternP2").GetComponent<Pattern>().getNbItem2().ToString();
                break;
            case "score item3 P2":
                expectedItem = GameObject.Find("PatternP2").GetComponent<Pattern>().getExpectedItem3().ToString();
                nbItem = GameObject.Find("PatternP2").GetComponent<Pattern>().getNbItem3().ToString();
                break;
            default:
                break;
        }
        gameObject.GetComponent<TextMeshProUGUI>().SetText(nbItem + " / " + expectedItem);
    }
}
