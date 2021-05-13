using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk___Yu_Chun
{
    public enum Delivery
    {
        Rush3Day,
        Rush5Day,
        Rush7Day,
        Normal14Day
    }

    public class DeskQuote
    {
        // constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;
        private const decimal OAK_COST = 200.00M;
        private const decimal LAMINATE_COST = 100.00M;
        private const decimal PINE_COST = 50.00M;
        private const decimal ROSEWOOD_COST = 300.00M;
        private const decimal VENEER_COST = 125.00M;


        // properties
        public Desk Desk { get; set; }
        public string QuoteDate { get; set; } // set the type to string because we will convert dateTime to string later
        public string CustomerName { get; set; }
        public Delivery DeliveryType { get; set; }


        // methods

        //public decimal GetMaterialCost()
        //{
        //    switch(Desk.SurfaceMaterial)
        //    {
        //        case Laminate:
        //            return LAMINATE_COST;

        //        case Oak:
        //            return OAK_COST;

        //        case 2:
        //            return ROSEWOOD_COST;

        //        case 3:
        //            return VENEER_COST;

        //        case 4:
        //            PINE_COST;
        //    }
        //}

        public decimal GetQuotePrice()
        {
            decimal totalPrice;
            decimal surfaceArea = Desk.Depth * Desk.Width;
            decimal totalSurfaceAreaCost = surfaceArea * SURFACE_AREA_COST;
            decimal totalDrawerCost = Desk.NumberOfDrawers * DRAWER_COST;
            //decimal surfaceMaterialCost = getMaterialCost();
            return totalSurfaceAreaCost; 
        }

        public void GetRushOrder()
        {

        }
    }
}
