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
        // When this tile is clicked, play out
        protected override void OnMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CanBeCaptured())
            {
                Capture();
            }
            else
            {
                Select();
            }
        }

        // Can this tile be captured by another piece targeting it, if there is one?
        protected bool CanBeCaptured()
        {
            return (null != TargetedBy && this != TargetedBy &&
                    Piece != TargetedBy.Piece &&
                    GamePiece.None != TargetedBy.Piece);
        }

        // Make the piece targeting this tile, if any, capture this tile
        protected void Capture()
        {
            // if this tile isn't being targeted by anything, don't bother
            if (!CanBeCaptured())
            {
                return;
            }

            // Otherwise, the piece targeting this tile captures it
            switch (Piece)
            {
                case GamePiece.Dwarf: CaptureDwarf(); break;
                case GamePiece.Troll: CaptureTroll(); break;
                case GamePiece.None: CaptureNone(); break;
            }
        }

        // An empty tile targeted by another tile swaps contents with that tile
        private void CaptureNone()
        {
            Piece = TargetedBy.Piece;
            TargetedBy.Piece = GamePiece.None;

            // If this tile isn't now occupied by a troll, nothing more needs doing
            if (GamePiece.Troll != Piece)
            {
                EndTurn();
            }
            else
            {
                // Check for surrounding dwarves
                IEnumerable<ThudTile> dwarves =
                    Neighbors.Where(tile => GamePiece.Dwarf == tile.Piece);

                // if there aren't any, end the turn
                if (null == dwarves || dwarves.Count() == 0)
                {
                    EndTurn();
                }
                else
                {
                    // If the troll was shoved here, then it must capture at least one dwarf
                    captureRequired = !Neighbors.Contains(TargetedBy);

                    // Target the surrounding dwarves
                    ClearTargeting(Parent);
                    foreach (ThudTile tile in dwarves)
                    {
                        tile.TargetedBy = this;
                    }
                    TargetedBy = this;
                }
            }
        }

        // A troll targeted by a dwarf is replaced with said dwarf
        private void CaptureTroll()
        {
            Piece = GamePiece.Dwarf;
            TargetedBy.Piece = GamePiece.None;
            EndTurn();
        }

        // A dwarf targeted by a troll is removed
        protected void CaptureDwarf()
        {
            Piece = GamePiece.None;

            // If no more dwarves can be targeted by the troll, end the turn
            if (TargetedBy.Neighbors.Count(tile => (this != tile &&
                                                    this.TargetedBy == tile.TargetedBy)) == 0)
            {
                EndTurn();
                return;
            }

            // Otherwise, no more captures are required and the turn can be ended by clicking elsewhere
            if (TargetedBy.captureRequired)
            {
                TargetedBy.captureRequired = false;
            }
            TargetedBy = null;
        }

        // End the current turn
        protected void EndTurn()
        {
            // Clear targeting and capturing to end turn
            if (null == Parent)
            {
                TargetedBy = null;
                captureRequired = false;
                return;
            }
            ClearTargeting(Parent);
            ClearCaptureRequired(Parent);

            // If one side runs out of pieces, the game ends
            if (CountPieces(Parent, GamePiece.Troll) == 0 ||
                CountPieces(Parent, GamePiece.Dwarf) == 0)
            {
                SetPlayer(Parent, GamePiece.None);
            }

            // Otherwise, as long as it's some player's turn, switch sides
            else if (GetPlayer(Parent) != GamePiece.None)
            {
                SetPlayer(Parent, (GetPlayer(Parent) == GamePiece.Troll
                                  ? GamePiece.Dwarf : GamePiece.Troll));
            }
        }

        // Select the piece on this tile, if any
        protected void Select()
        {
            // Are there dwarves being targeted by a troll?
            IEnumerable<ThudTile> targetedDwarves =
                GetAll(Parent, GamePiece.Dwarf)
                .Where(tile => (null != tile.TargetedBy &&
                                GamePiece.Troll == tile.TargetedBy.Piece));
            if (targetedDwarves.Count() > 0)
            {
                // if the troll doesn't need to capture any of them, end the
                // turn.
                if (targetedDwarves.Count(tile => tile.TargetedBy.captureRequired) == 0)
                {
                    EndTurn();
                }

                // either way, don't continue
                return;
            }

            // Select this piece, if any
            ClearTargeting(Parent);
            if (GamePiece.None == Piece || GetPlayer(Parent) != Piece)
            {
                return;
            }
            TargetedBy = this;

            // In every direction,
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    if (i != 0 || j != 0)
                    {
                        // mark movement targets
                        MarkMovementTargets(i, j);
                    }
                }
            }
        }

        // Mark targets for movement of a game piece from this tile in the given direction
        protected void MarkMovementTargets(int xDir, int yDir)
        {
            // if no direction is given or if this tile is empty, no movement is possible.
            if ((0 == xDir && 0 == yDir) || GamePiece.None == Piece)
            {
                return;
            }

            // if there's another piece of the same type in front of this one in the
            // given direction, then it can't move in that direction.
            int row = Row, column = Column;
            ThudTile inFront = GetNextInDirection(Parent, ref column, ref row, xDir, yDir);
            if ((null != inFront && Piece == inFront.Piece) || !WithinBoard(column, row))
            {
                return;
            }

            // Calculate potential assisted move distance
            int backRow = Row, backColumn = Column;
            ThudTile assister =
                GetNextInDirection(Parent, ref backColumn, ref backRow, -xDir, -yDir);
            int assistRange = 1;
            bool assistPossible = (GamePiece.Troll == Piece ||
                (null != inFront && GamePiece.Troll == inFront.Piece));
            while (null != assister && Piece == assister.Piece &&
                   WithinBoard(column, row) && WithinBoard(backColumn, backRow))
            {
                ++assistRange;
                assister = GetNextInDirection(Parent, ref backColumn, ref backRow, -xDir, -yDir);
                inFront = GetNextInDirection(Parent, ref column, ref row, xDir, yDir);
                if (!assistPossible && null != inFront &&
                    GamePiece.Troll == inFront.Piece)
                {
                    assistPossible = true;
                }
            }
            if (!assistPossible)
            {
                assistRange = 0;
            }

            // target tiles for movement
            int targetColumn = Column, targetRow = Row;
            ThudTile target =
                GetNextInDirection(Parent, ref targetColumn, ref targetRow, xDir, yDir);
            bool blocked = false;
            while ((!blocked || assistRange > 0) && WithinBoard(targetColumn, targetRow))
            {
                // If this piece can move to the target tile, mark it.
                if (CanMoveTo(target, assistRange, blocked))
                {
                    target.TargetedBy = this;
                }

                // If the tile doesn't exist or contains an obstacle, or if this
                // piece is a troll, further movement is impossible without assist.
                if (!blocked &&
                    (GamePiece.Troll == Piece || null == target ||
                     GamePiece.None != target.Piece))
                {
                    blocked = true;
                }

                // get ready to check the next tile
                --assistRange;
                target = GetNextInDirection(Parent, ref targetColumn, ref targetRow, xDir, yDir);
            }
        }

        // Can this piece move to the given tile?
        protected bool CanMoveTo(ThudTile target, int assistRange, bool blocked)
        {
            // if the tile doesn't exist or is occupied by the same piece as this
            // or by a dwarf, then this piece can't move to it.
            if (null == target || Piece == target.Piece || GamePiece.Dwarf == target.Piece)
            {
                return false;
            }

            // if this piece is a troll, then it can move to the tile if not
            // blocked or if the tile is within shove distance and is adjacent
            // to at least one dwarf
            if (GamePiece.Troll == Piece)
            {
                return (GamePiece.None == target.Piece &&
                    (!blocked ||
                    (assistRange > 0 &&
                     target.Neighbors.Count(tile => GamePiece.Dwarf == tile.Piece) > 0)));
            }

            // if this piece is a dwarf, then it can move to the tile if not
            // blocked or if the tile is within hurling distance
            if (GamePiece.Dwarf == Piece)
            {
                return ((!blocked && GamePiece.None == target.Piece) || assistRange > 0);
            }

            // if this tile is empty, then it can't target anything.
            return false;
        }
    }
}