using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 2f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	
	public GameObject[] fishOptions;		// Array of enemy prefabs.
	public Transform[] spawnTransforms;
	public int[] fishCountBySize;	

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		//InvokeRepeating("Spawn", spawnDelay, spawnTime);
		for (int fishCountIndex = 0; fishCountIndex < fishCountBySize.Length; fishCountIndex++) {
			for (int spawnCount = 0; spawnCount < fishCountBySize[fishCountIndex]; spawnCount++) {
				int size = fishCountIndex + 1;

				float range = 12f;
				float split = range / ((float) (fishCountBySize[fishCountIndex] + 1));
				int slot = spawnCount + 1;
				float xPos = ((float)slot * split) + (-.5f * range);

				float yPos = .5f +(-1.25f * size);

				Vector2 newPosition = new Vector2( xPos, yPos);



				Spawn (size, newPosition);
			}
		}
	}
	
	void Spawn(int size, Vector2 newPosition)
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, fishOptions.Length);
//		int spawnerIndex = Random.Range (0, spawnTransforms.Length);

		GameObject fish = ( GameObject) Instantiate(fishOptions[enemyIndex], newPosition, transform.rotation);
		SpawnedFish fishScript = fish.GetComponent (typeof(SpawnedFish)) as SpawnedFish ;
		fishScript.setDirection ( (Random.Range(0,2) * 2) - 1 );
		fishScript.setSize (size);

	}
}