// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Given an initial speed, what elevation angle is needed to hit a target at a specified height offset and flat distance away?")]
    public class ComputeElevationToHitTargetWithSpeed : FsmStateAction
    {

	    public FsmFloat heightOffset;
	    public FsmFloat distanceOffset;
	    public FsmFloat gravityNegative;
	    public FsmFloat speed;
	    public FsmBool useSmallerAngle;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmFloat angleRadians;
	    public float _angleRadians;

	    [UIHint(UIHint.Variable)]
	    public FsmBool canHit;

	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {


			everyFrame = false;

	    }


	    public override void OnEnter()
	    {

		    if (!everyFrame.Value)
		    {
			    doCalculations();
			    Finish();
		    }
		    
	    }
	    
	    
	    public override void OnUpdate()
	    {
		    if (everyFrame.Value)
		    {
			    doCalculations();
		    }
	    }
	    
	   
	    void doCalculations()
	    
	    {

		    canHit.Value = ProjectileHelper.ComputeElevationToHitTargetWithSpeed(heightOffset.Value, distanceOffset.Value, gravityNegative.Value, speed.Value, useSmallerAngle.Value, out _angleRadians);
		    angleRadians.Value = _angleRadians;

        }

    }
}
