using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    AirSabun = 1,
    Jaring = 2,
    Plastik = 3,
    Bebek = 4,
    BurungHantu = 5,
    Ular = 6
}

public static class GameData
{
  public static readonly int[] MAX_ENEMY = new int[] {7, 15, 17, 22, 25};
  public static int[] TrapRank = new int[] {1, 1, 1, 1, 1, 1};



  public static int currentEnemy = 0;


}
