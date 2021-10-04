using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Padi = 0,
    AirSabun = 1,
    Jaring = 2,
    Plastik = 3,
    Bebek = 4,
    BurungHantu = 5,
    Ular = 6
}

public static class GameData
{
  public static Canvas MainMenuCanvas;
  public static readonly int[] MAX_ENEMY_SPAWN = new int[] {7, 15, 17, 22, 25};
  public static readonly int[] WIN_REWARD = new int[] {100, 150, 200, 300, 500};
  public static int[] TrapRank = new int[] {1, 1, 1, 1, 1, 1, 1};
  public static int SELECTED_STAGE = 0;

  public static int ENEMY_KILLED = 0;

  

  public static void UponRestart()
	{
	  ENEMY_KILLED = 0;
	}


}
