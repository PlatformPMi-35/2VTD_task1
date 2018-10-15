﻿namespace Task2.Library
{
    using System.Collections.ObjectModel;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    /// Represents Model_View part of pattern
    /// </summary>
    public class LineDrawingManager
    {
        /// <summary>
        /// Creates isnstance.
        /// </summary>
        public LineDrawingManager()
        {
            this.Polylines = new ObservableCollection<PolyLine>();           
        }

        /// <summary>
        /// Gets or sets <see cref="ObservableCollection"/> .
        /// </summary>
        public ObservableCollection<PolyLine> Polylines { get; set; }

        /// <summary>
        /// Adds <see cref="PolyLine"/ to <see cref="ObservableCollection"/> >
        /// </summary>
        /// <param name="line"><see cref="Polyline"/> to add.</param>
        /// <param name="color"><see cref="Brush"/>(Color) to draw.</param>
        public void AddPl(Polyline line, Brush color)
        {
            PolyLine pl = new PolyLine(line.Points, color);
            this.Polylines.Add(pl);
        }

        /// <summary>
        /// Creates and Adds <see cref="PolyLine"/> to <see cref="ObservableCollection"/> >
        /// </summary>
        /// <param name="line"><see cref="Polyline"/> to add.</param>
        public void AddPl(Polyline line)
        {
            PolyLine pl = new PolyLine(line.Points);
            this.Polylines.Add(pl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        public void AddPl(PolyLine line)
        {
            this.Polylines.Add(line);
        }
    }
}
