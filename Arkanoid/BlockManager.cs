using System;
using System.Collections.Generic;

namespace Arkanoid
{
    class BlockManager
    {
        private List<Block> blocks;
        private int row, column;

        public BlockManager() 
        {
            row = 5;
            column = 14;
            blocks = new List<Block>();
            SetupBlocks();
        }

        private void SetupBlocks()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++) blocks.Add(new Block(i, j));                
            }
        }

        public void Draw(System.Drawing.Graphics g) { foreach (Block block in blocks) block.Draw(g); }

        public List<Block> GetBlocks { get { return blocks; } }        
    }
}