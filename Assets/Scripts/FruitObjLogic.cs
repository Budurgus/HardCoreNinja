using UnityEngine;

public class FruitObjLogic : MonoBehaviour
{
    public float speed = 5f; // �������� �������� � ������������
    public float speedRotation = 30f; // �������� �������� � ������������
    public GameObject[] friutsList; // ������ ������� �������
    public float timeDestroy = 10f;

    private GameObject visionPart; // ������ �� ������ ������ ������


    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0f, 360f)); // ��������� ������� ������������ ������ �� �����
        visionPart = Instantiate(friutsList[Random.Range(0, friutsList.Length)], transform); // ������� � �������� ������ � ���������� ������� ������ ������
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime); // ������ ����������� �������� � ��������.
                                                                    // ����� ��������� ������� �� �����, �� �������� ��������� � ������� ������, ���� �������� �� ����� (Back Wall).

        visionPart.transform.Rotate(speedRotation * Time.deltaTime, 0, 0); ; // ������ ��������� �������� ������ ������

        //���������� ������ ����� 10 ������ (���� ���-�� ��������� � �� �� ������ �����)
        timeDestroy -= Time.deltaTime;
        if (timeDestroy < 0f)
        {
            Destroy(gameObject);
        }
    }
}
