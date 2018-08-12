using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, DamageDealer
{
    [Header("Bullet")]
    public BulletData Data;
    private Rigidbody2D _rigi;

    #region DamageDealer interface
    public float GetDamageAMount()
    {
        return Data.DamageAmount;
    }
    #endregion

    private void Awake()
    {
        _rigi = GetComponent<Rigidbody2D>();
        if(Data.OnAwak != null && Data.OnAwak.GetPersistentEventCount() > 0)
            Data.OnAwak.Invoke();
    }

    private void Start()
    {
        _rigi.AddForce(Data.Velocity.Value * transform.forward, ForceMode2D.Force);
    }

    private void OnDestroy()
    {
        if (Data.OnDest != null && Data.OnDest .GetPersistentEventCount() > 0)
            Data.OnDest.Invoke();
    }
}
