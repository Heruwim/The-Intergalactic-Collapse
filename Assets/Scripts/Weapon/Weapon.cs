using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected float FireDelay = 0.8f;

    protected float NextFireTime;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }

    public void Reset()
    {
        _isBuyed = false;
    }
}
