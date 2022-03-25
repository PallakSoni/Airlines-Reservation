/*
 * 
 * Program Name: Assignment 1
 * 
 * Purpose: Implementing Windows form Application
 * 
 * Created by: Palak Soni, June 12, 2020
 * 
 * 
 */
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservation
{
    public partial class AirlineReservation : Form
    {
        RadioButton seatButton;
        string[,] booking;
        string[] waitList = new string[20];
        int const_Wseatlist;
        bool debug = false;
        string[] seatLabel = new string[4] { "A", "B", "C", "D" };
        string[,] debugNames = new string[5, 4] {
            { "Angelina leo", " Palak Soni", "Critino sam", "Chinar Shak" },
            {"Osazee Atekha","Bhavya pancholi","Owen Towriss","Nathan Towriss" }
            ,{"Noopur Patel","Ariel Palubaski","Asif Khan","Dylan Dong" },
            { "Amanda Bunny","Angle Fisher","Cris Brown","Jeffrey List"},
            {"Yash Patel","Celina Gomez","Lawren Strachen","Mani Tamang" }  
        };
        
        public AirlineReservation()
        {
            InitializeComponent();
        }

        private void AirlineReservation_Load(object sender, EventArgs e)
        {
            const_Wseatlist = 0;
            booking = new string[5, 4];
            
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            debug = false;
            if ((seatButton != null) && (txtName.Text != ""))
            {


                string seatTag = (string)seatButton.Tag;
                string[] seatIdStrings = seatTag.Split(',');

                // the seat IdStrings array should have 2 elements
                // at 0 will be the row of the seat
                // at 1 will be the column of the seat
                int row = int.Parse(seatIdStrings[0]);
                int col = int.Parse(seatIdStrings[1]);

                if (booking[row, col] == null || booking[row, col] == "")
                {
                    booking[row, col] = txtName.Text;
                    lblOutput.Text = "SUCCESS: Seat Booked!";
                    seatButton.BackColor = Color.Red;
                    txtName.Text = "";
                    seatButton.Checked = false;
                    seatButton = null;
                }
                else
                {
                    lblOutput.Text = "ERROR: Requested seat is already Occupied";
                    
                }
            }
            else
            {
                if (seatButton == null)
                {
                    lblOutput.Text = "ERROR: Please Select a seat";
                }
                else
                {
                    lblOutput.Text = "ERROR: Please Enter Passangers Name";
                }
            }
        }


        private void btnShowSeats_Click(object sender, EventArgs e)
        {
            txtShowAllSeats.Clear();
            if (debug)
            {


                for (int row = 0; row < 5; row++)
                {

                    for (int col = 0; col < 4; col++)
                    {

                        txtShowAllSeats.Text = "\n" + txtShowAllSeats.Text + (row + 1) + seatLabel[col] + " - " + debugNames[row, col] + Environment.NewLine;

                    }
                }


            }
            else
            {
                for (int row = 0; row < 5; row++)
                {

                    for (int col = 0; col < 4; col++)
                    {

                        txtShowAllSeats.Text = "\n" + txtShowAllSeats.Text + (row + 1) + seatLabel[col] + " - " + booking[row, col] + Environment.NewLine;

                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            debug = false;
            if ((seatButton != null))
            {


                string seatTag = (string)seatButton.Tag;
                string[] seatIdStrings = seatTag.Split(',');

                //// the seat IdStrings array should have 2 elements
                //// at 0 will be the row of the seat
                //// at 1 will be the column of the seat
                int row = int.Parse(seatIdStrings[0]);
                int col = int.Parse(seatIdStrings[1]);

                if (booking[row, col] != null && booking[row, col] != "")
                {
                    booking[row, col] = null;
                    lblOutput.Text = "SUCCESS: Reservation Cancelled!";
                    seatButton.BackColor = Color.LightBlue;
                    txtName.Text = "";
                    seatButton.Checked = false;
                    seatButton = null;

                }
                
                else
                {
                    lblOutput.Text = "ERROR: Please select approporite seat which is booked already!";
                }


            }
            else
            {
                lblOutput.Text = "ERROR: Please select a seat";
            }
        }


        private void btnAddWaitingList_Click(object sender, EventArgs e)
        {
            txtshowWaitingList.Text = "";
            string name = txtName.Text;
            Boolean emptySeat = true;

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (booking[row, col] == null || booking[row, col] == "")
                    {
                        emptySeat = false;
                        lblOutput.Text = "ERROR: There are still seats available";
                        return;
                    }
                }
            }
            if (txtName.Text == "")
            {
                lblOutput.Text = "ERROR: Select a Seat";
            }
            else
            {
                waitList[const_Wseatlist] = name;
                const_Wseatlist++;
                lblOutput.Text = "SUCCESS: Passanger added to Waiting List";
            }


        }

        private void btnShowWaitingSeats_Click(object sender, EventArgs e)
        {
            txtName.Clear();

            for (int waitListSeat = 0; waitListSeat < waitList.Length; waitListSeat++)
            {

                txtshowWaitingList.Text = txtshowWaitingList.Text + waitList[waitListSeat] + Environment.NewLine;
            }
        }


        private void radio_selected(RadioButton obj)
        {
            seatButton = obj;
            seatButton.Checked = false;
        }

        private void rdbA1_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbB1_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbC1_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbD1_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbA2_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbB2_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbC2_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbD2_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbA3_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbB3_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbC3_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbD3_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbA4_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbB4_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbC4_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbD4_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbA5_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbB5_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbC5_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void rdbD5_CheckedChanged(object sender, EventArgs e)
        {
            radio_selected((RadioButton)sender);
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            debug = true;

            foreach (Control c in pnlSeats.Controls)
            {
                if (c is RadioButton)
                {
                    c.BackColor = Color.Red;
                }
            }

            for (int row = 0; row < 5; row++)
            {

                for (int col = 0; col < 4; col++)
                {
                    booking[row, col] = debugNames[row, col];
                }
            }
        }

        private void pnlSeats_Paint(object sender, PaintEventArgs e)
        {
            pnlSeats.BackColor = Color.LightSlateGray;
        }

       
    }
}
    
