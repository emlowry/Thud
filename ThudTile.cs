using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace ThudPrototype
{
    public partial class ThudTile : Canvas
    {
        // stroke and fill
        protected Pen stroke;
        public Pen Stroke
        {
            get { return stroke; }
            set
            {
                if (value != stroke)
                {
                    stroke = value;
                    InvalidateVisual();
                }
            }
        }
        protected Brush fill;
        public Brush Fill
        {
            get { return fill; }
            set
            {
                if (value != fill)
                {
                    fill = value;
                    InvalidateVisual();
                }
            }
        }

        // game piece on this tile, if any
        public enum GamePiece { None, Dwarf, Troll }
        protected GamePiece piece;
        public GamePiece Piece
        {
            get { return piece; }
            set
            {
                if (value != piece)
                {
                    piece = value;
                    InvalidateVisual();
                }
            }
        }

        // Was a troll just shoved onto this tile?  If so, it must capture at least one dwarf.
        protected bool captureRequired = false;

        // tile with a piece that can be moved to this tile
        protected ThudTile targetedBy;
        public ThudTile TargetedBy
        {
            get { return targetedBy; }
            set
            {
                if (value != targetedBy)
                {
                    targetedBy = value;
                    InvalidateVisual();
                }
            }
        }

        // location on grid
        public int Column
        {
            get { return Grid.GetColumn(this); }
            set
            {
                if (value != Grid.GetColumn(this))
                {
                    Grid.SetColumn(this, value);
                    InvalidateVisual();
                    if (null != Parent && Parent is UIElement)
                    {
                        (Parent as UIElement).InvalidateVisual();
                    }
                }
            }
        }
        public int Row
        {
            get { return Grid.GetRow(this); }
            set
            {
                if (value != Grid.GetRow(this))
                {
                    Grid.SetRow(this, value);
                    InvalidateVisual();
                    if (null != Parent && Parent is UIElement)
                    {
                        (Parent as UIElement).InvalidateVisual();
                    }
                }
            }
        }

        // neighboring tiles
        public ThudTile UpLeftTile { get { return Get(Parent, Column - 1, Row + 1); } }
        public ThudTile UpTile { get { return Get(Parent, Column, Row + 1); } }
        public ThudTile UpRightTile { get { return Get(Parent, Column + 1, Row + 1); } }
        public ThudTile RightTile { get { return Get(Parent, Column + 1, Row); } }
        public ThudTile DownRightTile { get { return Get(Parent, Column + 1, Row - 1); } }
        public ThudTile DownTile { get { return Get(Parent, Column, Row - 1); } }
        public ThudTile DownLeftTile { get { return Get(Parent, Column - 1, Row - 1); } }
        public ThudTile LeftTile { get { return Get(Parent, Column - 1, Row); } }
        public List<ThudTile> Neighbors
        {
            get
            {
                List<ThudTile> neighbors = new List<ThudTile>();
                for (int i = -1; i <= 1; ++i)
                {
                    for (int j = -1; j <= 1; ++j)
                    {
                        if (i != 0 || j != 0)
                        {
                            ThudTile neighbor = Get(Parent, Column + i, Row + j);
                            if (null != neighbor)
                            {
                                neighbors.Add(neighbor);
                            }
                        }
                    }
                }
                return neighbors;
            }
        }

        // Constructor
        public ThudTile(int column, int row, GamePiece content = GamePiece.None)
        {
            Column = column;
            Row = row;
            Grid.SetColumnSpan(this, 1);
            Grid.SetRowSpan(this, 1);
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Piece = content;
        }

        // Draw a tile
        protected override void OnRender(DrawingContext dc)
        {
            DrawTile(dc);
            DrawPiece(dc);
            DrawTargetingOverlay(dc);
        }

        // Draw the tile itself
        protected void DrawTile(DrawingContext dc)
        {
            // draw tile
            bool even = ((Row + Column) % 2 == 0);
            Pen pen = even ? GetEvenTileStroke(this)
                           : GetOddTileStroke(this);
            Brush brush = even ? GetEvenTileFill(this)
                               : GetOddTileFill(this);
            if (null == pen)
            {
                pen = even ? GetOddTileStroke(this)
                            : GetEvenTileStroke(this);
            }
            if (null == brush)
            {
                brush = even ? GetOddTileFill(this)
                                : GetEvenTileFill(this);
            }
            if (null == pen)
            {
                pen = Stroke;
            }
            if (null == brush)
            {
                brush = Fill;
            }
            dc.DrawRectangle(brush, pen, new Rect(0, 0, ActualWidth, ActualHeight));
        }

        // Draw the game piece on the tile, if any
        protected void DrawPiece(DrawingContext dc)
        {
            if (GamePiece.None == Piece)
            {
                return;
            }
            bool troll = (GamePiece.Troll == Piece);
            bool selected = (this == TargetedBy);
            Rect rect = troll ? GetTrollRect(this) : GetDwarfRect(this);
            if (troll ? !GetTrollRectIsAbsolute(this) : !GetDwarfRectIsAbsolute(this))
            {
                rect.X *= ActualWidth;
                rect.Y *= ActualHeight;
                rect.Width *= ActualWidth;
                rect.Height *= ActualHeight;
            }
            Brush brush = troll ? (selected ? GetSelectedTrollFill(this) : GetTrollFill(this))
                                : (selected ? GetSelectedDwarfFill(this) : GetDwarfFill(this));
            Pen pen = troll ? (selected ? GetSelectedTrollStroke(this) : GetTrollStroke(this))
                            : (selected ? GetSelectedDwarfStroke(this) : GetDwarfStroke(this));
            dc.DrawRectangle(brush, pen, rect);
        }

        // If a piece on another tile targets this one, draw the overlay
        protected void DrawTargetingOverlay(DrawingContext dc)
        {
            if (CanBeCaptured())
            {
                bool troll = (GamePiece.Troll == TargetedBy.Piece);
                dc.DrawRectangle(troll ? GetTrollTargetFill(this) : GetDwarfTargetFill(this),
                                 null,
                                 new Rect(0, 0, ActualWidth, ActualHeight));
                Pen pen = troll ? GetTrollTargetStroke(this) : GetDwarfTargetStroke(this);
                if (null != pen)
                {
                    Rect border = new Rect(pen.Thickness / 2, pen.Thickness / 2,
                        ActualWidth - pen.Thickness, ActualHeight - pen.Thickness);
                    dc.DrawRectangle(null, pen, border);
                }
            }
        }

    }
}
