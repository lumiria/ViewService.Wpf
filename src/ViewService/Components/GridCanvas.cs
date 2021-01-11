using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ViewServices.Components
{
    public sealed class GridCanvas : Canvas
    {
        private Pen _gridLinePen;

        public GridCanvas()
        {
            _gridLinePen = new Pen(Brushes.Gray, 1d);
            _gridLinePen.Freeze();
        }

        public double VerticalGridSpacing
        {
            get => (double)GetValue(VerticalGridSpacingProperty);
            set => SetValue(VerticalGridSpacingProperty, value);
        }
        /// <summary>Identifies the <see cref="VerticalGridSpacing"/> attached property.</summary>
        public static readonly DependencyProperty VerticalGridSpacingProperty =
            DependencyProperty.Register("VerticalGridSpacing", typeof(double), typeof(GridCanvas),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsRender));

        public double HorizontalGridSpacing
        {
            get => (double)GetValue(HorizontalGridSpacingProperty);
            set => SetValue(HorizontalGridSpacingProperty, value);
        }
        /// <summary>Identifies the <see cref="HorizontalGridSpacing"/> attached property.</summary>
        public static readonly DependencyProperty HorizontalGridSpacingProperty =
            DependencyProperty.Register("HorizontalGridSpacing", typeof(double), typeof(GridCanvas),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsRender));


        public Brush GridLineStoke
        {
            get => (Brush)GetValue(GridLineStokeProperty);
            set => SetValue(GridLineStokeProperty, value);
        }
        /// <summary>Identifies the <see cref="GridLineStoke"/> attached property.</summary>
        public static readonly DependencyProperty GridLineStokeProperty =
            DependencyProperty.Register("GridLineStoke", typeof(Brush), typeof(GridCanvas),
                new FrameworkPropertyMetadata(Brushes.Gray, FrameworkPropertyMetadataOptions.AffectsRender,
                    (d, e) =>
                    {
                        if (d is not GridCanvas self)
                            return;
                        if (e.NewValue is not Brush brush)
                            return;

                        self._gridLinePen = new Pen(brush, 1d);
                        self._gridLinePen.Freeze();
                    }));


        public double GridLineThickness
        {
            get => (double)GetValue(GridLineThicknessProperty);
            set => SetValue(GridLineThicknessProperty, value);
        }
        /// <summary>Identifies the <see cref="GridLineThickness"/> attached property.</summary>
        public static readonly DependencyProperty GridLineThicknessProperty =
            DependencyProperty.Register("GridLineThickness", typeof(double), typeof(GridCanvas),
                new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender,
                    (d, e) =>
                    {
                        if (d is not GridCanvas self)
                            return;
                        if (self.GridLineStoke == null)
                            return;

                        self._gridLinePen = new Pen(self.GridLineStoke, (double)e.NewValue);
                        self._gridLinePen.Freeze();
                    }));


        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            if (HorizontalGridSpacing > 0d)
            {
                for (double x = HorizontalGridSpacing; x < ActualWidth; x += HorizontalGridSpacing)
                {
                    dc.DrawLine(
                        _gridLinePen,
                        new Point(x, 0),
                        new Point(x, ActualHeight));
                }
            }

            if (VerticalGridSpacing > 0d)
            {
                for (double y = VerticalGridSpacing; y < ActualHeight; y += VerticalGridSpacing)
                {
                    dc.DrawLine(
                        _gridLinePen,
                        new Point(0, y),
                        new Point(ActualWidth, y));
                }
            }

        }
    }
}
