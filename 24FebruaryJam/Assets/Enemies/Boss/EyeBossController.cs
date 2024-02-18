using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EyeBossController : EnemyController
{
    public List<GameObject> RingParts = new();

    public GameObject RingHolder;

    private int nrPhasesTotal = 4;
    private int currentPhase;
    private float eachPhaseMaxHP;

    public bool IsPhaseChanging = false;
    public bool IsInvincible = false;
    private WaitForSecondsRealtime phaseChangeDelayTime = new WaitForSecondsRealtime(10f);

    public GameObject EyeGO;
    
    public GameObject BodyOneGO;
    public GameObject BodyTwoGO;
    public GameObject BodyThreeGO;

    public GameObject LastBody;
    public DefaultGun DefaultGun { get; private set; } = new DefaultGun();
    public BossProjectile DefaultProjectile;

    private float timeStamp;
    private float cooldownPeriodInSeconds = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyStats.MaxHP.BaseValue = 800;
        EnemyStats.CurrentHP = EnemyStats.MaxHP.Value;

        eachPhaseMaxHP = EnemyStats.MaxHP.BaseValue / nrPhasesTotal;
        currentPhase = 1;
    }

    private void FixedUpdate()
    {
        RingHolder.transform.RotateAround(transform.position, Vector3.up, Time.fixedDeltaTime * 100f);

        if (EnemyStats.CurrentHP < eachPhaseMaxHP * (nrPhasesTotal - currentPhase) && !IsPhaseChanging)
        {
            PhaseChange();
        }

        if (IsPhaseChanging)
        {
            EnemyStats.CurrentHP = eachPhaseMaxHP * (nrPhasesTotal - currentPhase + 1);
            Debug.Log("Reset HP " + EnemyStats.CurrentHP);
            //PhaseChangeProcess(currentPhase);
        }
        else 
        {
            PhaseBehaviour(currentPhase);
        }
    }

    void PhaseChange()
    {
        if ( currentPhase >= nrPhasesTotal) { return;}
        currentPhase += 1;
        Debug.Log("PhaseChangeStart");
        IsPhaseChanging = true;
        StartCoroutine(ChangingPhase());
    }

    IEnumerator ChangingPhase()
    {
        IsInvincible = true;
        Debug.Log("InChangeCoroutine");
        PhaseChangeProcess(currentPhase);

        yield return phaseChangeDelayTime;

        IsInvincible = false;
        IsPhaseChanging = false;
    }

    void PhaseChangeProcess(int thisPhase)
    {
        //EnemyStats.CurrentHP = eachPhaseMaxHP * (nrPhasesTotal - currentPhase + 1);

        switch (thisPhase)
        {
            case 2:
                PhaseOneToTwo();
                break;

            case 3:
                PhaseTwoToThree();
                break;

            case 4:
                PhaseThreeToFour();
                break;

            default:
                break;
        }
    }

    void PhaseOneToTwo()
    {
        Debug.Log("PhaseOneToTwo");
        Vector3 moveBody = new Vector3 (0, 0.8f, 0);
       if(BodyOneGO != null)
       {
            BodyOneGO.gameObject.SetActive(false);

            EyeGO.transform.position -= moveBody;
       }
    }

    void PhaseTwoToThree()
    {
        Vector3 moveBody = new Vector3(0, 0.8f, 0);
        if (BodyTwoGO != null)
        {
            BodyTwoGO.gameObject.SetActive(false);

            EyeGO.transform.position -= moveBody;
        }
    }

    void PhaseThreeToFour()
    {
        Vector3 moveBody = new Vector3(0, 0.8f, 0);
        if (BodyThreeGO != null)
        {
            BodyThreeGO.gameObject.SetActive(false);

            EyeGO.transform.position -= moveBody;
        }
    }

    void PhaseBehaviour(int thisPhase)
    {
        switch (thisPhase)
        {
            case 1:
                PhaseOne();
                break;

            case 2:
                PhaseTwo();
                break;

            case 3:
                PhaseThree();
                break;

            case 4:
                PhaseFour();
                break;

            default:
                break;
        }
    }

    void PhaseOne()
    {
        if (timeStamp <= Time.time)
        {
            BossProjectile projectile = ObjectPooler.DequeuObject<BossProjectile>("BossDefaultProjectile");
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.identity;
            projectile.Damage = DefaultGun.Damage.Value;
            projectile.RB.linearVelocity = Vector3.forward * DefaultGun.ProjectileSpeed.Value;
            projectile.gameObject.SetActive(true);

            timeStamp = Time.time + cooldownPeriodInSeconds;
        }
    }

    void PhaseTwo()
    {
        if (timeStamp <= Time.time)
        {
            BossProjectile projectile = ObjectPooler.DequeuObject<BossProjectile>("BossDefaultProjectile");
            projectile.transform.position = transform.position;
            projectile.transform.rotation = Quaternion.identity;
            projectile.Damage = DefaultGun.Damage.Value;
            projectile.RB.linearVelocity = Vector3.forward * DefaultGun.ProjectileSpeed.Value;
            projectile.gameObject.SetActive(true);

            timeStamp = Time.time + cooldownPeriodInSeconds;
        }
    }

    void PhaseThree()
    {
        
    }

    void PhaseFour()
    {
        
    }
}
