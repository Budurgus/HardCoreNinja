using UnityEngine;

public class SpawnObj : MonoBehaviour
{   
    public GameObject obj;
    public GameObject[] spawnsObj;
    public float updateTimer = 5f;
    public float timer = 5f;

    void Update()
    {
        // ������ 5 ������ ������� ������ � ����� �� �����-������
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Instantiate(obj, spawnsObj[Random.Range(0, spawnsObj.Length)].transform);

            timer = updateTimer;
        }
    }
}
