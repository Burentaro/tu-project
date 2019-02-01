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
    public Text displayText;
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
        addPowderBT.onClick.AddListener(LoadPowder);
        loadCannonBall.onClick.AddListener(LoadCB);
        fireCannon.onClick.AddListener(Shoot);
        addAngle.onClick.AddListener(AddAng);
        restAngle.onClick.AddListener(SubstractAngle);
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
        ShootHistory shootHistory = SceneManager.Instance.GetLastShoot();
        if (shootHistory != null)
        {

            displayText.text = "Last Shoot: Angle = " + shootHistory.GetAngle() + " Cannonball = " + shootHistory.GetCannonBall() + " Gunpowder = " + shootHistory.GetPowder() + " Shoot Distance = " + shootHistory.GetShotDistance();
        }
    }

    public void LoadPowder()
    {
        cannonController.AddPowder(500);
    }

    private void LoadCB()
    {
        cannonController.LoadCannonBall(cannonBall);
    }

    private void AddAng()
    {
        cannonController.AddCannonAngle(angleIncrement);
    }

    private void SubstractAngle()
    {
        cannonController.AddCannonAngle(- angleIncrement);
    }

    private void Shoot()
    {
        cannonController.Shoot();
    }
}
