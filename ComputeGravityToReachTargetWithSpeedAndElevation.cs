// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Determine the gravity needed to reach a target distance and height with a given speed and elevation angle")]
    public class ComputeGravityToReachTargetWithSpeedAndElevation : FsmStateAction
    {

	    public FsmFloat distanceOffset;
	    public FsmFloat heightOffset;
	    public FsmFloat elevationRadians;
	    public FsmFloat speed;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmFloat nessesaryGravity;

	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {
		    distanceOffset = null;
		    heightOffset = null;
		    elevationRadians = null;
		    speed = null;
		    nessesaryGravity = null;
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

		    nessesaryGravity.Value = ProjectileHelper.ComputeGravityToReachTargetWithSpeedAndElevation(distanceOffset.Value, heightOffset.Value, elevationRadians.Value, speed.Value);

        }

    }
}
