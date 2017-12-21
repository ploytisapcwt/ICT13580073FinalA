using System;
using System.Collections.Generic;
using ICT13580073FinalA.Model;


using Xamarin.Forms;

namespace ICT13580073FinalA
{
    public partial class ProductNewPage : ContentPage
    {   Product product;
        public ProductNewPage(Product product = null)
        {
            InitializeComponent();

            this.product = product;
			titleLable.Text = product == null ? "เพิ่มประวัติใหม่" : "แก้ไขรายชื่อ";
			
            saveButton.Clicked += SaveButton_Clicked;
            cancelButton.Clicked+= CancelButton_Clicked;
           
            genderPicker.Items.Add("หญิง");
			genderPicker.Items.Add("ชาย");

            departmentPicker.Items.Add("บัญชี");
			departmentPicker.Items.Add("การเงิน"); 
            departmentPicker.Items.Add("การตลาด"); 
            departmentPicker.Items.Add("ฝ่ายทรัพยากร");
            statuPicker.Items.Add("สมรส");
            statuPicker.Items.Add("โสด");

           /* mySlider.ValueChanged += MySlider_ValueChanged;*/
           
            myStepper.ValueChanged += MyStepper_ValueChanged;
			if (product != null)
			{
                /*nameEntry.Text = product.Name;
				desEntry.Text = product.Descrpition;
				categoryPicker.SelectedItem = product.Category;
				productPriceEntry.Text = product.ProductPrice.ToString();
				sellPriceEntry.Text = product.SellPrice.ToString();
				stockEntry.Text = product.Stock.ToString();*/
                nameEntry.Text = product.Name;
                lastnameEntry.Text = product.Lastname;
                ageEntry.Text = product.Age.ToString();
                genderPicker.SelectedItem = product.Gender;
                departmentPicker.SelectedItem = product.Department;
                telEntry.Text = product.Tel.ToString();
                emailEntry.Text = product.email.ToString();
                addressEditor.Text = product.Address.ToString();
                statuPicker.SelectedItem = product.Status;
                childrenLabel.Text = product.Children.ToString();
              

			}


        }

       
        void MyStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
			int value = (int)e.NewValue;
            /*value2Label.Text = value.ToString();*/
            childrenLabel.Text = value.ToString();
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบัญทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				if (product == null)
				{
					product = new Product();
					/*product.Name = nameEntry.Text;
					product.Descrpition = desEntry.Text;
					product.Category = categoryPicker.SelectedItem.ToString();
					product.ProductPrice = decimal.Parse(productPriceEntry.Text);
					product.SellPrice = decimal.Parse(sellPriceEntry.Text);
					product.Stock = int.Parse(stockEntry.Text);*/

                    product.Name = nameEntry.Text;
                    product.Lastname = lastnameEntry.Text;
                    product.Age = int.Parse(ageEntry.Text);
                    product.Gender = genderPicker.SelectedItem.ToString();
                    product.Department = departmentPicker.SelectedItem.ToString();
                    product.Tel = int.Parse(telEntry.Text);
                    product.email = emailEntry.Text;
                    product.Status = statuPicker.SelectedItem.ToString();
                    product.Children = childrenLabel.ToString();
                    product.Address = addressEditor.Text;
                    product.Saraly = salaryEntry.Text;


					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");
				}



				else
				{
					product.Name = nameEntry.Text;
					product.Lastname = lastnameEntry.Text;
					product.Age = int.Parse(ageEntry.Text);
					product.Gender = genderPicker.SelectedItem.ToString();
					product.Department = departmentPicker.SelectedItem.ToString();
					product.Tel = int.Parse(telEntry.Text);
					product.email = emailEntry.Text;
					product.Status = statuPicker.SelectedItem.ToString();
					product.Children = childrenLabel.ToString();
					product.Address = addressEditor.Text;
					product.Saraly = salaryEntry.Text;

					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้า" + id, "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
