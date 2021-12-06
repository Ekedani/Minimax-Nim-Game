using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimax_Nim_Game.Algorithm;

namespace Minimax_Nim_Game
{
    public partial class NimGameForm : Form
    {
        private NimGameState _currentState;

        public NimGameForm()
        {
            InitializeComponent();
            CreateNimGame();
        }

        private void CreateNimGame()
        {
            //You can add array as parameter if you don't want classic nim
            var startState = new NimGameState();
            _currentState = startState;
            RenderNimGame();
        }

        private void RenderNimGame()
        {
            gameField.RowCount = _currentState.HeapSizes.Length;
            gameField.ColumnCount = _currentState.HeapSizes.Max();
            var objSize = gameField.RowTemplate.Height;
            foreach (DataGridViewColumn gameFieldColumn in gameField.Columns)
            {
                gameFieldColumn.Width = objSize;
            }

            for (var i = 0; i < _currentState.HeapSizes.Length; i++)
            {
                RenderHeap(i);
            }
        }


        private void restartButton_Click(object sender, EventArgs e)
        {
            var startState = new NimGameState();
            _currentState = startState;
            RenderNimGame();
        }

        private void RenderHeap(int heap)
        {
            for (int i = 0; i < gameField.Columns.Count; i++)
            {
                gameField[i, heap].Style.BackColor = Color.Azure;
            }
            for (var j = 0; j < _currentState.HeapSizes[heap]; j++)
            {
                gameField[j, heap].Style.BackColor = Color.DarkBlue;
            }
        }

        private void gameField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 0; i < _currentState.HeapSizes.Length; i++)
            {
                RenderHeap(i);
            }

            for (var j = e.ColumnIndex; j < _currentState.HeapSizes[e.RowIndex]; j++)
            {
                gameField[j, e.RowIndex].Style.BackColor = Color.DarkGreen;
            }
        }

        private void MakeAMove(int heap, int objNum)
        {
            if (!(_currentState.HeapSizes[heap] < objNum))
            {
                _currentState.HeapSizes[heap] -= objNum;
            }
            RenderHeap(heap);
        }

        private void AiMove()
        {
            var miniMaxTree = new MinimaxNimTree(_currentState);
            var newCurrentState = miniMaxTree.AiMakeMove();
            _currentState = newCurrentState;
            for (var i = 0; i < _currentState.HeapSizes.Length; i++)
            {
                RenderHeap(i);
            }
            if (newCurrentState.IsTerminal())
            {
                //TODO: Loss
            }
            else
            {
                
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            AiMove();
        }
    }
}