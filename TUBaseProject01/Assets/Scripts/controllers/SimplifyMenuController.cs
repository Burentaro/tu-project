using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplifyMenuController : MonoBehaviour
{
    public CannonController cannonController;
    public Text cannonBallText;
    public Text powderText;
    public Text cannonAngleText;
    public Button addPowderBT;
    public Button loadCannonBall;
    public Button fireCannon;
    public Button addAngle;
    public Button restAngle;
    public Rigidbody cannonBall;

    private float angleIncrement = 2;

    // Start is called before the first frame update
    void Start()
    {
        addPowderBT.onClick.AddListener(loadPowder);
        loadCannonBall.onClick.AddListener(loadCB);
        fireCannon.onClick.AddListener(shoot);
        addAngle.onClick.AddListener(addAng);
        restAngle.onClick.AddListener(substractAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (cannonController.isCannonballLoaded())
        {
            cannonBallText.text = "Loaded";
        } else
        {
            cannonBallText.text = "NONE";
        }

        cannonAngleText.text = cannonController.getCannonAngle() + "%";

        powderText.text = cannonController.getPowder() + " g";
    }

    public void loadPowder()
    {
        cannonController.addPowder(500);
    }

    private void loadCB()
    {
        cannonController.loadCannonball(cannonBall);
    }

    private void addAng()
    {
        cannonController.setCannonAngle(cannonController.getCannonAngle() + angleIncrement);
    }

    private void substractAngle()
    {
        cannonController.setCannonAngle(cannonController.getCannonAngle() - angleIncrement);
    }

    private void shoot()
    {
        cannonController.shoot();
    }
}
