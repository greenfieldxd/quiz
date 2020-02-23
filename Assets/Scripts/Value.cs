using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Value")]
public class Value : ScriptableObject
{
    [Header("Quiz Settings")]
    public Sprite contentImage;
    public string btnText1 = "TextButton1";
    public string btnText2 = "TextButton2";
    public string btnText3 = "TextButton3";
    public string btnText4 = "TextButton4";


    

    public Value[] nextValue;
}
