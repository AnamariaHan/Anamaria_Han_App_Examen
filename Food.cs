using System;
using System.Collections.Generic;
using System.Text;

namespace Anamaria_Han_App_Examen
{
    class Food
    {

        private FoodType mProduct;

        public FoodType Product
        {
            get
            {
                return mProduct;
            }
            set
            {
                mProduct = value;
            }
        }

        private float mPrice;

        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public Food(FoodType aProduct) // constructor
        {
            mProduct = aProduct;
        }
    }
    public enum FoodType
    {
        Muffin,
        Cookies,
        IceCream,
        Juice,
        Tea,
        Coffee
    }

}

