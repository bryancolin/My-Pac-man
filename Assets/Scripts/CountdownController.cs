﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownController : MonoBehaviour
{
    private TextMeshProUGUI countdownDisplay;
    private int countdownTime = 3;

    private GameObject managers;
    private Coroutine countDownCoroutine;

    private void Awake()
    {
        countdownDisplay = GameObject.FindWithTag("CountDown").GetComponent<TextMeshProUGUI>();

        managers = GameObject.FindWithTag("Managers");
        if (managers != null)
        {
            managers.gameObject.SetActive(false);
        }        

        if (countDownCoroutine == null)
        {
            countDownCoroutine = StartCoroutine(CountdownToStart());
        }
    }   

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.SetText(countdownTime.ToString());
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }

        countdownDisplay.SetText("GO!");
        yield return new WaitForSecondsRealtime(1f);

        countdownDisplay.gameObject.SetActive(false);

        if (managers != null)
        {
            managers.gameObject.SetActive(true);
            GameObject.FindWithTag("Managers").AddComponent<GameManager>();
        }

        Time.timeScale = 1;

        countDownCoroutine = null;
    }
}
