using UnityEngine;

public class BurningStatusEffect : StatusEffect
{
    [Header("Burning")]
    public int damageCount = 10;
    public float interval = 1f;
    public Color color = Color.red;
    public DamageInfo damageInfo;

    private int _currentCount = 0;
    private float _timer = 0f;

    public override void Activate()
    {
        base.Activate();
        Entity.render.SetColor(color);
        _currentCount = damageCount;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Entity.render.ToDefault();
        _currentCount = 0;
        _timer = 0f;
    }


    public override void UpdateState(float dt)
    {
        if (IsActive)
        {
            if (_currentCount > 0)
            {
                _timer += dt;

                if (_timer >= 1f)
                {
                    _currentCount--;
                    _timer = 0f;
                    Entity.Damage(damageInfo);
                }
            }
            else { Deactivate(); }
        }
    }
}