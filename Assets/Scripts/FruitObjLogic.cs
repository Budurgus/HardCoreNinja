using UnityEngine;

public class FruitObjLogic : MonoBehaviour
{
    public float speed = 5f; // Скорость движения в пространстве
    public float speedRotation = 30f; // Скорость вращения в пространстве
    public GameObject[] friutsList; // Список моделей фруктов
    public float timeDestroy = 10f;

    private GameObject visionPart; // Ссылка на объект модели фрукта


    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0f, 360f)); // Случайным образом прокручиваем объект на сцене
        visionPart = Instantiate(friutsList[Random.Range(0, friutsList.Length)], transform); // Создаем и получаем доступ к случайному объекту модели фрукта
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime); // Задаем направление движения и скорость.
                                                                    // После появления объекта на сцене, он начинает двигаться в сторону игрока, чтоб вылететь за арену (Back Wall).

        visionPart.transform.Rotate(speedRotation * Time.deltaTime, 0, 0); ; // Задаем случаеное вращение модели фрукта

        //Уничтожаем объект через 10 секунд (если что-то случилось и он не достиг стены)
        timeDestroy -= Time.deltaTime;
        if (timeDestroy < 0f)
        {
            Destroy(gameObject);
        }
    }
}
