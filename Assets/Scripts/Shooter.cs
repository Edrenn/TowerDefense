using Assets.Scripts;
using Assets.Scripts.Projectiles;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] List<Attacker> allTargetInSight = new List<Attacker>();
    [SerializeField] protected Attacker currentTarget;
    [SerializeField] protected Projectile projectile;
    [SerializeField] private int damage;
    [SerializeField] private float shootSpeed;
    private float range;
    protected Tower parent;

    private void Start()
    {
        parent = GetComponentInParent<Tower>();
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.speed = shootSpeed;
        }
    }

    private void Update()
    {
        if (IsTargetInSight() && currentTarget == null)
        {
            SetCurrentTarget();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker newAttacker = other.GetComponent<Attacker>();
        if (newAttacker)
        {
            if (!allTargetInSight.Contains(newAttacker))
            {
                allTargetInSight.Add(newAttacker);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Attacker newAttacker = other.GetComponent<Attacker>();
        if (newAttacker)
        {
            if (allTargetInSight.Contains(newAttacker))
            {
                allTargetInSight.Remove(newAttacker);
                if (newAttacker == currentTarget)
                {
                    currentTarget = null;
                    GetComponent<Animator>().SetBool("isTargetInSight", false);
                }
            }
        }
    }

    public void SetIdleSpeed()
    {
        Animator anim = GetComponent<Animator>();
        if (anim)
        {
            anim.speed = 1;
        }
    }

    public void SetShootSpeed()
    {
        Animator anim = GetComponent<Animator>();
        if (anim)
        {
            anim.speed = this.shootSpeed;
        }
    }

    public void Upgrade(int damageIncrease, float shootSpeedIncrease)
    {
        this.damage += damageIncrease;
        this.shootSpeed += shootSpeedIncrease;
    }

    public void Fire()
    {
        if (currentTarget)
        {
            Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.SetTarget(currentTarget);
            proj.SetDamage(damage);
            proj.parent = parent;

            if (!IsTargetInSight())
            {
                GetComponent<Animator>().SetBool("isTargetInSight", false);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("isTargetInSight", false);
        }
    }

    public void InitDamage(int damage)
    {
        this.damage = damage;
    }

    public void InitShootSpeed(float _shootSpeed)
    {
        shootSpeed = _shootSpeed;
    }

    public void InitRange(float _range)
    {
        range = _range;
        CircleCollider2D circleCollider2D = GetComponent<CircleCollider2D>();
        circleCollider2D.radius = range;
    }

    private void SetCurrentTarget()
    {
        currentTarget = allTargetInSight.First();
        GetComponent<Animator>().SetBool("isTargetInSight", true);
    }

    protected bool IsTargetInSight()
    {
        return allTargetInSight.Count > 0;
    }
}
