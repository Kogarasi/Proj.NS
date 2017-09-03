using System;
using UnityEngine;

using Sparrow.Rx;
using Sparrow.Interface;

namespace NS.Model {
  public class PlayerModel: Sparrow.Model<PlayerModel>, Updatable {
    Model.BulletModel bulletModel = Model.BulletModel.instance;

    public Variable<int> life = new Variable<int>( 100 );
    public Variable<float> speed = new Variable<float>( Config.normalSpeed );
    public Variable<Vector2> position = new Variable<Vector2>( Vector2.zero );

    bool isEmit = false;
    int emitWaitCounter = 0;

    public void update(){
      if( emitWaitCounter > 0 ){
        emitWaitCounter--;
      }

      if( isEmit && emitWaitCounter == 0 ){
        emitWaitCounter = 30;
        bulletModel.emit( typeof(Bullet.NormalBullet), position.value );
      }
    }

    public void setEmitStatus( bool state ){
      this.isEmit = state;
    }
    public void move( Vector2 moveRawDelta ){
      var newPosition = position.value + (speed.value * moveRawDelta);
      newPosition.x = Mathf.Clamp( newPosition.x, -350, 350 );
      newPosition.y = Mathf.Clamp( newPosition.y, -625, 625 );

      position.value = newPosition;
    }
  }
}