using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rows : MonoBehaviour {

    [SerializeField]
    private AudioSource clickSound;

    [SerializeField]
    private AudioSource reelSound;

    private int randomValue;
    private float timeInterval;
    private int currentRow;

    public bool rowSpinning;
    public string stoppedSlot;

    void Start()
    {
        rowSpinning = false;
        GameControl.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowSpinning = true;
        timeInterval = 0.025f;
        reelSound.Play();

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -3.5f)
                ChangeRows();
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            clickSound.Play();
            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -3.5f)
                ChangeRows();

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            clickSound.Play();

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
            { 
                reelSound.Stop();
                timeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }

        switch (currentRow)
        {
            case 1:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Melon";
                        break;
                    case -2f:
                        stoppedSlot = "Lemon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Seven";
                        break;
                    case -0.5f:
                        stoppedSlot = "Cherry";
                        break;
                    case 0.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1f:
                        stoppedSlot = "Lemon";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
            case 2:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Crown";
                        break;
                    case -2f:
                        stoppedSlot = "Melon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case -0.5f:
                        stoppedSlot = "Seven";
                        break;
                    case 0.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1f:
                        stoppedSlot = "Melon";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
            case 3:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Lemon";
                        break;
                    case -2f:
                        stoppedSlot = "Melon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case -0.5f:
                        stoppedSlot = "Diamond";
                        break;
                    case 0.25f:
                        stoppedSlot = "Seven";
                        break;
                    case 1f:
                        stoppedSlot = "Lemon";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
            case 4:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Seven";
                        break;
                    case -2f:
                        stoppedSlot = "Melon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Melon";
                        break;
                    case -0.5f:
                        stoppedSlot = "Lemon";
                        break;
                    case 0.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
            case 5:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Cherry";
                        break;
                    case -2f:
                        stoppedSlot = "Lemon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Lemon";
                        break;
                    case -0.5f:
                        stoppedSlot = "Melon";
                        break;
                    case 0.25f:
                        stoppedSlot = "Lemon";
                        break;
                    case 1f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
            case 6:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Lemon";
                        break;
                    case -2f:
                        stoppedSlot = "Lemon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Lemon";
                        break;
                    case -0.5f:
                        stoppedSlot = "Cherry";
                        break;
                    case 0.25f:
                        stoppedSlot = "Diamond";
                        break;
                    case 1f:
                        stoppedSlot = "Melon";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
            case 7:
                switch (transform.position.y)
                {
                    case -3.5f:
                        stoppedSlot = "Bar";
                        break;
                    case -2.75f:
                        stoppedSlot = "Melon";
                        break;
                    case -2f:
                        stoppedSlot = "Melon";
                        break;
                    case -1.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case -0.5f:
                        stoppedSlot = "Bar";
                        break;
                    case 0.25f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1f:
                        stoppedSlot = "Cherry";
                        break;
                    case 1.75f:
                        stoppedSlot = "Bar";
                        break;
                }
                break;
        }

        rowSpinning = false;
    }

    private void ChangeRows()
    {
        switch (gameObject.name)
        {
            case "Wheel1":
                transform.position = new Vector2(RandomRowWheel1(), 1.75f);
                break;
            case "Wheel2":
                transform.position = new Vector2(RandomRowWheel2(), 1.75f);
                break;
            case "Wheel3":
                transform.position = new Vector2(RandomRowWheel3(), 1.75f);
                break;
        }
    }

    private float RandomRowWheel1()
    {
        int rand = Random.Range(1, 8);
        switch (rand)
        {
            case 1:
                currentRow = 1;
                return 1.355f;
            case 2:
                currentRow = 2;
                return 0.61f;
            case 3:
                currentRow = 3;
                return -0.135f;
            case 4:
                currentRow = 4;
                return -0.88f;
            case 5:
                currentRow = 5;
                return -1.625f;
            case 6:
                currentRow = 6;
                return -2.37f;
            case 7:
                currentRow = 7;
                return -3.115f;
            default:
                Debug.LogError("no rows chosen");
                return transform.position.x;
        }
    }

    private float RandomRowWheel2()
    {
        int rand = Random.Range(1, 8);
        switch (rand)
        {
            case 1:
                currentRow = 1;
                return 2.115f;
            case 2:
                currentRow = 2;
                return 1.37f;
            case 3:
                currentRow = 3;
                return 0.625f;
            case 4:
                currentRow = 4;
                return -0.12f;
            case 5:
                currentRow = 5;
                return -0.865f;
            case 6:
                currentRow = 6;
                return -1.61f;
            case 7:
                currentRow = 7;
                return -2.355f;
            default:
                Debug.LogError("no rows chosen");
                return transform.position.x;
        }
    }

    private float RandomRowWheel3()
    {
        int rand = Random.Range(1, 8);
        switch (rand)
        {
            case 1:
                currentRow = 1;
                return 2.875f;
            case 2:
                currentRow = 2;
                return 2.13f;
            case 3:
                currentRow = 3;
                return 1.385f;
            case 4:
                currentRow = 4;
                return 0.64f;
            case 5:
                currentRow = 5;
                return -0.105f;
            case 6:
                currentRow = 6;
                return -0.85f;
            case 7:
                currentRow = 7;
                return -1.595f;
            default:
                Debug.LogError("no rows chosen");
                return transform.position.x;
        }
    }

    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }
}
