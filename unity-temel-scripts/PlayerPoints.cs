using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = score.totalScore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Elmas")
        {
            audioSource.Play();
            Destroy(collision.gameObject);
            score.totalScore++;
            scoreText.text = score.totalScore.ToString();   
        }
    }
}
