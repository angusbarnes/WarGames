using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTemp : MonoBehaviour {

    [Space(10)]
    [Header("Spawn Zone")]
    public Transform[] Points;

    [Header("Spawns")]
    public Spawnable[] spawnables;

    private void OnEnable()
    {
        CombatManager.Clear();
    }

    // Use this for initialization
    void Start () {

        for (int i = 0; i < spawnables.Length; i++) {
            
            Spawnable spawn = spawnables[i];
            for(int roll = 0; roll < spawn.rolls; roll++) {
                if (Random.Range(0f, 1f) <= spawn.Chance) {
                    spawn.Spawn(Points);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(0);
        }
    }
}
