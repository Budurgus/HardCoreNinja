using UnityEngine;

public class Destroer : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        // ���������� ������ c ����� (Fruit), ����� �� ������� �� ������� ����� (Back Wall)
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
        }
    }
}
