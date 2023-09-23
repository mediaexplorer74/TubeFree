// Decompiled with JetBrains decompiler
// Type: AngleSharp.Css.TransformMatrix
// Assembly: AngleSharp, Version=0.9.9.0, Culture=neutral, PublicKeyToken=e83494dcdc6d31ea
// MVID: 6D8FC1AC-F585-421F-BEC1-9105A73220DF
// Assembly location: C:\Users\Admin\Desktop\re\Tube Free for WP v.1.6.8.0\AngleSharp.dll

using System;

namespace AngleSharp.Css
{
  public sealed class TransformMatrix : IEquatable<TransformMatrix>
  {
    public static readonly TransformMatrix Zero = new TransformMatrix();
    public static readonly TransformMatrix One = new TransformMatrix(1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
    private readonly float[,] _matrix;

    private TransformMatrix() => this._matrix = new float[4, 4];

    public TransformMatrix(float[] values)
      : this()
    {
      if (values == null)
        throw new ArgumentNullException(nameof (values));
      if (values.Length != 16)
        throw new ArgumentException("You need to provide 16 (4x4) values.", nameof (values));
      int index1 = 0;
      int index2 = 0;
      for (; index1 < 4; ++index1)
      {
        int index3 = 0;
        while (index3 < 4)
        {
          this._matrix[index3, index1] = values[index2];
          ++index3;
          ++index2;
        }
      }
    }

    public TransformMatrix(
      float m11,
      float m12,
      float m13,
      float m21,
      float m22,
      float m23,
      float m31,
      float m32,
      float m33,
      float tx,
      float ty,
      float tz,
      float px,
      float py,
      float pz)
      : this()
    {
      this._matrix[0, 0] = m11;
      this._matrix[0, 1] = m12;
      this._matrix[0, 2] = m13;
      this._matrix[1, 0] = m21;
      this._matrix[1, 1] = m22;
      this._matrix[1, 2] = m23;
      this._matrix[2, 0] = m31;
      this._matrix[2, 1] = m32;
      this._matrix[2, 2] = m33;
      this._matrix[0, 3] = tx;
      this._matrix[1, 3] = ty;
      this._matrix[2, 3] = tz;
      this._matrix[3, 0] = px;
      this._matrix[3, 1] = py;
      this._matrix[3, 2] = pz;
      this._matrix[3, 3] = 1f;
    }

    public float M11 => this._matrix[0, 0];

    public float M12 => this._matrix[0, 1];

    public float M13 => this._matrix[0, 2];

    public float M21 => this._matrix[1, 0];

    public float M22 => this._matrix[1, 1];

    public float M23 => this._matrix[1, 2];

    public float M31 => this._matrix[2, 0];

    public float M32 => this._matrix[2, 1];

    public float M33 => this._matrix[2, 2];

    public float Tx => this._matrix[0, 3];

    public float Ty => this._matrix[1, 3];

    public float Tz => this._matrix[2, 3];

    public bool Equals(TransformMatrix other)
    {
      float[,] matrix1 = this._matrix;
      float[,] matrix2 = other._matrix;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if ((double) matrix1[index1, index2] != (double) matrix2[index1, index2])
            return false;
        }
      }
      return true;
    }

    public override bool Equals(object obj) => obj is TransformMatrix other && this.Equals(other);

    public override int GetHashCode()
    {
      float hashCode = 0.0f;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
          hashCode += this._matrix[index1, index2] * (float) (4 * index1 + index2);
      }
      return (int) hashCode;
    }
  }
}
