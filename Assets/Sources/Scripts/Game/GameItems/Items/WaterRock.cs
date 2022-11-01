using UnityEngine;

public class WaterRock : GameItem
{
    [Header("WaterRock")]
    public float startForce = 5f;
    public Transform spawnPoint;
    public GameObject waterBallPrefab;

    [Header("Pooling")]
    public int maxCount = 15;

    private Pool<WaterBall> _waterBallPool;

    private void Awake()
    {
        _waterBallPool = new Pool<WaterBall>(maxCount, waterBallPrefab, true);
    }

    public override void Action()
    {
        _waterBallPool.Get().Throw(spawnPoint.position, transform.forward * startForce);
    }
}
