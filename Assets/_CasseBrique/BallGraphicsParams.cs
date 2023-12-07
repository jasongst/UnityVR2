using UnityEngine;

namespace _CasseBrique
{
    public record BallGraphicsParams
    {
        /// <summary>
        ///  The color of the ball
        /// </summary>
        public Color ballColor;
        
        /// <summary>
        /// The color of the little grid on the ball
        /// </summary>
        public Color gridColor;

        public BallGraphicsParams(Color ballColor, Color gridColor)
        {
            this.ballColor = ballColor;
            this.gridColor = gridColor;
        }
    }
    
}