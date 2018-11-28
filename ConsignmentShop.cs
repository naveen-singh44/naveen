using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {

        private Store store = new Store();
        private List<item> shoppingCartdata = new List<item>(); 
        BindingSource itemsBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();

        public ConsignmentShop()
        {
            InitializeComponent();
            SetupData();
            itemsBinding.DataSource = store.Items.Where(x=> x.Sold==false).ToList();
            ItemListBox.DataSource = itemsBinding;

            ItemListBox.DisplayMember = "Display";
            ItemListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingCartdata;
            ShoppingCartListBox.DataSource = cartBinding;

            ShoppingCartListBox.DisplayMember = "Display";
            ShoppingCartListBox.ValueMember = "Display";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetupData()
        {
            store.Vendors.Add(new Vendor { FirstName = "Raja", LastName = " Duggabati", });
            store.Vendors.Add(new Vendor { FirstName = "Ram", LastName = " Singh" });
            store.Vendors.Add(new Vendor { FirstName = "Tim", LastName = " Correy" });
            store.Vendors.Add(new Vendor { FirstName = "Sue", LastName = " Jones" });
            store.Vendors.Add(new Vendor { FirstName = "Naveen", LastName = "Singh" });

            store.Items.Add(new item
            {
                Title = "Moby Dick",
                Description = "A book about a whale",
                Price = 4.50M,
                Owner = store.Vendors[0],
                PaymentDisrtibuted = true
            });
            store.Items.Add(new item
            {
                Title = "Meryy Jackson",
                Description = "A book about a Sheep",
                Price = 6.90M,
                Owner = store.Vendors[1],
                PaymentDisrtibuted = true
            });
            store.Items.Add(new item
            {
                Title = "Harry Potter",
                Description = "A book about a Guy",
                Price = 5.90M,
                Owner = store.Vendors[2],
                PaymentDisrtibuted = true
            });
            store.Items.Add(new item
            {
                Title = "Larry ",
                Description = "A book about a Google",
                Price = 6.90M,
                Owner = store.Vendors[3],
                PaymentDisrtibuted = true
            });
            store.Items.Add(new item
            {
                Title = "Dress",
                Description = "A book about a Clothes",
                Price = 6.60M,
                Owner = store.Vendors[4],
                PaymentDisrtibuted = true
            });

            store.Name = "Seconds are Better";
        }

        private void AddToCart_Click_1(object sender, EventArgs e)
        {
            // Figure out what is selected from the items list
            // Copy that item to the shopping cart

            item selectedItem = (item)ItemListBox.SelectedItem;

            shoppingCartdata.Add(selectedItem);

            cartBinding.ResetBindings(false);
            
        }

        private void MakePurchase_Click(object sender, EventArgs e)
        {
            // mark each item in the cart as sold
            // Clear the cart
            foreach (item item in shoppingCartdata)
            {
                item.Sold = true;
            }
            shoppingCartdata.Clear();

            itemsBinding.DataSource = store.Items.Where(x => x.Sold == false).ToList();

            cartBinding.ResetBindings(false);
            itemsBinding.ResetBindings(false);
        }
    }
}
