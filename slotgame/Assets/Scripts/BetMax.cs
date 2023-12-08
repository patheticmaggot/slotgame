using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetMax : MonoBehaviour
{
    [SerializeField]
    private Text betText;

    [SerializeField]
    private Rows[] rows;

    [SerializeField]
    private BetOne betOne;

    private bool isAnimating = false;

    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            if (!isAnimating)
                StartCoroutine("AnimateButton");
            betOne.currentBet = 10000;
            betOne.resultMultiplier = 50f;
            betOne.UpdateBetText();
            betOne.UpdateResults();
        }
    }

    private IEnumerator AnimateButton()
    {
        isAnimating = true;

        if (transform.localPosition.y == -0.464f)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, -0.525f);
        }

        yield return new WaitForSeconds(0.1f);
        transform.localPosition = new Vector2(transform.localPosition.x, -0.464f);

        isAnimating = false;
    }
}
