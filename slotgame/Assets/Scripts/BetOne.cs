using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class BetOne : MonoBehaviour
{
    [SerializeField]
    private Text betText;

    [SerializeField]
    private Rows[] rows;

    [SerializeField]
    public Text[] resultText;

    [SerializeField]
    private Menu menu;

    [SerializeField]
    private Sounds sound;

    public int currentBet = 200;
    public float resultMultiplier = 1;
    private bool isAnimating = false;

    [HideInInspector]
    public int[] resultsAmounts;

    private void Start()
    {
        resultsAmounts = new int[]
        {
            20000, 1800,   // crown amounts
            12000, 1300,   // diamond amounts
            4000, 800,     // seven amounts
            2400, 400,     // bar amounts
            1600, 400,     // melon amounts
            800, 200,      // lemon amounts
            800, 200       // cherry amounts
        };
        UpdateBetText();
        UpdateResults();
    }

    private void OnMouseDown()
    {
        if (!rows[0].rowSpinning && !rows[1].rowSpinning && !rows[2].rowSpinning && !menu.menuActive)
        {
            if (!isAnimating)
            {
                StartCoroutine("AnimateButton");
                sound.ButtonClickSound();
            }
            RaiseBet();
            UpdateResults();
        }
    }

    private IEnumerator AnimateButton()
    {
        isAnimating = true;

        if (transform.localPosition.y == -0.464f)
            transform.localPosition = new Vector2(transform.localPosition.x, -0.525f);

        yield return new WaitForSeconds(0.1f);
        transform.localPosition = new Vector2(transform.localPosition.x, -0.464f);

        isAnimating = false;
    }

    public void UpdateResults()
    {
        for (int i = 0; i < resultsAmounts.Length; i++)
        {
            resultText[i].text = ((int)(resultsAmounts[i] * resultMultiplier)).ToString();
        }

    }

    public void UpdateBetText()
    {
        betText.text = "BET\n" + currentBet;
    }

    private void RaiseBet()
    {
        switch (currentBet)
        {
            case 10000:
                currentBet = 200;
                resultMultiplier = 1f;
                break;

            case 200:
                currentBet = 400;
                resultMultiplier = 2f;
                break;

            case 400:
                currentBet = 500;
                resultMultiplier = 2.5f;
                break;

            case 500:
                currentBet = 600;
                resultMultiplier = 3f;
                break;

            case 600:
                currentBet = 800;
                resultMultiplier = 4f;
                break;

            case 800:
                currentBet = 1000;
                resultMultiplier = 5f;
                break;

            case 1000:
                currentBet = 1500;
                resultMultiplier = 7.5f;
                break;

            case 1500:
                currentBet = 2000;
                resultMultiplier = 10f;
                break;

            case 2000:
                currentBet = 3000;
                resultMultiplier = 15f;
                break;

            case 3000:
                currentBet = 4000;
                resultMultiplier = 20f;
                break;

            case 4000:
                currentBet = 5000;
                resultMultiplier = 25f;
                break;

            case 5000:
                currentBet = 10000;
                resultMultiplier = 50f;
                break;
        }
        UpdateBetText();
        UpdateResults();
    }
}
