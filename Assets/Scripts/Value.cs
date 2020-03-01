using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Value")]
public class Value : ScriptableObject
{
    [Header("Quiz Settings")]
    public Sprite contentImage;
    public string[] buttonTexts;

    public int correctIndex; // индекс для хранения правильного ответа
}
