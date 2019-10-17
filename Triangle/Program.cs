using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace Triangle
{
    
        public class Triangle
    {



        // variables for triangle

        public double SideA = 0;

        public double SideB = 0;

        public double SideC = 0;

        public double AngleA = 0;

        public double AngleB = 0;

        public double AngleC = 0;

        public double tBase = 0;



        public double FindAngle(double AngleA, double AngleB)

        {
            return (180.00 - AngleA - AngleB);

        }



       

        //public double FindArea(double tBase, double height)

        //{

        //    return (0.5 * (height * tBase));

        //}


        //public void FindTriangleType(double SideA, double SideB, double SideC)

        //{

        //    if (SideA == SideB && SideB == SideC)

        //    {

        //        Console.WriteLine("Equalateral Triangle!!1\n");

        //    }

        //    else if (SideA == SideB || SideB == SideC || SideA == SideC)

        //    {

        //        Console.WriteLine("Iscoles triangle!!\n");

        //    }

        //    else

        //    {

        //        Console.WriteLine("Scalene triangle!!!\n");

        //    }



        //}

    }
}
   

   