using System;
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

    public float getAngle()
    {
        return angle;
    }

    public void setAngle(float newAngle)
    {
        angle = newAngle;
    }


    public float getPowder()
    {
        return powder;
    }

    public void setPowder(float newPowder)
    {
        powder = newPowder;
    }


    public string getCannonBall()
    {
        return cannonBall;
    }

    public void setCannonBall(string newCannonBall)
    {
        cannonBall = newCannonBall;
    }


    public string getHitTarget()
    {
        return hitTarget;
    }

    public void setHitTarget(string newHitTarget)
    {
        hitTarget = newHitTarget;
    }


    public float getShotDistance()
    {
        return shotDistance;
    }

    public void setShotDistance(float newShotDistance)
    {
        shotDistance = newShotDistance;
    }

}
