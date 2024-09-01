using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMovement = 15f;
    public float speedRotation = 45f;
    public GameObject attackTrigger;

    // Дочерний объект с триггером
    private Collider triggerCollider;
    // Список для хранения объектов с тегом "Fruit"
    private List<GameObject> fruitsInTrigger = new List<GameObject>();

    void Start()
    {
        // Получаем коллайдер дочернего объекта
        triggerCollider = GetComponentInChildren<Collider>();
    }

    void Update()
    {
        // Получаем ввод от клавиш WASD 
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Вычисляем направление движения 
        Vector3 movement = new Vector3(0f, 0f, verticalInput) * speedMovement * Time.deltaTime;
        Vector3 rotation = new Vector3(0f, horizontalInput, 0f) * speedRotation * Time.deltaTime;

        // Применяем движение к персонажу 
        transform.Translate(movement);
        transform.Rotate(rotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Dash()
    {
        transform.Translate(Vector3.forward * 3f);
    }

    public void Attack()
    {
        // Уничтожаем все объекты с тегом "Fruit", которые находятся в списке
        foreach (GameObject fruit in fruitsInTrigger)
        {
            Destroy(fruit);
        }
        // Очищаем список
        fruitsInTrigger.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, если объект с тегом "Fruit" вошел в триггер
        if (other.CompareTag("Fruit"))
        {
            fruitsInTrigger.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Если объект с тегом "Fruit" вышел из триггера, удаляем его из списка
        if (other.CompareTag("Fruit"))
        {
            fruitsInTrigger.Remove(other.gameObject);
        }
    }
}
