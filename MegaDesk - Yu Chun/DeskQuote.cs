﻿using System;
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
        // get the material cost based on the material the customer chose
        public decimal GetMaterialCost()
        {
            switch (Desk.SurfaceMaterial)
            {
                case DesktopMaterial.Laminate:
                    return LAMINATE_COST;

                case DesktopMaterial.Oak:
                    return OAK_COST;

                case DesktopMaterial.Rosewood:
                    return ROSEWOOD_COST;

                case DesktopMaterial.Veneer:
                    return VENEER_COST;

                case DesktopMaterial.Pine:
                    return PINE_COST;
                default:
                    return 0.00M;
            }
        }

        // get the total cost of surface area, if total is less or equal to 1000, then it is free
        public decimal GetTotalSurfaceAreaCost(decimal surfaceArea)
        {
            if (surfaceArea > 1000)
            {
                return surfaceArea * SURFACE_AREA_COST;
            }
            else
            {
                return 0.00M;
            }
        }

        public decimal GetRushOrderCost()
        {
            return 0.00M;
        }

        // get the total price for the specific quote
        public decimal GetQuotePrice()
        {
            decimal totalPrice;
            decimal surfaceArea = Desk.Depth * Desk.Width;

            decimal totalSurfaceAreaCost = GetTotalSurfaceAreaCost(surfaceArea);
            decimal totalDrawerCost = Desk.NumberOfDrawers * DRAWER_COST;
            decimal surfaceMaterialCost = GetMaterialCost();
            decimal shippingCost = GetRushOrderCost();

            totalPrice = BASE_DESK_PRICE + totalSurfaceAreaCost + totalDrawerCost + surfaceMaterialCost;  
            return totalPrice;
        }
    }
}
