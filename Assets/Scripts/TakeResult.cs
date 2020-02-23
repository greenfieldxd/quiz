using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeResult : MonoBehaviour
{
    public Text resultText; 
    void Start()
    {
        GameManager gameScript = FindObjectOfType<GameManager>();
        int correctResult = gameScript.correctAnswers;
        int failResult = gameScript.failAnswers;
        resultText.text = "Игра окончена, количество правильных ответов составило: " + correctResult + ". Количество неправильных ответов составило: " + failResult + ".";

        Destroy(gameScript.gameObject); //Destroy Game Object 
        //Destoy(magicNumbers); //destroy component
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
