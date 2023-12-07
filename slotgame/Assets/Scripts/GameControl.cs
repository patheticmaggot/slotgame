using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour {
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Rows[] rows;

    [SerializeField]
    private Transform handle;

    private int winValue;

    private bool resultsChecked = false;

    private string matchingValue = null;

    void Update() {
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            winValue = 0;
            winText.enabled = false;
            resultsChecked = false;
        }

        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !resultsChecked)
        {
            CheckResults();
            if (winValue != 0)
            {
                winText.enabled = true;
                winText.text = "WIN\n" + winValue;
            }
        }
    }

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
            StartCoroutine("PullHandle");
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

    private void CheckResults()
    {
        if (rows[0].stoppedSlot == rows[1].stoppedSlot 
            && rows[1].stoppedSlot == rows[2].stoppedSlot)
        {
            switch (rows[0].stoppedSlot)
            {
                case "Lemon":
                    winValue = 5000;
                    break;

                case "Cherry":
                    winValue = 3000;
                    break;

                case "Seven":
                    winValue = 1500;
                    break;

                case "Bar":
                    winValue = 800;
                    break;

                case "Melon":
                    winValue = 600;
                    break;

                case "Crown":
                    winValue = 400;
                    break;

                case "Diamond":
                    winValue = 200;
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
                case "Lemon":
                    winValue = 4000;
                    break;

                case "Cherry":
                    winValue = 2000;
                    break;

                case "Seven":
                    winValue = 1000;
                    break;

                case "Bar":
                    winValue = 700;
                    break;

                case "Melon":
                    winValue = 500;
                    break;

                case "Crown":
                    winValue = 300;
                    break;

                case "Diamond":
                    winValue = 100;
                    break;
            }
        }
    }
}
