using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Interface;

namespace NS.Model {
  public class EnemyModel : Sparrow.Model<EnemyModel>, Updatable {
    PrefabCacheModel<GameObject> prefabCacheModel = PrefabCacheModel<GameObject>.instance;
    List<Enemy.Enemy> enemies = new List<Enemy.Enemy>();

    public void update(){
      enemies.ForEach( x => x.transform.Translate( 0, -0.01f, 0 ) );
    }
  }
}