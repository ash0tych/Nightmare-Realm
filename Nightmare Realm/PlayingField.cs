using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Nightmare_Realm.Square;

namespace Nightmare_Realm
{
    class PlayingField
    {
        public Square[,] field ;
        private bool was_clicked;
        private int[] last_click;

        public PlayingField()
        {
            field = new Square[5,5];
            last_click = new int[2];
            was_clicked = false;
        }
     
        public void FillField()
        {
            field[0, 1] = new BLockSquare();
            field[0, 3] = new BLockSquare();
            field[2, 1] = new BLockSquare();
            field[2, 3] = new BLockSquare();
            field[4, 1] = new BLockSquare();
            field[4, 3] = new BLockSquare();

            field[1, 1] = new EmptySquare();
            field[1, 3] = new EmptySquare();
            field[3, 1] = new EmptySquare();
            field[3, 3] = new EmptySquare();

            string[] temp = randomPermutation();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j += 2)
                {
                    field[i, j] = new GameSquare(temp[i * 3 + j / 2]);
                }
            }
        }

        private string[] randomPermutation()
        {
            string[] temp = { "red", "red", "red", "red", "red", "blue", "blue", "blue", "blue", "blue", "green", "green", "green", "green", "green" };
            Random rnd = new Random();
            for (int i = 14; i >= 0; i--)
            {
                int j = rnd.Next(0, i);
                string buffer = temp[j];
                temp[j] = temp[i];
                temp[i] = buffer;
            }

            return temp;
        }

        public Square getSquare(int i, int j)
        {
            return field[i, j];
        }

        private void emptyMode(bool x)
        {
            if (last_click[0] < 4 && field[last_click[0] + 1, last_click[1]].Type() == "none")
            {
                field[last_click[0] + 1, last_click[1]].Can_be_displayed(x);
            }
            if (last_click[0] > 0 && field[last_click[0] - 1, last_click[1]].Type() == "none")
            {
                field[last_click[0] - 1, last_click[1]].Can_be_displayed(x);
            }
            if (last_click[1] < 4 && field[last_click[0], last_click[1] + 1].Type() == "none")
            {
                field[last_click[0], last_click[1] + 1].Can_be_displayed(x);
            }
            if (last_click[1] > 0 && field[last_click[0], last_click[1] - 1].Type() == "none")
            {
                field[last_click[0], last_click[1] - 1].Can_be_displayed(x);
            }
        }

        private bool closeClick(int i, int j)
        {
            if (last_click[0] < 4 && last_click[0] + 1 == i && last_click[1] == j)
            {
                return true;
            }
            if (last_click[0] > 0 && last_click[0] - 1 == i && last_click[1] == j)
            {
                return true;
            }
            if (last_click[1] < 4 && last_click[1] + 1 == j && last_click[0] == i)
            {
                return true;
            }
            if (last_click[1] > 0 && last_click[1] - 1 == j && last_click[0] == i)
            {
                return true;
            }
            return false;
        }

        private bool is_game_square(int y,int i)
        {
            return field[y - 1, i - 1].Type() != "block" && field[y - 1, i - 1].Type() != "none";
        }

        public void readPos(int y, int i)
        {
            if (!was_clicked)
            {
                if (is_game_square(y, i))
                {
                    last_click[0] = y - 1;
                    last_click[1] = i - 1;
                    emptyMode(true);
                    was_clicked = true;
                }
            }
            else
            {
                if (is_game_square(y, i))
                {
                    emptyMode(false);
                    last_click[0] = y - 1;
                    last_click[1] = i - 1;
                    emptyMode(true);
                    was_clicked = true;
                }
                else
                {
                    if (closeClick(y - 1, i - 1))
                    {
                        move(y, i);
                    }
                    else
                    {
                        emptyMode(false);
                        was_clicked = false;
                    }
                }
            }
        }

        private void move(int y, int i)
        {
            emptyMode(false);
            Square buf = field[y - 1, i - 1];
            field[y - 1, i - 1] = field[last_click[0], last_click[1]];
            field[last_click[0], last_click[1]] = buf;
            last_click[0] = y - 1;
            last_click[1] = i - 1;
            was_clicked = false;
        }

        public bool isActiveLine(int x)
        {
            return (field[0, ((x - 1) * 2)].Type() == field[1, ((x - 1) * 2)].Type()) && (field[1, ((x - 1) * 2)].Type() == field[2, ((x - 1) * 2)].Type()) &&
                (field[2, ((x - 1) * 2)].Type() == field[3, ((x - 1) * 2)].Type()) && (field[3, ((x - 1) * 2)].Type() == field[4, ((x - 1) * 2)].Type());
        }
    }
}
