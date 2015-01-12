﻿using MobileCRM.Shared.Models;
using MobileCRM.Shared.ViewModels.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileCRM.Shared.Interfaces;
using Xamarin.Forms;

namespace MobileCRM.Shared.Pages.Contacts
{
	public partial class ContactDetailsView
	{

		public ContactDetailsView (ContactDetailsViewModel viewModel)
		{
				InitializeComponent ();

				SetBinding(Page.TitleProperty, new Binding("Title"));
				SetBinding(Page.IconProperty, new Binding("Icon"));

				this.BindingContext = viewModel;

		} //end ctor


	    async private void OnPhoneTapped(object sender, EventArgs e)
	    {
	        if (sender == null)
	        {
	            return;
	        }

            string phoneCell = ((EntryCell)sender).Text;

	        if (String.IsNullOrEmpty(phoneCell) == true)
	        {
	            return;
	        }            

	        if (await this.DisplayAlert(
	            "Dial a Number",
	            "Would you like to call " + phoneCell + "?",
	            "Yes",
	            "No"))
	        {

	            var dialer = DependencyService.Get<IDialer>();
	            phoneCell = phoneCell.Replace("-", "");
	            if (dialer == null)
	            {
	                return;
	            }

	            dialer.Dial(phoneCell);
	        }
	    }
	} //end class
}
