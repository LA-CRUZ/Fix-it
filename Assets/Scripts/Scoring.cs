using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{

    public Color colorP1 = Color.red;
    public Color colorP2 = Color.blue;
    public int scoreMax = 3;

    public GameObject completeLevelUI;

    private int currentScore = 0;
    private int scoreWin;
    private int scoreP1 = 0;
    private int scoreP2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreWin = scoreMax / 2 + 1;
        updateScore(2);
        updateScore(1);
        updateScore(1);
        updateScore(1);
    }

    // Update is called once per frame
    void Update()
    {
    }

  void updateScore(int player)
    {
        currentScore++;
    
        switch (player)
        {
            case 1:
                scoreP1++;
                this.gameObject.transform.GetChild(currentScore-1).GetComponent<Renderer>().material.color = colorP1;
                break;
            case 2:
                scoreP2++;
                this.gameObject.transform.GetChild(currentScore-1).GetComponent<Renderer>().material.color = colorP2;
                break;
        }

        if (currentScore > scoreMax || scoreP1 == scoreWin || scoreP2 == scoreWin)
        {
            showVictory();
            return;
        }
    }


    void showVictory()
    {
        completeLevelUI.SetActive(true);
        String winner = scoreP1 <= scoreP2 ? "player 2" : "player 1";
        completeLevelUI.transform.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = winner + ", you win !";
    }

    public void reset()
    {
        Debug.Log("reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        SceneManager.LoadScene("mainScene");
    }
}
