// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Given a maximum range (on flat ground) and gravity, what is the maximum speed the projectile can be launched?")]
    public class ComputeSpeedToReachMaxFlatRange : FsmStateAction
    {

	    public FsmFloat range;
	    public FsmFloat gravityNegative;
	    [UIHint(UIHint.Variable)]
	    public FsmFloat timeToLand;
	    [UIHint(UIHint.Variable)]
	    public FsmFloat speed;
	    private float _timeToLand = 0f;


	    public FsmBool everyFrame;
	    
	    
	    public override void Reset()
	    {
		    
		    range = null;
		    gravityNegative = null;
		    timeToLand = null;
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
	    	
		    var _range = range.Value;
		    var _gravity = gravityNegative.Value;
		    speed.Value = ProjectileHelper.ComputeSpeedToReachMaxFlatRange(_range, _gravity, out _timeToLand);
		    timeToLand.Value =  _timeToLand;
		    

           
        }

    }
}
