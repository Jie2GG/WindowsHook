using System.Drawing;

namespace System.Hooks
{
    /// <summary>
    /// 为 <see cref="GlobalHookMouse.MouseUp"/>、<see cref="GlobalHookMouse.MouseDown"/>、<see cref="GlobalHookMouse.MouseMove"/> 和 <see cref="GlobalHookMouse.MouseWheel"/> 事件提供数据。
    /// </summary>
    public class MouseEventArgs : EventArgs
    {
        #region --字段--
        private readonly MouseButtons button;
        private readonly int clicks;
        private readonly int x;
        private readonly int y;
        private readonly int delta;
        private bool _handled;
        private bool _suppressMousePress;
        #endregion

        #region --属性--
        /// <summary>
        /// 获取曾按下的是哪个鼠标按钮。
        /// </summary>
        public MouseButtons Button
        {
            get
            {
                return button;
            }
        }

        /// <summary>
        /// 获取按下并释放鼠标按钮的次数。
        /// </summary>
        public int Clicks
        {
            get
            {
                return clicks;
            }
        }

        /// <summary>
        /// 获取鼠标在产生鼠标事件时的 x 坐标。
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
        }

        /// <summary>
        /// 获取鼠标在产生鼠标事件时的 y 坐标。
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// 获取鼠标轮已转动的制动器数的有符号计数乘以 WHEEL_DELTA 常数。 制动器是鼠标轮的一个凹口。
        /// </summary>
        public int Delta
        {
            get
            {
                return delta;
            }
        }

        /// <summary>
        /// 获取鼠标在产生鼠标事件时的位置。
        /// </summary>
        public Point Location
        {
            get
            {
                return new Point (x, y);
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示鼠标事件是否应传递到基础控件。
        /// </summary>
        public bool SuppressMousePress
        {
            get
            {
                return this._suppressMousePress;
            }
            set
            {
                this._suppressMousePress = value;
                this._handled = value;
            }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否处理过此事件。
        /// </summary>
        public bool Handled
        {
            get
            {
                return this._handled;
            }
            set
            {
                this._handled = value;
            }
        }
        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化 <see cref="MouseEventArgs"/> 类的新实例。
        /// </summary>
        /// <param name="button"><see cref="MouseButtons"/> 值之一，指示按下的鼠标按钮。</param>
        /// <param name="clicks">按下鼠标按钮的次数。</param>
        /// <param name="x">鼠标单击的 x 坐标（以像素为单位）。</param>
        /// <param name="y">鼠标单击的 y 坐标（以像素为单位）。</param>
        /// <param name="delta">鼠标轮已转动的制动器数的有符号计数。</param>
        public MouseEventArgs (MouseButtons button, int clicks, int x, int y, int delta)
        {
            this.button = button;
            this.clicks = clicks;
            this.x = x;
            this.y = y;
            this.delta = delta;
        }
        #endregion
    }
}
