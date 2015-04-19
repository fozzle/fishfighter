using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 2f;		// The amount of time between each spawn.
	public float spawnDelay = 0f;		// The amount of time before spawning starts.
	
	public GameObject[] fishOptions;		// Array of enemy prefabs.
	public Transform[] spawnTransforms;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, fishOptions.Length);
		int spawnerIndex = Random.Range (0, spawnTransforms.Length);

		GameObject fish = ( GameObject) Instantiate(fishOptions[enemyIndex], new Vector2(spawnTransforms[spawnerIndex].position.x, -1f +(-3f * Random.value)), transform.rotation);
		SpawnedFish fishScript = fish.GetComponent (typeof(SpawnedFish)) as SpawnedFish ;
		fishScript.setDirection (spawnerIndex == 0 ? 1 : -1);
	}
}