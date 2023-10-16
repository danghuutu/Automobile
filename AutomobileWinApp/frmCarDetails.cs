using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomobileLibrary.BusinesssObject;
using AutomobileLibrary.Repository;
namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        public ICarRepository CarRepository { get; set; }
        public bool InsertorUpdate { get; set; }
        public Car CarInfo{ get; set; }
        
        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertorUpdate;
            if(InsertorUpdate == true )
            {
                txtCarID.Text = CarInfo.CarID.ToString();
                txtCarName.Text = CarInfo.CarName;
                txtPrice.Text = CarInfo.Price.ToString();
                txtReleasedYear.Text = CarInfo.ReleasedYear.ToString();
                cboManufacturer.Text = CarInfo.Manufacturer.Trim();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleasedYear = int.Parse(txtReleasedYear.Text)

                };
                if(InsertorUpdate == false)
                {
                    CarRepository.InsertCar(car);
                }
                else
                {
                    CarRepository.UpdateCar(car);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, InsertorUpdate == false ? "Add a new car": "Update a car");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
