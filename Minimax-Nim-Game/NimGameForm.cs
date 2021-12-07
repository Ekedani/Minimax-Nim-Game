using System;
using System.Drawing;
using System.Linq;
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
            //You can add array as parameter if you don't want to play classic nim
            var startState = new NimGameState();
            _currentState = startState;
            RenderNimGame();
        }

        private void RenderNimGame()
        {
            gameField.RowCount = _currentState.HeapSizes.Length;
            gameField.ColumnCount = _currentState.HeapSizes.Max();
            var objSize = gameField.RowTemplate.Height;
            foreach (DataGridViewColumn gameFieldColumn in gameField.Columns) gameFieldColumn.Width = objSize;

            for (var i = 0; i < _currentState.HeapSizes.Length; i++) RenderHeap(i);
        }


        private void restartButton_Click(object sender, EventArgs e)
        {
            var startState = new NimGameState();
            _currentState = startState;
            skipButton.Enabled = true;
            moveButton.Enabled = true;
            turnLabel.Text = "Your turn!";
            RenderNimGame();
        }

        private void RenderHeap(int heap)
        {
            for (var i = 0; i < gameField.Columns.Count; i++) gameField[i, heap].Style.BackColor = Color.Azure;

            for (var j = 0; j < _currentState.HeapSizes[heap]; j++) gameField[j, heap].Style.BackColor = Color.DarkBlue;
        }

        private void gameField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (var i = 0; i < _currentState.HeapSizes.Length; i++) RenderHeap(i);

            for (var j = e.ColumnIndex; j < _currentState.HeapSizes[e.RowIndex]; j++)
                gameField[j, e.RowIndex].Style.BackColor = Color.DarkGreen;
        }

        private void ChangeState(int heap, int objNum)
        {
            if (!(_currentState.HeapSizes[heap] < objNum) && objNum > 0)
            {
                _currentState.HeapSizes[heap] -= objNum;
                RenderHeap(heap);
            }
            else
            {
                throw new Exception("Invalid cell selected!");
            }
        }

        private void AiMove()
        {
            var miniMaxTree = new MinimaxNimTree(_currentState);
            _currentState = miniMaxTree.AiMakeMove();
            for (var i = 0; i < _currentState.HeapSizes.Length; i++) RenderHeap(i);

            if (!_currentState.IsTerminal()) return;
            moveButton.Enabled = false;
            MessageBox.Show("You have lost!", "Result",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            turnLabel.Text = "Defeat";
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            AiMove();
            skipButton.Enabled = false;
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                skipButton.Enabled = false;
                var selectedCells = gameField.SelectedCells;
                if (selectedCells.Count != 1) throw new Exception("Only one cell must be selected!");

                var selectedCell = selectedCells[0];
                var heap = selectedCell.RowIndex;
                var objNum = _currentState.HeapSizes[heap] - selectedCell.ColumnIndex;
                ChangeState(heap, objNum);
                gameField.ClearSelection();
                if (_currentState.IsTerminal())
                {
                    moveButton.Enabled = false;
                    MessageBox.Show("You have won!", "Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    turnLabel.Text = "Victory!";
                }
                else
                {
                    AiMove();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}