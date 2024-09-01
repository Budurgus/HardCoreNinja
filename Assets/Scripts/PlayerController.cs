using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMovement = 15f;
    public float speedRotation = 45f;
    public GameObject attackTrigger;

    // �������� ������ � ���������
    private Collider triggerCollider;
    // ������ ��� �������� �������� � ����� "Fruit"
    private List<GameObject> fruitsInTrigger = new List<GameObject>();

    void Start()
    {
        // �������� ��������� ��������� �������
        triggerCollider = GetComponentInChildren<Collider>();
    }

    void Update()
    {
        // �������� ���� �� ������ WASD 
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // ��������� ����������� �������� 
        Vector3 movement = new Vector3(0f, 0f, verticalInput) * speedMovement * Time.deltaTime;
        Vector3 rotation = new Vector3(0f, horizontalInput, 0f) * speedRotation * Time.deltaTime;

        // ��������� �������� � ��������� 
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
        // ���������� ��� ������� � ����� "Fruit", ������� ��������� � ������
        foreach (GameObject fruit in fruitsInTrigger)
        {
            Destroy(fruit);
        }
        // ������� ������
        fruitsInTrigger.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        // ���������, ���� ������ � ����� "Fruit" ����� � �������
        if (other.CompareTag("Fruit"))
        {
            fruitsInTrigger.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ���� ������ � ����� "Fruit" ����� �� ��������, ������� ��� �� ������
        if (other.CompareTag("Fruit"))
        {
            fruitsInTrigger.Remove(other.gameObject);
        }
    }
}
