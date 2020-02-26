using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Elements")]  //Создаем ссылки к элементам на сцену
    public Image imageContent;
    public List<Image> imageLives;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;


    public List<Value> values; // Массив для хранения вопросов

    public int correctAnswers = 0; //Верные ответы
    public int failAnswers = 0; //Неправильные ответы
    int indexElementLive = 2; // индекс сердечка в массиве
    int nextValue; // индекс следующего вопроса

    //List<int> numbers = new List<int>() { 1, 2, 3, 45 };
    //numbers.Add(6); // добавление элемента


    void Start()
    {
        nextValue = Random.Range(0, values.Count); // Рандомим следующий вопрос
        Initialization(nextValue); // загружаем его
        DontDestroyOnLoad(gameObject); // не уничтожаем объект, чтобы потом достать из него переменные correctAnswers и failAnswers

    }


    public void Initialization(int index) // находим текст у кнопок и присваиваем им значение
    {
        Text btnText1 = btn1.gameObject.GetComponentInChildren<Text>();
        Text btnText2 = btn2.gameObject.GetComponentInChildren<Text>();
        Text btnText3 = btn3.gameObject.GetComponentInChildren<Text>();
        Text btnText4 = btn4.gameObject.GetComponentInChildren<Text>();

        imageContent.sprite = values[index].contentImage; // присваиваем картинке и тексту значения
        btnText1.text = values[index].btnText1;
        btnText2.text = values[index].btnText2;
        btnText3.text = values[index].btnText3;
        btnText4.text = values[index].btnText4;
    }

    public void LoadNextValue() //Загрузка следующего вопроса
    {
        values.RemoveAt(nextValue); // удаление пройденного вопроса

        if (values.Count == 0) //Если все вопросы пройдены, загрузка последней сцены
        {
            LoadEndScene(); 
        }
        else // В противном случае рандомим следующий вопрос и загружаем его
        {
            nextValue = Random.Range(0, values.Count);
            Initialization(nextValue);
        }
    }


    public void ButtoncClick(int index)  // функция для наших кнопок принимающая индекс  кнопки
    {
        if (index == values[nextValue].correctIndex) //реализация проверки: сверяем индекс в вопросе с индексом кнопки
        {
            correctAnswers++; // +1 к правильным  
        }
        else
        {
            failAnswers++; // +1 к неправильным
            SetActiveFalseLives(indexElementLive); // Выключаем объект с сердцем на сцене
            indexElementLive--; //уменьшаем индекс сердца на 1
            if (failAnswers == 3) //если неправильных 3, то проигрыш
            {
                LoadEndScene();
            }
        }

        LoadNextValue(); // загрузка следующего вопроса

    }

    public void LoadEndScene() // переход к последней сцене
    {
        SceneManager.LoadScene(2);
    }

    public void SetActiveFalseLives(int element)
    {
        imageLives[element].gameObject.SetActive(false);
    }
}