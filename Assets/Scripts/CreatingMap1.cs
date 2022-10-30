using Scripts.BoardLogic;
using UnityEngine;

public class CreatingMap1 : MonoBehaviour
{
    public int shoiseMap;


    void Start()
    {
        shoiseMap = 1;
        shoiseMaps();
        
    }

    void shoiseMaps()
    {

        if (shoiseMap == 1)
        {
            #region машина
            for (int i = 0; i < 5; i++) 
            {
                for (int j = 302+i*20; j < 305+i*20; j++)
                {
                    BoardGrid.GetInstance().Cells[j].GetComponent<ContentTail>().content.Add(Content.car);
                }
            }
            #endregion машина

            #region двери машины
            BoardGrid.GetInstance().Cells[345].GetComponent<ContentTail>().content.Add(Content.doorCar);
            BoardGrid.GetInstance().Cells[341].GetComponent<ContentTail>().content.Add(Content.doorCar);
            #endregion

            #region окна
            BoardGrid.GetInstance().Cells[115].GetComponent<ContentTail>().content.Add(Content.windowsRight);
            BoardGrid.GetInstance().Cells[135].GetComponent<ContentTail>().content.Add(Content.windowsLeft);
            BoardGrid.GetInstance().Cells[336].GetComponent<ContentTail>().content.Add(Content.windowsRight);
            BoardGrid.GetInstance().Cells[356].GetComponent<ContentTail>().content.Add(Content.windowsLeft); 
            BoardGrid.GetInstance().Cells[337].GetComponent<ContentTail>().content.Add(Content.windowsRight);
            BoardGrid.GetInstance().Cells[357].GetComponent<ContentTail>().content.Add(Content.windowsLeft);
            BoardGrid.GetInstance().Cells[330].GetComponent<ContentTail>().content.Add(Content.windowsRight);
            BoardGrid.GetInstance().Cells[350].GetComponent<ContentTail>().content.Add(Content.windowsLeft);
            BoardGrid.GetInstance().Cells[331].GetComponent<ContentTail>().content.Add(Content.windowsRight);
            BoardGrid.GetInstance().Cells[351].GetComponent<ContentTail>().content.Add(Content.windowsLeft);
            #endregion

            #region двери
            BoardGrid.GetInstance().Cells[111].GetComponent<ContentTail>().content.Add(Content.doorRight);
            BoardGrid.GetInstance().Cells[131].GetComponent<ContentTail>().content.Add(Content.doorLeft);
            BoardGrid.GetInstance().Cells[193].GetComponent<ContentTail>().content.Add(Content.doorRight);
            BoardGrid.GetInstance().Cells[213].GetComponent<ContentTail>().content.Add(Content.doorLeft);
            BoardGrid.GetInstance().Cells[333].GetComponent<ContentTail>().content.Add(Content.doorRight);
            BoardGrid.GetInstance().Cells[353].GetComponent<ContentTail>().content.Add(Content.doorLeft);

            BoardGrid.GetInstance().Cells[165].GetComponent<ContentTail>().content.Add(Content.doorUp);
            BoardGrid.GetInstance().Cells[166].GetComponent<ContentTail>().content.Add(Content.doorDown);
            BoardGrid.GetInstance().Cells[212].GetComponent<ContentTail>().content.Add(Content.doorUp);
            BoardGrid.GetInstance().Cells[213].GetComponent<ContentTail>().content.Add(Content.doorUp);
            BoardGrid.GetInstance().Cells[213].GetComponent<ContentTail>().content.Add(Content.doorDown);
            BoardGrid.GetInstance().Cells[214].GetComponent<ContentTail>().content.Add(Content.doorDown);
            BoardGrid.GetInstance().Cells[247].GetComponent<ContentTail>().content.Add(Content.doorUp);
            BoardGrid.GetInstance().Cells[248].GetComponent<ContentTail>().content.Add(Content.doorDown);
            #endregion

            #region поиск
            BoardGrid.GetInstance().Cells[82].GetComponent<ContentTail>().content.Add(Content.find);
            BoardGrid.GetInstance().Cells[178].GetComponent<ContentTail>().content.Add(Content.find);
            BoardGrid.GetInstance().Cells[210].GetComponent<ContentTail>().content.Add(Content.find);
            BoardGrid.GetInstance().Cells[234].GetComponent<ContentTail>().content.Add(Content.find);
            BoardGrid.GetInstance().Cells[338].GetComponent<ContentTail>().content.Add(Content.find);
            BoardGrid.GetInstance().Cells[383].GetComponent<ContentTail>().content.Add(Content.find);
            #endregion

            #region дом
            for (int i = 0; i < 11; i++)
            {
                for (int j = 128 + i * 20; j < 139 + i * 20; j++)
                {
                    BoardGrid.GetInstance().Cells[j].GetComponent<ContentTail>().content.Add(Content.home);
                }
            }
            #endregion

            #region стены
            // гараж
            for (int i = 80; i <= 180; i+=20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i+1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            BoardGrid.GetInstance().Cells[201].GetComponent<ContentTail>().content.Add(Content.wallLeft);
            BoardGrid.GetInstance().Cells[181].GetComponent<ContentTail>().content.Add(Content.wallRight);
            for (int i = 81; i <=85; i ++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i-20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            for (int i = 85; i <= 145; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i + 1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            BoardGrid.GetInstance().Cells[185].GetComponent<ContentTail>().content.Add(Content.wallUp);
            BoardGrid.GetInstance().Cells[186].GetComponent<ContentTail>().content.Add(Content.wallDown);
            BoardGrid.GetInstance().Cells[205].GetComponent<ContentTail>().content.Add(Content.wallLeft);
            BoardGrid.GetInstance().Cells[185].GetComponent<ContentTail>().content.Add(Content.wallRight);
            // дом
            //низ
            for (int i = 127; i <= 227; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i + 1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            for (int i = 267; i <= 327; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i + 1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            //верх
            for (int i = 138; i <= 338; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i + 1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            //лево
            for (int i = 128; i <= 130; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            for (int i = 132; i <= 134; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            for (int i = 136; i <= 138; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            //право
            for (int i = 348; i <= 349; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            BoardGrid.GetInstance().Cells[352].GetComponent<ContentTail>().content.Add(Content.wallLeft);
            BoardGrid.GetInstance().Cells[332].GetComponent<ContentTail>().content.Add(Content.wallRight);
            for (int i = 354; i <= 355; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            BoardGrid.GetInstance().Cells[358].GetComponent<ContentTail>().content.Add(Content.wallLeft);
            BoardGrid.GetInstance().Cells[338].GetComponent<ContentTail>().content.Add(Content.wallRight);
            //внутри
            for (int i = 228; i <= 232; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            for (int i = 214; i <= 218; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            for (int i = 254; i <= 258; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallLeft);
                BoardGrid.GetInstance().Cells[i - 20].GetComponent<ContentTail>().content.Add(Content.wallRight);
            }
            BoardGrid.GetInstance().Cells[234].GetComponent<ContentTail>().content.Add(Content.wallLeft);
            BoardGrid.GetInstance().Cells[214].GetComponent<ContentTail>().content.Add(Content.wallRight);
            BoardGrid.GetInstance().Cells[314].GetComponent<ContentTail>().content.Add(Content.wallLeft);
            BoardGrid.GetInstance().Cells[294].GetComponent<ContentTail>().content.Add(Content.wallRight);
            for (int i = 132; i <= 192; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i + 1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            for (int i = 234; i <= 294; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.wallUp);
                BoardGrid.GetInstance().Cells[i + 1].GetComponent<ContentTail>().content.Add(Content.wallDown);
            }
            BoardGrid.GetInstance().Cells[210].GetComponent<ContentTail>().content.Add(Content.wallUp);
            BoardGrid.GetInstance().Cells[211].GetComponent<ContentTail>().content.Add(Content.wallDown);
            #endregion

            #region препятствия (barrier)
            // улица
            BoardGrid.GetInstance().Cells[12].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[18].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[19].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[39].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[26].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[61].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[68].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[113].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[114].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[426].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[348].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[349].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[369].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[389].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[390].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[430].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[433].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[435].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[419].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[439].GetComponent<ContentTail>().content.Add(Content.barrier);

            // гараж
            for (int i = 81; i <= 181; i+=20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            for (int i = 82; i <= 85; i ++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            BoardGrid.GetInstance().Cells[162].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[105].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[125].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[145].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[185].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[124].GetComponent<ContentTail>().content.Add(Content.barrier);

            //дом
            //спальня
            for (int i = 128; i <= 168; i+=20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            for (int i = 129; i <= 169; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            for (int i = 208; i <= 210; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            for (int i = 132; i <= 172; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            //работа
            for (int i = 136; i <= 138; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            for (int i = 194; i <= 198; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            BoardGrid.GetInstance().Cells[133].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[134].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[153].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[158].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[178].GetComponent<ContentTail>().content.Add(Content.barrier);
            // ванна
            BoardGrid.GetInstance().Cells[235].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[236].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[218].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[238].GetComponent<ContentTail>().content.Add(Content.barrier);
            //кухня
            for (int i = 255; i <= 258; i++)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            for (int i = 278; i <= 338; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            BoardGrid.GetInstance().Cells[334].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[335].GetComponent<ContentTail>().content.Add(Content.barrier);
            // зал
            for (int i = 234; i <= 294; i += 20)
            {
                BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.barrier);
                BoardGrid.GetInstance().Cells[i+34].GetComponent<ContentTail>().content.Add(Content.barrier);
            }
            BoardGrid.GetInstance().Cells[228].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[230].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[271].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[272].GetComponent<ContentTail>().content.Add(Content.barrier);
            BoardGrid.GetInstance().Cells[291].GetComponent<ContentTail>().content.Add(Content.barrier);
            #endregion

            #region пустой таил
            for (int i = 0; i < 480; i++)
            {
                if (BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.IsEmpty())
                {
                    BoardGrid.GetInstance().Cells[i].GetComponent<ContentTail>().content.Add(Content.none);
                }
            }
            #endregion

        }
    }

}
