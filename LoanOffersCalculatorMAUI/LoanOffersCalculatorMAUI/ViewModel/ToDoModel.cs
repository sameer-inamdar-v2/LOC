using Realms.Sync;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using LoanOffersCalculatorMAUI.Data;
using CommunityToolkit.Mvvm.Input;
//using TodoMaui.Helpers;
using static Realms.ThreadSafeReference;
using MongoDB.Bson;

namespace LoanOffersCalculatorMAUI.ViewModel
{
	public class ToDoModel
	{

        public string Id { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }

        public bool Completed { get; set; }

        public string Partition { get; set; }


    }
}
