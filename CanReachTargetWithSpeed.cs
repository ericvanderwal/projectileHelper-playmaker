// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Given a start position, gravity and initial speed, can a projectile reach a target position?")]
    public class CanReachTargetWithSpeed : FsmStateAction
    {


	    public FsmVector3 startPosition;
	    public FsmVector3 targetPosition;
	    public FsmFloat gravityNegative;
	    public FsmFloat speed;
	    [UIHint(UIHint.Variable)]
	    public FsmBool canReachTarget;

		public FsmBool everyFrame;
	    
	    
	    public override void Reset()
	    {
		    
		    canReachTarget = false;
		    startPosition = null;
		    targetPosition = null;
			gravityNegative = null;
			speed = null;
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
	    	
		    canReachTarget.Value = ProjectileHelper.CanReachTargetWithSpeed(startPosition.Value, targetPosition.Value, gravityNegative.Value, speed.Value);   
           
        }

    }
}
