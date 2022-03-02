using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform posDribble;
    [SerializeField] private Transform posOverHead;
    [SerializeField] private Transform arms;
    [SerializeField] private Transform basket;
    
    private bool ballInArms = true;
    private bool ballFlying = false;
    private float time = 0f;
    
    private void Update()
    {
        #region BallInArms
        if (ballInArms)
        {
            #region BallHoldOverHead
            if (Input.GetKey(KeyCode.Space))
            {
                ball.position = posOverHead.position;
                arms.localEulerAngles = Vector3.right * 180;
                transform.LookAt(basket.parent.position);
            }
            #endregion
            #region Dribbling
            else
            {
                ball.position = posDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                arms.localEulerAngles = Vector3.right * 0;
            }
            #endregion
            #region BallThrow
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ballInArms = false;
                ballFlying = true;
                time = 0f;
            }
            #endregion
        } 
        #endregion

        #region BallInAir
        if (ballFlying)
        {
            time += Time.deltaTime;
            float duration = 0.66f;
            float ballTravel = time / duration;
            Vector3 ballOverHead = posOverHead.position;
            Vector3 basketPos = basket.position;
            Vector3 pos = Vector3.Lerp(ballOverHead, basketPos, ballTravel);
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(ballTravel * 3.14f);
            ball.position = pos + arc;
            if (ballTravel >= 1)
            {
                ballFlying = false;
                ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        } 
        #endregion
    }
    #region PickUpBall
    private void OnTriggerEnter(Collider other)
    {
        if (!ballInArms && !ballFlying)
        {
            ballInArms = true;
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    #endregion
}
