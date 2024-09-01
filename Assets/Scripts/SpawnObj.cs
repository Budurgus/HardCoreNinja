using UnityEngine;

public class SpawnObj : MonoBehaviour
{   
    public GameObject obj;
    public GameObject[] spawnsObj;
    public float updateTimer = 5f;
    public float timer = 5f;

    void Update()
    {
        // Каждые 5 секунд создаем объект в одном из спавн-поинте
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            Instantiate(obj, spawnsObj[Random.Range(0, spawnsObj.Length)].transform);

            timer = updateTimer;
        }
    }
}
