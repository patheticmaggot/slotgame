using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;

public class GameControl : MonoBehaviour {
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Text cashText;

    [SerializeField]
    public Rows[] rows;

    [SerializeField]
    private Transform handle;

    [SerializeField]
    private BetOne betOne;

    [SerializeField]
    private GameObject jackpotLights;

    public int currentCash;
    private int winValue;
    private bool resultsChecked = true;
    private bool isFlashing = false;
    private string matchingValue = null;


    void Start ()
    {
        winText.enabled = false;
        UpdateCashText();
        UpdateWinText();
    }

    void Update() {
        if (rows[0].rowSpinning || rows[1].rowSpinning || rows[2].rowSpinning)
        {
            winValue = 0;
            winText.enabled = false;
            resultsChecked = false;
        }

        if (!rows[0].rowSpinning && !rows[1].rowSpinning && !rows[2].rowSpinning && !resultsChecked)
        {
            CheckResults();
            if (winValue != 0)
            {
                UpdateWinText();
                winText.enabled = true;
                UpdateCashText();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!rows[0].rowSpinning && !rows[1].rowSpinning && !rows[2].rowSpinning && currentCash >= betOne.currentBet)
        {
            StartCoroutine("PullHandle");
            PayToSpin();
        }
        else if (!rows[0].rowSpinning && !rows[1].rowSpinning && !rows[2].rowSpinning)
        {
            if (!isFlashing) 
                StartCoroutine("FlashCashRed");
        }
    }

    

    private IEnumerator PullHandle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        for (int i = 0;i < 15; i += 5)
        {
            handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Jackpot()
    {
        float waitBetweenFlashes = 0.1f;

        for (int i = 0; i < 50; i++)
        {
            jackpotLights.SetActive(false);
            yield return new WaitForSeconds(waitBetweenFlashes);
            jackpotLights.SetActive(true);
            yield return new WaitForSeconds(waitBetweenFlashes);
        }
    }

    private IEnumerator FlashCashRed()
    {
        isFlashing = true;
        float flashDuration = 0.3f;
        float waitBetweenFlashes = 0.3f;

        for (int i = 0; i < 3; i++)
        {
            float elapsed = 0f;
            Color startColor = HexToColor("E1D696");
            Color targetColor = HexToColor("FF0000");

            while (elapsed < flashDuration)
            {
                cashText.color = Color.Lerp(startColor, targetColor, elapsed / flashDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(waitBetweenFlashes);

            elapsed = 0f;

            while (elapsed < flashDuration)
            {
                cashText.color = Color.Lerp(targetColor, startColor, elapsed / flashDuration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(waitBetweenFlashes);
        }
        isFlashing = false;
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.white;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }

    private void PayToSpin()
    {
        currentCash -= betOne.currentBet;
        UpdateCashText();
    }

    private void SpinToWin()
    {
        currentCash += winValue;
        UpdateCashText();
    }

    public void UpdateCashText()
    {
        cashText.text = "CASH\n" + currentCash;
    }

    private void UpdateWinText()
    {
        winText.text = "WIN\n" + winValue;
    }

    private void CheckResults()
    {
        if (rows[0].stoppedSlot == rows[1].stoppedSlot
            && rows[1].stoppedSlot == rows[2].stoppedSlot)
        {
            switch (rows[0].stoppedSlot)
            {
                case "Crown":
                    winValue = ((int)(betOne.resultsAmounts[0] * betOne.resultMultiplier));
                    StartCoroutine("Jackpot");
                    break;

                case "Diamond":
                    winValue = ((int)(betOne.resultsAmounts[2] * betOne.resultMultiplier));
                    StartCoroutine("Jackpot");
                    break;

                case "Seven":
                    winValue = ((int)(betOne.resultsAmounts[4] * betOne.resultMultiplier));
                    break;

                case "Bar":
                    winValue = ((int)(betOne.resultsAmounts[6] * betOne.resultMultiplier));
                    break;

                case "Melon":
                    winValue = ((int)(betOne.resultsAmounts[8] * betOne.resultMultiplier));
                    break;

                case "Lemon":
                    winValue = ((int)(betOne.resultsAmounts[10] * betOne.resultMultiplier));
                    break;

                case "Cherry":
                    winValue = ((int)(betOne.resultsAmounts[12] * betOne.resultMultiplier));
                    break;
            }
        }

        else if (rows[0].stoppedSlot == rows[1].stoppedSlot
            || rows[0].stoppedSlot == rows[2].stoppedSlot
            || rows[1].stoppedSlot == rows[2].stoppedSlot)
        {
            if (rows[0].stoppedSlot == rows[2].stoppedSlot)
                matchingValue = rows[0].stoppedSlot;
            else
                matchingValue = rows[1].stoppedSlot;

            switch (matchingValue)
            {
                case "Crown":
                    winValue = ((int)(betOne.resultsAmounts[1] * betOne.resultMultiplier));
                    break;

                case "Diamond":
                    winValue = ((int)(betOne.resultsAmounts[3] * betOne.resultMultiplier));
                    break;

                case "Seven":
                    winValue = ((int)(betOne.resultsAmounts[5] * betOne.resultMultiplier));
                    break;

                case "Bar":
                    winValue = ((int)(betOne.resultsAmounts[7] * betOne.resultMultiplier));
                    break;

                case "Melon":
                    winValue = ((int)(betOne.resultsAmounts[9] * betOne.resultMultiplier));
                    break;

                case "Lemon":
                    winValue = ((int)(betOne.resultsAmounts[11] * betOne.resultMultiplier));
                    break;

                case "Cherry":
                    winValue = ((int)(betOne.resultsAmounts[13] * betOne.resultMultiplier));
                    break;
            }
        }
        else
            winValue = 0;

        SpinToWin();
        resultsChecked = true;
    }
}
