﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2test1
{
	public partial class CommunityForum : Form
	{
		Customer loggedInCustomer;
		PostForm postObject;
		List<Customer> listOfCustomers = new List<Customer>();
		string userInput;
		public CommunityForum(Customer loggedInCustomer)
		{
			InitializeComponent();
			this.loggedInCustomer = loggedInCustomer;
		}
		public void Form5_Load(object sender, EventArgs e)
		{
			Post postObject = new Post();
			string[] post = postObject.readPostFile();
			string[] postDetails = post[0].Split('|');

			for (int ii = 0; ii < postDetails.Length; ii++)
			{
				string element = postDetails[ii];
				TextBox textBox = new TextBox();
				textBox.Text = element;
				textBox.Dock = DockStyle.Top;
				panel1.Controls.Add(textBox);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Hide();
			new PostForm(loggedInCustomer).Show();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			textBox1.Text = userInput;
			System.IO.File.AppendAllText(string.Format("post.txt"), (string.Format("," + textBox1)));
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
			new DashBoard(loggedInCustomer,listOfCustomers).Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string userInput = textBox1.Text; 
			textBox1.Visible = true;
		}
	}
}
