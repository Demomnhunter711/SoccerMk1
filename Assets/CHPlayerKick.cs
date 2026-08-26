using UnityEngine.UI;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public Rigidbody ball;

    public float minKickPower = 5f;
    public float maxKickPower = 20f;
    public float chargeSpeed = 10f;
    public float kickRange = 2f;
    public Slider powerBar;

    private float currentKickPower;
    private bool isCharging = false;
    private bool chargingUp = true;

    void Start()
{
    currentKickPower = minKickPower;

    powerBar.minValue = minKickPower;
    powerBar.maxValue = maxKickPower;
    powerBar.value = minKickPower;

}

    void Update()
    {
        float distance = Vector3.Distance(
            transform.position,
            ball.transform.position
        );

        // Start charging
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
            currentKickPower = minKickPower;
            chargingUp = true;
            // powerBar.gameObject.SetActive(true);
        }

        // Keep charging while Space is held
        if (Input.GetKey(KeyCode.Space) && isCharging)
        {
            if (chargingUp)
            {
                currentKickPower += chargeSpeed * Time.deltaTime;

                if (currentKickPower >= maxKickPower)
                {
                    currentKickPower = maxKickPower;
                    chargingUp = false;
                }

            }
            else
            {
                currentKickPower -= chargeSpeed* Time.deltaTime;

                if(currentKickPower <= minKickPower)
                {
                    currentKickPower = minKickPower;
                    chargingUp = true;
                }
            }

            // currentKickPower = Mathf.Clamp(
            //     currentKickPower,
            //     minKickPower,
            //     maxKickPower
            // );

            powerBar.value = currentKickPower;
        }

        // Kick when Space is released
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            if(distance <= kickRange)
            {
               Vector3 kickDirection = transform.forward;

            ball.AddForce(
                kickDirection * currentKickPower,
                ForceMode.Impulse
            ); 
            }
    
            isCharging = false;
            currentKickPower = minKickPower;
            powerBar.value = minKickPower;
        }
    }
}