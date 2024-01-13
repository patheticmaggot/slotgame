using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menu;

    [SerializeField]
    private TMP_InputField euroInputText;

    [SerializeField]
    private TMP_InputField cashInputText;

    [SerializeField]
    GameControl gameControl;

    [SerializeField]
    private TextMeshProUGUI cashOutText;

    [SerializeField]
    private Sounds sound;

    public bool menuActive;

    private float euros = 0;
    private float cash = 0;

    void Start()
    {
        menu.SetActive(true);
        menuActive = true;
        cashOutText.enabled = false;
    }

    public void ActivateMenu()
    {
        sound.PauseMusic();
        cashOutText.text = "You collected\n" + gameControl.currentCash;
        if (gameControl.currentCash > 0)
            sound.PayOutWinSound();
        else
            sound.PayOutLoseSound();
        menu.SetActive(true);
        menuActive = true;
        Time.timeScale = 0f;
    }

    public void DeActivateMenu()
    {
        if (!sound.mainThemeAudio.isPlaying)
            sound.PlayMusic();
        menu.SetActive(false);
        menuActive = false;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void InsertMoney()
    {
        if (cash >= 200)
        {
            DeActivateMenu();
            gameControl.currentCash = (int)cash;
            gameControl.UpdateCashText();
            euroInputText.text = string.Empty;
            cashInputText.text = string.Empty;
            cashOutText.enabled = true;
            sound.InsertMoneySound();
        }
    }

    public void EuroInput(string Input)
    {
        euros = ConvertInputToFloat(Input);
        if (euros == 0)
            euroInputText.text = string.Empty;
        else
            cashInputText.text = (euros * 1000).ToString();
    }

    public void CashInput(string Input)
    {
        cash = ConvertInputToFloat(Input);
        if (cash == 0)
            euroInputText.text = string.Empty;
        else
            euroInputText.text = (cash / 1000).ToString();
    }

    private float ConvertInputToFloat(string stringputText)
    {
        float floatput;

        if (float.TryParse(stringputText, out floatput))
        {
            Debug.Log("Float value: " + floatput);
            return floatput;
        }
        else
        {
            Debug.Log("Empty input");
            return 0f;
        }
    }
}
