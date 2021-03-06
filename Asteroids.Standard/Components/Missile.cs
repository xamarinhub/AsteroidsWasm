﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Asteroids.Standard.Base;
using Asteroids.Standard.Screen;

namespace Asteroids.Standard.Components
{
    /// <summary>
    /// Guided missle to target a <see cref="Ship"/>.
    /// </summary>
    class Missile : ScreenObject
    {
        private const double Velocity = 2000 / ScreenCanvas.FPS;

        /// <summary>
        /// Creates a new instace of <see cref="Missile"/>.
        /// </summary>
        /// <param name="saucer">Parent <see cref="Saucer"/>.</param>
        public Missile(Saucer saucer) : base(saucer.GetCurrLoc())
        {
            ExplosionLength = 1;
        }

        protected override void InitPoints()
        {
            ClearPoints();
            AddPoints(PointsTemplate);
        }

        /// <summary>
        /// Moves in the direction of the target <see cref="Point"/>.
        /// </summary>
        /// <param name="target">Point to target.</param>
        /// <returns>Indication if the move was successful.</returns>
        public bool Move(Point target)
        {
            //point at the ship
            Align(target);

            //adjust velocity
            velocityX = -Math.Sin(radians) * Velocity;
            velocityY = Math.Cos(radians) * Velocity;

            return Move();
        }

        #region Statics

        /// <summary>
        /// Non-transformed point template for creating a new missile.
        /// </summary>
        private static IList<Point> PointsTemplate = new List<Point>();

        /// <summary>
        /// Index location in <see cref="PointsTemplate"/> for thrust point 1.
        /// </summary>
        public static int PointThrust1 { get; }

        /// <summary>
        /// Index location in <see cref="PointsTemplate"/> for thrust point 2.
        /// </summary>
        public static int PointThrust2 { get; }

        /// <summary>
        /// Setup the <see cref="PointsTemplate"/>.
        /// </summary>
        static Missile()
        {
            const int s = 12;

            PointsTemplate.Add(new Point(0, -4 * s));
            PointsTemplate.Add(new Point(s, -3 * s));
            PointsTemplate.Add(new Point(s, 3 * s));
            PointsTemplate.Add(new Point(2 * s, 4 * s));

            PointsTemplate.Add(new Point(s, 4 * s)); //Midpoint for thrust
            PointsTemplate.Add(new Point(-s, 4 * s)); //Midpoint for thrust

            PointsTemplate.Add(new Point(-2 * s, 4 * s));
            PointsTemplate.Add(new Point(-s, 3 * s));
            PointsTemplate.Add(new Point(-s, -3 * s));

            PointThrust1 = 4;
            PointThrust2 = 5;
        }

        #endregion
    }
}
