﻿namespace Task3.Controllers
{
    using System;
    using System.Collections.Generic;
    using Task3.Models;

    /// <summary>
    /// Store and manage offers.
    /// </summary>
    public class OfferController
    {
        /// <summary>
        /// <see cref="List{Offer}"/> of <see cref="Offer"/>s.
        /// </summary>
        private readonly List<Offer> offers;

        /// <summary>
        /// This function initializes a new instance of the <see cref="OfferController" /> class.
        /// </summary>
        /// <param name="lo"><see cref="List{Offer}"/> of <see cref="Offer"/>s.</param>
        public OfferController(List<Offer> lo)
        {
            this.offers = lo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController" /> class.
        /// </summary>
        public OfferController() : this(new List<Offer>())
        {
        }

        /// <summary>
        /// Function that adding offer to <see cref="List{Offer}"/>.
        /// </summary>
        /// <param name="offer">Needed Offer.</param>
        public void AddOffer(Offer offer)
        {
            this.offers.Add(offer);
        }

        /// <summary>
        /// Remove offer from <see cref="List{Offer}"/>.
        /// </summary>
        /// <param name="offer">Needed Offer.</param>
        public void RemoveOffer(Offer offer)
        {
            this.offers.Remove(offer);
        }

        /// <summary>
        /// Function that getting offer from <see cref="List{Offer}"/>.
        /// </summary>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s.</returns>
        public List<Offer> GetOffers()
        {
            return this.offers;
        }

        /// <summary>
        /// Get list of offers with applied filter.
        /// </summary>
        /// <param name="filter">Filter to apply.</param>
        /// <returns><see cref="List{Offer}"/> of <see cref="Offer"/>s.</returns>
        public List<Offer> GetOffers(Filter filter)
        {
            try
            {
                List<Offer> res = new List<Offer>();

                foreach (Offer o in this.offers)
                {
                    if (filter.MinDateOfPosting != null)
                    {
                        if (o.DateOfPosting < filter.MinDateOfPosting)
                        {
                            continue;
                        }
                    }

                    if (filter.MaxDateOfPosting != null)
                    {
                        if (o.DateOfPosting > filter.MaxDateOfPosting)
                        {
                            continue;
                        }
                    }

                    if (filter.From != null)
                    {
                        if (o.From != filter.From)
                        {
                            continue;
                        }
                    }

                    if (filter.To != null)
                    {
                        if (o.To != filter.To)
                        {
                            continue;
                        }
                    }

                    if (filter.MinDateOfLoading != null)
                    {
                        if (o.DateOfLoading < filter.MinDateOfLoading)
                        {
                            continue;
                        }
                    }

                    if (filter.MaxDateOfLoading != null)
                    {
                        if (o.DateOfLoading > filter.MaxDateOfLoading)
                        {
                            continue;
                        }
                    }

                    if (filter.Type != null)
                    {
                        if (o.Carrier.Vehicle.Type != filter.Type)
                        {
                            continue;
                        }
                    }

                    if (filter.MinWeight != null)
                    {
                        if (o.Carrier.Vehicle.Weight < filter.MinWeight)
                        {
                            continue;
                        }
                    }

                    if (filter.MaxWeight != null)
                    {
                        if (o.Carrier.Vehicle.Weight > filter.MaxWeight)
                        {
                            continue;
                        }
                    }

                    res.Add(o);
                }

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
