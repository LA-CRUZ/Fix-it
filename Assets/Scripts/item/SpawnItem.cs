using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    private Transform itemPrefab;
    // les dimension en x de l'arène
    [SerializeField]
    private int minX = -6;
    [SerializeField]
    private int maxX = 6;
    [SerializeField]
    private float timeBetweenSpawnNextItem = 2f;
    
    public bool stopSpawn = false;

    private Transform oldSpawnPosition;
    private float currentTime = 2f;
    private Transform spawnPosition;

    public int nbItem;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform;
        oldSpawnPosition = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if( !stopSpawn)
        {
            if (currentTime <= 0f)
            {
                int countItem1 = GameObject.FindGameObjectsWithTag("item1").Length;
                int countItem2 = GameObject.FindGameObjectsWithTag("item2").Length;
                int countItem3 = GameObject.FindGameObjectsWithTag("item3").Length;

                int countAllItem = countItem1 + countItem2 + countItem3;

                if (countAllItem <= nbItem)
                    SpawnObj();

                currentTime = timeBetweenSpawnNextItem;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
        
    }

    private void SpawnObj ()
    {
        if (oldSpawnPosition.position.x == 0)
        {
            spawnPosition.position = new Vector3(Random.Range(minX / 2, maxX / 2), spawnPosition.position.y, spawnPosition.position.z);
        }
        else
        {
            if (oldSpawnPosition.position.x < 0)
                spawnPosition.position = new Vector3(Random.Range(0, maxX), spawnPosition.position.y, spawnPosition.position.z);
            else
                spawnPosition.position = new Vector3(Random.Range(minX, 0), spawnPosition.position.y, spawnPosition.position.z);
        }
        print(spawnPosition.position);
        int randomItemTag = Random.Range(1, 4);
        itemPrefab.tag = "item" + randomItemTag;
        Instantiate(itemPrefab, spawnPosition.position, spawnPosition.rotation);
        oldSpawnPosition = spawnPosition;
    }
}
