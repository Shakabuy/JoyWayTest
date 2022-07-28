using UnityEngine;

public class WaterRock : GameItem
{
    [Header("WaterRock")]
    public float StartForce = 5f;
    public Transform SpawnPoint;
    public GameObject WaterBallPrefab;

    [Header("Pooling")]
    public int MaxCount = 15;

    private Pool<WaterBall> WaterBallPool;

    private void Awake()
    {
        WaterBallPool = new Pool<WaterBall>(MaxCount, WaterBallPrefab, true);
    }

    public override void Action()
    {
        WaterBallPool.Get().Throw(SpawnPoint.position, transform.forward * StartForce);
    }
}
