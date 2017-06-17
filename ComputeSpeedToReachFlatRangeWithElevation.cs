// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Determine the speed needed to reach a certain range (on flat ground) given a starting elevation")]
    public class ComputeSpeedToReachFlatRangeWithElevation : FsmStateAction
    {

	    public FsmFloat elevationRadians;
	    public FsmFloat range;
	    public FsmFloat gravityNegative;
	    
	    
	    [UIHint(UIHint.Variable)]
	    public FsmFloat speed;
	    private float _speed;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmBool canHit;
	    
	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {
		    
		    elevationRadians = null;
		    range = null;
		    gravityNegative = null;
		    speed = null;
		    canHit = null;
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
		    canHit.Value = ProjectileHelper.ComputeSpeedToReachFlatRangeWithElevation(elevationRadians.Value, range.Value, gravityNegative.Value, out _speed);
		    speed.Value = _speed;
		    
        }

    }
}
