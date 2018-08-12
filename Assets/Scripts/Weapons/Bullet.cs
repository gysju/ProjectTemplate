using UnityEngine;
using UnityEngine.Events;

public class Bullet : DamageDealer
{
    [Header("Bullet")]
    public BulletData Data;
    private Rigidbody2D _rigi;

    private void Awake()
    {
        _rigi = GetComponent<Rigidbody2D>();
        Data.OnAwak.Invoke();
    }

    private void Start()
    {
        _rigi.AddForce(Data.Velocity.Value * transform.forward, ForceMode2D.Force);
    }

    private void OnDestroy()
    {
        Data.OnDest.Invoke();
    }
}
