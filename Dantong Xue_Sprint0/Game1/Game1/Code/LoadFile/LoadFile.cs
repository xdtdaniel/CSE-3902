using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using Game1.Code.Block.BlockFactory;
using System.Drawing;

namespace Game1.Code.LoadFile
{
    class LoadFile
    {
        int MAX_ROWS = 23;
        int MAX_COLUMNS = 26;
        private class Cell {
            private int column { get; set; }
            private int row { get; set; }            
            private string element { get; set; }

        }
        List<Tuple<int, int, string>> mapElementList;

        public LoadFile() {
            mapElementList = new List<Tuple<int, int, string>>();
            StreamReader streamReader = new StreamReader("PartialLevelOne.csv");
            string line;
            string[] str = new string[MAX_COLUMNS];
            int cell_x = 0;
            int cell_y = 0;
            //each loop add 1 line to list
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                //seperate a line by comma. this string array should have all strings seperately.              
                    str = line.Split(',');   

                //cell_x, and cell_y represent the postion in csv
                for (int i = 0; i < MAX_COLUMNS; i++)
                {
                    mapElementList.Add(new Tuple<int, int, string>(cell_x, cell_y, str[i]));
                    cell_x++;
                }
                cell_y++;

            }

            //switch case for each string
            for (int j = 0; j < mapElementList.count; j++)
            {
                switch (mapelementlist[j])
                {
                    case "black":
                        blockfactory.instance.createblackblock();// need to pass row anad columbs and multiply by the block's width and height
                    case "block":
                        blockfactory.instance.createflatblock();
                    case "dragon":
                        blockfactory.instance.createdragon();
                }

            }



        }





    }
}
