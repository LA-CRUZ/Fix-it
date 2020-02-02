using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Object_SyncPosition : NetworkBehaviour
{
    [SerializeField]
    private GameObject itemPrefab;
    // les dimension en x de l'arène
    [SerializeField]
    private int minX = -6;
    [SerializeField]
    private int maxX = 6;
    [SerializeField]
    private float timeBetweenSpawnNextItem = 4f;


    private Transform oldSpawnPosition;
    private float currentTime = 2f;
    private Transform spawnPosition;

    // pour savoir s'il faut encore générer des item1,2,3
    private int[] countItem;


    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform;
        oldSpawnPosition = spawnPosition;
        countItem = new int[3];

    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        { return; }

        if (!gameObject.GetComponent<Pattern>().isFinished)
        {
            if (currentTime <= 1f)
            {

                int aleaSpwn = Random.Range(0, 2); // pour ne pas faire spawn toute les 3 sec à chaque fois un item
                if (aleaSpwn == 0)
                {
                    countItem[0] = GameObject.FindGameObjectsWithTag("item1").Length;
                    countItem[1] = GameObject.FindGameObjectsWithTag("item2").Length;
                    countItem[2] = GameObject.FindGameObjectsWithTag("item3").Length;
                    int countAllItem = countItem[0] + countItem[1] + countItem[2];

                    if (countAllItem <= (gameObject.GetComponent<Pattern>().NB_ITEMS - 1))
                        SpawnObj();

                    currentTime = timeBetweenSpawnNextItem;
                }
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }

    }

    private void SpawnObj()
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

        int randomItemTag = Random.Range(1, 4);
        itemPrefab.tag = "item" + randomItemTag;
        // setTagItem(); // 
        cmdSpawnMyCrap();
        oldSpawnPosition = spawnPosition;
    }

    
    void cmdSpawnMyCrap()
    {
        GameObject go = Instantiate(itemPrefab, spawnPosition);
        NetworkServer.Spawn(go);
        Debug.Log("YAY MY ITEM SPAWN");
    }
}
