public class ShootHistory
{
    private float angle = 0;
    private float powder = 0;
    private string cannonBall;
    private string hitTarget = "";
    private float shotDistance = 0;

    public ShootHistory(float newAngle, float newPowder, string newCannonBall)
    {
        this.angle = newAngle;
        this.powder = newPowder;
        this.cannonBall = newCannonBall;
    }

    public float GetAngle()
    {
        return angle;
    }

    public void SetAngle(float newAngle)
    {
        angle = newAngle;
    }


    public float GetPowder()
    {
        return powder;
    }

    public void SetPowder(float newPowder)
    {
        powder = newPowder;
    }


    public string GetCannonBall()
    {
        return cannonBall;
    }

    public void SetCannonBall(string newCannonBall)
    {
        cannonBall = newCannonBall;
    }


    public string GetHitTarget()
    {
        return hitTarget;
    }

    public void SetHitTarget(string newHitTarget)
    {
        hitTarget = newHitTarget;
    }


    public float GetShotDistance()
    {
        return shotDistance;
    }

    public void SetShotDistance(float newShotDistance)
    {
        shotDistance = newShotDistance;
    }

}
