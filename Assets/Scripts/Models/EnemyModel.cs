using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Interface;

namespace NS.Model {
	public class EnemyModel : Sparrow.Model<EnemyModel>, Updatable {
		Model.PrefabCacheModel prefabCacheModel = Model.PrefabCacheModel.instance;
		List<View.Enemy.EnemyView> enemies = new List<View.Enemy.EnemyView>();

		public void spawn( Type enemyType, Vector2 position ){
			var view = createView( enemyType, position );
			enemies.Add( view );
		}
		public void update(){
			// enemies = enemies.where( (x) => { x.move; return x.isDirty(); } );
			enemies.ForEach( x => x.move() );
		}

		public View.Enemy.EnemyView createView( Type type, Vector2 position ){
			var path = getPrefabPathFromAttribute( type );
			var prefab = prefabCacheModel.get( path );
			var go = GameObject.Instantiate( prefab, View.Container.EnemyContainerView.instance.transform, false ) as GameObject;

			go.transform.localPosition = new Vector3( position.x, position.y, 0 );

			return go.GetComponent<View.Enemy.EnemyView>();
		}
	}
}