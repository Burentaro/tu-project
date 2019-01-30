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
    public string cannonBall;

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
        if (cannonController.IsCannonBallLoaded)
        {
            cannonBallText.text = "Loaded";
        } else
        {
            cannonBallText.text = "NONE";
        }

        cannonAngleText.text = cannonController.GetCannonAngle() + "%";

        powderText.text = cannonController.GetPowder() + " g";
    }

    public void loadPowder()
    {
        cannonController.AddPowder(500);
    }

    private void loadCB()
    {
        cannonController.LoadCannonBall(cannonBall);
    }

    private void addAng()
    {
        cannonController.AddCannonAngle(angleIncrement);
    }

    private void substractAngle()
    {
        cannonController.AddCannonAngle(- angleIncrement);
    }

    private void shoot()
    {
        cannonController.Shoot();
    }
}
