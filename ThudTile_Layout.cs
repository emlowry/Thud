using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace ThudPrototype
{
    public partial class ThudTile
    {
        // The board is roughly octagonal, with the center square blocked by
        // the "thud stone". There are eight troll pieces surrounding the
        // thud stone, and 32 dwarf pieces along the diagonal sides of the
        // board.  http://en.wikipedia.org/wiki/Games_of_the_Discworld#Thud
        public const int BoardSideLength = 15;
        public static readonly Point ThudstoneLocation = new Point(7, 7);
        public static readonly GamePiece?[][] Layout = MakeLayout();
        protected static GamePiece?[][] MakeLayout()
        {
            return new GamePiece?[BoardSideLength][]
            {
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    null,
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    GamePiece.Dwarf,
                    null,
                    null,
                    null,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null,
                    null,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf
                },
                new GamePiece?[BoardSideLength]
                {
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Troll,
                    GamePiece.Troll,
                    GamePiece.Troll,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf
                },
                new GamePiece?[BoardSideLength]
                {
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Troll,
                    null,
                    GamePiece.Troll,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None
                },
                new GamePiece?[BoardSideLength]
                {
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Troll,
                    GamePiece.Troll,
                    GamePiece.Troll,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf
                },
                new GamePiece?[BoardSideLength]
                {
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    null,
                    null,
                    null,
                    null
                },
                new GamePiece?[BoardSideLength]
                {
                    null,
                    null,
                    null,
                    null,
                    null,
                    GamePiece.Dwarf,
                    GamePiece.Dwarf,
                    GamePiece.None,
                    GamePiece.Dwarf,
                    GamePiece.Dwarf,
                    null,
                    null,
                    null,
                    null,
                    null
                }
            };
        }
    }
}