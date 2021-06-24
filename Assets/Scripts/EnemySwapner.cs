using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwapner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] enemyRecerence;

    public Transform leftPos,rightPos;

    private GameObject spawnedEnemy;

    private int randomIndex;
    private int randomSide;

    
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

   
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters(){
        while(true){
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex = Random.Range(0,enemyRecerence.Length);

            randomSide  = Random.Range(0,2);

            spawnedEnemy = Instantiate(enemyRecerence[randomIndex]);
            

            if(randomSide==0){
                spawnedEnemy.transform.position = leftPos.position;
                spawnedEnemy.GetComponent<EnemyLogic>().speed = Random.Range(4,10);
                
            }else{
                spawnedEnemy.transform.position = rightPos.position;
                spawnedEnemy.GetComponent<EnemyLogic>().speed = Random.Range(-4,-10);
                spawnedEnemy.transform.localScale = new Vector3(-1f,1f,1f);
            }
        }
    }
}
