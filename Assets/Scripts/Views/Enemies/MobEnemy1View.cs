using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;

namespace NS.View.Enemy {
	
	[Prefab("Prefabs/Enemies/MobEnemy1")]
	public class MobEnemy1View : EnemyView {
		public override void move(){
			transform.Translate( 0, -1, 0 );
		}
	}
}