using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pay : MonoBehaviour
{
    [SerializeField]
    private Rows[] rows;

    [SerializeField]
    private Menu menu;

    [SerializeField]
    private Sounds sound;

    private bool isAnimating = false;


    private void OnMouseDown()
    {
        if (!rows[0].rowSpinning && !rows[1].rowSpinning && !rows[2].rowSpinning && !menu.menuActive && !isAnimating)
        {
            StartCoroutine("AnimateButton");
            sound.ButtonClickSound();
            menu.ActivateMenu();
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
}
