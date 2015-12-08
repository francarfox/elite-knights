using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EliteKnightsModel
{
    public class Vector
    {
        private float x, y, z;

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(float x, float y)
            : this(x, y, 0)
        { }

        public void Move(Vector traslation, float rotation)
        {
            Vector3 tras = new Vector3(traslation.X, traslation.Z, traslation.Y);
            Vector3 move = Vector3.Transform(tras, Matrix.CreateRotationY(rotation));

            Sume(move);
        }

        private void Sume(Vector3 move)
        {
            x += move.X;
            y += move.Z;
            z += move.Y;
        }

        public float Module()
        {
            return (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public Vector Product(float porcentage)
        {
            return new Vector(x * porcentage, y * porcentage, z * porcentage);
        }

        public Vector Diference(Vector vector)
        {
            return new Vector(x - vector.X, y - vector.Y, z - vector.Z);
        }

        public void Normalize()
        {
            Vector3 vector = new Vector3(x, y, z);
            vector.Normalize();

            x = vector.X;
            y = vector.Y;
            z = vector.Z;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        public static Vector Zero
        {
            get { return new Vector(0, 0); }
        }
    }
}
