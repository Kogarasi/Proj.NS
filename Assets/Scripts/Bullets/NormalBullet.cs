using UnityEngine;

using Sparrow.Binding;

namespace NS.Bullet {

	[Prefab( "Prefabs/Bullets/NormalBullet" )]
	public class NormalBullet : Bullet<NormalBullet> {

		public override void move(){
			view.transform.Translate( 0, 1, 0 );
		}
	}
}