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

    private bool isAnimating = false;


    private void OnMouseDown()
    {
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && !menu.menuActive)
        {
            if (!isAnimating)
                StartCoroutine("AnimateButton");
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
        menu.ActivateMenu();
        
    }
}