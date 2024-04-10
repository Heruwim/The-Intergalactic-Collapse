using UnityEngine;

public abstract class BaseEntity: MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;


    public virtual void TakeDamage(int damage){
        _health -= damage;
        if(_health <= 0){
            Death();
        }
    }

    protected abstract void Death();
    protected abstract void Move();

}
