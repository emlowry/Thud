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
        // For setting the size of Dwarf pieces
        public static readonly DependencyProperty DwarfRectProperty =
            DependencyProperty.RegisterAttached("DwarfRect", typeof(Rect), typeof(Panel),
                                                new FrameworkPropertyMetadata(
                                                    new Rect(0.125, 0.125, 0.75, 0.75),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetDwarfRect(DependencyObject d, Rect rect)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(DwarfRectProperty, rect);
            }
        }
        public static Rect GetDwarfRect(DependencyObject d)
        {
            return (d is Panel) ? (Rect)(d as Panel).GetValue(DwarfRectProperty)
                                : (Rect)DwarfRectProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty DwarfRectIsAbsoluteProperty =
            DependencyProperty.RegisterAttached("DwarfRectIsAbsolute", typeof(bool), typeof(Panel),
                                                new FrameworkPropertyMetadata(false,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetDwarfRectIsAbsolute(DependencyObject d, bool absolute)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(DwarfRectIsAbsoluteProperty, absolute);
            }
        }
        public static bool GetDwarfRectIsAbsolute(DependencyObject d)
        {
            return (d is Panel) ? (bool)(d as Panel).GetValue(DwarfRectIsAbsoluteProperty)
                                : (bool)DwarfRectIsAbsoluteProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board uses for Dwarf pieces
        public static readonly DependencyProperty DwarfStrokeProperty =
            DependencyProperty.RegisterAttached("DwarfStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetDwarfStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(DwarfStrokeProperty, stroke);
            }
        }
        public static Pen GetDwarfStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(DwarfStrokeProperty)
                                : (Pen)DwarfStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty DwarfFillProperty =
            DependencyProperty.RegisterAttached("DwarfFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(MakeDefaultDwarfFill(),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetDwarfFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(DwarfFillProperty, fill);
            }
        }
        public static Brush GetDwarfFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(DwarfFillProperty)
                                : (Brush)DwarfFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board uses for selected Dwarf pieces
        public static readonly DependencyProperty SelectedDwarfStrokeProperty =
            DependencyProperty.RegisterAttached("SelectedDwarfStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetSelectedDwarfStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(SelectedDwarfStrokeProperty, stroke);
            }
        }
        public static Pen GetSelectedDwarfStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(SelectedDwarfStrokeProperty)
                                : (Pen)SelectedDwarfStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty SelectedDwarfFillProperty =
            DependencyProperty.RegisterAttached("SelectedDwarfFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(MakeDefaultSelectedDwarfFill(),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetSelectedDwarfFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(SelectedDwarfFillProperty, fill);
            }
        }
        public static Brush GetSelectedDwarfFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(SelectedDwarfFillProperty)
                                : (Brush)SelectedDwarfFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board overlays on tiles targeted by Dwarf pieces
        public static readonly DependencyProperty DwarfTargetStrokeProperty =
            DependencyProperty.RegisterAttached("DwarfTargetStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(new Pen(Brushes.Yellow, 3),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetDwarfTargetStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(DwarfTargetStrokeProperty, stroke);
            }
        }
        public static Pen GetDwarfTargetStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(DwarfTargetStrokeProperty)
                                : (Pen)DwarfTargetStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty DwarfTargetFillProperty =
            DependencyProperty.RegisterAttached("DwarfTargetFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetDwarfTargetFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(DwarfTargetFillProperty, fill);
            }
        }
        public static Brush GetDwarfTargetFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(DwarfTargetFillProperty)
                                : (Brush)DwarfTargetFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the size of Troll pieces
        public static readonly DependencyProperty TrollRectProperty =
            DependencyProperty.RegisterAttached("TrollRect", typeof(Rect), typeof(Panel),
                                                new FrameworkPropertyMetadata(
                                                    new Rect(0.125, 0.125, 0.75, 0.75),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetTrollRect(DependencyObject d, Rect rect)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(TrollRectProperty, rect);
            }
        }
        public static Rect GetTrollRect(DependencyObject d)
        {
            return (d is Panel) ? (Rect)(d as Panel).GetValue(TrollRectProperty)
                                : (Rect)TrollRectProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty TrollRectIsAbsoluteProperty =
            DependencyProperty.RegisterAttached("TrollRectIsAbsolute", typeof(bool), typeof(Panel),
                                                new FrameworkPropertyMetadata(false,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetTrollRectIsAbsolute(DependencyObject d, bool absolute)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(TrollRectIsAbsoluteProperty, absolute);
            }
        }
        public static bool GetTrollRectIsAbsolute(DependencyObject d)
        {
            return (d is Panel) ? (bool)(d as Panel).GetValue(TrollRectIsAbsoluteProperty)
                                : (bool)TrollRectIsAbsoluteProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board uses for Troll pieces
        public static readonly DependencyProperty TrollStrokeProperty =
            DependencyProperty.RegisterAttached("TrollStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetTrollStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(TrollStrokeProperty, stroke);
            }
        }
        public static Pen GetTrollStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(TrollStrokeProperty)
                                : (Pen)TrollStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty TrollFillProperty =
            DependencyProperty.RegisterAttached("TrollFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(MakeDefaultTrollFill(),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetTrollFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(TrollFillProperty, fill);
            }
        }
        public static Brush GetTrollFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(TrollFillProperty)
                                : (Brush)TrollFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board uses for selected Troll pieces
        public static readonly DependencyProperty SelectedTrollStrokeProperty =
            DependencyProperty.RegisterAttached("SelectedTrollStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetSelectedTrollStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(SelectedTrollStrokeProperty, stroke);
            }
        }
        public static Pen GetSelectedTrollStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(SelectedTrollStrokeProperty)
                                : (Pen)SelectedTrollStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty SelectedTrollFillProperty =
            DependencyProperty.RegisterAttached("SelectedTrollFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(MakeDefaultSelectedTrollFill(),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetSelectedTrollFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(SelectedTrollFillProperty, fill);
            }
        }
        public static Brush GetSelectedTrollFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(SelectedTrollFillProperty)
                                : (Brush)SelectedTrollFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board overlays on tiles targeted by Troll pieces
        public static readonly DependencyProperty TrollTargetStrokeProperty =
            DependencyProperty.RegisterAttached("TrollTargetStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(new Pen(Brushes.Lime, 3),
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetTrollTargetStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(TrollTargetStrokeProperty, stroke);
            }
        }
        public static Pen GetTrollTargetStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(TrollTargetStrokeProperty)
                                : (Pen)TrollTargetStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty TrollTargetFillProperty =
            DependencyProperty.RegisterAttached("TrollTargetFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetTrollTargetFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(TrollTargetFillProperty, fill);
            }
        }
        public static Brush GetTrollTargetFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(TrollTargetFillProperty)
                                : (Brush)TrollTargetFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board uses for tiles where GridX + GridY is even
        public static readonly DependencyProperty EvenTileStrokeProperty =
            DependencyProperty.RegisterAttached("EvenTileStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetEvenTileStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(EvenTileStrokeProperty, stroke);
            }
        }
        public static Pen GetEvenTileStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(EvenTileStrokeProperty)
                                : (Pen)EvenTileStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty EvenTileFillProperty =
            DependencyProperty.RegisterAttached("EvenTileFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(Brushes.White,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetEvenTileFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(EvenTileFillProperty, fill);
            }
        }
        public static Brush GetEvenTileFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(EvenTileFillProperty)
                                : (Brush)EvenTileFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting the graphics a board uses for tiles where GridX + GridY is odd
        public static readonly DependencyProperty OddTileStrokeProperty =
            DependencyProperty.RegisterAttached("OddTileStroke", typeof(Pen), typeof(Panel),
                                                new FrameworkPropertyMetadata(null,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetOddTileStroke(DependencyObject d, Pen stroke)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(OddTileStrokeProperty, stroke);
            }
        }
        public static Pen GetOddTileStroke(DependencyObject d)
        {
            return (d is Panel) ? (Pen)(d as Panel).GetValue(OddTileStrokeProperty)
                                : (Pen)OddTileStrokeProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly DependencyProperty OddTileFillProperty =
            DependencyProperty.RegisterAttached("OddTileFill", typeof(Brush), typeof(Panel),
                                                new FrameworkPropertyMetadata(Brushes.Black,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetOddTileFill(DependencyObject d, Brush fill)
        {
            if (d is Panel)
            {
                (d as Panel).SetValue(OddTileFillProperty, fill);
            }
        }
        public static Brush GetOddTileFill(DependencyObject d)
        {
            return (d is Panel) ? (Brush)(d as Panel).GetValue(OddTileFillProperty)
                                : (Brush)OddTileFillProperty.GetMetadata(d).DefaultValue;
        }

        // For setting a board's current player
        public static readonly DependencyProperty PlayerProperty =
            DependencyProperty.RegisterAttached("Player", typeof(GamePiece), typeof(Panel),
                                                new FrameworkPropertyMetadata(GamePiece.None,
                                                    FrameworkPropertyMetadataOptions.Inherits));
        public static void SetPlayer(DependencyObject d, GamePiece playerPiece)
        {
            if (d is Panel)
            {
                Panel panel = d as Panel;
                panel.SetValue(PlayerProperty, playerPiece);
                panel.RaiseEvent(new RoutedEventArgs(PlayerChangedEvent));
            }
        }
        public static GamePiece GetPlayer(DependencyObject d)
        {
            return (d is Panel) ? (GamePiece)(d as Panel).GetValue(PlayerProperty)
                                : (GamePiece)PlayerProperty.GetMetadata(d).DefaultValue;
        }
        public static readonly RoutedEvent PlayerChangedEvent =
            EventManager.RegisterRoutedEvent("PlayerChanged", RoutingStrategy.Bubble,
                                             typeof(RoutedEventHandler), typeof(Panel));
        public static void AddPlayerChangedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (null != uie)
            {
                uie.AddHandler(ThudTile.PlayerChangedEvent, handler);
            }
        }
        public static void RemovePlayerChangedHandler(DependencyObject d, RoutedEventHandler handler)
        {
            UIElement uie = d as UIElement;
            if (null != uie)
            {
                uie.RemoveHandler(ThudTile.PlayerChangedEvent, handler);
            }
        }
    }
}