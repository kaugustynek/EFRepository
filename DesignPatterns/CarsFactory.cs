using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface ICarsFactory
    {
        ICar MakeCar();
    }

    public class SedanFactory: ICarsFactory
	{	    	
	    public ICar MakeCar()
        {
 	        return new Sedan();
        }
    }

    public interface ICar
    {
        string GetCarType();
    }

    public class Sedan: ICar
    {
        public string GetCarType()
        {
            return "Sedan";
        }
    }
}
