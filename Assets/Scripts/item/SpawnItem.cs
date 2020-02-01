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
        if( !gameObject.GetComponent<Pattern>().isFinished)
        {
            if (currentTime <= 1f)
            {

                int aleaSpwn = Random.Range(0, 2); // pour ne pas faire spawn toute les 3 sec à chaque fois un item
                if(aleaSpwn == 0)
                {
                    countItem[0] = GameObject.FindGameObjectsWithTag("item1").Length;
                    countItem[1] = GameObject.FindGameObjectsWithTag("item2").Length;
                    countItem[2] = GameObject.FindGameObjectsWithTag("item3").Length;
                    int countAllItem = countItem[0] + countItem[1] + countItem[2];

                    if (countAllItem <= ( gameObject.GetComponent<Pattern>().NB_ITEMS - 1))
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

        int randomItemTag = Random.Range(0, 3);
        itemPrefab.tag = "item" + randomItemTag;
        // setTagItem(); // a utiliser quand après que Pattern soit appelé
        Instantiate(itemPrefab, spawnPosition.position, spawnPosition.rotation);
        oldSpawnPosition = spawnPosition;
    }


    private void setTagItem ()
    {
        bool isDone = false;
        int randomItemTag = Random.Range(0, 3);

        while (!isDone) {
            if (countItem[randomItemTag] > 0)
            {
                isDone = true;
                countItem[randomItemTag] = countItem[randomItemTag] - 1;

                switch (randomItemTag)
                {
                    case 0:
                        itemPrefab.tag = "item1";
                        break;
                    case 1:
                        itemPrefab.tag = "item2";
                        break;
                    case 2:
                        itemPrefab.tag = "item3";
                        break;
                    default:
                        break;
                }
            }else
            {
                randomItemTag = Random.Range(0, 3);
            }
        }
    }
}
