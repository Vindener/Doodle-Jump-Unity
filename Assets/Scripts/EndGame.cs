using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text endGameText;

    void Start()
    {
        endGameText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            endGameText.enabled = true;
            StartCoroutine(EndGameCoroutine());
        }
    }

    IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(0.1f);

        endGameText.enabled = true;
        Time.timeScale = 0f;
    }
}
