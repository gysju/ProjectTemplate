using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IDamageDealer, IPulling
{
    public BulletData Data;
    private Rigidbody2D _rigi;

    #region DamageDealer interface
    public float GetDamageAMount()
    {
        return Data.DamageAmount;
    }
    #endregion

    #region IPulling interface
    private bool _isAvailable = false;

    public bool IsAvailable()
    {
        return _isAvailable;
    }

    #endregion
    private void Awake()
    {
        BulletManager.Instance.CurrentAliveBullets.Add(this);

        _rigi = GetComponent<Rigidbody2D>();
        if(Data.OnAwak != null && Data.OnAwak.GetPersistentEventCount() > 0)
            Data.OnAwak.Invoke();
    }

    private void Start()
    {
        _rigi.AddForce(Data.Velocity.Value * transform.forward, ForceMode2D.Force);
    }

    private void OnDisable()
    {
        _rigi.angularVelocity = 0.0f;
        _rigi.velocity = Vector2.zero;

        BulletManager.Instance.CurrentAliveBullets.Remove(this);

        if (Data.OnDest != null && Data.OnDest .GetPersistentEventCount() > 0)
            Data.OnDest.Invoke();
    }
}
