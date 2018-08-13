using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{

    public float MaxDistance = 10.0f;
    public static BulletManager Instance;

    [HideInInspector]
    public List<Bullet> CurrentAliveBullets = new List<Bullet>();
    private List<Bullet> bulletsToDestroy = new List<Bullet>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        checkBulletPosition();
        cleanBulletList();
    }

    void checkBulletPosition()
    {
        foreach (Bullet bullet in CurrentAliveBullets)
        {
            if (bullet.transform.position.magnitude > MaxDistance) // 
            {
                bulletsToDestroy.Add(bullet);
            }
        }
    }

    void cleanBulletList()
    {
        foreach (Bullet bullet in bulletsToDestroy)
        {
            CurrentAliveBullets.Remove(bullet);
            Destroy(bullet.gameObject);
        }

        bulletsToDestroy.Clear();
    }
}
