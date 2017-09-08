using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;

namespace NS.View.Bullet {

	[Prefab( "Prefabs/Bullets/NormalBullet" )]
	public class NormalBulletView : BulletView {
		public override void move(){
			transform.Translate( 0, 2, 0 );
		}

		public override bool isDirty(){
			if( transform.localPosition.y > 700 ){
				return true;
			} else {
				return false;
			}
		}
	}
}