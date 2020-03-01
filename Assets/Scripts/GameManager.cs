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
    public Button[] buttons;


    public List<Value> values; // Массив для хранения вопросов

    public int correctAnswers = 0; //Верные ответы
    public int failAnswers = 0; //Неправильные ответы
    int indexElementLive; // индекс последнего сердечка в массиве
    int nextValue; // индекс следующего вопроса

    //List<int> numbers = new List<int>() { 1, 2, 3, 45 };
    //numbers.Add(6); // добавление элемента


    void Start()
    {
        indexElementLive = imageLives.Count - 1;// последний индекс меньше на 1
        nextValue = Random.Range(0, values.Count); // Рандомим следующий вопрос
        Initialization(nextValue); // загружаем его
        DontDestroyOnLoad(gameObject); // не уничтожаем объект, чтобы потом достать из него переменные correctAnswers и failAnswers

    }


    public void Initialization(int index) // находим текст у кнопок и присваиваем им значение
    {
        for (int i = 0; i < buttons.Length; i++) // Проходим по всем 4 компонентам текста
        {
            Text btnText = buttons[i].gameObject.GetComponentInChildren<Text>(); // Находим текст в кнопке
            imageContent.sprite = values[index].contentImage; // присваиваем картинке и тексту значения
            btnText.text = values[index].buttonTexts[i]; //Присваиваем текст из нужного вопроса
        }
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
            SetActiveFalseLives(indexElementLive); // Выключаем объект с сердцем на сцене по индексу
            indexElementLive--; //уменьшаем индекс сердца на 1
            if (failAnswers == 3) //если неправильных 3, то проигрыш
            {
                LoadEndScene();
            }
        }

        RestartAllButtons();//перезагрузка всех кнопок
        LoadNextValue(); // загрузка следующего вопроса

    }

    public void ButtonHint()
    {
        int counter = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (counter == 2)
            {
                break;//заверщение цикла
            }

            Button button = buttons[i];
            int index = i + 1;// приравниваем индекс кнопки к правильному ответу(индексы кнопки начинаются с 0, а правильные ответы с 1)

            if (index != values[nextValue].correctIndex)
            {
                button.interactable = false; //выключаем кнопку
                counter++;
            }
        }
    }

    public void RestartAllButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];
            button.interactable = true;
        }
    }

    public void LoadEndScene() // переход к последней сцене
    {
        SceneManager.LoadScene(2);
    }

    public void SetActiveFalseLives(int element) // Выключение сердечка по индексу
    {
        imageLives[element].gameObject.SetActive(false);
    }
}