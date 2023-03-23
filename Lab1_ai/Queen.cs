
namespace Lab1_ai
{
    public class Queen
    {
        private int row;
        private int col;

        public Queen(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return col;
        }

        public bool IsAttacking(Queen queen)
        {
            return row == queen.GetRow() || col == queen.GetColumn() || Math.Abs(row - queen.GetRow()) == Math.Abs(col - queen.GetColumn());
        }
    }
}
