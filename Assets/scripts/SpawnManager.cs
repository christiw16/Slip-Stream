using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
	public GameObject SkiffEnemy;
	public GameObject LaserEnemy;
	public int numEnemies;
	// Use this for initialization
	void Start ()
	{
		numEnemies = 0;
		StartCoroutine (EnemySpawn());
	}
	
	IEnumerator EnemySpawn()
	{
		while(numEnemies <= 10)
		{
			int EnemyType = Random.Range(0, 100);
			var position = new Vector3(Random.Range (-90, 90), transform.position.y, Random.Range (-90, 90));
			if(EnemyType < 60)
				Instantiate (SkiffEnemy, position, Quaternion.identity);
			else if(EnemyType < 90)
				Instantiate (LaserEnemy, position, Quaternion.identity);
			else
				Instantiate (LaserEnemy, position, Quaternion.identity);

			numEnemies++;
			yield return new WaitForSeconds(5f);
		}
	}
}
