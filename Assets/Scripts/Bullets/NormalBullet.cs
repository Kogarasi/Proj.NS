using System;
using UnityEngine;

using Sparrow.Binding;

namespace NS.Bullet {

	[Prefab( "Prefabs/Bullets/NormalBullet" )]
	public class NormalBullet : Bullet<NormalBullet, View.NormalBulletView> {

		public override void move(){
			position = position + new Vector2( 0, 1 );
			view.transform.Translate( 0, 1, 0 );
		}

		public override bool isDirty(){
			var abs_x = Math.Abs( position.x );
			var abs_y = Math.Abs( position.y );

			var dirtyFlag = false;
			if( abs_x > Config.resolution.x/2 ){
				dirtyFlag = true;
			}
			if( abs_y > Config.resolution.y/2 ){
				dirtyFlag = true;
			}
			
			return dirtyFlag;
		}
	}
}