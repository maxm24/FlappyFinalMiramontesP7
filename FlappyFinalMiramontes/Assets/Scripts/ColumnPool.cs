using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;

    public float spawnRate = 4f; //how fast my columns will generate
    public float columnMin = -1f; // min y val of columns
    public float columnMax = 3.5f; //max y val of columns

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f); //somewhat a holding position for unused columns

    private float timeSinceLastSpawned;
    private float SpawnXPosition = 10f;

    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.Instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned= 0;
            float spawnYPosition = Random.Range (columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2 (SpawnXPosition, spawnYPosition);
            //So, if new size of the column is too big, it'll reset it back to 0
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
