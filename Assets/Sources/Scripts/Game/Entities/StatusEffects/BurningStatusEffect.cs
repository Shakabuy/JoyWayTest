using UnityEngine;

public class BurningStatusEffect : StatusEffect
{
    [Header("Burning")]
    public int DamageCount = 10;
    public float Interval = 1f;
    public Color Color = Color.red;
    public DamageInfo DamageInfo;

    private int CurrentCount = 0;
    private float Timer = 0f;

    public override void Activate()
    {
        base.Activate();
        Entity.Render.SetColor(Color);
        CurrentCount = DamageCount;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Entity.Render.ToDefault();
        CurrentCount = 0;
        Timer = 0f;
    }


    public override void UpdateState(float dt)
    {
        if (IsActive)
        {
            if (CurrentCount > 0)
            {
                Timer += dt;

                if (Timer >= 1f)
                {
                    CurrentCount--;
                    Timer = 0f;
                    Entity.Damage(DamageInfo);
                }
            }
            else { Deactivate(); }
        }
    }
}