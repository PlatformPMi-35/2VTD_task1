﻿namespace Task3
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;
    using Task3.Controllers;
    using Task3.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            try
            {
                this.InitializeComponent();
                //IOConroller.GenerateRandomOffers();

                //OfferController offerController = new OfferController(IOConroller.LoadOffer(@"../../Resourses/Offres.dat"));
                //DbController.SaveOffers(offerController.GetOffers());

            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Image MouseDown
        /// </summary>
        /// <param name="sender">Just Object</param>
        /// <param name="e">MouseButtonEventArgs e</param>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var v = fromCountry.Text;
                fromCountry.Text = toCountry.Text;
                toCountry.Text = v;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }

        /// <summary>
        /// Button Click
        /// </summary>
        /// <param name="sender">Just Object</param>
        /// <param name="e">MouseButtonEventArgs e</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Filter f = new Filter(
                from: fromCountry.Text != string.Empty ? fromCountry.Text : null,
                to: toCountry.Text != string.Empty ? toCountry.Text : null,
                minDateOfLoading: dateFrom.SelectedDate,
                maxDateOfLoading: dateTo.SelectedDate,
                type: (VehicleType?)(expander1.SelectedIndex - 1),
                minWeight: double.TryParse(weightFrom.Text, out double res1) ? res1 as double? : null,
                maxWeight: double.TryParse(weightTo.Text, out double res2) ? res2 as double? : null);
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    OfferController offerController = new OfferController(new List<Offer>(unitOfWork.Offers.GetAll()));
                    dataList.ItemsSource = offerController.GetOffers(f);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error occured");
            }
        }
    }
}
