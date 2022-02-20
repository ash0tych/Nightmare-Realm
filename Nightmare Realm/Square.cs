using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Nightmare_Realm
{
    class Square
    {
        private Image img;
        private bool can_block;
        public string type;
        private bool movable;
        protected bool can_be_displayed;
        public Square() {}
        public Square(Square sqr)
        {
            type = sqr.type;
            movable = sqr.movable;
            can_be_displayed = sqr.can_be_displayed;
            can_block = sqr.can_block;
            img = sqr.img;
    }
        public bool Can_be_displayed()
        {
            return can_be_displayed;
        }
        public void Can_be_displayed(bool x)
        {
            can_be_displayed = x;
        }

        public bool Can_block()
        {
            return can_block;
        }
        protected void Can_block(bool x)
        {
            can_block = x;
        }

        public bool Movable()
        {
            return movable;
        }
        protected void Movable(bool x)
        {
            movable = x;
        }

        public string Type()
        {
            return type;
        }
        protected void Type(string typ)
        {
            type = typ;
        }
        public Image Img()
        {
            return img;
        }
        protected void Img(Image image)
        {
            img = image;
        }

        ~Square()
        {
            
        }
    }

    class EmptySquare : Square
    {
        public EmptySquare() : base ()
        {
            Can_be_displayed(false);
            Can_block(false);
            Movable(false);
            Type("none");
            Img(Image.FromFile(@"Assets\none.png"));
        }
        ~EmptySquare() { }
    }

    class BLockSquare : Square
    {
        public BLockSquare() : base()
        {
            Can_be_displayed(true);
            Can_block(true);
            Movable(false);
            Type("block");
            Img(Image.FromFile(@"Assets\block.png"));

        }
        ~BLockSquare() { }
    }


    class GameSquare : Square
    {
        public GameSquare(string type) : base()
        {
            Can_be_displayed(true);
            Can_block(true);
            Movable(true);
            Type(type);
            Img(Image.FromFile(@"Assets\" + type + ".png"));
        }
        ~GameSquare() { 
            img = null;
        }
    }
}

