
using MigraDoc.DocumentObjectModel;
using System;
using System.ComponentModel;
using System.Drawing;

namespace PrintCore
{
    //
    // 摘要:
    //     Provides functionality to measure the width of text during document design time.
    public sealed class TextMeasurement
    {
        private MigraDoc.DocumentObjectModel.Font font;

        private System.Drawing.Font gdiFont;

        private Graphics graphics;

        //
        // 摘要:
        //     Gets or sets the font used for measurement.
        public MigraDoc.DocumentObjectModel.Font Font
        {
            get
            {
                return font;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                if (font != value)
                {
                    font = value;
                    gdiFont = null;
                }
            }
        }

        //
        // 摘要:
        //     Initializes a new instance of the TextMeasurement class with the specified font.
        public TextMeasurement(MigraDoc.DocumentObjectModel.Font font)
        {
            if (font == null)
            {
                throw new ArgumentNullException("font");
            }

            this.font = font;
        }

        //
        // 摘要:
        //     Returns the size of the bounding box of the specified text.
        public SizeF MeasureString(string text, UnitType unitType)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            if (!Enum.IsDefined(typeof(UnitType), unitType))
            {
                throw new InvalidEnumArgumentException();
            }

            Graphics graphics = Realize();
            SizeF result = graphics.MeasureString(text, gdiFont, new PointF(0f, 0f), StringFormat.GenericTypographic);
            switch (unitType)
            {
                case UnitType.Centimeter:
                    result.Width = (float)((double)result.Width * 2.54 / 72.0);
                    result.Height = (float)((double)result.Height * 2.54 / 72.0);
                    break;
                case UnitType.Inch:
                    result.Width /= 72f;
                    result.Height /= 72f;
                    break;
                case UnitType.Millimeter:
                    result.Width = (float)((double)result.Width * 25.4 / 72.0);
                    result.Height = (float)((double)result.Height * 25.4 / 72.0);
                    break;
                case UnitType.Pica:
                    result.Width /= 12f;
                    result.Height /= 12f;
                    break;
            }

            return result;
        }

        //
        // 摘要:
        //     Returns the size of the bounding box of the specified text in point.
        public SizeF MeasureString(string text)
        {
            return MeasureString(text, UnitType.Point);
        }

        //
        // 摘要:
        //     Initializes appropriate GDI+ objects.
        private Graphics Realize()
        {
            if (graphics == null)
            {
                graphics = Graphics.FromHwnd(IntPtr.Zero);
            }

            graphics.PageUnit = GraphicsUnit.Point;
            if (gdiFont == null)
            {
                FontStyle fontStyle = FontStyle.Regular;
                if (font.Bold)
                {
                    fontStyle |= FontStyle.Bold;
                }

                if (font.Italic)
                {
                    fontStyle |= FontStyle.Italic;
                }

                gdiFont = new System.Drawing.Font(font.Name, font.Size, fontStyle, GraphicsUnit.Point);
            }

            return graphics;
        }
    }
}