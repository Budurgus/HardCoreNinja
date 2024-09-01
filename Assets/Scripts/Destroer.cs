using UnityEngine;

public class Destroer : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        // ”ничтожаем объект c тегом (Fruit), когда он выходит за триггер арены (Back Wall)
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
        }
    }
}
