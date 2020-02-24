using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Elements")]
    public Image ImageContent;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    public Value zeroValue;
    Value activeValue;

    List<int> correctButtons = new List<int> { 1, 2, 3, 4, 3, 2, 2, 4, 3, 1, 0}; //Верные ответы, один лишний в конце, потому что массив динамический
    List<int> answerButtons = new List<int> { }; // Тут должны быть ответы игрока

    public int correctAnswers = 0;
    public int failAnswers = 0;

    //List<int> numbers = new List<int>() { 1, 2, 3, 45 };
    //numbers.Add(6); // добавление элемента


    void Start()
    {
        
        Initialization();
        DontDestroyOnLoad(gameObject);
        


    }

    
    public void ButtonClick1()
    {
        answerButtons.Add(1);
        CheckButton();
        
    }

    public void ButtonClick2()
    {
        answerButtons.Add(2);
        CheckButton();
        
    }



    public void ButtonClick3()
    {
        answerButtons.Add(3);
        CheckButton();
        
    }

    public void ButtonClick4()
    {
        answerButtons.Add(4);
        CheckButton();
        
    }

    void Initialization() //Первоначальная инициализация текста из buttons
    {
        Text btnText1 = btn1.gameObject.GetComponentInChildren<Text>();
        Text btnText2 = btn2.gameObject.GetComponentInChildren<Text>();
        Text btnText3 = btn3.gameObject.GetComponentInChildren<Text>();
        Text btnText4 = btn4.gameObject.GetComponentInChildren<Text>();

        ImageContent.sprite = zeroValue.contentImage; // присваиваем картинке и тексту нулевые значения
        btnText1.text = zeroValue.btnText1;
        btnText2.text = zeroValue.btnText2;
        btnText3.text = zeroValue.btnText3;
        btnText4.text = zeroValue.btnText4;
        activeValue = zeroValue;
    }

    public void CheckButton()
    {
        if (activeValue.nextValue != null) // Проверяем чтобы не null и на соответствие длины, если длина = 0, то конец игры
            if (activeValue.nextValue.Length == 1)
            {
                {
                    activeValue = activeValue.nextValue[0];

                    Text btnText1 = btn1.gameObject.GetComponentInChildren<Text>();
                    Text btnText2 = btn2.gameObject.GetComponentInChildren<Text>();
                    Text btnText3 = btn3.gameObject.GetComponentInChildren<Text>();
                    Text btnText4 = btn4.gameObject.GetComponentInChildren<Text>();

                    ImageContent.sprite = activeValue.contentImage;
                    btnText1.text = activeValue.btnText1;
                    btnText2.text = activeValue.btnText2;
                    btnText3.text = activeValue.btnText3;
                    btnText4.text = activeValue.btnText4;

                }
            }
        else if (activeValue.nextValue.Length == 0) //если 0, то загрузка финальной сцены
            {
                ChekAnswers();//Запуск проверки ответов
                LoadEndScene(); //Финальная сцена
            }
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(2);
    }

    void ChekAnswers() //Проверка правильности ответов
    {
        answerButtons.Add(0);//Добавил для проверки и избежания ошибки OutOfRange

        /*for (int i = 0; i < answerButtons.Count; i++) // Проверка элементов списка
        {
            Debug.Log(answerButtons[i]);
        }

        for (int i = 0; i < correctButtons.Count; i++) // Проверка элементов списка
        {
            Debug.Log(correctButtons[i]);
        }*/

        for (int i = 0; i < 10; i++)
        {
            if (correctButtons[i] == answerButtons[i])
            {
                correctAnswers++;
            }
            else
            {
                failAnswers++;
            }
        }

    }

}
