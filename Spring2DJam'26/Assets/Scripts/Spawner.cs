using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform shapePrefab;
    [SerializeField] float spawnTime = 3f;

    float timer = 0f;

    void Update()
    {
        if (timer <= 0f)
        {
            SpawnShape();
            ChangeSpawnTime();
            timer = spawnTime;
        }
        else timer -= Time.deltaTime;
    }
    float CreateSpawnPointOffscreen()
    {
        float rng1 = Random.Range(1f, 1.1f);
        float rng2 = Random.Range(0f, -0.1f);
        int rng = Random.Range(0, 2);
        float rngPos = rng == 0 ? rng1 : rng2;
        return rngPos;
    }
    void SpawnShape()
    {
        float positionX = 0f;
        float positionY = 0f;
        int rng = Random.Range(0, 2);
        if (rng == 0)
        {
            positionX = CreateSpawnPointOffscreen();
            positionY = Random.Range(-0.1f, 1.1f);
        }
        else
        {
            positionX = Random.Range(-0.1f, 1.1f);
            positionY = CreateSpawnPointOffscreen();
        }
        Instantiate(shapePrefab, Camera.main.ViewportToWorldPoint(new Vector3(positionX, positionY, Camera.main.nearClipPlane)), Quaternion.identity);
    }
    void ChangeSpawnTime()
    {
        switch (GameManager.Instance.GetFollowersNumber())
        {
            case 50:
                spawnTime = 2.5f;
                break;
            case 100:
                spawnTime = 2f;
                break;
            case 150:
                spawnTime = 1.5f;
                break;
            case 200:
                spawnTime = 1f;
                break;
            case 250:
                spawnTime = 0.5f;
                break;
        }
    }
}