using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //Task task = new Task(() =>
            //{
            //    for (int i = 0; i < 3000; i++)
            //    {
            //        this.lblResponse.Text = i.ToString();
            //    }
            //});

            //task.Start();

            //new Task(() =>
            //{
            //    for (int i = 0; i < 3000; i++)
            //    {
            //        this.lbl2.Text = i.ToString();
            //    }
            //}).Start();


            //task.ContinueWith((_task) =>
            //{
            //    MessageBox.Show("Finished " + _task.Id);
            //});

            using(SaleEntities db =new SaleEntities())
            {
                dgvData.Rows.Clear();
                List<Cutomer> customers = db.Cutomers.ToList(); 
                int rowIndex = 0;
                foreach (Cutomer item in customers)
                {
                    dgvData.Rows.Add();
                    dgvData.Rows[rowIndex].Cells[0].Value = (rowIndex + 1);
                    dgvData.Rows[rowIndex].Cells[1].Value = item.Id;
                    dgvData.Rows[rowIndex].Cells[2].Value = item.Name;
                    dgvData.Rows[rowIndex].Cells[3].Value = item.Email;
                    rowIndex++;
                }
            }
            MessageBox.Show("Complited Succesfuly"); 
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {

            //Task task = new Task(()=> 
            //{
            //   using(SaleEntities db =new SaleEntities())
            //    {
            //        dgvData.Rows.Clear();
            //        List<Cutomer> customers = db.Cutomers.ToList();
            //        int rowIndex = 0;
            //        foreach (Cutomer item in customers)
            //        {
            //            dgvData.Rows.Add();
            //            dgvData.Rows[rowIndex].Cells[0].Value = (rowIndex + 1);
            //            dgvData.Rows[rowIndex].Cells[1].Value = item.Id;
            //            dgvData.Rows[rowIndex].Cells[2].Value = item.Name;
            //            dgvData.Rows[rowIndex].Cells[3].Value = item.Email;
            //            rowIndex++;
            //        }
            //    }

            //});

            //task.Start();

            //task.ContinueWith((x) =>
            //{
            //    MessageBox.Show("Complited Succesfuly");
            //});



            await ReadDataAsync();


        }

        public async Task ReadDataAsync()
        {  
           await Task.Run(() =>
            {
                dgvData.Rows.Clear();
                List<Cutomer> customers = GetAllDataAsync().Result.ToList();
                int rowIndex = 0;
                foreach (Cutomer item in customers)
                {
                    dgvData.Rows.Add();
                    dgvData.Rows[rowIndex].Cells[0].Value = (rowIndex + 1);
                    dgvData.Rows[rowIndex].Cells[1].Value = item.Id;
                    dgvData.Rows[rowIndex].Cells[2].Value = item.Name;
                    dgvData.Rows[rowIndex].Cells[3].Value = item.Email;
                    rowIndex++;
                }
            });

        }


        public async Task<IEnumerable<Cutomer>> GetAllDataAsync()
        {
            using (SaleEntities db = new SaleEntities())
            {
                return await db.Cutomers.ToListAsync();
            }
        }
    }
}
