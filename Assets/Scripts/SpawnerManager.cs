using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]GameObject elevatorPref;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float maxY, minY;
    void Start()
    {
            
    }
    void Update()
    {
        
    }
    public void InstantElevator()
    {
        
        Instantiate(elevatorPref, new Vector2(spawnPoint.position.x,Random.Range(minY,maxY)), Quaternion.identity);
    }
}
