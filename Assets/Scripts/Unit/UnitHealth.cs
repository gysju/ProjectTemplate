using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    [Header("Unit settings")]

    public FloatVariable HP;

    public bool ResetHP;
    public FloatReference StartingHP;
    public UnityEvent DamageEvent;
    public UnityEvent DeathEvent;

    private void Start()
    {
        if (ResetHP)
            HP.SetValue(StartingHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageDealer damage = other.gameObject.GetComponent<IDamageDealer>();
        if (damage != null)
        {
            HP.ApplyChange(-damage.GetDamageAMount());
            DamageEvent.Invoke();
        }

        if (HP.Value <= 0.0f)
        {
            DeathEvent.Invoke();
        }
    }
}
