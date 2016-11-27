using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WaterHouseBusinessLayer
{
    public class OrderBusinessLayer
    {
        public IEnumerable<Order> OrderList
        {
           get{ //ConfigurationManager

               List<Order> orders = new List<Order>();
               var connectionString = ConfigurationManager.ConnectionStrings["OrderListDBContext"].ConnectionString;
               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                   var command = new SqlCommand("spGetALLOrders", connection);
                   command.CommandType = CommandType.StoredProcedure;

                   //SqlParameter parameterFIRSTNAME = new SqlParameter();
                   //parameterFIRSTNAME.ParameterName = "FIRSTNAME";

                   //SqlParameter parameterMIDDLENAME = new SqlParameter();
                   //parameterMIDDLENAME.ParameterName = "MIDDLENAME";

                   //SqlParameter parameterLASTNAME = new SqlParameter();
                   //parameterLASTNAME.ParameterName = "LASTNAME";

                   //SqlParameter parameterPHONENUMBER = new SqlParameter();
                   //parameterPHONENUMBER.ParameterName = "PHONENUMBER";

                   //SqlParameter parameterADDRESS = new SqlParameter();
                   //parameterADDRESS.ParameterName = "ADDRESS";

                   //SqlParameter parameterQTYBTBottle = new SqlParameter();
                   //parameterADDRESS.ParameterName = "QTYBTBottle";

                   //SqlParameter parameterQTYICEJUG = new SqlParameter();
                   //parameterADDRESS.ParameterName = "QTYICEJUG";

                   //SqlParameter parameterQTYPOUCE = new SqlParameter();
                   //parameterADDRESS.ParameterName = "QTYPOUCH";

                   //SqlParameter parameterROOT_ID = new SqlParameter();
                   //parameterADDRESS.ParameterName = "ROOT_ID";



                   connection.Open();
                   using (var reader = command.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           Order order = new Order();
                           order.ORDERNUMBER = Convert.ToInt32(reader["ORDERNUMBER"].ToString());
                           order.FIRSTNAME = reader["FIRSTNAME"].ToString();
                           order.MIDDLENAME = reader["MIDDLENAME"].ToString();
                           order.LASTNAME = reader["LASTNAME"].ToString();
                           order.MOBILENO = reader["MOBILENO"].ToString();
                           order.ADDRESS = reader["ADDRESS"].ToString();
                           order.QTYBTBOTTLE =Convert.ToInt32( reader["QTYBTBOTTLE"].ToString());
                           order.QTYICEBOTTLE =Convert.ToInt32(  reader["QTYICEBOTTLE"].ToString());
                           order.QTYPOUCH = Convert.ToInt32( reader["QTYPOUCH"].ToString());
                           order.ROOTID = Convert.ToInt32( reader["ROOTID"].ToString());
                           orders.Add(order);
                       }
                   }
               }

               return orders;
           }

        }

        public void AddOrder(Order order)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["OrderListDBContext"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("OrderAdd", connection);
                command.CommandType = CommandType.StoredProcedure;
                

                SqlParameter parameterFIRSTNAME = new SqlParameter();
                parameterFIRSTNAME.ParameterName = "FIRSTNAME";
            //    parameterFIRSTNAME.TypeName=
                parameterFIRSTNAME.Value = order.FIRSTNAME;
                command.Parameters.Add(parameterFIRSTNAME);

                SqlParameter parameterMIDDLENAME = new SqlParameter();
                parameterMIDDLENAME.ParameterName = "MIDDLENAME";
                parameterMIDDLENAME.Value = order.MIDDLENAME;
                command.Parameters.Add(parameterMIDDLENAME);

                SqlParameter parameterLASTNAME = new SqlParameter();
                parameterLASTNAME.ParameterName = "LASTNAME";
                parameterLASTNAME.Value = order.LASTNAME;
                command.Parameters.Add(parameterLASTNAME);

                SqlParameter parameterPHONENUMBER = new SqlParameter();
                parameterPHONENUMBER.ParameterName = "PHONENUMBER";
                parameterPHONENUMBER.Value = order.MOBILENO;
                command.Parameters.Add(parameterPHONENUMBER);

                SqlParameter parameterADDRESS = new SqlParameter();
                parameterADDRESS.ParameterName = "ADDRESS";
                parameterADDRESS.Value = order.ADDRESS;
                command.Parameters.Add(parameterADDRESS);

                SqlParameter parameterQTYBTBottle = new SqlParameter();
                parameterQTYBTBottle.ParameterName = "QTYBTBottle";
                parameterQTYBTBottle.Value = order.QTYBTBOTTLE;
                command.Parameters.Add(parameterQTYBTBottle);

                SqlParameter parameterQTYICEJUG = new SqlParameter();
                parameterQTYICEJUG.ParameterName = "QTYICEJUG";
                parameterQTYICEJUG.Value = order.QTYICEBOTTLE;
                command.Parameters.Add(parameterQTYICEJUG);

                SqlParameter parameterQTYPOUCE = new SqlParameter();
                parameterQTYPOUCE.ParameterName = "QTYPOUCH";
                parameterQTYPOUCE.Value = order.QTYPOUCH;
                command.Parameters.Add(parameterQTYPOUCE);

                SqlParameter parameterROOT_ID = new SqlParameter();
                parameterROOT_ID.ParameterName = "ROOT_ID";
                parameterROOT_ID.Value = order.ROOTID;
                command.Parameters.Add(parameterROOT_ID);

                connection.Open();
               // command.Ex
                command.ExecuteNonQuery();
            }
        }

    }
}
