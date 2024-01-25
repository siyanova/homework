using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=homework;Integrated Security=SSPI;");
                connection.Open();
                ConnectionText.Text = "";
                ConnectionText.Text = "Подключение установлено";
            }
            catch
            {
                ConnectionText.Text = " ";
                ConnectionText.Text = "Ошибка подключения к серверу";
                ConnectionBack.Background = new SolidColorBrush(Colors.LightGray);
            }
        }

        private void Fulltable_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT*FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for(int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Close();
                ConnectionText.Text = " ";
                ConnectionText.Text = "Сервер отключен";
                ConnectionBack.Background = new SolidColorBrush(Colors.LightGray);

            }
            catch
            {
                ConnectionText.Text = " ";
                ConnectionText.Text = "Ошибка отключения к серверу";
                ConnectionBack.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void FruitandVeget_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT names FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT color FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void MaxColories_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT MAX(calorie) FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void MinColories_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT MIN(calorie) FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void MidColories_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT AVG(calorie) FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void CountVeg_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT SUM(CASE WHEN kind='veg' THEN 1 ELSE 0 END) FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void CountFruit_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT SUM(CASE WHEN kind='fruit' THEN 1 ELSE 0 END) FROM Fruit";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void CountColor_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            
            string fulltable = @"SELECT count(*) from Fruit where color='"+ colorinput.Text+"'";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void MinCalorie_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";

            string fulltable = @"SELECT names from Fruit where calorie<'" + MinCalorieText.Text + "'";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void MaxCalorie_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";

            string fulltable = @"SELECT names from Fruit where calorie>'" + MaxCalorieText.Text + "'";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void DiaCalorie_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";

            string fulltable = @"SELECT names from Fruit where calorie>'" + Min.Text + "' and calorie<'" + Max.Text + "'";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void YellowOrRed_Click(object sender, RoutedEventArgs e)
        {
            output.Text = "";

            string fulltable = @"SELECT names from Fruit where color='yellow' or color='red'";
            SqlCommand command = new SqlCommand(fulltable, connection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }
    }
}
